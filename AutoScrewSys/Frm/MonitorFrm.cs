using AutoScrewSys.Base;
using AutoScrewSys.Enums;
using AutoScrewSys.Interface;
using AutoScrewSys.VariableName;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoScrewSys.Base.GlobalMonitor;

namespace AutoScrewSys.Frm
{
    public partial class MonitorFrm : Form, IRefreshable
    {
        private Thread _refreshThread;
        private bool _isRunning;
        public MonitorFrm()
        {
            InitializeComponent();
        }

        private async void btnTightenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("TightenAction");
            await GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private async void btnLoosenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("LoosenAction");
           await GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private async void btnFreeMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("FreeAction");
           await GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        public void StartRefreshing()
        {
            _refreshThread = new Thread(() =>
            {
                while (false)
                {
                    Thread.Sleep(5);

                    try
                    {
                        if (this.IsHandleCreated && !this.IsDisposed)
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (this.IsDisposed) return; // 再次保险

                                TaskNumber.Text = AddrName.Default.TaskNumber.ToString();
                                ScrewResultStr.Text = ((ScrewStatus)AddrName.Default.ScrewResult).ToString();
                                Torque.Text = AddrName.Default.Torque.ToString();
                                LapsNum.Text = AddrName.Default.LapsNum.ToString();
                                ElecBatchPower.Text = AddrName.Default.ElecBatchPower.ToString();
                                RotateSpeed.Text = AddrName.Default.RotateSpeed.ToString();
                            }));
                        }
                    }
                    catch (ObjectDisposedException disposeEx)
                    {
                        LogHelper.WriteLog(disposeEx.Message, LogType.Error);
                        break;
                    }
                    catch (InvalidOperationException invalidEx)
                    {
                        LogHelper.WriteLog(invalidEx.Message, LogType.Error);
                        break;
                    }
                }
            });

        }

        public void StopRefreshing()
        {
            _isRunning = false;

            if (_refreshThread != null && _refreshThread.IsAlive)
            {
                // 避免在同一个线程里等待自己
                if (Thread.CurrentThread != _refreshThread)
                {
                    _refreshThread.Join(200); // 等待线程退出
                }
            }

            _refreshThread = null;
        }

        private void MonitorFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void MonitorFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopRefreshing();

        }

        private void MonitorFrm_Load(object sender, EventArgs e)
        {

            BindLabels(this, AddrName.Default);
            OnStatusChanged(AddrName.Default.StateBits, AddrName.Default.TightenAction, AddrName.Default.LoosenAction, AddrName.Default.FreeAction);//首次进入手动赋值
            GlobalMonitor.StatusChanged += OnStatusChanged;

        }

        private void OnStatusChanged(int s, int t, int l, int f)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnStatusChanged(s, t, l, f)));
                return;
            }

            System.Windows.Forms.Label[] BEAlabels = new System.Windows.Forms.Label[]
            {
                lblBusySignal, lblEndSignal, lblAlarmSignal
            };

            System.Windows.Forms.Label[] TLLlabels = new System.Windows.Forms.Label[]
            {
                lblTightenSignal, lblLoosenSignal, lblLdlingSignal
            };

            for (int i = 0; i < BEAlabels.Length; i++)
            {
                bool isActive = ((s >> i) & 1) == 0; // 0表示有效
                BEAlabels[i].BackColor = isActive ? Color.LimeGreen : Color.Gray;
            }

            TLLlabels[0].BackColor = t == 1 ? Color.LimeGreen : Color.Gray;
            TLLlabels[1].BackColor = l == 1 ? Color.LimeGreen : Color.Gray;
            TLLlabels[2].BackColor = f == 1 ? Color.LimeGreen : Color.Gray;
        }
    }
}
