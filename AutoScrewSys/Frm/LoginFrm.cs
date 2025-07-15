using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZimaBlueScrew.Frm
{
    public partial class LoginFrm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public LoginFrm()
        {
            InitializeComponent();

        }
        private void LoginFrm1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // 确保窗体能捕获按键事件
        }
        [DllImport("kernel32.dll")]
        public static extern bool Beep(uint dwFreq, uint dwDuration);
        public static void ButBeep()
        {
            Task.Run(() =>
            { Beep(1500, 200); });
        }
        private void materialButtonpro11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void materialButtonpro1_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "1";
        }

        private void materialButtonpro2_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "2";
        }

        private void materialButtonpro3_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "3";
        }

        private void materialButtonpro4_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "4";
        }

        private void materialButtonpro5_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "5";
        }

        private void materialButtonpro6_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "6";
        }

        private void materialButtonpro7_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "7";
        }

        private void materialButtonpro8_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "8";
        }

        private void materialButtonpro9_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "9";
        }

        private void materialButtonpro10_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text += "0";
        }

        private void materialButtonpro13_Click(object sender, EventArgs e)
        {
            ButBeep();
            passBox.Text = "";
        }

        private void materialButtonpro12_Click(object sender, EventArgs e)
        {
            ButBeep();
            if (passBox.Text == "061900")
            {
                //Settings.Default.ModelEnabled = true;
                //Settings.Default.VisionsEnabled = true;
                //Debuger = 9;
                //Settings.Default.Login = 5;
                Close();
            }
            else if (passBox.Text == "358974" && LevelComboBox.SelectedIndex == 3)
            {
                //Settings.Default.ModelEnabled = false;
                //Settings.Default.VisionsEnabled = false;
                //Debuger = 4;
                //MainInstance.Upgradebut.Visible = true;
                //MainInstance.LockingDevicebut.Visible = true;
                //Settings.Default.Login = 4;
                Close();
            }
            else if (passBox.Text == "61254" && LevelComboBox.SelectedIndex == 2)
            {
                //Settings.Default.ModelEnabled = false;
                //Settings.Default.VisionsEnabled = false;
                //MainInstance.Upgradebut.Visible = false;
                //MainInstance.LockingDevicebut.Visible = false;
                //Debuger = 3;
                //Settings.Default.Login = 3;
                Close();
            }
            else if (passBox.Text == "123321" && LevelComboBox.SelectedIndex == 1)
            {
                //Settings.Default.ModelEnabled = false;
                //Settings.Default.VisionsEnabled = false;
                //MainInstance.Upgradebut.Visible = false;
                //MainInstance.LockingDevicebut.Visible = false;
                //Debuger = 2;
                //Settings.Default.Login = 2;
                Close();
            }
            else if (passBox.Text == "1234" && LevelComboBox.SelectedIndex == 0)
            {
                //Settings.Default.ModelEnabled = false;
                //Settings.Default.VisionsEnabled = false;
                //MainInstance.Upgradebut.Visible = false;
                //MainInstance.LockingDevicebut.Visible = false;
                //Debuger = 1;
                //Settings.Default.Login = 1;
                Close();
            }
            else
            {
                Infocom.SelectedIndex = 1;
                //Debuger = 0;
                passBox.Text = "";
                passlable.ForeColor = Color.Red;
                passlable.Text = Infocom.Text;
                passBox.Focus();
            }
        }
        private void LoginFrm1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                materialButtonpro12_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void LoginFrm1_Shown(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 200;
            timer.Tick += (s, args) =>
            {
                passBox.Focus();
                timer.Stop();
            };
            timer.Start();
        }

        private void Logout_Click(object sender, EventArgs e)//注销
        {
            //Settings.Default.VisionsEnabled = false;
            //MainInstance.Upgradebut.Visible = false;
            //MainInstance.LockingDevicebut.Visible = false;
            //if (Debuger==9)
            //{
            //    Debuger = 3;
            //    Settings.Default.Login = 3;
            //}
            //else
            //{
            //    Debuger = 0;
            //    Settings.Default.Login = 0;
            //}
            Close();
        }
    }
}
