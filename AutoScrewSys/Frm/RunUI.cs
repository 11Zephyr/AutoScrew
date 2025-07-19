using AutoScrewSys.Base;
using AutoScrewSys.VariableName;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Frm
{
    public partial class RunUI : UserControl
    {
        ControlScaler scaler;
        bool isResize = false;
        private Timer refreshTimer;
        public RunUI()
        {
            InitializeComponent();

            refreshTimer = new Timer();
            refreshTimer.Interval = 500; // 刷新间隔 1 秒
            refreshTimer.Tick += RefreshTimer_Tick;
            //refreshTimer.Start();
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // 实时读取 Settings 并刷新显示
            TaskNumber.Text = AddrName.Default.TaskNumber.ToString();
        }
        private void RunUI_Load(object sender, EventArgs e)
        {
            LogHelper.InitializeLogBox(rtbLog, Color.White);
        }
    }
}
