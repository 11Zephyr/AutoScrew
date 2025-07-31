using AutoScrewSys.Base;
using AutoScrewSys.BLL;
using AutoScrewSys.Enums;
using AutoScrewSys.Interface;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
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
        // 上一次的值（类字段）
        int lastStateBits, lastTighten, lastLoosen, lastFree;
        bool isFirst = true;
        private Thread _refreshThread;
        private bool _isRunning;
        public RunUI()
        {
            InitializeComponent();
        }
        private void RunUI_Load(object sender, EventArgs e)
        {
            UIThread.Context = SynchronizationContext.Current;
            BindLabels(this, AddrName.Default);

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
        }
        private int _torquePointIndex = 0;
        private void InitTorqueChart()
        {
           GlobalMonitor.OnChartDataReceived += points => {

               if (chart1.InvokeRequired)
               {
                   chart1.BeginInvoke(new Action(() =>
                   {
                       foreach (var val in points)
                       {
                           chart1.Series[0].Points.AddXY(_torquePointIndex++, val); // X 是点序号
                       }
                   }));
               }
               else
               {
                   foreach (var val in points)
                   {
                       chart1.Series[0].Points.AddXY(_torquePointIndex++, val); // X 是点序号
                   }
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
                    string result = ((ScrewStatus)AddrName.Default.ScrewResult).ToString();
                    Settings.Default.GoodScrews = result == "OK" ? Settings.Default.GoodScrews + 1 : Settings.Default.GoodScrews;

                    ModbusCfgModel HoldTimeAddr = ModbusAddressConfig.Instance.GetAddressItem("HoldTime", $"Task{AddrName.Default.TaskNumber}");
                    ushort[] HoldTime = await ModbusRtuHelper.Instance.ReadRegistersAsync((byte)HoldTimeAddr.SlaveAddress, (ushort)HoldTimeAddr.StartAddress, (ushort)HoldTimeAddr.Length);

                    lblCT.Text = HoldTime[0].ToString();

                    int rowIndex = PositionView.Rows.Count + 1;

                    // 当前时间戳（秒级）
                    string timestamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();

                    // 当前时间：时分秒
                    string timeNow = DateTime.Now.ToString("HH:mm:ss");

                    PositionView.Rows.Add(rowIndex, timestamp, timeNow, rowIndex, AddrName.Default.LapsNum, AddrName.Default.Torque, result);
                    AppendLastRowToCsv(PositionView, Settings.Default.ProductionDataPath);
                    SaveWaveformToDatedFolder();
                   
                }));
            };
        }
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


        public void StopRefreshing()
        {
            _isRunning = false;
            if (_refreshThread != null && _refreshThread.IsAlive)
            {
                _refreshThread.Join(200); // 可选：等待线程结束
            }
            _refreshThread = null;
        }


     
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
            }

            TLLlabels[0].BackColor = t == 1 ? Color.LimeGreen : Color.Gray;
            TLLlabels[1].BackColor = l == 1 ? Color.LimeGreen : Color.Gray;
            TLLlabels[2].BackColor = f == 1 ? Color.LimeGreen : Color.Gray;
        }
    }
}
