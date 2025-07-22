using AutoScrewSys.Base;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Properties;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Frm
{
    public partial class TaskParametersUI : UserControl
    {
        private WorkState currentState;
        private TaskNumber currentTask;
        public TaskParametersUI()
        {
            InitializeComponent();
            LoadSettings();
            InitTaskList();
            InitBtn();
            InitDgv();
        }
        private void InitBtn()
        {
            btnTightenMove.Tag = false;  // 初始为 false，点击后写入 1
            btnLoosenMove.Tag = false;
            btnFreeMove.Tag = false;
        }
        private void InitTaskList()
        {
            TaskLists.Items.AddRange(Enum.GetNames(typeof(TaskNumber)));
            TaskLists.SelectedIndex = (int)currentTask - 1;
        }
        private void LoadSettings()
        {
            if (!Enum.TryParse(Settings.Default.CurrentState, out currentState))
                currentState = WorkState.Tighten;

            if (!Enum.IsDefined(typeof(TaskNumber), Settings.Default.CurrentTask))
                currentTask = TaskNumber.Task1;
            else
                currentTask = (TaskNumber)Settings.Default.CurrentTask;
        }
        private void TaskLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse<TaskNumber>(TaskLists.SelectedItem.ToString(), out var task))
            {
                currentTask = task;
                SaveSettings();
                UpdateModbusAddress();
            }
        }
        private void UpdateModbusAddress()
        {
            try
            {
                if (!GlobalMonitor.isInit) return;

                string param1 = string.Empty;
                switch (currentState)
                {
                    case WorkState.Tighten:
                        param1 = "Tighten";
                        break;
                    case WorkState.Loosen:
                        param1 = "Loosen";
                        break;
                    case WorkState.Free:
                        param1 = "Free";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                string param2 = currentTask.ToString();

                var addr = ModbusAddressConfig.Instance.GetAddressItem(param1, param2);
                if (addr == null) return;
                //LogHelper.WriteLog($"{addr.Description}", LogType.Run);

                ushort[] result = ModbusRtuHelper.Instance.ReadRegisters(
                           (byte)addr.SlaveAddress,
                           (ushort)addr.StartAddress,
                           (ushort)addr.Length
                       );

                dgvStepView?.Rows?.Clear();

                for (int i = 0; i < result.Length; i += 2)
                {
                    string stepName = $"Step{i / 2 + 1}";

                    int value1 = result[i];
                    int value2 = (i + 1 < result.Length) ? result[i + 1] : -1; // 防止越界

                    dgvStepView.Rows.Add(
                    stepName,
                    currentState == WorkState.Tighten ? value1 / 100 : value2 / 100,
                    currentState == WorkState.Tighten ? value2 : value1
                                          );
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"{ex.Message}", LogType.Fault);
            }

        }
        private void SaveSettings()
        {
            Settings.Default.CurrentState = currentState.ToString();
            Settings.Default.CurrentTask = (int)currentTask;
            Settings.Default.CurrTaskStr = ((int)currentTask).ToString();
            Settings.Default.Save();
        }

        private void btnTighten_Click(object sender, EventArgs e)
        {
            currentState = WorkState.Tighten;
            SaveSettings();
            UpdateModbusAddress();
        }

        private void btnLoosen_Click(object sender, EventArgs e)
        {
            currentState = WorkState.Loosen;
            SaveSettings();
            UpdateModbusAddress();
        }

        private void btnFree_Click(object sender, EventArgs e)
        {
            currentState = WorkState.Free;
            SaveSettings();
            UpdateModbusAddress();
        }

        private void btnTightenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("Tighten", "TightenAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }
        private void btnLoosenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("Loosen", "LoosenAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private void btnFreeMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("Free", "FreeAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private void btnReadParam_Click(object sender, EventArgs e)
        {

        }
        private void InitDgv()
        {
            // 中文参数名列表
            string[] paramNames = new string[]
            {
                "拧紧旋转方向",           // 0
                "目标扭力mN.M",           // 1
                "上限偏差mN.M",           // 2
                "下限偏差mN.M",           // 3
                "保持时间ms",             // 4
                "浮高滑牙检测开关",       // 5
                "浮高界定圈数（0.01圈）", // 6
                "滑牙界定圈数（0.01圈）", // 7
                "触发速度切换的扭力比值", // 8
                "切换后速度(保留参数)",   // 9
                "扭力补偿值mN.M",         // 10
                "扭力免检圈数",           // 11
                "免检圈数内扭力限定mN.M", // 12
                "拧松扭力",               // 13
                "偏移角度"                // 14
             };

            dgvParam?.Rows?.Clear();
            foreach (string name in paramNames)
            {
                dgvParam.Rows.Add(name); // 第一列写名称，第二列初始为空
            }
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            string[] paramKeys = new string[]
            {
                  "TightenDirection",              // 拧紧旋转方向
                  "TargetTorque",              // 目标扭力mN.M
                  "TorqueUpperDeviation",      // 上限偏差mN.M
                  "TorqueLowerDeviation",      // 下限偏差mN.M
                  "HoldTime",                   // 保持时间ms
                  "FloatThreadCheckEnable",        // 浮高滑牙检测开关
                  "FloatLimitTurns",           // 浮高界定圈数（0.01圈）
                  "ThreadSlipLimitTurns",      // 滑牙界定圈数（0.01圈）
                  "TorqueSwitchRatio",             // 触发速度切换的扭力比值
                  "SpeedAfterSwitch",              // 切换后速度(保留参数)
                  "TorqueOffset",              // 扭力补偿值mN.M
                  "NoCheckTurns",                  // 扭力免检圈数
                  "LimitTorqueInNoCheck",      // 免检圈数内扭力限定mN.M
                  "LoosenTorque",                  // 拧松扭力
                  "OffsetAngle"                    // 偏移角度
            };

            foreach (string name in paramKeys)
            {
                var addr = ModbusAddressConfig.Instance.GetAddressItem($"{name}{(int)currentTask}");
                if ( addr == null )continue;

            }
                
        }
    }
}
