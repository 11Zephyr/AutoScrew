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
        }
        private void InitBtn()
        {
            btnTightenMove.Tag = false;  // 初始为 false，点击后写入 1
            //btnLoosen.Tag = false;
            //btnFree.Tag = false;
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

                var mdsInfo = ModbusAddressConfig.Instance.GetAddressItem(param1, param2);
                if (mdsInfo == null) return;
                LogHelper.WriteLog($"{mdsInfo.Description}", LogType.Run);

                ushort[] result = RTU.GetInstance().ReadRegisters(
                           (byte)mdsInfo.SlaveAddress,
                           (ushort)mdsInfo.StartAddress,
                           (ushort)mdsInfo.Length
                       );

                dgvStepView.Rows.Clear(); // 先清除旧行（可选）

                for (int i = 0; i < result.Length; i += 2)
                {
                    string stepName = $"Step{i / 2 + 1}";

                    int value1 = result[i];
                    int value2 = (i + 1 < result.Length) ? result[i + 1] : -1; // 防止越界

                    dgvStepView.Rows.Add(
                    stepName,
                    currentState== WorkState.Tighten ? value1 : value2,
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
            //UpdateModbusAddress();
        }

        private void btnTightenMove_Click(object sender, EventArgs e)
        {
            WriteToggle(btnTightenMove,3);
        }
        // 写入函数（简洁封装）
        private void WriteToggle(Button btn, ushort address)
        {
            try
            {
                bool state = btn.Tag is bool b && b;
                ushort valueToWrite = state ? (ushort)0 : (ushort)1;

                bool success = RTU.GetInstance().WriteSingleRegister(
                     1,
                     address,
                     valueToWrite
                 );
                if (success)
                {
                    LogHelper.WriteLog($"{btn.Text} 写入成功：{valueToWrite}", LogType.Run);
                    btn.Tag = !state;  // 翻转状态
                }
                else
                {
                    LogHelper.WriteLog($"{btn.Text} 写入失败", LogType.Run);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"{ex.Message}", LogType.Error);
            }

        }
    }
}
