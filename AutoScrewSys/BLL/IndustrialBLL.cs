using AutoScrewSys.Modbus;
using AutoScrewSys.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.BLL
{
    public class IndustrialBLL
    {
        public DataResult<ModbusSerialInfo> InitSerialInfo()
        {
            DataResult<ModbusSerialInfo> result = new DataResult<ModbusSerialInfo>();
            result.State = false;

            try
            {
                ModbusSerialInfo SerialInfo = new ModbusSerialInfo();
                SerialInfo.PortName = Settings.Default.cbxPort;
                SerialInfo.BaudRate = int.Parse(Settings.Default.cbxBaudRate);
                SerialInfo.DataBit = int.Parse(Settings.Default.cbxDataBits);
                SerialInfo.Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), Settings.Default.cbxParity, true);
                SerialInfo.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), Settings.Default.cbxStopBits, true);

                result.State = true;
                result.Data = SerialInfo;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
