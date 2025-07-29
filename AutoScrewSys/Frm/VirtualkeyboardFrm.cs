using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SharedCore
{
    public partial class VirtualkeyboardFrm : Form
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



        private double Max;
        private double Min;
        private ModbusCfgModel _modnusAddrModel;

        public VirtualkeyboardFrm(ModbusCfgModel modbusCfgModel, double min, double max)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _modnusAddrModel = modbusCfgModel;
            Max = max;
            Min = min;
        }

        private void VirtualkeyboardFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            UpperLimitlab.Text = Max.ToString();
            LowerLimitlab.Text = Min.ToString();
        }
        //软键盘

        public string KeyboardValue { get; private set; }
        private  void Enterbut_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Inputbox.Text, out double inputvlaue))
            {
                Convert.ToDouble(UpperLimitlab.Text);
                Convert.ToDouble(LowerLimitlab.Text);

                if (inputvlaue >= Convert.ToDouble(LowerLimitlab.Text) && inputvlaue <= Convert.ToDouble(UpperLimitlab.Text))
                {
                    ModbusRtuHelper.Instance.WriteSingleRegister((byte)_modnusAddrModel.SlaveAddress, (ushort)_modnusAddrModel.StartAddress, (ushort)inputvlaue);
                    Close();
                }
                else
                {
                    SystemSounds.Beep.Play();
                    label2.ForeColor = Color.Red;
                    zRoundPanel1.PanelBorderColor = Color.Red;
                    Enterbut.ButtonColor = Color.Red;
                    label2.Text = "超出范围";
                }
            }
            else if (Inputbox.Text == "")
            {
                Close();
            }
        }

        private void Num1_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "1";
        }

        private void Num2_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "2";
        }

        private void Num3_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "3";
        }

        private void Num4_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "4";
        }

        private void Num5_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "5";
        }

        private void Num6_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "6";
        }

        private void Num7_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "7";
        }

        private void Num8_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "8";
        }

        private void Num9_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "9";
        }

        private void Num0_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "0";
        }

        private void Nump_Click(object sender, EventArgs e)
        {
            Inputbox.Text += ".";
        }

        private void Escbut_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void Subbut_Click(object sender, EventArgs e)
        {
            Inputbox.Text += "-";
        }

        private void Backbut_Click(object sender, EventArgs e)
        {
            Inputbox.Text = "";
            label2.Text = "";
            Enterbut.ButtonColor = Color.FromArgb(128, 255, 128);
            zRoundPanel1.PanelBorderColor = Color.FromArgb(128, 255, 128);
        }

        private void VirtualkeyboardFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enterbut_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void VirtualkeyboardFrm_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += (s, args) =>
            {
                Inputbox.Focus();
                timer.Stop();
            };
            timer.Start();
        }
    }
}
