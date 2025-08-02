using AutoScrewSys.Base;
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
using Color = System.Drawing.Color;
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
                string appRoot = AppDomain.CurrentDomain.BaseDirectory;
                string newFolderPath = Path.Combine(appRoot, "ScrewData");

                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }
                Settings.Default.ProductionDataPath = newFolderPath;
                LogHelper.WriteLog($"保存数据路径不存在，已创建默认文件夹：{newFolderPath}",LogType.Run);
            }

            listHisData?.Items?.Clear(); // 清空之前的数据

            var files = Directory.GetFiles(folderPath, "*.csv");
            foreach (var file in files)
            {
                listHisData.Items.Add(Path.GetFileNameWithoutExtension(file)); // 只显示文件名
            }
            if (listHisData.Items.Count == 0)
            {
                listHisData.Items.Add("无CSV文件...");
            }
            else
            {
                //listHisData.SelectedIndex = 0;
            }
        }
        private void GetHisCsvData()
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
            string barcodeFilter = tbxSnSearchBox.Text.Trim();
            string circleFilter = textBoxCircle.Text.Trim();
            string torqueFilter = textBoxTorque.Text.Trim();
            string resultFilter = comboBoxResult.Text.Trim();

            // ✅ 依次构建筛选条件
            IEnumerable<DataRow> filteredRows = dt.AsEnumerable();

            if (!string.IsNullOrEmpty(barcodeFilter) && dt.Columns.Count > 1)
            {
                filteredRows = filteredRows.Where(row => row.Field<string>(1) == barcodeFilter);
            }

            if (!string.IsNullOrEmpty(circleFilter) && dt.Columns.Count > 4)
            {
                filteredRows = filteredRows.Where(row => row.Field<string>(4) == circleFilter);
            }

            if (!string.IsNullOrEmpty(torqueFilter) && dt.Columns.Count > 5)
            {
                filteredRows = filteredRows.Where(row => row.Field<string>(5) == torqueFilter);
            }

            // 下拉框不为空且不是“无”或“全部”才过滤
            if (!string.IsNullOrWhiteSpace(resultFilter) && resultFilter != "无"  && dt.Columns.Count > 6)
            {
                filteredRows = filteredRows.Where(row => row.Field<string>(6) == resultFilter);
            }

            // ✅ 最终应用筛选结果
            if (filteredRows.Any())
            {
                dt = filteredRows.CopyToDataTable();
            }
            else
            {
                dt.Rows.Clear(); // 没有匹配项就显示空表
            }
            PositionView.DataSource = dt;
            ColorRowsByStatus(PositionView);
        }
        private void listHisData_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetHisCsvData(); 
        }
        private void ColorRowsByStatus(DataGridView dgv)
        {
            Color dark = Color.FromArgb(33, 33, 33);
            Color light = Color.FromArgb(55, 55, 55);
            int index = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                string val = row.Cells[row.Cells.Count - 1].Value?.ToString();
                if (val != "OK")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = (index % 2 == 0) ? dark : light;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

                index++;
            }
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
            if (e.RowIndex < 0) return;

            string selectedDate = listHisData.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDate))
            {
                MessageBox.Show("请先选择日期！");
                return;
            }

            string folderPath = Path.Combine(Settings.Default.ProductionDataPath, "BinFiles", selectedDate);
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"波形不存在：{folderPath}");
                return;
            }

            var cellValue = PositionView.Rows[e.RowIndex].Cells[0].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int fileIndex))
            {
                MessageBox.Show("转换值失败");
                return;
            }

            string filePath = Path.Combine(folderPath, $"{fileIndex:D3}.bin");
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"数据文件不存在：{filePath}");
                return;
            }

            var waveform = new List<double>();
            using (var reader = new BinaryReader(File.OpenRead(filePath)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                    waveform.Add(reader.ReadDouble());
            }

            ShowWaveform(waveform);

        }

        private void HistoryDataUI_Load(object sender, EventArgs e)
        {
            RefreshHisDataList();
        }

        private void cmbLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFileList?.Items?.Clear();
            lstLogContent?.Items?.Clear();

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

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            // 1. 获取日志类型
            string selectedType = cmbLogType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedType) || !logTypeFolderMap.ContainsKey(selectedType))
            {
                MessageBox.Show("请选择有效的日志类型！");
                return;
            }

            string folderName = logTypeFolderMap[selectedType];

            // 2. 获取选中的日志文件名（例如 20250719.txt）
            string selectedFile = cmbFileList.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedFile))
            {
                MessageBox.Show("请选择要删除的日志文件！");
                return;
            }

            // 3. 拼接完整文件路径
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", folderName, selectedFile);

            // 4. 判断文件是否存在
            if (!File.Exists(logFilePath))
            {
                MessageBox.Show($"日志文件不存在：{logFilePath}");
                return;
            }

            // 5. 弹出确认删除提示
            var confirmResult = MessageBox.Show(
                $"确定要删除以下日志文件吗？\n\n{logFilePath}",
                "确认删除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            // 6. 执行删除
            try
            {
                File.Delete(logFilePath);
                MessageBox.Show("日志文件删除成功！");

                // 7. 可选：从 ComboBox 中移除该项
                cmbFileList.Items.Remove(selectedFile);
                if (cmbFileList.Items.Count > 0)
                    cmbFileList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除失败：{ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetHisCsvData();
        }

      
    }
}
