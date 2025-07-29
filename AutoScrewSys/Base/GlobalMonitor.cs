using AutoScrewSys.BLL;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoScrewSys.Base
{
    public class GlobalMonitor
    {
        private static bool _collecting = false;
        private static List<double> waveDataInfo = new List<double>();
        public static event Action<int, ushort[]> OnTorqueWaveUpdated;
        public static event Action<string> OnResultsUpdated;
        public static List<StorageModel> StorageList { get; set; }
        public static ModbusSerialInfo SerialInfo { get; set; }
        public static bool isInit { get; private set; }
        static Task mainTask = null;
        static Thread _modbusSyncThread;
        private static Stopwatch _stopwatch = new Stopwatch();
        private static bool _end = false;
        public static void Start(Action successAction, Action<string> faultAction)
        {
            try
            {
                mainTask = Task.Run(new Action(() =>
                {
                    IndustrialBLL bll = new IndustrialBLL();
                    var si = bll.InitSerialInfo();
                    if (si.State) SerialInfo = si.Data;
                    else
                    {
                        faultAction.Invoke(si.Message); return;
                    }

                    if (ModbusRtuHelper.Instance.Init(SerialInfo.PortName, SerialInfo.BaudRate, SerialInfo.Parity, SerialInfo.DataBit, SerialInfo.StopBits,Convert.ToInt32(Settings.Default.receptOutTime), Convert.ToInt32(Settings.Default.sendOutTime)))
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

        public static void MainThread()
        {
            var cfg = AddrName.Default;
            var type = cfg.GetType();
            //ushort i = 0;
            while (isInit)
            {
                foreach (SettingsProperty p in cfg.Properties)
                {

                    var addr = ModbusAddressConfig.Instance.GetAddressItem(p.Name);
                    if (addr == null)
                    {
                        LogHelper.WriteLog($"空属性:{p.Name}", LogType.Fault);
                        Thread.Sleep(1000); continue;
                    }
                    try
                    {
                        var val = ModbusRtuHelper.Instance.ReadRegisters(
                            (byte)addr.SlaveAddress, (ushort)addr.StartAddress, (ushort)addr.Length
                        )?[0];

                        var prop = type.GetProperty(p.Name);
                        prop?.SetValue(cfg, Convert.ChangeType(val, p.PropertyType));

                        RunStatusMonitor();
                        #region 调试使用
                        //if (i == cfg.Properties.Count)
                        //{
                        //    LogHelper.WriteLog("========================================", LogType.Error);
                        //    i = 0;
                        //}
                        //LogHelper.WriteLog($"{addr.Description}:{val}", LogType.Error);
                        //i++; 
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog($"读取 {p.Name} 失败: {ex.Message}", LogType.Error);
                    }
                    //if (AddrName.Default.ScrewResult == 1) LogHelper.WriteLog($"{addr.Description}:{addr.StartAddress}-运行中", LogType.Run);
                }
            
                Thread.Sleep(5);
            }

            //cfg.Save();
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
                   if(_end) OnResultsUpdated?.Invoke($"{_stopwatch.Elapsed.TotalSeconds:F2}");
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
                    //_collecting = false;
                    //Settings.Default.RunStateStr = status.ToString();
                    //OnResultsUpdated?.Invoke(status.ToString());

                }
                else
                {
                    //_collecting = false;
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
        private static void CollectTorqueData()
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

            while (_collecting || collected < AddrName.Default.TotalCollections)
            {
                startNum ++;
                // 实时读取采集总数（地址3895）
                int totalToCollect = AddrName.Default.TotalCollections;

                // 如果已经采集完成则退出
                if (collected >= totalToCollect)
                {
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

                    ushort[] part1 = ModbusRtuHelper.Instance.ReadRegisters(slaveId, (ushort)startAddr, (ushort)part1Count);
                    ushort[] part2 = ModbusRtuHelper.Instance.ReadRegisters(slaveId, baseAddress, (ushort)part2Count);

                    // 合并两段数据
                    ushort[] allData = part1.Concat(part2).ToArray();
                    OnTorqueWaveUpdated?.Invoke(startNum, allData);
                    waveDataInfo.AddRange(allData.Select(x => (double)x));
                }
                else
                {
                    // 正常读取连续地址
                    ushort[] data = ModbusRtuHelper.Instance.ReadRegisters(slaveId, (ushort)startAddr, (ushort)count);
                    OnTorqueWaveUpdated?.Invoke(startNum, data);
                    waveDataInfo.AddRange(data.Select(x => (double)x));
                }


                
                collected += count;
                offset += count;

                // 每个数据间隔1ms，总共sleep count ms
                Thread.Sleep(count);
            }
        }

        public static void ElectricBatchAction(object sender, byte slaveId, ushort address)
        {
            try
            {
                if (sender is System.Windows.Forms.Button btn)
                {
                    bool state = btn.Tag is bool b && b;
                    ushort valueToWrite = state ? (ushort)0 : (ushort)1;

                    ModbusRtuHelper.Instance.WriteSingleRegister(slaveId, address, valueToWrite);
                    btn.Tag = !state;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, LogType.Error);
            }
        }

        public static string GetAlarmMessage(int code)
        {
            switch (code)
            {
                case 0: return "无报警";
                case 1: return "滑牙";
                case 2: return "浮高";
                case 3: return "过扭力";
                case 4: return "编码器报警";
                case 5: return "过压";
                case 6: return "扭力上限报警";
                case 7: return "扭力下限报警";
                case 8: return "电批报警";
                default: return "未知报警代码";
            }
        }
    }
}
