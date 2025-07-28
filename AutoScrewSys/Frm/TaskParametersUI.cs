using AutoScrewSys.Base;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
            var addr = ModbusAddressConfig.Instance.GetAddressItem("TightenAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }
        private void btnLoosenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem( "LoosenAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private void btnFreeMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("FreeAction");
            GlobalMonitor.ElectricBatchAction(sender, (byte)addr.SlaveAddress, (ushort)addr.StartAddress);
        }

        private void btnReadParam_Click(object sender, EventArgs e)
        {
            //Settings.Default.RunStateStr = ScrewStatus.NG.ToString();
            LoadTaskParameters();
        }
        public void LoadTaskParameters()
        {
            int taskIndex = (int)currentTask - 1;
            if (taskIndex < 0 || taskIndex >= AddressTable.GetLength(1))
            {
                LogHelper.WriteLog("任务号索引无效！", LogType.Fault);
                return;
            }

            // 遍历 DataGridView 的每一行
            for (int row = 0; row < dgvParam.Rows.Count; row++)
            {
                try
                {
                    ushort address = AddressTable[row, taskIndex];//后面要从文件中读取
                    ushort[] values = ModbusRtuHelper.Instance.ReadRegisters(1, address, 1);

                    dgvParam.Rows[row].Cells[1].Value = values[0];
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog($"读取第 {row + 1} 行参数失败: {ex.Message}", LogType.Error);
                    dgvParam.Rows[row].Cells[1].Value = "错误";
                    dgvParam.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
            }
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
                "自由转速度",              // 14
                "自由转扭力",             // 15
                "偏移角度"              // 16
             };

            dgvParam?.Rows?.Clear();
            foreach (string name in paramNames)
            {
                dgvParam.Rows.Add(name); // 第一列写名称，第二列初始为空
            }

        }
        private static readonly ushort[,] AddressTable = new ushort[,]
        {
            { 5888, 5952, 6016, 6080, 6144, 6208, 6272, 6336 }, // 拧紧旋转方向
            { 5889, 5953, 6017, 6081, 6145, 6209, 6273, 6337 }, // 目标扭力mN.M
            { 5925, 5989, 6053, 6117, 6181, 6245, 6309, 6373 }, // 上限偏差mN.M
            { 5926, 5990, 6054, 6118, 6182, 6246, 6310, 6374 }, // 下限偏差mN.M
            { 5893, 5957, 6021, 6085, 6149, 6213, 6277, 6341 }, // 保持时间ms
            { 5921, 5985, 6049, 6113, 6177, 6241, 6305, 6369 }, // 浮高滑牙检测开关
            { 5894, 5958, 6022, 6086, 6150, 6214, 6278, 6342 }, // 浮高界定圈数（0.01圈）
            { 5895, 5959, 6023, 6087, 6151, 6215, 6279, 6343 }, // 滑牙界定圈数（0.01圈）
            { 5898, 5962, 6026, 6090, 6154, 6218, 6282, 6346 }, // 触发速度切换的扭力比值
            { 5899, 5963, 6027, 6091, 6155, 6219, 6283, 6347 }, // 切换后速度(保留参数)
            { 5917, 5981, 6045, 6109, 6173, 6237, 6301, 6365 }, // 扭力补偿值mN.M
            { 5918, 5982, 6046, 6110, 6174, 6238, 6302, 6366 }, // 扭力免检圈数
            { 5919, 5983, 6047, 6111, 6175, 6239, 6303, 6367 }, // 免检圈数内扭力限定mN.M
            { 5920, 5984, 6048, 6112, 6176, 6240, 6304, 6368 }, // 4 拧松扭力mN.M
            { 5916, 5980, 6044, 6108, 6172, 6236, 6300, 6364 }, // 19 自由转速度
            { 5922, 5986, 6050, 6114, 6178, 6242, 6306, 6370 }, // 20 自由转扭力mN.M
            { 5927, 5991, 6055, 6119, 6183, 6247, 6311, 6375 }, // 21 偏移角度
        };

        private void dgvParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (e.ColumnIndex == 1)
                {
                    int taskIndex = (int)currentTask - 1;
                    if (taskIndex < 0 || taskIndex >= AddressTable.GetLength(1))
                    {
                        LogHelper.WriteLog("任务号索引无效！", LogType.Fault);
                        return;
                    }

                    int rowIndex = e.RowIndex;
                    ushort address = AddressTable[rowIndex, taskIndex];//后面要从文件中读取
                    ModbusRtuHelper.Instance.WriteSingleRegister(1, address, 999);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, LogType.Error);
                
            }
          
        }

        private void dgvStepView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex <= 0)
                    return;
                int taskIndex = (int)currentTask;
                if (taskIndex < 0 || taskIndex >= AddressTable.GetLength(1))
                {
                    LogHelper.WriteLog("任务号索引无效！", LogType.Fault);
                    return;
                }

                int columnIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
                string section = string.Empty;
                // 计算偏移量
                int offset = 0;

                if (currentState == WorkState.Tighten)
                {
                    section = "Tighten";
                    offset = columnIndex == 1 ? rowIndex * 2 : rowIndex * 2 + 1;
                }
                else if (currentState == WorkState.Loosen)
                {
                    section = "Loosen";
                    offset = columnIndex == 1 ? rowIndex * 2 + 1 : rowIndex * 2;
                }

                var addr = ModbusAddressConfig.Instance.GetAddressItem(section, $"Task{taskIndex}");
                if (addr == null) return;
                ushort finalAddress = (ushort)(addr.StartAddress + offset);
                ModbusRtuHelper.Instance.WriteSingleRegister((byte)addr.SlaveAddress, finalAddress, 666);

                UpdateModbusAddress();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, LogType.Error);
            }
         
        }
    }
}
