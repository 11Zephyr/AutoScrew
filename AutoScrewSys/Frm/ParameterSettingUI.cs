using AutoScrewSys.Base;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Frm
{
    public partial class ParameterSettingUI : UserControl
    {
        public ParameterSettingUI()
        {
            InitializeComponent();
            //this.Load += SettingsControl_Load;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
          
            ///启动全局监控
            GlobalMonitor.Start(
                 // 串口打开成功时回调，打开主窗口
                 () =>
                 {
                     LogHelper.WriteLog("串口连接成功...", LogType.Run);
                     //MessageBox.Show("串口连接成功");
                 },
                 // 串口打开失败时回调，错误消息提醒，并退出程序
                 (msg) =>
                 {
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
            LoadSerialPortSettings();
            ////启动全局监控
            //GlobalMonitor.Start(
            //     () =>
            //     {
            //         LogHelper.WriteLog("串口连接成功!", LogType.Run);
            //     },
            //     (msg) =>
            //     {
            //         LogHelper.WriteLog("串口连接失败...", LogType.Run);
            //     });
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
           // Settings.Default.DataStoredTime = cbxDataStoredTime.SelectedItem.ToString();
        }

        private void cbxTorqueUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Settings.Default.TorqueUnit = cbxTorqueUnit.SelectedItem.ToString();
        }

        private void cbxLogStoredTime_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Settings.Default.LogStoredTime = cbxLogStoredTime.SelectedItem.ToString();
        }

        private void cbxLoggedOutTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Settings.Default.LoggedOutTime = cbxLoggedOutTime.SelectedItem.ToString();
        }
    }
}
