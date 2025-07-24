using AutoScrewSys.BLL;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Base
{
    public class GlobalMonitor
    {
        private static bool _collecting = false;
        private static bool _running = true;
        private static int currentAddress = 1;
        private  const int MaxAddress = 1000;
        private const int ReadBlockSize = 10;
        public static event Action<DateTime[], ushort[]> OnTorqueWaveUpdated;
        public static event Action<string> OnResultsUpdated;
        public static List<StorageModel> StorageList { get; set; }
        public static ModbusSerialInfo SerialInfo { get; set; }
        public static bool isInit { get; private set; }
        static Task mainTask = null;
        static Thread _modbusSyncThread;

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
            
                    // 初始化串口一次
                    if (ModbusRtuHelper.Instance.Init(SerialInfo.PortName, SerialInfo.BaudRate, SerialInfo.Parity, SerialInfo.DataBit, SerialInfo.StopBits))
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

        private static void RunStatusMonitor()
        {
            try
            {
                var status = (ScrewStatus)AddrName.Default.ScrewResult;

                if (status == ScrewStatus.Running && !_collecting)
                {
                    currentAddress = 1;
                    _collecting = true;
                    Settings.Default.CurrentRunState = true;
                    Task.Run(() => CollectTorqueData());
                }
                else if (status == ScrewStatus.OK && _collecting)
                {
                    _collecting = false;
                    OnResultsUpdated?.Invoke(status.ToString());
                }
                else if (status == ScrewStatus.NG && _collecting)
                {
                    _collecting = false;
                    OnResultsUpdated?.Invoke(status.ToString());

                }
                else if (status == ScrewStatus.Incomplete && _collecting)
                {
                    _collecting = false;
                    OnResultsUpdated?.Invoke(status.ToString());

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
        private static void CollectTorqueData()
        {
            while (_collecting)
            {
                try
                {
                    // 读取地址11208~12207，1000个16位无符号
                    ushort[] data = ModbusRtuHelper.Instance.ReadRegisters(1, (ushort)currentAddress, ReadBlockSize);

                    currentAddress += ReadBlockSize;
                    if (currentAddress > MaxAddress)
                        currentAddress = 1;

                    if (data != null)
                    {
                        DateTime startTime = DateTime.Now;

                        DateTime[] timeAxis = Enumerable.Range(0, 10)
                            .Select(i => startTime.AddMilliseconds(i)).ToArray();

                        OnTorqueWaveUpdated?.Invoke(timeAxis, data);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog($"采集扭力波形失败：{ex.Message}", LogType.Error);
                }

                Thread.Sleep(5); // 1秒采集1次1000个点
            }
        }
        public static void ElectricBatchAction(object sender, byte slaveId, ushort address)
        {
            try
            {
                if (sender is Button btn)
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
    }
}
