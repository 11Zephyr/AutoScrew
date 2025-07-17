using AutoScrewSys.BLL;
using AutoScrewSys.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.Base
{
    public class GlobalMonitor
    {
        public static ModbusSerialInfo SerialInfo { get; set; }

        static Task mainTask = null;
        public static void Start(Action successAction, Action<string> faultAction)
        {
            mainTask = Task.Run(new Action( () =>
            {
                IndustrialBLL bll = new IndustrialBLL();
                var si = bll.InitSerialInfo();
                if (si.State) SerialInfo = si.Data;
                else
                {
                    faultAction.Invoke(si.Message); return;
                }
                var rtu = RTU.GetInstance(SerialInfo);
                rtu.Responsed = new Action<int, List<byte>>(ParsingData);

               
                /// 连接
                if (rtu.Connection())
                {
                    successAction.Invoke();
                }
                else
                {
                    faultAction.Invoke("串口连接初始化失败！请检查设备是否连接正常。");
                }
            }));
        }
        private static void ParsingData(int start_addr, List<byte> byteList)
        {
        }
    }
}
