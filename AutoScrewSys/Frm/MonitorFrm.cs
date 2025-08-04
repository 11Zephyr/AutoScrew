using AutoScrewSys.Base;
using AutoScrewSys.Enums;
using AutoScrewSys.Interface;
using AutoScrewSys.Properties;
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
    public partial class MonitorFrm : Form
    {
        public MonitorFrm()
        {
            InitializeComponent();
        }

        private async void btnTightenMove_Click(object sender, EventArgs e)
        {
            GlobalMonitor.CheckLogin(3);
            if (Settings.Default.Login < 3) return;

            var addr = ModbusAddressConfig.Instance.GetAddressItem("TightenAction");
            await GlobalMonitor.ElectricBatchAction((byte)addr.SlaveAddress, (ushort)addr.StartAddress,AddrName.Default.TightenAction);
        }

        private async void btnLoosenMove_Click(object sender, EventArgs e)
        {
            GlobalMonitor.CheckLogin(3);
            if (Settings.Default.Login < 3) return;

            var addr = ModbusAddressConfig.Instance.GetAddressItem("LoosenAction");
            await GlobalMonitor.ElectricBatchAction((byte)addr.SlaveAddress, (ushort)addr.StartAddress, AddrName.Default.LoosenAction);
        }

        private async void btnFreeMove_Click(object sender, EventArgs e)
        {
            GlobalMonitor.CheckLogin(3);
            if (Settings.Default.Login < 3) return;

            var addr = ModbusAddressConfig.Instance.GetAddressItem("FreeAction");
            await GlobalMonitor.ElectricBatchAction((byte)addr.SlaveAddress, (ushort)addr.StartAddress, AddrName.Default.FreeAction);
        }
        private void MonitorFrm_Load(object sender, EventArgs e)
        {
            BindLabels(this, AddrName.Default);
            OnStatusChanged(AddrName.Default.StateBits, AddrName.Default.TightenAction, AddrName.Default.LoosenAction, AddrName.Default.FreeAction,AddrName.Default.TorqueMode);//首次进入手动赋值
            GlobalMonitor.StatusChanged += OnStatusChanged;
        }

        private void OnStatusChanged(int s, int t, int l, int f, int torqueMode)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnStatusChanged(s, t, l, f, torqueMode)));
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

            MaterialSkin.Controls.MaterialButtonpro[] buttons = new MaterialSkin.Controls.MaterialButtonpro[]
            {
                 btnTightenMove, btnLoosenMove, btnFreeMove
            };

            btnTorqueMode.ButtonColor = torqueMode == 1? Color.FromArgb(255, 128, 0): Color.Green;
            btnTorqueMode.Text = torqueMode == 1 ? "连续旋转模式" : "固定圈数模式";

            for (int i = 0; i < BEAlabels.Length; i++)
            {
                bool isActive = ((s >> i) & 1) == 0; // 0表示有效
                BEAlabels[i].BackColor = isActive ? Color.LimeGreen : Color.Gray;
                BEAlabels[i].ForeColor = isActive ? Color.Black : Color.White;
            }

            int[] states = { t, l, f };
            for (int i = 0; i < 3; i++)
            {
                buttons[i].ButtonColor = states[i] == 1 ? Color.LimeGreen : Color.White;
                TLLlabels[i].BackColor = states[i] == 1 ? Color.LimeGreen : Color.Gray;
                TLLlabels[i].ForeColor = states[i] == 1 ? Color.Black : Color.White;
            }

        }

        private async void btnTorqueMode_Click(object sender, EventArgs e)
        {
            GlobalMonitor.CheckLogin(3);
            if (Settings.Default.Login < 3) return;

            var addr = ModbusAddressConfig.Instance.GetAddressItem("TorqueMode");
            await GlobalMonitor.ElectricBatchAction((byte)addr.SlaveAddress, (ushort)addr.StartAddress, AddrName.Default.TorqueMode);
        }
    }
}
