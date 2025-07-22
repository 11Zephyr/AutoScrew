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
                     MessageBox.Show("串口连接成功");
                 },
                 // 串口打开失败时回调，错误消息提醒，并退出程序
                 (msg) =>
                 {
                     MessageBox.Show(msg, "异常提示");
                 });
        }

        private void cbxPort_DropDown(object sender, EventArgs e)
        {
            cbxPort.DataSource = SerialPort.GetPortNames();
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
        private void LoadComboBoxSetting(ComboBox comboBox)
        {
            string settingName = comboBox.Name;
            string savedValue = Properties.Settings.Default[settingName]?.ToString();

            if (!string.IsNullOrEmpty(savedValue) && comboBox.Items.Contains(savedValue))
            {
                comboBox.SelectedItem = savedValue;
            }
        }

        private void SettingsControl_Load(object sender, EventArgs e)
        {
            LoadComboBoxSetting(cbxPort);
            LoadComboBoxSetting(cbxBaudRate);
            LoadComboBoxSetting(cbxParity);
            LoadComboBoxSetting(cbxDataBits);
            LoadComboBoxSetting(cbxStopBits);
        }

        private void ParameterSettingUI_Load(object sender, EventArgs e)
        {
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
    }
}
