using DocumentFormat.OpenXml.Drawing.Charts;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Base
{
    internal class ZMProgressBar : ProgressBar
    {
        public ZMProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        [Browsable(false)]
        public int Depth { get; set; }

        [Browsable(false)]



        public MouseState MouseState { get; set; }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, 20, specified);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var doneProgress = (int)(Width * ((double)Value / Maximum));
            // 定义颜色
            Color orange = Color.FromArgb(255, 128, 0);
            Color white = Color.White;

            // 填充橙色部分
            using (SolidBrush orangeBrush = new SolidBrush(orange))
            {
                e.Graphics.FillRectangle(orangeBrush, 0, 0, doneProgress, Height);
            }

            // 填充白色部分
            using (SolidBrush whiteBrush = new SolidBrush(white))
            {
                e.Graphics.FillRectangle(whiteBrush, doneProgress, 0, Width - doneProgress, Height);
            }

        }
    }
}
