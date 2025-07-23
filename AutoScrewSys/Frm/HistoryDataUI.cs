using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Settings = AutoScrewSys.Properties.Settings;

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

        private void btnRefreshListBox_Click(object sender, EventArgs e)
        {
            string folderPath = Settings.Default.ProductionDataPath; // 替换为你自己的路径
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("路径不存在！");
                return;
            }

            listHisData.Items.Clear(); // 清空之前的数据

            var files = Directory.GetFiles(folderPath, "*.csv");
            foreach (var file in files)
            {
                listHisData.Items.Add(Path.GetFileNameWithoutExtension(file)); // 只显示文件名
            }

            if (listHisData.Items.Count == 0)
            {
                listHisData.Items.Add("无CSV文件...");
            }
        }

        private void listHisData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listHisData.SelectedItem == null || listHisData.SelectedItem.ToString() == "无CSV文件...") return;

            string selectedFileName = listHisData.SelectedItem.ToString() + ".csv";
            string fullPath = Path.Combine(Settings.Default.ProductionDataPath, selectedFileName); // csvFolderPath 是你设置的文件夹路径

            if (!File.Exists(fullPath))
            {
                MessageBox.Show("文件不存在");
                return;
            }

            DataTable dt = new DataTable();

            using (var reader = new StreamReader(fullPath, Encoding.UTF8))
            {
                bool isHeader = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (isHeader)
                    {
                        foreach (var header in values)
                        {
                            dt.Columns.Add(header);
                        }
                        isHeader = false;
                    }
                    else
                    {
                        dt.Rows.Add(values);
                    }
                }
            }

            PositionView.DataSource = dt;
        }
      

    }
}
