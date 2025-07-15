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
    public partial class HistoryDataUI : UserControl
    {
        public HistoryDataUI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void materialTabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void btnHisData_Click(object sender, EventArgs e)
        {
            hisFrmTabControl.SelectedIndex = 0;
        }

        private void btnHisLog_Click(object sender, EventArgs e)
        {
            hisFrmTabControl.SelectedIndex = 1;
        }
    }
}
