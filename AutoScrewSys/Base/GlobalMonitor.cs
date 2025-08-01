using AutoScrewSys.BLL;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zmodbus;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Control = System.Windows.Forms.Control;
using Path = System.IO.Path;

namespace AutoScrewSys.Base
{
    public class GlobalMonitor
    {
        public static bool isInit { get; private set; }//初始化标志
        private static bool _collecting = false;//采集波形数据标志
        private static int _lastIndex = 0;
        private static readonly object _binFileLock = new object();

        public static Action ClearChartAction;
        public static event Action<List<float>> OnChartDataReceived;
        public static event Action OnResultsUpdated;
        public static event Action<int, int, int, int> StatusChanged;
        public delegate void UpdateChartDelegate(List<float> yValues);
        public event UpdateChartDelegate OnWaveDataUpdate;
        public static ModbusSerialInfo SerialInfo { get; set; }//ModBus串口信息
        static Thread _modbusSyncThread;//住循环线程
        private static List<double> waveDataInfo = new List<double>();//存储波形数据

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
                        _modbusSyncThread = new Thread(MainThread)
                        {
                            IsBackground = true,
                            Priority = ThreadPriority.Highest // 设置为最高优先级
                        };
                        _modbusSyncThread.Start();
                        successAction?.Invoke();
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

        public async static void MainThread()
        {
            var cfg = AddrName.Default;
            var stopwatch = Stopwatch.StartNew();
            var semaphore = new SemaphoreSlim(1, 1); // 控制串口物理串行访问

            while (isInit)
            {
                stopwatch.Restart();

                var tasks = new List<Task>();

                foreach (SettingsProperty p in cfg.Properties)
                {
                    var addr = ModbusAddressConfig.Instance.GetAddressItem(p.Name);
                    if (addr == null) continue;

                    var task = Task.Run(async () =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            ushort[] result = await ModbusRtuHelper.Instance.ReadRegistersAsync(
                                (byte)addr.SlaveAddress,
                                (ushort)addr.StartAddress,
                                (ushort)addr.Length
                            );
                            SettingsUpdater.SetIfChanged(cfg, p.Name, result[0]);
                            UpdateScrewResultStr(cfg, AddrName.Default.ScrewResult);

                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteLog($"读取 {p.Name} 失败: {ex.Message}", LogType.Error);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    tasks.Add(task);
                }
                // 等待所有读取任务完成
                // await Task.WhenAll(tasks);
                UpdateAlarmMsgStr(cfg, AddrName.Default.AlarmInfo);
                StatusChangeNotifier.CheckAndNotifyStatusChange(StatusChanged);
                //LogHelper.WriteLog($"耗时 {stopwatch.ElapsedMilliseconds}ms", LogType.Run);
                await Task.Delay(10);
            }
        }

        public async static void UpdateScrewResultStr(SettingsBase cfg, int code)
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

            if (code == 1 && !_collecting)
            {
                _collecting = true;
                ClearChartAction?.Invoke();
                waveDataInfo?.Clear();
                int blockSize = 20;
                ushort maxValue = 1000;
                ushort prevValue = 0;
                int totalAccumulate = 0;
                ModbusCfgModel TorsionCurve = ModbusAddressConfig.Instance.GetAddressItem("TorsionCurve");

                await Task.Run(async () =>
                {
                    while (_collecting)
                    {
                        try
                        {
                            //ushort[] totalCollections = await ModbusRtuHelper.Instance.ReadRegistersAsync((byte)TotalCollections.SlaveAddress,(ushort)TotalCollections.StartAddress,(ushort)TotalCollections.Length);
                            //ushort[] runStatus = await ModbusRtuHelper.Instance.ReadRegistersAsync((byte)Runstatus.SlaveAddress, (ushort)Runstatus.StartAddress, (ushort)Runstatus.Length);
                            ushort currValue = (await ReadRegisterByNameAsync("TotalCollections"))[0];
                            totalAccumulate += (currValue >= prevValue)? (currValue - prevValue): (currValue + maxValue - prevValue);
                            prevValue = currValue;

                            if (_lastIndex  >= totalAccumulate)
                            {
                                //LogHelper.WriteLog($"跳出:_lastIndex:{_lastIndex}-_collectTotalNum{_collectTotalNum}-collectTotalNum:{totalCollections[0]}", LogType.Run);
                                _lastIndex = 0;
                                break;
                            }

                            int batchSize = Math.Min(blockSize, totalAccumulate - _lastIndex);
                            int startAddr = TorsionCurve.StartAddress + _lastIndex;

                            ushort[] waveData = await ModbusRtuHelper.Instance.ReadRegistersAsync((byte)TorsionCurve.SlaveAddress,(ushort)startAddr,(ushort)batchSize);
                            _lastIndex += batchSize;
                          
                            List<float> torqueValues = waveData.Select(v => (float)v).ToList();
                            waveDataInfo.AddRange(waveData.Select(x => (double)x));
                            OnChartDataReceived?.Invoke(torqueValues);
                            //LogHelper.WriteLog($"起始: {startAddr}-大小:{batchSize}-_lastIndex:{_lastIndex}-TotalNum:{totalAccumulate}-实时:{totalCollections[0]}", LogType.Run);
                            await Task.Delay(5);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteLog($"采集异常: {ex.Message}", LogType.Fault);
                            break;
                        }
                    }
                });
            }
            else if ((code == 2 || code == 3 || code == 4) && _collecting)
            {
                LogHelper.WriteLog("--------------运行结束--------------", LogType.Run);
                OnResultsUpdated?.Invoke();
                _lastIndex = 0;
                _collecting = false;
            }
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
            string fileName = $"{GetBinFilesNum():D3}.bin";

            string filePath = Path.Combine(fullFolderPath, fileName);

            // 写入数据
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (var val in waveDataInfo)
                    writer.Write(val);
            }

