using AutoScrewSys.Base;
using AutoScrewSys.BLL;
using AutoScrewSys.Enums;
using AutoScrewSys.Interface;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoScrewSys.Base.GlobalMonitor;
using Color = System.Drawing.Color;
using Settings = AutoScrewSys.Properties.Settings;

namespace AutoScrewSys.Frm
{
    public partial class RunUI : UserControl
    {
        public RunUI()
        {
            InitializeComponent();
        }
        private void RunUI_Load(object sender, EventArgs e)
        {
            UIThread.Context = SynchronizationContext.Current;
            BindLabels(this, AddrName.Default);

            lblScrews.DataBindings.Add("Text", Properties.Settings.Default, "ScrewNum");
            lblGoodScrews.DataBindings.Add("Text", Properties.Settings.Default, "GoodScrews");
            lblBadScrews.DataBindings.Add("Text", Properties.Settings.Default, "BadScrews");

            EnableChartZoomAndPan();
            InitTorqueChart();
            InitResultDgv();
            LogHelper.InitializeLogBox(rtbLog, System.Drawing.Color.White);

            GlobalMonitor.StatusChanged += OnStatusChanged;

            GlobalMonitor.Start(
                 () =>
                 {
                     LogHelper.WriteLog("串口连接成功...", LogType.Run);
                 },
                 (msg) =>
                 {
                     MessageBox.Show(msg, "异常提示");
                 });
            Settings.Default.ScrewNum = 0;
            Settings.Default.BadScrews = 0;
            Settings.Default.GoodScrews = 0;
        }
        private int _torquePointIndex = 0;
        private void InitTorqueChart()
        {
            GlobalMonitor.OnChartDataReceived += points =>
            {
                // UI 线程安全添加到 Chart
                if (chart1.InvokeRequired)
                {
                    chart1.BeginInvoke(new Action(() =>
                    {
                        chart1.Series[0].Points.AddXY(_torquePointIndex++, points.Max());
                    }));
                }
                else
                {
                    chart1.Series[0].Points.AddXY(_torquePointIndex++, points.Max());
                }
            };

            GlobalMonitor.ClearChartAction = () =>
            {
                _torquePointIndex = 0;
                if (chart1.InvokeRequired)
                {
                    chart1.BeginInvoke(new Action(() => chart1.Series[0].Points.Clear()));
                }
                else
                {
                    chart1.Series[0].Points.Clear();
                }
            };

        }


