using AutoScrewSys.Base;
using AutoScrewSys.Interface;
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
    public partial class IOMonitorUI : UserControl
    {
        public IOMonitorUI()
        {
            InitializeComponent();
        }

        private void IOMonitorUI_Load(object sender, EventArgs e)
        {
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
