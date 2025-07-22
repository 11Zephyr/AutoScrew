using AutoScrewSys.BLL;
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

namespace AutoScrewSys.Base
{
    public class GlobalMonitor
    {
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

                    #region 注释:读取excel方式获取数据地址
                    /// 初始化存储区
                    //var sa = bll.InitStorageArea(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ModbusAddr.xlsx"));
                    //if (sa.State) StorageList = sa.Data;
                    //else
                    //{
                    //    faultAction.Invoke(sa.Message); return;
                    //} 
                    #endregion

                    // 初始化串口一次
                    if (ModbusRtuHelper.Instance.Init(SerialInfo.PortName, SerialInfo.BaudRate, SerialInfo.Parity, SerialInfo.DataBit, SerialInfo.StopBits))
                    {
                        isInit = true;
                        successAction?.Invoke();

                        _modbusSyncThread = new Thread(UpdateSettingsFromModbus)
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
                    #region 使用库函数读写
                    //var rtu = rtu.getinstance(serialinfo);

                    ///// 连接
                    //if (rtu.connection())
                    //{
                    //    successaction?.invoke();
                    //    while (false)
                    //    {
                    //        //loghelper.writelog($"步1", logtype.run);

                    //        thread.sleep(100);
                    //        // rtu.readregisters((byte)item.slaveaddress, (byte)item.startaddress, (byte)item.length);

                    //        var runstatus = modbusaddressconfig.instance.getaddressitem("realtvoltage");

                    //        ushort[] runstatusresult = rtu.readregisters(
                    //            (byte)runstatus.slaveaddress,
                    //            (ushort)runstatus.startaddress,
                    //            (ushort)runstatus.length
                    //            );
                    //        ushort r = runstatusresult[0];

                    //        loghelper.writelog($"电压:{r}", logtype.run);

                    //        #region 暂时注释
                    //        //return;
                    //        //if (r == 0) continue;

                    //        //if (r == 2 || r == 3 || r == 4)
                    //        //{
                    //        //    //单次结束
                    //        //}

                    //        //foreach (var prop in typeof(addrname).getproperties())
                    //        //{

                    //        //    var modbusinfo = modbusaddressconfig.instance.getaddressitem(prop.name);
                    //        //    if (modbusinfo == null) continue;

                    //        //    // 调用 modbus rtu 读取方法
                    //        //    ushort[] result = rtu.readregisters(
                    //        //        (byte)modbusinfo.slaveaddress,
                    //        //        (ushort)modbusinfo.startaddress,
                    //        //        (ushort)modbusinfo.length
                    //        //    );

                    //        //    object value;

                    //        //    // 进行类型判断转换
                    //        //    if (prop.propertytype == typeof(int))
                    //        //        value = (int)result[0];
                    //        //    else if (prop.propertytype == typeof(bool))
                    //        //        value = result[0] != 0;
                    //        //    else if (prop.propertytype == typeof(string))
                    //        //        value = result[0].tostring();
                    //        //    else if (prop.propertytype == typeof(ushort))
                    //        //        value = result[0];
                    //        //    else if (prop.propertytype == typeof(double))
                    //        //        value = (double)result[0];
                    //        //    else
                    //        //        continue;

                    //        //    prop.setvalue(addrname.default, value);
                    //        //} 
                    //        #endregion

                    //    }
                    //}
                    //else
                    //{
                    //    faultaction.invoke("串口连接初始化失败！请检查设备是否连接正常。");
                    //} 
                    #endregion
                }));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"{ex.Message}", LogType.Error);
            }

        }

        public static void UpdateSettingsFromModbus()
        {
            var cfg = AddrName.Default;
            var type = cfg.GetType();
            ushort i = 0;
            while (false)
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

                        if(i == cfg.Properties.Count)
                        {
                            LogHelper.WriteLog("========================================", LogType.Error);
                            i= 0;
                        }
                        LogHelper.WriteLog($"{addr.Description}:{val}", LogType.Error);
                        i++;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog($"读取 {p.Name} 失败: {ex.Message}", LogType.Error);
                    }
                }
                Thread.Sleep(5);
            }

            //cfg.Save();
        }
    }
}
