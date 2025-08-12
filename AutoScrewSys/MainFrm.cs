using AutoScrewSys.Base;
using AutoScrewSys.Frm;
using AutoScrewSys.Interface;
using AutoScrewSys.Modbus;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZimaBlueScrew;
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
        private List<UserControl> formList;
        private int nCurTag;


        public MainFm()
        {
            InitializeComponent();
            EnableDoubleBuffer();
            AutoControlSize.RegisterFormControl(this);
        }
        public void EnableDoubleBuffer()
        {
            // 启用双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // 如果tpContainer是Panel或者UserControl，也做同样设置
            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(tpContainer, true, null);
        }

        private void MainFm_Load(object sender, EventArgs e)
        {
            LanguageManager.SetCurrentCulture(Settings.Default.Language);
            LangService.Instance.SetEnglishMode(Settings.Default.LanguageIndex);

            LoadFrm loadFrm = new LoadFrm();
            loadFrm.ApplyLanguage();
            Task.Run(() =>
            {
                loadFrm.ShowDialog();
            });
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
            parameterSettingUI.LanguageChanged += (langcode) =>
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        LanguageManager.SetLanguage(langcode, this, formList);
                    }));
                }
                else
                {
                    LanguageManager.SetLanguage(langcode, this, formList);
                }
                //FormResize();
                Settings.Default.Language = langcode;
            };
           
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
            this.radioBtnStatusAction.Tag = 5;
            this.nCurTag = 0;
            this.radioBtnRunFrm.Checked = true;

            //this.TopMost = true;
            RealTVoltage.DataBindings.Add("Text", AddrName.Default, "RealTVoltage");//实时电压值
            LanguageManager.ApplyLanguage(Settings.Default.Language, this, formList);
            LangService.Instance.Load();

        }



        private void radioBtnPageChoose(object sender, EventArgs e)
        {
            GlobalMonitor.CheckLogin(2);
            if (Settings.Default.Login < 2) return;

            if (sender is RadioButton rBtn)
            {
                if (int.TryParse(rBtn.Tag?.ToString(), out int tag) && tag < formList.Count && tag != nCurTag)
                {
                    foreach (var rb in rBtn.Parent.Controls.OfType<RadioButton>())
                    {
                        if (rb.Tag == null) continue;

                        if (tag != nCurTag)
                        {
                            rb.BackColor = Color.FromArgb(33, 33, 33);
                            rb.ForeColor = Color.White;
                            rb.Checked = false;
                        }
                    }
                    rBtn.BackColor = SystemColors.ActiveCaption;
                    rBtn.ForeColor = Color.Black;

                    nCurTag = tag;
                    tpContainer.Controls.Clear();
                    var uc = formList[tag];
                    uc.Dock = DockStyle.Fill;
                    tpContainer.Controls.Add(uc);
                }
            }

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

                var result = MessageBox.Show("确认要退出程序吗？", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    GlobalMonitor.StopModbusSyncThread();
                    Settings.Default.Save();
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

        private void MainFm_Resize(object sender, EventArgs e)
        {
            FormResize();
        }

        private void FormResize()
        {

            AutoControlSize.ChangeFormControlSize(this);

            if (this.WindowState == FormWindowState.Normal)
            {
                btnClose.Invalidate(); // 强制刷新 Panel
                btnClose.Update();
            }
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
      

        private void MainFm_Shown(object sender, EventArgs e)
        {
            // GlobalMonitor.Isload = true;
        }
    }
}
