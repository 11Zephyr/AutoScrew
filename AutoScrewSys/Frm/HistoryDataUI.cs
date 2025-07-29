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
using System.Windows.Forms.DataVisualization.Charting;
using Settings = AutoScrewSys.Properties.Settings;

namespace AutoScrewSys.Frm
{
    public partial class HistoryDataUI : UserControl
    {
        private readonly Dictionary<string, string> logTypeFolderMap = new Dictionary<string, string>
        {
            { "运行日志", "RunLog" },
            { "故障日志", "FaultLog" },
            { "报错日志", "ErrorLog" }
        };
        public HistoryDataUI()
        {
            InitializeComponent();
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
            RefreshHisDataList();
        }

        private void RefreshHisDataList()
        {
            string folderPath = Settings.Default.ProductionDataPath;
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

        private void ShowWaveform(List<double> data)
        {
            chartWaveData.Series.Clear();
            var series = new Series("扭力") { ChartType = SeriesChartType.Line };
            for (int i = 0; i < data.Count; i++)
                series.Points.AddXY(i, data[i]);
            chartWaveData.Series.Add(series);
        }

        private void PositionView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 过滤表头等无效行

            // 1. 获取listHisData选中的日期字符串
            string selectedDate = listHisData.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDate))
            {
                MessageBox.Show("请先选择日期！");
                return;
            }

            // 2. 拼接当日目录完整路径
            string basePath = Path.Combine(Settings.Default.ProductionDataPath, "BinFiles");
            string folderPath = Path.Combine(basePath, selectedDate);
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"日期目录不存在：{folderPath}");
                return;
            }

            // 3. 获取点击的行号，转成编号（编号从1开始，对应文件名 001.bin）
            int fileIndex = e.RowIndex + 1; // 如果你的 dgv 行索引和编号一一对应（从0开始），+1变成文件名编号
            string fileName = $"{fileIndex:D3}.bin";
            string filePath = Path.Combine(folderPath, fileName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"文件不存在：{filePath}");
                return;
            }

            // 4. 读取bin文件数据，生成波形列表
            List<double> waveform = new List<double>();
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    waveform.Add(reader.ReadDouble());
                }
            }

            // 5. 显示波形图
            ShowWaveform(waveform);
        }

        private void HistoryDataUI_Load(object sender, EventArgs e)
        {
            RefreshHisDataList();
        }

        private void cmbLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFileList.Items.Clear();
            lstLogContent.Items.Clear();

            if (cmbLogType.SelectedItem is string logType &&
                logTypeFolderMap.TryGetValue(logType, out string subFolder))
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", subFolder);

                if (Directory.Exists(folderPath))
                {
                    var txtFiles = Directory.GetFiles(folderPath, "*.txt");
                    foreach (var file in txtFiles)
                    {
                        cmbFileList.Items.Add(Path.GetFileName(file));
                    }

                    if (cmbFileList.Items.Count > 0)
                        cmbFileList.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show($"文件夹不存在: {folderPath}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstLogContent.Items.Clear();

            if (cmbLogType.SelectedItem is string logType &&
                cmbFileList.SelectedItem is string fileName &&
                logTypeFolderMap.TryGetValue(logType, out string subFolder))
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", subFolder, fileName);

                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    lstLogContent.Items.AddRange(lines);
                }
            }
        }
    }
}
