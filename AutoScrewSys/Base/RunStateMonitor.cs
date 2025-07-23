using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Base
{
    public class RunStateMonitor
    {
        private bool _collecting = false;
        private Thread _collectorThread;
        private bool _running = true;
        private int currentAddress = 1;
        private const int MaxAddress = 1000;
        private const int ReadBlockSize = 10;
        public event Action<DateTime[], ushort[]> OnWaveformReady;

        public void Start()
        {
            _collectorThread = new Thread(() =>
            {
                while (_running)
                {
                    try
                    {
                        var status = (ScrewStatus)AddrName.Default.ScrewResult;

                        if (status == ScrewStatus.Running && !_collecting)
                        {
                            currentAddress = 1;
                            _collecting = true;
                            Settings.Default.CurrentRunState = true;
               
                            Settings.Default.RunStateStr = status.ToString();
                            Task.Run(() => CollectTorqueData());
                        }
                        else if (status == ScrewStatus.OK && _collecting)
                        {
                            _collecting = false;
                            
                            Settings.Default.RunStateStr = status.ToString();
                        }
                        else if (status == ScrewStatus.NG && _collecting)
                        {
                            _collecting = false;
                            Settings.Default.RunStateStr = status.ToString();
                        }
                        else if (status == ScrewStatus.Incomplete && _collecting)
                        {
                            _collecting = false;
                            Settings.Default.RunStateStr = status.ToString();
                        }
                        else if (status == ScrewStatus.Ready)
                        {
                            _collecting = false;
                            Settings.Default.RunStateStr = status.ToString();
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
            });
            _collectorThread.IsBackground = true;
            _collectorThread.Start();
        }

        private void CollectTorqueData()
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

                    if (data != null )
                    {
                        DateTime startTime = DateTime.Now;

                        DateTime[] timeAxis = Enumerable.Range(0, 10)
                            .Select(i => startTime.AddMilliseconds(i)).ToArray();

                        OnWaveformReady?.Invoke(timeAxis, data);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog($"采集扭力波形失败：{ex.Message}", LogType.Error);
                }

                Thread.Sleep(5); // 1秒采集1次1000个点
            }
        }

        public void Stop() => _running = false;
    }

}
