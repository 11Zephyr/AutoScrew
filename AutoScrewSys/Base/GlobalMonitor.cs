using AutoScrewSys.BLL;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Diagrams;
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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZimaBlueScrew.Frm;
using Zmodbus;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;
using Path = System.IO.Path;

namespace AutoScrewSys.Base
{
    public class GlobalMonitor
    {
        public static bool isInit { get; private set; } //初始化标志
        private static bool _collecting = false;//采集波形数据标志
        public static bool Isload { get; set; }
        private static readonly object _binFileLock = new object();//二进制文件锁

        public static Action ClearChartAction;//清除波形图委托
        public static event Action<List<float>> OnChartDataReceived;//波形图接收事件
        public static event Action OnResultsUpdated;//更新表格事件
        public static event Action<int, int, int, int, int> StatusChanged;//状态变换事件

        public static ModbusSerialInfo SerialInfo { get; set; }//ModBus串口信息
        static Thread _modbusSyncThread;//主循环线程
        private static List<double> waveDataInfo = new List<double>();//存储波形数据

        /// <summary>
        /// 启动检测主函数
        /// </summary>
        /// <param name="successAction">成功委托</param>
        /// <param name="faultAction">失败委托</param>
        public static void Start(Action successAction, Action<string> faultAction)
        {
            try
            {
                Task.Run(new Action(() =>
                {
                    IndustrialBLL bll = new IndustrialBLL();
                    var si = bll.InitSerialInfo();
                    if (si.State)
                    {
                        SerialInfo = si.Data;

                        if (ModbusRtuHelper.Instance.TryConnectSerialPort(
                            new SerialPort(SerialInfo.PortName, SerialInfo.BaudRate, SerialInfo.Parity, SerialInfo.DataBit, SerialInfo.StopBits)
                            {
                                ReadTimeout = Convert.ToInt32(Settings.Default.receptOutTime),
                                WriteTimeout = Convert.ToInt32(Settings.Default.sendOutTime)

                            }))
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
                    }
                    else
                    {
                        faultAction.Invoke(si.Message); return;
                    }
                }));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"{ex.Message}", LogType.Error);
            }
        }

