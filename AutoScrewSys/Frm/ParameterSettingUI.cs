using AutoScrewSys.Base;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Frm
{
    public partial class ParameterSettingUI : UserControl
    {
        private AutoLogoutManager _autoLogoutManager;
        public ParameterSettingUI()
        {
            InitializeComponent();
            //this.Load += SettingsControl_Load;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ///启动全局监控
            GlobalMonitor.Start(
                 () =>
                 {
                     Settings.Default.RTVoltageColor = System.Drawing.Color.Green;
                     LogHelper.WriteLog("串口连接成功...", LogType.Run);
                 },
                 (msg) =>
                 {
                     Settings.Default.RTVoltageColor = System.Drawing.Color.Red;
                     MessageBox.Show(msg, "异常提示");
                 });
        }

        private void SaveComboBoxSetting(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                string settingName = comboBox.Name;
                string value = comboBox.SelectedItem?.ToString() ?? "";

                var settings = Properties.Settings.Default;
                var property = settings.Properties.Cast<System.Configuration.SettingsProperty>()
                                 .FirstOrDefault(p => p.Name == settingName);

                if (property != null)
                {
                    settings[settingName] = value;
                    settings.Save();
                }
                else
                {
                    // 可选：提示某个 ComboBox 没有在 settings 中定义项
                     MessageBox.Show($"Settings 中没有名为 {settingName} 的设置项");
                }
            }
        }

        private void ParameterSettingUI_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSerialPortSettings();

                // 清理数据文件夹
                if (Settings.Default.DataStoredTime != "永久")
                {
                    CleanFolder(Settings.Default.ProductionDataPath, Settings.Default.DataStoredTime, "数据文件");
                }
                // 清理日志文件夹

                if (Settings.Default.LogStoredTime != "永久")
                {
                    CleanFolder(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log"), Settings.Default.LogStoredTime, "日志文件");
                }


                _autoLogoutManager = new AutoLogoutManager();

                // 窗体加载时应用一次配置
                _autoLogoutManager.ApplySettings();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"参数设置页面加载报错:{ex.Message}", LogType.Error);
            }
         
        }

        private static void CleanFolder(string folderPath, string keepTime, string label)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
                {
                    LogHelper.WriteLog($"[{label}] 路径不存在或无效：{folderPath}", LogType.Fault);
                    return;
                }

                var match = Regex.Match(keepTime, @"\d+");
                if (!match.Success)
                {
                    LogHelper.WriteLog($"[{label}] 保留时间格式错误，示例：15天，当前值：{keepTime}", LogType.Fault);
                    return;
                }

                int days = int.Parse(match.Value);
                DateTime threshold = DateTime.Now.AddDays(-days);

                int deleteCount = 0;
                foreach (var file in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
                {
                    try
                    {
                        if (File.GetLastWriteTime(file) < threshold)
                        {
                            File.Delete(file);
                            deleteCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog($"[{label}] 删除文件失败：{file}，原因：{ex.Message}", LogType.Fault);
                    }
                }

                LogHelper.WriteLog($"[{label}] 清理完成，删除文件 {deleteCount} 个，超过 {days} 天。", LogType.Run);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"[{label}] 清理异常：{ex.Message}", LogType.Error);
            }
        }

        private void LoadSerialPortSettings()
        {
            // 1. 串口号
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cbxPort.Items.Clear();
            cbxPort.Items.AddRange(ports);

            string savedPort = Settings.Default.cbxPort;
            if (ports.Contains(savedPort))
                cbxPort.SelectedItem = savedPort;
            else if (ports.Length > 0)
                cbxPort.SelectedIndex = 0;

            // 2. 波特率
            string[] baudRates = { "9600", "19200", "38400", "57600", "115200" };
            cbxBaudRate.Items.Clear();
            cbxBaudRate.Items.AddRange(baudRates);

            string savedBaud = Settings.Default.cbxBaudRate;
            if (baudRates.Contains(savedBaud))
                cbxBaudRate.SelectedItem = savedBaud;
            else
                cbxBaudRate.SelectedIndex = 0;

            // 3. 校验位
            string[] parities = Enum.GetNames(typeof(Parity)); // None, Odd, Even, Mark, Space
            cbxParity.Items.Clear();
            cbxParity.Items.AddRange(parities);

            string savedParity = Settings.Default.cbxParity;
            if (parities.Contains(savedParity))
                cbxParity.SelectedItem = savedParity;
            else
                cbxParity.SelectedIndex = 0;

            // 4. 数据位
            string[] dataBits = {"5","6","7", "8" };
            cbxDataBits.Items.Clear();
            cbxDataBits.Items.AddRange(dataBits);

            string savedDataBits = Settings.Default.cbxDataBits;
            if (dataBits.Contains(savedDataBits))
                cbxDataBits.SelectedItem = savedDataBits;
            else
                cbxDataBits.SelectedIndex = 0;

            // 5. 停止位
            string[] stopBits = {"0", "1", "1.5", "2" };
            cbxStopBits.Items.Clear();
            cbxStopBits.Items.AddRange(stopBits);

            string savedStopBits = Settings.Default.cbxStopBits;
            if (stopBits.Contains(savedStopBits))
                cbxStopBits.SelectedItem = savedStopBits;
            else
                cbxStopBits.SelectedIndex = 0;
        }

        private void cbxDataStoredTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.DataStoredTime = cbxDataStoredTime.SelectedItem.ToString();
        }

        private void cbxTorqueUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.TorqueUnit = cbxTorqueUnit.SelectedItem.ToString();
        }

        private void cbxLogStoredTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.LogStoredTime = cbxLogStoredTime.SelectedItem.ToString();
        }

        private void cbxLoggedOutTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.LoggedOutTime = cbxLoggedOutTime.SelectedItem.ToString();
            // 重新应用权限计时器设置
            _autoLogoutManager.ApplySettings();

        }
    }
}
