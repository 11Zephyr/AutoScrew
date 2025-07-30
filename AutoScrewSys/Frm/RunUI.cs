using AutoScrewSys.Base;
using AutoScrewSys.BLL;
using AutoScrewSys.Enums;
using AutoScrewSys.Interface;
using AutoScrewSys.Modbus;
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
using Settings = AutoScrewSys.Properties.Settings;

namespace AutoScrewSys.Frm
{
    public partial class RunUI : UserControl, IRefreshable
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


            ///启动全局监控
            GlobalMonitor.Start(
                 // 串口打开成功时回调，打开主窗口
                 () =>
                 {
                     LogHelper.WriteLog("串口连接成功...", LogType.Run);
                     //MessageBox.Show("串口连接成功");
                 },
                 // 串口打开失败时回调，错误消息提醒，并退出程序
                 (msg) =>
                 {
                     MessageBox.Show(msg, "异常提示");
                 });
        }

        private void InitTorqueChart()
        {
            GlobalMonitor.OnTorqueWaveUpdated += (startNum, torqueArray) =>
            {

                this.Invoke(new Action(() =>
                {
                    if (Settings.Default.CurrentRunState)
                    {
                        chart1.Series[0].Points.Clear();
                        Settings.Default.CurrentRunState = false;
                    }
                    chart1.Series[0].Points.AddXY(startNum, torqueArray.Average(t => (double)t));

                }));


            };
        }
        private void InitResultDgv()
        {
            GlobalMonitor.OnResultsUpdated += ( string ct) =>
            {
                this.Invoke((Action)(() =>
                {
                    string result = ((ScrewStatus)AddrName.Default.ScrewResult).ToString();
                    Settings.Default.GoodScrews = result == "OK" ? Settings.Default.GoodScrews + 1 : Settings.Default.GoodScrews;
                    lblCT.Text = ct;

                    int rowIndex = PositionView.Rows.Count + 1;

                    // 当前时间戳（秒级）
                    string timestamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();

                    // 当前时间：时分秒
                    string timeNow = DateTime.Now.ToString("HH:mm:ss");

                    // 添加新行
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

        public void StartRefreshing()
        {
            if (_refreshThread != null && _refreshThread.IsAlive)
                return;

            _isRunning = true;
            _refreshThread = new Thread(() =>
            {
                while (false)
                {
                    Thread.Sleep(500);
                    this.Invoke(new Action(() => { LogHelper.WriteLog($"任务号:{AddrName.Default.TaskNumber.ToString()}", LogType.Run); }));
                    
                        
                      
                    //Invoke(new Action(() =>
                    //{
                    //    TaskNumber.Text = AddrName.Default.TaskNumber.ToString();
                    //    lblRunState.Text = ((ScrewStatus)AddrName.Default.ScrewResult).ToString();
                    //    lblTorque.Text = AddrName.Default.Torque.ToString();
                    //    lblLaps.Text = AddrName.Default.LapsNum.ToString();
                    //    lblAlarm.Text = GetAlarmMessage(AddrName.Default.AlarmInfo);
                    //    lblScrewsTotal.Text = AddrName.Default.ScrewsTotal.ToString();
                    //    lblGoodScrews.Text = Settings.Default.GoodScrews.ToString();
                    //    lblBadScrews.Text = (AddrName.Default.ScrewsTotal - Settings.Default.GoodScrews).ToString();
                    //    Yield.Progress = AddrName.Default.ScrewsTotal == 0? 0f: (float)((Settings.Default.GoodScrews / (double)AddrName.Default.ScrewsTotal) * 100);

                    //    System.Windows.Forms.Label[] beaLabels = new System.Windows.Forms.Label[] { lblBusySignal, lblEndSignal, lblAlarmSignal };
                    //    System.Windows.Forms.Label[] tllLabels = new System.Windows.Forms.Label[] { lblTightenSignal, lblLoosenSignal, lblLdlingSignal };
                    //    UpdateActionStatus(beaLabels,tllLabels);
                    //}));
                }
            });
            _refreshThread.IsBackground = true;
            _refreshThread.Start();
        }

        public void StopRefreshing()
        {
            _isRunning = false;
            if (_refreshThread != null && _refreshThread.IsAlive)
            {
                _refreshThread.Join(200); // 可选：等待线程结束
            }
            _refreshThread = null;
        }

        private void SDbut_Click(object sender, EventArgs e)
        {
            tpanel.Visible = tpanel.Visible?false:true;
            tpanel.BringToFront();
        }

        private void btnTightenMove_Click_1(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("TightenAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private void btnLoosenMove_Click_1(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("LoosenAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private void btnFreeMove_Click_1(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("FreeAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }


        public void UpdateActionStatus(System.Windows.Forms.Label[] BEAlabels, System.Windows.Forms.Label[] TLLlabels)
        {
            int s = AddrName.Default.StateBits;
            int t = AddrName.Default.TightenAction;
            int l = AddrName.Default.LoosenAction;
            int f = AddrName.Default.FreeAction;

            if (isFirst || s != lastStateBits || t != lastTighten || l != lastLoosen || f != lastFree)
            {
                //UpdateStateLabels(s, t, l, f);

                for (int i = 0; i < BEAlabels.Length; i++)
                {
                    bool isActive = ((s >> i) & 1) == 0; // 0表示有效
                    BEAlabels[i].BackColor = isActive ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
                }

                TLLlabels[0].BackColor = t == 1 ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
                TLLlabels[1].BackColor = l == 1 ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
                TLLlabels[2].BackColor = f == 1 ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;

                // 更新旧值
                lastStateBits = s;
                lastTighten = t;
                lastLoosen = l;
                lastFree = f;
                isFirst = false;
            }
        }
        private void UpdateStateLabels(int stateBits, int tightenSignal, int lossenSignal, int freeSignal, System.Windows.Forms.Label[] BEAlabels)
        {

            //System.Windows.Forms.Label[] labels = { lblBusySignal, lblEndSignal, lblAlarmSignal };

            for (int i = 0; i < BEAlabels.Length; i++)
            {
                bool isActive = ((stateBits >> i) & 1) == 0; // 0表示有效
                BEAlabels[i].BackColor = isActive ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
            }
            lblTightenSignal.BackColor = tightenSignal == 1 ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
            lblLoosenSignal.BackColor = lossenSignal == 1 ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
            lblLdlingSignal.BackColor = freeSignal == 1 ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
        }
    }
}
