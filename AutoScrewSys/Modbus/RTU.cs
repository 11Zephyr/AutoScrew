using AutoScrewSys.Base;
using AutoScrewSys.Interface;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.Modbus
{
    public class RTU
    {
        /// <summary>
        /// 响应回调（起始地址、数据）
        /// </summary>
        public Action<int, List<byte>> Responsed;

        private SerialPort _serialPort;
        private ModbusSerialMaster _master;
        private static RTU _instance;
        private static ModbusSerialInfo _serialInfo;
        public bool IsConnected { get; private set; } = false;
        private RTU(ModbusSerialInfo serialInfo)
        {
            _serialPort = new SerialPort();
            _serialPort.ReceivedBytesThreshold = 1;
            _serialInfo = serialInfo;
        }
        public static RTU GetInstance(ModbusSerialInfo serialInfo)
        {
            lock ("rtu")
            {
                if (_instance == null)
                    _instance = new RTU(serialInfo);
                return _instance;
            }
        }
        public static RTU GetInstance()
        {
            if (_instance == null)
            {
                throw new InvalidOperationException("RTU 未初始化...");
            }
            return _instance;
        }
        public void Close()
        {
            throw new NotImplementedException();
        }

        public bool Connection()
        {
            try
            {
                //关闭已打开串口
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                //设置串口属性
                _serialPort.PortName = _serialInfo.PortName;
                _serialPort.BaudRate = _serialInfo.BaudRate;
                _serialPort.DataBits = _serialInfo.DataBit;
                _serialPort.Parity = _serialInfo.Parity;
                _serialPort.StopBits = _serialInfo.StopBits;

                _serialPort.ReceivedBytesThreshold = 1;
                _serialPort.Open();

                // 初始化 NModbus 主站对象
                _master = ModbusSerialMaster.CreateRtu(_serialPort);
                _master.Transport.ReadTimeout = 1000;
                _master.Transport.WriteTimeout = 1000;
                IsConnected = true;
                return true;
            }
            catch
            {
                IsConnected = false;
                return false;
            }
        }

        public ushort[] ReadRegisters(byte slaveId, ushort startAddress, ushort numRegisters)
        {
            try
            {
                if (!IsConnected)
                    throw new InvalidOperationException("未连接 Modbus 设备");

                return _master.ReadHoldingRegisters(slaveId, startAddress, numRegisters);
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog($"读取失败:{ex.Message}", LogType.Error);
                return null;
            }
         
        }

        public bool WriteSingleRegister(byte slaveId, ushort address, ushort value)
        {
            try
            {
                if (!IsConnected) return false;
                _master.WriteSingleRegister(slaveId, address, value);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void Dispose()
        {
            Disconnect();
            _serialPort?.Dispose();
        }

        public void Disconnect()
        {
            try
            {
                _master?.Dispose();
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                IsConnected = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"断开失败: {ex.Message}");
            }
        }
    }
}
