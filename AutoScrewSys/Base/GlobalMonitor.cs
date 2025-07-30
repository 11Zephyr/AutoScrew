using AutoScrewSys.BLL;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Vml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Control = System.Windows.Forms.Control;
using Path = System.IO.Path;

namespace AutoScrewSys.Base
{
    public class GlobalMonitor
    {
        public static ModbusSerialInfo SerialInfo { get; set; }//ModBus串口信息
        public static bool isInit { get; private set; }//初始化标志
        private static bool _collecting = false;//采集波形数据标志
        private static bool _end = false;//采集结束标志

        private static List<double> waveDataInfo = new List<double>();//存储波形数据

        public static event Action<int, ushort[]> OnTorqueWaveUpdated;//更新波形图委托
        public static event Action<string> OnResultsUpdated;//更新结果数据委托
        public static event Action<int, int, int, int> StatusChanged;

        static Thread _modbusSyncThread;//住循环线程
        private static Stopwatch _stopwatch = new Stopwatch();//采集数据计时器
        public static ManualResetEventSlim _pauseSignal = new ManualResetEventSlim(true); // 初始为“允许运行”

        public static void Start(Action successAction, Action<string> faultAction)
        {
            try
            {
               Task.Run(new Action(() =>
               {
                    IndustrialBLL bll = new IndustrialBLL();
                    var si = bll.InitSerialInfo();
                    if (si.State) SerialInfo = si.Data;
                    else
                    {
                        faultAction.Invoke(si.Message); return;
                    }

                    if (ModbusRtuHelper.Instance.Init(SerialInfo.PortName, SerialInfo.BaudRate, SerialInfo.Parity, SerialInfo.DataBit, SerialInfo.StopBits, Convert.ToInt32(Settings.Default.receptOutTime), Convert.ToInt32(Settings.Default.sendOutTime)))
                    {
                        isInit = true;
                        successAction?.Invoke();

                        _modbusSyncThread = new Thread(MainThread)
                        {
                            IsBackground = true,
                            Priority = ThreadPriority.Highest // 设置为最高优先级
                        };
                        _modbusSyncThread.Start();

                    }
                    else
                    {
                        faultAction.Invoke("打开串口失败...");
                    }
                }));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"{ex.Message}", LogType.Error);
            }
        }

