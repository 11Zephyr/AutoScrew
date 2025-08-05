using AutoScrewSys.Base;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZimaBlueScrew
{
    public partial class LoadFrm : Form
    {
        public static LoadFrm LoadFrmInstance;
        public LoadFrm()
        {
            InitializeComponent();
            LoadFrmInstance = this;
        }

        private void LoadFrm_Load(object sender, EventArgs e)
        {
            zmProgressBar1.Value = 0;

            // 用于记录时间的变量
            int elapsedTime = 0;

            Task.Run(() =>
            {
                while (elapsedTime < 2000 && !GlobalMonitor.Isload)
                {
                    Thread.Sleep(100); // 每100毫秒更新一次
                    elapsedTime += 100; // 累计经过的时间
                        Invoke(new MethodInvoker(() =>
                        {
                            if (zmProgressBar1.Value + 10 < zmProgressBar1.Maximum)
                            {
                                zmProgressBar1.Value = zmProgressBar1.Value + 10;
                            }
                        }));
                }
                Invoke((Action)(() =>
                {
                    Close();
                }));
            });
        }


    }
}
