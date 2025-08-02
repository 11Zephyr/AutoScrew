using AutoScrewSys.Base;
using AutoScrewSys.Frm;
using AutoScrewSys.Interface;
using AutoScrewSys.Modbus;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZimaBlueScrew.Frm;
namespace AutoScrewSys
{
    public partial class MainFm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private Image[] radioBtnSelectedImg;
        private List<UserControl> formList;
        private int nCurTag;


        public MainFm()
        {
            InitializeComponent();
            EnableDoubleBuffer(tpContainer);
        }
        private void EnableDoubleBuffer(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        private void MainFm_Load(object sender, EventArgs e)
        {
            //radioBtnSelectedImg = new Image[]
            //{
            //    global :: AutoScrewSys.Properties.Resources.User,
            //    global::AutoScrewSys.Properties.Resources.MainPage,

            //};

            //Image img = AutoScrewSys.Properties.Resources.User;
            this.formList = new System.Collections.Generic.List<UserControl>();

            RunUI runUI = new RunUI();
            runUI.Dock = DockStyle.Fill;
            runUI.Parent = this.tpContainer;
            this.formList.Add(runUI);

            HistoryDataUI historyDataUI = new HistoryDataUI();
            historyDataUI.Dock = DockStyle.Fill;
            historyDataUI.Parent = this.tpContainer;
            this.formList.Add(historyDataUI);

            TaskParametersUI taskParametersUI = new TaskParametersUI();
            taskParametersUI.Dock = DockStyle.Fill;
            taskParametersUI.Parent = this.tpContainer;
            this.formList.Add(taskParametersUI);

            ParameterSettingUI parameterSettingUI = new ParameterSettingUI();
            parameterSettingUI.Dock = DockStyle.Fill;
            parameterSettingUI.Parent = this.tpContainer;
            this.formList.Add(parameterSettingUI);

            IOMonitorUI ioMonitorUI = new IOMonitorUI();
            ioMonitorUI.Dock = DockStyle.Fill;
            ioMonitorUI.Parent = this.tpContainer;
            this.formList.Add(ioMonitorUI);

            runUI.Tag = 0;
            historyDataUI.Tag = 1;
            taskParametersUI.Tag = 2;
            parameterSettingUI.Tag = 3;
            ioMonitorUI.Tag = 4;

            this.radioBtnRunFrm.Tag = 0;
            this.radioBtnHistoryData.Tag = 1;
            this.radioBtnTaskParam.Tag = 2;
            this.radioBtnParamSet.Tag = 3;
            this.radioBtnIOMonitor.Tag = 4;
            this.nCurTag = 0;
            this.radioBtnRunFrm.Checked = true;
            //this.WindowState = FormWindowState.Maximized;

            //LoadControlToPanel(new HistoryDataUI());

            RealTVoltage.DataBindings.Add("Text", AddrName.Default, "RealTVoltage");//实时电压值

        }



        private void radioBtnPageChoose(object sender, EventArgs e)
        {
            GlobalMonitor.CheckLogin(2);
            if (Settings.Default.Login < 2) return;

            if (sender is RadioButton rBtn)
            {
                int tag = Convert.ToInt32(rBtn.Tag);
                if (tag < this.formList.Count)
                {
                    if (tag != nCurTag)
                    {
                        nCurTag = tag;
                        tpContainer.Controls.Clear();
                        var uc = formList[tag];
                        uc.Dock = DockStyle.Fill;
                        tpContainer.Controls.Add(uc);

                    }

                }
            }

            #region MyRegion

            #endregion
            //rBtn.BackgroundImage = rBtn.Checked ? radioBtnSelectedImg[tag] : radioBtnUnselectedImg[tag];
            // rBtn.ForeColor = rBtn.Checked ? Color.White : Color.Black;

            //if (rBtn.Checked)
            //{
            //    formList[tag].Show();

            //}
            //else
            //{
            //    formList[tag].Hide();
            //}
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.Save();
                var result = MessageBox.Show("确认要退出程序吗？", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void radioBtnLogin_Click(object sender, EventArgs e)
        {
            LoginFrm frm = new LoginFrm();
            frm.ShowDialog();
        }

        private void radioBtnStatusAction_Click(object sender, EventArgs e)
        {
            GlobalMonitor.CheckLogin(2);
            if (Settings.Default.Login < 2) return;

            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is MonitorFrm)
                {
                    openForm.Activate();
                    return;
                }
            }
            MonitorFrm frm = new MonitorFrm();
            frm.Show();
        }

        private void btnToggleSize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
