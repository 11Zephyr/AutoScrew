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

        private void btnTightenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("TightenAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private void btnLoosenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("LoosenAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private void btnFreeMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("FreeAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        public void StartRefreshing()
        {
            _refreshThread = new Thread(() =>
            {
                while (_isRunning)
                {
                    Thread.Sleep(5);

                    try
                    {
                        if (this.IsHandleCreated && !this.IsDisposed)
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (this.IsDisposed) return; // 再次保险

                                lblTaskNumber.Text = AddrName.Default.TaskNumber.ToString();
                                lblRunState.Text = ((ScrewStatus)AddrName.Default.ScrewResult).ToString();
                                lblTorque.Text = AddrName.Default.Torque.ToString();
                                lblLaps.Text = AddrName.Default.LapsNum.ToString();
                                lblAlarm.Text = GlobalMonitor.GetAlarmMessage(AddrName.Default.AlarmInfo);
                                lblElecBatchPower.Text = AddrName.Default.ElecBatchPower.ToString();
                                lblRotateSpeed.Text = AddrName.Default.RotateSpeed.ToString();
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
    }
}