        public  static void MainThread()
        {
            var cfg = AddrName.Default;
            var type = cfg.GetType();
            var stopwatch = Stopwatch.StartNew();
            while (isInit)
            {
                _pauseSignal.Wait(); // 如果暂停了，这里会阻塞等待恢复
                stopwatch.Restart();

                List<Task> tasks = new List<Task>();

                foreach (SettingsProperty p in cfg.Properties)
                {
                    var addr = ModbusAddressConfig.Instance.GetAddressItem(p.Name);
                    if (addr == null) continue;

                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            ushort[] result;
                            result = await ModbusRtuHelper.Instance.ReadRegistersAsync(
                                    (byte)addr.SlaveAddress,
                                    (ushort)addr.StartAddress,
                                    (ushort)addr.Length);

                            SettingsUpdater.SetIfChanged(cfg, p.Name, result[0]);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteLog($"读取 {p.Name} 失败: {ex.Message}", LogType.Error);
                        }
                    }));
                }
                //await Task.WhenAll(tasks);
                RunStatusMonitor();

                UpdateScrewResultStr(cfg, AddrName.Default.ScrewResult);
                UpdateAlarmMsgStr(cfg, AddrName.Default.AlarmInfo);

                StatusChangeNotifier.CheckAndNotifyStatusChange(StatusChanged);

                //ogHelper.WriteLog($"耗时 {stopwatch.ElapsedMilliseconds}ms", LogType.Run);
              //Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 更新运行状态
        /// </summary>
        /// <param name="cfg"></param>
        /// <param name="code"></param>
        public static void UpdateScrewResultStr(SettingsBase cfg, int code)
        {
            string resultStr;

            switch (code)
            {
                case 0: resultStr = "就绪"; break;
                case 1: resultStr = "运行中"; break;
                case 2: resultStr = "OK"; break;
                case 3: resultStr = "NG"; break;
                case 4: resultStr = "未完成"; break;
                default: resultStr = "未知"; break;
            }

            SettingsUpdater.SetIfChanged(cfg, "ScrewResultStr", resultStr);
        }
        /// <summary>
        /// 更新拧紧结果
        /// </summary>
        /// <param name="cfg"></param>
        /// <param name="code"></param>
        public static void UpdateAlarmMsgStr(SettingsBase cfg, int code)
        {
            string alarmMsgStr;
            switch (code)
            {
                case 0: alarmMsgStr = "无报警"; break;
                case 1: alarmMsgStr = "滑牙"; break;
                case 2: alarmMsgStr = "浮高"; break;
                case 3: alarmMsgStr = "过扭力"; break;
                case 4: alarmMsgStr = "编码器报警"; break;
                case 5: alarmMsgStr = "过压"; break;
                case 6: alarmMsgStr = "扭力上限报警"; break;
                case 7: alarmMsgStr = "扭力下限报警"; break;
                case 8: alarmMsgStr = "电批报警"; break;
                default: alarmMsgStr = "未知报警代码"; break;
            }

            SettingsUpdater.SetIfChanged(cfg, "AlarmInfoStr", alarmMsgStr);
        }


        /// <summary>
        /// 保存二进制波形图数据
        /// </summary>
        public static void SaveWaveformToDatedFolder()
        {
            string basePath = Path.Combine(Settings.Default.ProductionDataPath, "BinFiles");
            string dateFolder = DateTime.Now.ToString("yyyy-MM-dd");
            string fullFolderPath = Path.Combine(basePath, dateFolder);

            if (!Directory.Exists(fullFolderPath))
                Directory.CreateDirectory(fullFolderPath);

            // 获取当天文件夹里的所有bin文件编号
            var files = Directory.GetFiles(fullFolderPath, "*.bin");
            List<int> numbers = new List<int>();
            foreach (var file in files)
            {
                string fileName_ = Path.GetFileNameWithoutExtension(file); // "001"、"002"等
                if (int.TryParse(fileName_, out int num))
                    numbers.Add(num);
            }

            int nextNum = numbers.Count > 0 ? numbers.Max() + 1 : 1;

            string fileName = $"{nextNum:D3}.bin";
            string filePath = Path.Combine(fullFolderPath, fileName);

            // 写入数据
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (var val in waveDataInfo)
                    writer.Write(val);
            }

            // 设置隐藏
            File.SetAttributes(filePath, FileAttributes.Hidden);
        }



        private static void RunStatusMonitor()
        {
            try
            {
                var status = (ScrewStatus)AddrName.Default.ScrewResult;

                if (status == ScrewStatus.Running && !_collecting)
                {
                    _collecting = true;
                    _stopwatch.Reset();  // 重置
                    _stopwatch.Start();  // 重新开始
                    Settings.Default.CurrentRunState = true;
                    Task.Run(() => CollectTorqueData());
                }
                else if (status == ScrewStatus.OK && _collecting)
                {
                    _stopwatch.Stop();  // 停止计时
                    if (_end) OnResultsUpdated?.Invoke($"{_stopwatch.Elapsed.TotalSeconds:F2}");
                    _collecting = _end = false;
                }
                else if (status == ScrewStatus.NG && _collecting)
                {
                    _stopwatch.Stop();  // 停止计时
                    if (_end) OnResultsUpdated?.Invoke($"{_stopwatch.Elapsed.TotalSeconds:F2}");
                    _collecting = _end = false;
                }
                else if (status == ScrewStatus.Incomplete && _collecting)
                {
                    _stopwatch.Stop();  // 停止计时
                    if (_end) OnResultsUpdated?.Invoke($"{_stopwatch.Elapsed.TotalSeconds:F2}");
                    _collecting = _end = false;
                }
                else if (status == ScrewStatus.Ready)
                {
                    _collecting = false;
                    //Settings.Default.RunStateStr = status.ToString();
                    //OnResultsUpdated?.Invoke(status.ToString());

                }
                else
                {
                    _collecting = false;
                }

                Thread.Sleep(5); // 检查状态间隔
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"波形状态监控失败：{ex.Message}", LogType.Error);
            }
        }

        /// <summary>
        /// 波形数据采集
        /// </summary>
        private static  async Task CollectTorqueData()
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("TorsionCurve");//扭力曲线 扭力数据 11208
            byte slaveId = (byte)addr.SlaveAddress;
            ushort baseAddress = (ushort)addr.StartAddress;  // 扭力数据起始地址
            int bufferSize = addr.Length;       // 缓冲区大小：11208~12207
            const int groupSize = 10;          // 每次读取数据数量
            int offset = 0;       // 当前偏移量
            int collected = 0;    // 已采集的数据数量
            waveDataInfo?.Clear();
            int startNum = 0;
            _pauseSignal.Reset(); // ⏸️ 暂停主线程

            while (_collecting || collected < AddrName.Default.TotalCollections)
            {
                startNum++;
                // 实时读取采集总数（地址3895）
                int totalToCollect = AddrName.Default.TotalCollections;

                // 如果已经采集完成则退出
                if (collected >= totalToCollect)
                {
                    _pauseSignal.Set(); // ⏸️ 暂停主线程
                    _end = true;
                    break;
                }

                // 剩余数据不足10则只读取剩下的数量
                int remain = totalToCollect - collected;
                int count = Math.Min(groupSize, remain);

                // 当前起始地址（循环区间）
                int startAddr = baseAddress + (offset % bufferSize);

                // 判断是否会跨越缓冲区末尾（12207）
                if (startAddr + count > baseAddress + bufferSize)
                {
                    // 分段读取：先读结尾，再读开头
                    int part1Count = baseAddress + bufferSize - startAddr;
                    int part2Count = count - part1Count;

                    ushort[] part1 =await ModbusRtuHelper.Instance.ReadRegistersAsync(slaveId, (ushort)startAddr, (ushort)part1Count);
                    ushort[] part2 =await ModbusRtuHelper.Instance.ReadRegistersAsync(slaveId, baseAddress, (ushort)part2Count);

                    // 合并两段数据
                    ushort[] allData = part1.Concat(part2).ToArray();
                    OnTorqueWaveUpdated?.Invoke(startNum, allData);
                    waveDataInfo.AddRange(allData.Select(x => (double)x));
                }
                else
                {
                    // 正常读取连续地址
                    ushort[] data =await ModbusRtuHelper.Instance.ReadRegistersAsync(slaveId, (ushort)startAddr, (ushort)count);
                    OnTorqueWaveUpdated?.Invoke(startNum, data);
                    waveDataInfo.AddRange(data.Select(x => (double)x));
                }
                collected += count;
                offset += count;

                // 每个数据间隔1ms，总共sleep count ms
            }
        }

        public static async Task ElectricBatchAction(object sender, byte slaveId, ushort address)
        {
            try
            {
                if (sender is System.Windows.Forms.Button btn)
                {
                    bool state = btn.Tag is bool b && b;
                    ushort valueToWrite = state ? (ushort)0 : (ushort)1;
                    await ModbusRtuHelper.Instance.WriteSingleRegisterAsync(slaveId, address, valueToWrite);
                    btn.Tag = !state;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, LogType.Error);
            }
        }

        /// <summary>
        /// 将控件树中所有 Label 控件与数据源对象按控件名进行属性绑定
        /// </summary>
        /// <param name="parent">容器控件（如 this、UserControl、Panel）</param>
        /// <param name="settingsSource">数据源对象（如 AddrName.Default）</param>
        public static void BindLabels(Control parent, object settingsSource)
        {
            if (parent == null || settingsSource == null)
                return;

            Type settingsType = settingsSource.GetType();

            foreach (Control control in parent.Controls)
            {
                // 递归处理嵌套控件（包括用户控件）
                if (control.HasChildren)
                {
                    BindLabels(control, settingsSource);
                }

                // 只处理 Label 控件
                if (control is Label lbl)
                {
                    string propertyName = lbl.Name;

                    // 反射判断属性是否存在
                    PropertyInfo property = settingsType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    if (property != null)
                    {
                        // 允许绑定 int、double 等，也会自动转成 string 显示
                        lbl.DataBindings.Add("Text", settingsSource, property.Name, false, DataSourceUpdateMode.OnPropertyChanged);
                    }
                }
            }
        }
    }
}