        /// <summary>
        /// 主循环线程
        /// </summary>
        public async static void MainThread()
        {
            var cfg = AddrName.Default;//存储地址名称设置文件

            while (isInit)
            {
                foreach (SettingsProperty p in cfg.Properties)
                {
                    var addr = ModbusAddressConfig.Instance.GetAddressItem(p.Name);
                    if (addr == null) continue;
                    try
                    {
                        var (success, values) = await ModbusRtuHelper.Instance.ReadRegistersAsync(
                            (byte)addr.SlaveAddress,
                            (ushort)addr.StartAddress,
                            (ushort)addr.Length
                        );
                        if (success)
                        {
                            var value = values[0] * addr.Proportion;
                            SettingsUpdater.SetIfChanged(cfg, p.Name, value);
                            SettingsUpdater.SetVoltageColor(Color.Green);
                            AcquireWaveformData(cfg, AddrName.Default.ScrewResult);
                        }
                        else
                        {
                            SettingsUpdater.SetVoltageColor(Color.Red);
                            LogHelper.WriteLog($"读取: {addr.Description} 失败-从站:{addr.SlaveAddress}-地址:{addr.StartAddress}-长度:{addr.Length}", LogType.Fault);
                            await Task.Delay(3000);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog($"读取 {p.Name} 报错: {ex.Message}", LogType.Error);
                    }

                    #region 注释
                    //var task = Task.Run(async () =>
                    //{

                    //});
                    //if (await semaphore.WaitAsync(TimeSpan.FromSeconds(3)))//异步锁,3秒超时
                    //{

                    //}
                    //else
                    //{
                    //    SettingsUpdater.SetVoltageColor(Color.Red);
                    //    LogHelper.WriteLog($"读取超时......", LogType.Error);
                    //    StopModbusSyncThread();
                    //    break;
                    //} 
                    #endregion
                }

                UpdateAlarmMsgStr(cfg, AddrName.Default.AlarmInfo);
                StatusChangeNotifier.CheckAndNotifyStatusChange(StatusChanged);
                await Task.Delay(10);
            }
        }
        /// <summary>
        /// 停止 Modbus 循环线程
        /// </summary>
        public static void StopModbusSyncThread()
        {
            isInit = false;

            if (_modbusSyncThread != null && _modbusSyncThread.IsAlive)
            {
                // 最多等待1秒让线程退出
                if (!_modbusSyncThread.Join(1000))
                {
                    LogHelper.WriteLog("强制释放线程", LogType.Run);
                    _modbusSyncThread.Abort(); // 危险，建议避免使用
                }
            }

            _modbusSyncThread = null;
        }
        /// <summary>
        /// 根据运行状态判断是否开始采集波形图
        /// </summary>
        /// <param name="cfg"></param>
        /// <param name="code"></param>
        public async static void AcquireWaveformData(SettingsBase cfg, int code)
        {
            try
            {
                string resultStr;
                Color backColor;
                switch (code)
                {
                    case 0:
                        resultStr = "就绪";
                        backColor = Color.GreenYellow;
                        break;
                    case 1:
                        resultStr = "运行中";
                        backColor = Color.Orange;
                        break;
                    case 2:
                        resultStr = "OK";
                        backColor = Color.Green;
                        break;
                    case 3:
                        resultStr = "NG";
                        backColor = Color.Red;
                        break;
                    case 4:
                        resultStr = "未完成";
                        backColor = Color.Gray;
                        break;
                    default:
                        resultStr = "未知";
                        backColor = Color.Brown;
                        break;
                }

                SettingsUpdater.SetResultBackColor(backColor);
                SettingsUpdater.SetIfChanged(cfg, "ScrewResultStr", resultStr);

                if (code == 1 && !_collecting)
                {
                    _collecting = true;
                    ClearChartAction?.Invoke();
                    waveDataInfo?.Clear();
                    int blockSize = 20;//一次采集20个数据
                    ushort maxValue = 1000;//1000个之后从头开始采集
                    ushort prevValue = 0;//当前值
                    int totalAccumulate = 0;//采集总数
                    int currentTotalCount = 0;//当前总数
                    int _lastIndex = 0;//上一次索引
                    ModbusCfgModel TorsionCurve = ModbusAddressConfig.Instance.GetAddressItem("TorsionCurve");//采集扭力地址

                    await Task.Run(async () =>
                    {
                        while (_collecting)
                        {
                            try
                            {
                                ushort currValue = (ushort)(await ReadRegisterByNameAsync("TotalCollections"))[0];
                                totalAccumulate += (currValue >= prevValue) ? (currValue - prevValue) : (currValue + maxValue - prevValue);
                                prevValue = currValue;
                                if (_lastIndex >= maxValue) _lastIndex = 0;
                                if (currentTotalCount >= totalAccumulate)
                                {
                                    //LogHelper.WriteLog($"跳出:_lastIndex:{_lastIndex}-_collectTotalNum{_collectTotalNum}-collectTotalNum:{totalCollections[0]}", LogType.Run);
                                    _lastIndex = 0;
                                    break;
                                }

                                int batchSize = Math.Min(blockSize, totalAccumulate - currentTotalCount);
                                int startAddr = TorsionCurve.StartAddress + _lastIndex;

                                var (success, values) = await ModbusRtuHelper.Instance.ReadRegistersAsync((byte)TorsionCurve.SlaveAddress, (ushort)startAddr, (ushort)batchSize);
                                _lastIndex += batchSize;
                                currentTotalCount = _lastIndex;
                                List<float> torqueValues = values.Select(v => (float)v).ToList();

                                waveDataInfo.AddRange(values.Select(x => (double)x));
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
                    _collecting = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"采集波形数据报错:{ex.Message}", LogType.Error);
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
        /// 权限检查
        /// </summary>
        /// <param name="level"></param>
        public static void CheckLogin(short level)
        {
            if (Settings.Default.Login < level)
            {
                LoginFrm frm = new LoginFrm();
                frm.ShowDialog();
            }
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
        /// <summary>
        /// 获取当天二进制波形数据索引
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 写入数据按钮操作
        /// </summary>
        /// <param name="slaveId"></param>
        /// <param name="address"></param>
        /// <param name="sourceValue"></param>
        /// <returns></returns>
        public static async Task ElectricBatchAction(byte slaveId, ushort address, int sourceValue)
        {
            try
            {
                await ModbusRtuHelper.Instance.WriteSingleRegisterAsync(slaveId, address, (ushort)(1 - sourceValue));//根据原值判断1写0，0写1
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
        public static async Task<short[]> ReadRegisterByNameAsync(string name)
        {
            // 获取地址项
            ModbusCfgModel cfg = ModbusAddressConfig.Instance.GetAddressItem(name);
            if (cfg == null)
            {
                throw new ArgumentException($"未找到配置项: {name}");
            }
            var (success, values) = await ModbusRtuHelper.Instance.ReadRegistersAsync(
                (byte)cfg.SlaveAddress,
                (ushort)cfg.StartAddress,
                (ushort)cfg.Length
            );
            return values;
        }
        public static async Task<short[]> ReadRegisterByNameAsync(string name1, string name2)
        {
            // 获取地址项
            ModbusCfgModel cfg = ModbusAddressConfig.Instance.GetAddressItem(name1, name2);
            if (cfg == null)
            {
                throw new ArgumentException($"未找到配置项: {name1}");
            }

            var (success, values) = await ModbusRtuHelper.Instance.ReadRegistersAsync(
                (byte)cfg.SlaveAddress,
                (ushort)cfg.StartAddress,
                (ushort)cfg.Length
            );
            return values;
        }
    }
}