        private void InitResultDgv()
        {
            GlobalMonitor.OnResultsUpdated += () =>
            {
                this.Invoke((Action)(async () =>
                {
                    try
                    {
                        string result = AddrName.Default.ScrewResultStr;
                        int rowIndex = GetBinFilesNum();
                        string timestamp = Settings.Default.SnCode;
                        string timeNow = DateTime.Now.ToString("HH:mm:ss");
                        ushort[] HoldTime = await GlobalMonitor.ReadRegisterByNameAsync("HoldTime", $"Task{AddrName.Default.TaskNumber}");
                        lblCT.Text = HoldTime[0].ToString();
                        int newRowIndex = PositionView.Rows.Add(rowIndex, timestamp, timeNow, rowIndex, AddrName.Default.LapsNum, AddrName.Default.Torque, result);

                        if (result != "OK")
                        {
                            PositionView.Rows[newRowIndex].DefaultCellStyle.BackColor = Color.Red;
                            PositionView.Rows[newRowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            PositionView.Rows[newRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(33, 33, 33);
                            PositionView.Rows[newRowIndex].DefaultCellStyle.ForeColor = Color.White;
                        }

                        UpdateScrewNum(result);
                        if (!Settings.Default.NoCollection)
                        {
                            await Task.Run(() =>
                            {
                                //要先添加数据到CSV再保存二进制数据
                                AppendLastRowToCsv(PositionView, Settings.Default.ProductionDataPath);
                                SaveWaveformToDatedFolder();
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog($"更新结果数据报错:{ex.Message}", LogType.Error);
                    }
                }));
            };
        }

        private void UpdateScrewNum(string result)
        {
            Settings.Default.ScrewNum ++;
            Settings.Default.GoodScrews += result == "OK" ? 1 : 0;
            Settings.Default.BadScrews += result != "OK" ? 1 : 0;
            Yield.Progress = ((float)Settings.Default.GoodScrews / Settings.Default.ScrewNum) * 100;
        }

        /// <summary>
        /// 保存数据到Csv文件
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="folderPath"></param>
        public void AppendLastRowToCsv(DataGridView dgv, string folderPath)
        {
            if (dgv.Rows.Count == 0) return;

            // 获取最后一行（刚插入的那行）
            var lastRow = dgv.Rows[dgv.Rows.Count - 1];

            // 构造文件路径
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
            string fullPath = Path.Combine(folderPath, fileName);

            // 确保目录存在
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // 如果文件不存在则写入表头
            if (!File.Exists(fullPath))
            {
                StringBuilder headerBuilder = new StringBuilder();
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    headerBuilder.Append(col.HeaderText + ",");
                }
                headerBuilder.Length--; // 移除最后逗号
                File.AppendAllText(fullPath, headerBuilder.ToString() + Environment.NewLine, Encoding.UTF8);
            }

            // 写入最后一行数据
            StringBuilder rowBuilder = new StringBuilder();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
            
                object cellValue = lastRow.Cells[i].Value ?? "";
                rowBuilder.Append(cellValue.ToString().Replace(",", "，")).Append(",");
            }
            rowBuilder.Length--; // 移除最后逗号

            File.AppendAllText(fullPath, rowBuilder.ToString() + Environment.NewLine, Encoding.UTF8);
        }

        #region chart1鼠标放缩
        private void EnableChartZoomAndPan()
        {
            var chartArea = chart1.ChartAreas[0];

            // 启用缩放与滚动条
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisX.ScrollBar.IsPositionedInside = true;

            chartArea.CursorY.IsUserEnabled = true;
            chartArea.CursorY.IsUserSelectionEnabled = true;
            chartArea.AxisY.ScaleView.Zoomable = true;
            chartArea.AxisY.ScrollBar.IsPositionedInside = true;

            // 鼠标事件绑定
            chart1.MouseWheel += Chart1_MouseWheel;
            chart1.MouseDown += Chart1_MouseDown;
            chart1.MouseMove += Chart1_MouseMove;
            chart1.MouseUp += Chart1_MouseUp;
            chart1.MouseDoubleClick += Chart1_MouseDoubleClick;

            // 鼠标移入图表时自动获取焦点
            chart1.MouseEnter += (s, e) => chart1.Focus();
        }


        private void Chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chartArea = chart1.ChartAreas[0];

            try
            {
                double xMin = chartArea.AxisX.ScaleView.ViewMinimum;
                double xMax = chartArea.AxisX.ScaleView.ViewMaximum;
                double posX = chartArea.AxisX.PixelPositionToValue(e.X);
                double range = xMax - xMin;
                double zoomRatio = 0.2;

                if (e.Delta > 0) // 向前滚动，放大
                {
                    chartArea.AxisX.ScaleView.Zoom(posX - range * zoomRatio / 2,
                                                   posX + range * zoomRatio / 2);
                }
                else if (e.Delta < 0) // 向后滚动，缩小
                {
                    chartArea.AxisX.ScaleView.Zoom(posX - range / (2 * zoomRatio),
                                                   posX + range / (2 * zoomRatio));
                }
            }
            catch
            {
                // 防止越界异常
            }
        }
        private bool isPanning = false;
        private int panStartX;

        private void Chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isPanning = true;
                panStartX = e.X;
                chart1.Cursor = Cursors.Hand;
            }
        }

        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPanning)
            {
                var chartArea = chart1.ChartAreas[0];
                double x0 = chartArea.AxisX.PixelPositionToValue(panStartX);
                double x1 = chartArea.AxisX.PixelPositionToValue(e.X);
                double delta = x0 - x1;

                chartArea.AxisX.ScaleView.Scroll(chartArea.AxisX.ScaleView.Position + delta);
                panStartX = e.X;
            }
        }

        private void Chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isPanning = false;
                chart1.Cursor = Cursors.Default;
            }
        }
        private void Chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var chartArea = chart1.ChartAreas[0];

            chartArea.AxisX.ScaleView.ZoomReset();
            chartArea.AxisY.ScaleView.ZoomReset();
        }
        #endregion

        private void OnStatusChanged(int s, int t, int l, int f)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnStatusChanged(s, t, l, f)));
                return;
            }

            System.Windows.Forms.Label[] BEAlabels = new System.Windows.Forms.Label[]
            {
                lblBusySignal, lblEndSignal, lblAlarmSignal
            };

            System.Windows.Forms.Label[] TLLlabels = new System.Windows.Forms.Label[]
            {
                lblTightenSignal, lblLoosenSignal, lblLdlingSignal
            };

            for (int i = 0; i < BEAlabels.Length; i++)
            {
                bool isActive = ((s >> i) & 1) == 0; // 0表示有效
                BEAlabels[i].BackColor = isActive ? Color.LimeGreen : Color.Gray;
                BEAlabels[i].ForeColor = isActive ? Color.Black : Color.White;
            }

            int[] states = { t, l, f };
            for (int i = 0; i < 3; i++)
            {
                TLLlabels[i].BackColor = states[i] == 1 ? Color.LimeGreen : Color.Gray;
                TLLlabels[i].ForeColor = states[i] == 1 ? Color.Black : Color.White;
            }

        }

        private void btnRandomSNCode_Click(object sender, EventArgs e)
        {
            Settings.Default.SnCode = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }
    }
}
