using AutoScrewSys.BLL;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using System;
using System.Collections.Generic;
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
        static bool isRunning = true;
        static Task mainTask = null;
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
                    var rtu = RTU.GetInstance(SerialInfo);

                    #region 注释:读取excel方式获取数据地址
                    /// 初始化存储区
                    //var sa = bll.InitStorageArea(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ModbusAddr.xlsx"));
                    //if (sa.State) StorageList = sa.Data;
                    //else
                    //{
                    //    faultAction.Invoke(sa.Message); return;
                    //} 
                    #endregion

                    /// 连接
                    if (rtu.Connection())
                    {
                        successAction?.Invoke();
                        while (isRunning)
                        {
                            //LogHelper.WriteLog($"步1", LogType.Run);

                            Thread.Sleep(100);
                            // rtu.ReadRegisters((byte)item.SlaveAddress, (byte)item.StartAddress, (byte)item.Length);

                            var runStatus = ModbusAddressConfig.Instance.GetAddressItem("RealTVoltage");

                            ushort[] runStatusResult = rtu.ReadRegisters(
                                (byte)runStatus.SlaveAddress,
                                (ushort)runStatus.StartAddress,
                                (ushort)runStatus.Length
                                );
                            ushort r = runStatusResult[0];

                            LogHelper.WriteLog($"电压:{r}", LogType.Run);

                            #region 暂时注释
                            //return;
                            //if (r == 0) continue;

                            //if (r == 2 || r == 3 || r == 4)
                            //{
                            //    //单次结束
                            //}

                            //foreach (var prop in typeof(AddrName).GetProperties())
                            //{

                            //    var modbusInfo = ModbusAddressConfig.Instance.GetAddressItem(prop.Name);
                            //    if (modbusInfo == null) continue;

                            //    // 调用 Modbus RTU 读取方法
                            //    ushort[] result = rtu.ReadRegisters(
                            //        (byte)modbusInfo.SlaveAddress,
                            //        (ushort)modbusInfo.StartAddress,
                            //        (ushort)modbusInfo.Length
                            //    );

                            //    object value;

                            //    // 进行类型判断转换
                            //    if (prop.PropertyType == typeof(int))
                            //        value = (int)result[0];
                            //    else if (prop.PropertyType == typeof(bool))
                            //        value = result[0] != 0;
                            //    else if (prop.PropertyType == typeof(string))
                            //        value = result[0].ToString();
                            //    else if (prop.PropertyType == typeof(ushort))
                            //        value = result[0];
                            //    else if (prop.PropertyType == typeof(double))
                            //        value = (double)result[0];
                            //    else
                            //        continue;

                            //    prop.SetValue(AddrName.Default, value);
                            //} 
                            #endregion


                        }
                    }
                    else
                    {
                        faultAction.Invoke("串口连接初始化失败！请检查设备是否连接正常。");
                    }
                }));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"{ex.Message}", LogType.Error);
            }
          
        }
    }
}