            File.SetAttributes(filePath, FileAttributes.Hidden);
        }

        public static int GetBinFilesNum()
        {
            lock (_binFileLock)
            {
                try
                {
                    string basePath = Path.Combine(Settings.Default.ProductionDataPath, "BinFiles");
                    string dateFolder = DateTime.Now.ToString("yyyy-MM-dd");
                    string fullFolderPath = Path.Combine(basePath, dateFolder);

                    if (!Directory.Exists(fullFolderPath))
                        Directory.CreateDirectory(fullFolderPath);

                    var files = Directory.GetFiles(fullFolderPath, "*.bin");
                    List<int> numbers = new List<int>();

                    foreach (var file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        if (int.TryParse(fileName, out int num))
                            numbers.Add(num);
                    }

                    return numbers.Count > 0 ? numbers.Max() + 1 : 1;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog($"获取Bin文件编号报错:{ex.Message}", LogType.Error);
                    return -1;
                }
            }
        }


        public static async Task ElectricBatchAction( byte slaveId, ushort address,int sourceValue)
        {
            try
            {
                await ModbusRtuHelper.Instance.WriteSingleRegisterAsync(slaveId, address, (ushort)(1 - sourceValue));
               
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

        /// <summary>
        /// 通过配置项名称读取 Modbus 寄存器（异步）
        /// </summary>
        /// <param name="name">配置项名称，例如 "TotalCollections"</param>
        /// <returns>读取到的寄存器值数组</returns>
        public static async Task<ushort[]> ReadRegisterByNameAsync(string name)
        {
            // 获取地址项
            ModbusCfgModel cfg = ModbusAddressConfig.Instance.GetAddressItem(name);
            if (cfg == null)
            {
                throw new ArgumentException($"未找到配置项: {name}");
            }

            // 调用 Modbus 异步读取方法
            return await ModbusRtuHelper.Instance.ReadRegistersAsync(
                (byte)cfg.SlaveAddress,
                (ushort)cfg.StartAddress,
                (ushort)cfg.Length
            );
        }
        public static async Task<ushort[]> ReadRegisterByNameAsync(string name1, string name2)
        {
            // 获取地址项
            ModbusCfgModel cfg = ModbusAddressConfig.Instance.GetAddressItem(name1,name2);
            if (cfg == null)
            {
                throw new ArgumentException($"未找到配置项: {name1}");
            }

            // 调用 Modbus 异步读取方法
            return await ModbusRtuHelper.Instance.ReadRegistersAsync(
                (byte)cfg.SlaveAddress,
                (ushort)cfg.StartAddress,
                (ushort)cfg.Length
            );
        }
    }
}
