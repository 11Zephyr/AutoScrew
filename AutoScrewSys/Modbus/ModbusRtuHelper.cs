using AutoScrewSys.Base;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoScrewSys.Modbus
{
    public class ModbusRtuHelper
    {
        private static ModbusRtuHelper _instance;
        private static readonly object _lock = new object();
        public bool Debug { get; set; } = true;
        private SerialPort _serialPort;
        private readonly object _portLock = new object();

        public static ModbusRtuHelper Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new ModbusRtuHelper();
                    return _instance;
                }
            }
        }

        private ModbusRtuHelper() { }

        public bool Init(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                    return true;

                _serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
                {
                    ReadTimeout = 1000,
                    WriteTimeout = 1000
                };
                _serialPort.Open();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }


        public ushort[] ReadRegisters(byte slaveId, ushort startAddress, ushort length)
        {
            byte[] frame = BuildRequestFrame(slaveId, 0x03, startAddress, length);
            byte[] response = SendAndReceive(frame, length * 2 + 5);

            if (response.Length < 5 || response[1] != 0x03)
                throw new Exception("无效响应");

            ushort[] values = new ushort[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = (ushort)(response[3 + i * 2] << 8 | response[4 + i * 2]);
            }
            return values;
        }

        public void WriteSingleRegister(byte slaveId, ushort address, ushort value)
        {
            byte[] frame = BuildRequestFrame(slaveId, 0x06, address, value);
            byte[] response = SendAndReceive(frame, 8);

            if (response.Length != 8 || response[1] != 0x06)
                throw new Exception("写入失败");
        }

        private byte[] BuildRequestFrame(byte slaveId, byte functionCode, ushort address, ushort data)
        {
            byte[] frame = new byte[8];
            frame[0] = slaveId;
            frame[1] = functionCode;
            frame[2] = (byte)(address >> 8);
            frame[3] = (byte)(address & 0xFF);
            frame[4] = (byte)(data >> 8);
            frame[5] = (byte)(data & 0xFF);
            ushort crc = CRC16(frame, 6);
            frame[6] = (byte)(crc & 0xFF);
            frame[7] = (byte)(crc >> 8);
            return frame;
        }

        private byte[] SendAndReceive(byte[] request, int expectedLength)
        {
            lock (_portLock)
            {
                _serialPort?.DiscardInBuffer();
                _serialPort?.Write(request, 0, request.Length);
                if(Debug) LogHelper.WriteLog($"TX:{BitConverter.ToString(request).Replace("-", " ")}",LogType.Run);

                Thread.Sleep(100);

                byte[] buffer = new byte[256];
                int received = _serialPort.Read(buffer, 0, expectedLength);
                byte[] actual = new byte[received];
                Array.Copy(buffer, actual, received);
                if (Debug) LogHelper.WriteLog($"RX:{BitConverter.ToString(actual).Replace("-", " ")}", LogType.Run);

                return actual;
            }
        }

        private ushort CRC16(byte[] data, int length)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < length; i++)
            {
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    bool lsb = (crc & 0x0001) != 0;
                    crc >>= 1;
                    if (lsb)
                        crc ^= 0xA001;
                }
            }
            return crc;
        }
    }
}
