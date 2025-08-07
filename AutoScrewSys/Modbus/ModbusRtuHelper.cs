using AutoScrewSys.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoScrewSys.Modbus
{
    public class ModbusRtuHelper
    {
        private byte[] _receiveBuffer;
        private int _receiveOffset = 0;
        private int _expectedLength = 0;
        private bool _dataReady = false;
        private readonly object _receiveLock = new object();

        private static ModbusRtuHelper _instance;//单例
        private static readonly object _lock = new object();//单例锁
        public bool Debug { get; set; } = false;//调试使用
        public static bool Controller { get; set; }
        private SerialPort _serialPort;
        private readonly SemaphoreSlim _asyncLock = new SemaphoreSlim(1, 1);
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
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="parity"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        /// <param name="readTimeout"></param>
        /// <param name="writeTimeout"></param>
        /// <returns></returns>
        public bool TryConnectSerialPort(SerialPort serialPort)
        {
            try
            {
                if (_serialPort == null)
                    _serialPort = serialPort;

                if (!_serialPort.IsOpen)
                {
                    _serialPort.DataReceived += SerialPort_DataReceived;
                    _serialPort.Open();
                    LogHelper.WriteLog("串口连接成功", LogType.Run);
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("串口连接失败：" + ex.Message, LogType.Error);
                return false;
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = _serialPort.BytesToRead;
                if (bytesToRead == 0) return;

                byte[] buffer = new byte[bytesToRead];
                int read = _serialPort.Read(buffer, 0, bytesToRead);

                lock (_receiveLock)
                {
                    int copyLen = Math.Min(read, _expectedLength - _receiveOffset);
                    Array.Copy(buffer, 0, _receiveBuffer, _receiveOffset, copyLen);
                    _receiveOffset += copyLen;

                    if (_receiveOffset >= _expectedLength)
                    {
                        _dataReady = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("串口接收异常：" + ex.Message, LogType.Error);
            }
        }
        /// <summary>
        /// 异步读取
        /// </summary>
        /// <param name="slaveId"></param>
        /// <param name="startAddress"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public async Task<(bool result, short[] values)> ReadRegistersAsync(byte slaveId, ushort startAddress, ushort length)//读取
        {
            try
            {
                byte[] frame = BuildRequestFrame(slaveId, 0x03, startAddress, length);

                // 带超时、死锁保护、串口重连保护的读取方法
                byte[] response = await SendAndReceiveAsync(frame, length * 2 + 5);

                if (response?.Length < 5 || response?[1] != 0x03)
                {
                    //LogHelper.WriteLog("响应格式错误或功能码不一致", LogType.Fault);
                    return (false, Array.Empty<short>());
                }

                short[] values = new short[length];
                for (int i = 0; i < length; i++)
                {
                    values[i] = (short)(response[3 + i * 2] << 8 | response[4 + i * 2]);
                }

                return (true, values);
            }
            catch (TimeoutException tex)
            {
                LogHelper.WriteLog("读取寄存器超时: " + tex.Message, LogType.Error,false);
            }
            catch (IOException ioex)
            {
                LogHelper.WriteLog("串口IO错误，尝试重连: " + ioex.Message, LogType.Error);

                try
                {
                    if (_serialPort.IsOpen)
                        _serialPort.Close();

                    _serialPort.Open();
                    LogHelper.WriteLog("串口重连成功", LogType.Run);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("串口重连失败: " + ex.Message, LogType.Error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("读取寄存器异常: " + ex.Message, LogType.Error);
            }

            return (false, Array.Empty<short>());
        }

        public async Task<byte[]> SendAndReceiveAsync(byte[] request, int expectedLength, int timeoutMs = 1000)
        {
            await _asyncLock.WaitAsync(); // 不设超时
            _dataReady = false;

            lock (_receiveLock)
            {
                _expectedLength = expectedLength;
                _receiveBuffer = new byte[expectedLength];
                _receiveOffset = 0;
            }

            await _serialPort.BaseStream.WriteAsync(request, 0, request.Length);
            if (Debug)
                LogHelper.WriteLog($"TX:{BitConverter.ToString(request).Replace("-", " ")}", LogType.Run);

            // 开始等待接收完成或超时
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                if (_dataReady)
                {
                    var result = new byte[_expectedLength];
                    lock (_receiveLock)
                    {
                        Array.Copy(_receiveBuffer, result, _expectedLength);
                    }

                    if (Debug)
                        LogHelper.WriteLog($"RX:{BitConverter.ToString(result).Replace("-", " ")}", LogType.Run);

                    _asyncLock.Release();
                    return result;
                }

                await Task.Delay(0); // 避免占满CPU
            }

            _asyncLock.Release();
            LogHelper.WriteLog("串口接收超时...", LogType.Run, false);
            return null;
        }


        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="slaveId"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> WriteSingleRegisterAsync(byte slaveId, ushort address, ushort value)//写入
        {
            byte[] frame = BuildRequestFrame(slaveId, 0x06, address, value);

            byte[] response = await SendAndReceiveAsync(frame, 8);

            if (response?.Length != 8 || response?[1] != 0x06)
                return false;
            return true;
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

        /// <summary>
        /// 向串口发送字节
        /// </summary>
        /// <param name="request"></param>
        /// <param name="expectedLength"></param>
        /// <param name="timeoutMs"></param>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        /// <exception cref="TimeoutException"></exception>
        public async Task<byte[]> SendAndReceiveAsyncCanUse(byte[] request, int expectedLength, int timeoutMs = 1000)
        {
            var cts = new CancellationTokenSource(timeoutMs);
            bool acquired = false;

            try
            {
                acquired = await _asyncLock.WaitAsync(TimeSpan.FromSeconds(3));
                if (!acquired)
                {
                    // LogHelper.WriteLog("连接失败,等待串口访问超时......", LogType.Error);
                    LogHelper.WriteLog($"串口状态: {_serialPort.IsOpen}, 端口: {_serialPort.PortName}", LogType.Run);

                    return null;
                }
                await _serialPort.BaseStream.WriteAsync(request, 0, request.Length);

                if (Debug)
                    LogHelper.WriteLog($"TX:{BitConverter.ToString(request).Replace("-", " ")}", LogType.Run);

                var buffer = new byte[expectedLength];
                int offset = 0;

                while (offset < expectedLength)
                {
                    int read = await _serialPort.BaseStream.ReadAsync(buffer, offset, expectedLength - offset, cts.Token);
                    if (read == 0)
                        throw new IOException("串口读取返回0字节");

                    offset += read;
                }

                var result = new byte[offset];
                Array.Copy(buffer, result, offset);

                if (Debug)
                    LogHelper.WriteLog($"RX:{BitConverter.ToString(result).Replace("-", " ")}", LogType.Run);

                return result;
            }
            catch (OperationCanceledException)
            {
                throw new TimeoutException("读取串口数据超时");
            }
            finally
            {
                cts.Dispose();

                if (acquired)
                    _asyncLock.Release();
            }
        }

        /// <summary>
        /// CRC16从低到高校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
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
