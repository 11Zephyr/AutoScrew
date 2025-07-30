using AutoScrewSys.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool Debug { get; set; } = false;
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

        public bool Init(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One,int readTimeout = 1000, int writeTimeout = 1000)
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                    return true;

                _serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
                {
                    ReadTimeout = readTimeout,
                    WriteTimeout = writeTimeout
                };
                _serialPort.Open();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public async Task<ushort[]> ReadRegistersAsync(byte slaveId, ushort startAddress, ushort length)
        {
            byte[] frame = BuildRequestFrame(slaveId, 0x03, startAddress, length);

            // 异步等待响应
            byte[] response = await SendAndReceiveAsync(frame, length * 2 + 5);

            if (response.Length < 5 || response[1] != 0x03)
                throw new Exception("无效响应");

            ushort[] values = new ushort[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = (ushort)(response[3 + i * 2] << 8 | response[4 + i * 2]);
            }
            return values;
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

        private readonly SemaphoreSlim _asyncLock = new SemaphoreSlim(1, 1);
        private const int ReadTimeoutMs = 500; // 适当设置读超时

        private async Task<byte[]> SendAndReceiveAsync(byte[] request, int expectedLength)
        {
            await _asyncLock.WaitAsync();
            try
            {
                _serialPort?.DiscardInBuffer();

                await _serialPort.BaseStream.WriteAsync(request, 0, request.Length);

                if (Debug) LogHelper.WriteLog($"TX:{BitConverter.ToString(request).Replace("-", " ")}", LogType.Run);

                // 异步读取响应，循环读取直到收到expectedLength字节或超时
                var buffer = new byte[expectedLength];
                int offset = 0;
                var stopwatch = Stopwatch.StartNew();

                while (offset < expectedLength)
                {
                    if (stopwatch.ElapsedMilliseconds > ReadTimeoutMs)
                    {
                        throw new TimeoutException("读取串口数据超时");
                    }

                    if (_serialPort.BytesToRead > 0)
                    {
                        int read = await _serialPort.BaseStream.ReadAsync(buffer, offset, expectedLength - offset);
                        if (read == 0) // 串口关闭或异常
                            throw new Exception("串口读取返回0字节");

                        offset += read;
                    }
                    else
                    {
                        // 没有数据时，异步短暂延时，避免死循环
                        await Task.Delay(0);
                    }
                }

                stopwatch.Stop();

                var actual = new byte[offset];
                Array.Copy(buffer, actual, offset);

                if (Debug) LogHelper.WriteLog($"RX:{BitConverter.ToString(actual).Replace("-", " ")}", LogType.Run);

                return actual;
            }
            finally
            {
                _asyncLock.Release();
            }
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
