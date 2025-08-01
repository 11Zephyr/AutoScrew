using AutoScrewSys.Base;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using SharedCore;
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
using Color = System.Drawing.Color;
using Settings = AutoScrewSys.Properties.Settings;

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
            //InitDgv();
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
                Task.Run(UpdateModbusAddress);
                Task.Run(async () =>
                {
                    await LoadTaskParameters();
                });
            }
        }
        private async void UpdateModbusAddress()
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

                ushort[] result =await ModbusRtuHelper.Instance.ReadRegistersAsync(
                           (byte)addr.SlaveAddress,
                           (ushort)addr.StartAddress,
                           (ushort)addr.Length
                       );
                if (dgvStepView.InvokeRequired)
                {
                    dgvStepView.Invoke(new Action(() =>
                    {
                        UpdateDgvStepView(result);
                    }));
                }
                else
                {
                    UpdateDgvStepView(result);
                }
                #region MyRegion
                //dgvStepView?.Rows?.Clear();

                //for (int i = 0; i < result.Length; i += 2)
                //{
                //    string stepName = $"Step{i / 2 + 1}";

                //    int value1 = result[i];
                //    int value2 = (i + 1 < result.Length) ? result[i + 1] : -1; // 防止越界

                //    dgvStepView.Rows.Add(
                //    stepName,
                //    currentState == WorkState.Tighten ? value1 : value2,
                //    currentState == WorkState.Tighten ? value2 : value1
                //                          );
                //}
                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"{ex.Message}", LogType.Fault);
            }

        }

        private void UpdateDgvStepView(ushort[] result)
        {
            dgvStepView?.Rows?.Clear();

            Color darkRowColor = Color.FromArgb(33, 33, 33);      // 奇数行颜色
            Color lightRowColor = Color.FromArgb(55, 55, 55);     // 偶数行颜色
            Color foreColor = Color.White;                        // 字体颜色（亮背景用黑，暗背景用白）

            for (int i = 0; i < result.Length; i += 2)
            {
                string stepName = $"Step{i / 2 + 1}";

                int value1 = result[i];
                int value2 = (i + 1 < result.Length) ? result[i + 1] : -1;

                int col1 = currentState == WorkState.Tighten ? value1 : value2;
                int col2 = currentState == WorkState.Tighten ? value2 : value1;

                int rowIndex = dgvStepView.Rows.Add(stepName, col1, col2);
                var row = dgvStepView.Rows[rowIndex];

                // 奇偶行交替背景色
                row.DefaultCellStyle.BackColor = (rowIndex % 2 == 0) ? darkRowColor : lightRowColor;
                row.DefaultCellStyle.ForeColor = foreColor;
            }
        }

        private void SaveSettings()
        {
            Settings.Default.CurrentState = currentState.ToString();
            Settings.Default.CurrentTask = (int)currentTask;
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

        private async void btnTightenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("TightenAction");
            await GlobalMonitor.ElectricBatchAction((byte)addr.SlaveAddress, (ushort)addr.StartAddress, AddrName.Default.TightenAction);
        }
        private async void btnLoosenMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("LoosenAction");
            await GlobalMonitor.ElectricBatchAction((byte)addr.SlaveAddress, (ushort)addr.StartAddress, AddrName.Default.LoosenAction);
        }

        private async void btnFreeMove_Click(object sender, EventArgs e)
        {
            var addr = ModbusAddressConfig.Instance.GetAddressItem("FreeAction");
            await GlobalMonitor.ElectricBatchAction((byte)addr.SlaveAddress, (ushort)addr.StartAddress, AddrName.Default.FreeAction);
        }

        public async Task LoadTaskParameters()
        {
            int taskIndex = (int)currentTask - 1;
            if (taskIndex < 0 || taskIndex >= AddressTable.GetLength(1))
            {
                LogHelper.WriteLog("任务号索引无效！", LogType.Fault);
                return;
            }

            var paramList = GetParamList();
            var displayList = new List<ParamDisplayModel>();

            for (int row = 0; row < paramList.Count; row++)
            {
                // 获取 Modbus 地址（你提供的）
                ushort address = AddressTable[row, taskIndex];

                // 从 Modbus 读取一个寄存器
                ushort[] values =await ModbusRtuHelper.Instance.ReadRegistersAsync(1, address, 1);
                int value = values != null && values.Length > 0 ? values[0] : -1;

                var paramInfo = paramList[row];
                displayList.Add(new ParamDisplayModel
                {
                    ParamName = paramInfo.Name,
                    Value = value,
                    Range = paramInfo.Range,
                    Unit = paramInfo.Unit,
                    Remark = paramInfo.Remark
                });
            }
            this.Invoke(new Action(() =>
            {
                dgvParam?.Rows.Clear();

                Color darkRowColor = Color.FromArgb(33, 33, 33);  // 深色行
                Color lightRowColor = Color.FromArgb(55, 55, 55); // 浅色行
                Color foreColor = Color.White;                    // 字体颜色

                for (int i = 0; i < displayList.Count; i++)
                {
                    var item = displayList[i];

                    int rowIndex = dgvParam.Rows.Add(item.ParamName, item.Value, item.Range, item.Unit, item.Remark);
                    var row = dgvParam.Rows[rowIndex];

                    // 设置交替颜色
                    row.DefaultCellStyle.BackColor = (rowIndex % 2 == 0) ? darkRowColor : lightRowColor;
                    row.DefaultCellStyle.ForeColor = foreColor;
                }
            }));

        }

        private List<ParamInfo> GetParamList()
        {
            return new List<ParamInfo>
            {
                new ParamInfo { Name = "拧紧旋转方向",            Range = "0-1",          Unit = "None",     Remark = "旋转方向:0正向/1反向" },
                new ParamInfo { Name = "目标扭力mN.M",            Range = "1-5000",       Unit = "mN.m",     Remark = "拧紧过程目标最大扭力,不可太小" },
                new ParamInfo { Name = "上限偏差mN.M",            Range = "0-1000",      Unit = "None",     Remark = "根据目标扭力判断偏差上限" },
                new ParamInfo { Name = "下限偏差mN.M",            Range = "0-1000",      Unit = "None",     Remark = "根据目标扭力判断偏差下限" },
                new ParamInfo { Name = "保持时间ms",              Range = "0-1000",      Unit = "ms",       Remark = "保持时间" },
                new ParamInfo { Name = "浮高滑牙检测开关",        Range = "0-1",        Unit = "None",     Remark = "浮高滑牙检测:0关闭/1开启" },
                new ParamInfo { Name = "浮高界定圈数（0.01圈）",  Range = "0-20",       Unit = "0.01 rev", Remark = "Above this = Float" },
                new ParamInfo { Name = "滑牙界定圈数（0.01圈）",  Range = "0-20",       Unit = "0.01 rev", Remark = "Below this = Slip" },
                new ParamInfo { Name = "触发速度切换的扭力比值",  Range = "0-1000",      Unit = "%",    Remark = "触发速度切换的扭力比值" },
                new ParamInfo { Name = "切换后速度(保留参数)",    Range = "0-1000",       Unit = "%",      Remark = "触发速度切换的速度比值。" },
                new ParamInfo { Name = "扭力补偿值mN.M",          Range = "0-100",       Unit = "mN.m",     Remark = "扭力补偿" },
                new ParamInfo { Name = "扭力免检圈数",            Range = "0-100",       Unit = "r",      Remark = "扭力免检圈数。" },
                new ParamInfo { Name = "免检圈数内扭力限定mN.M",  Range = "0-100",      Unit = "mN.m",     Remark = "免检圈数扭力" },
                new ParamInfo { Name = "拧松扭力",                Range = "0-1500",      Unit = "mN.m",     Remark = "拧松过程目标最大扭力,不可太小" },
                new ParamInfo { Name = "自由转速度",              Range = "1-5000",       Unit = "r",      Remark = "自由速度" },
                new ParamInfo { Name = "自由转扭力",              Range = "1-5000",      Unit = "mN.m",     Remark = "自由旋转扭力" },
                new ParamInfo { Name = "偏移角度",                Range = "0~3600",       Unit = "0.1°",    Remark = "In 0.1° units" }
            };
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

        private async void dgvParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (e.ColumnIndex == 1)
                {
                    DataGridView dgv = sender as DataGridView;
                    int taskIndex = (int)currentTask - 1;
                    if (taskIndex < 0 || taskIndex >= AddressTable.GetLength(1))
                    {
                        LogHelper.WriteLog("任务号索引无效！", LogType.Fault);
                        return;
                    }

                    int rowIndex = e.RowIndex;
                    ushort address = AddressTable[rowIndex, taskIndex];//后面要从文件中读取

                    ModbusCfgModel addr = new ModbusCfgModel
                    {
                        SlaveAddress = 1,
                        StartAddress = address,
                        Length = 1,
                    };
                    var cellText = dgvParam.CurrentRow.Cells[2].Value?.ToString(); // 第三列
                    double minVal = 0, maxVal = 0;
                    if (!string.IsNullOrEmpty(cellText) && cellText.Contains("-"))
                    {
                        var parts = cellText.Split('-');
                        if (parts.Length == 2 &&
                            double.TryParse(parts[0], out minVal) &&
                            double.TryParse(parts[1], out maxVal))
                        {
                            // 解析成功，传参
                            VirtualkeyboardFrm virtualkeyboardFrm = new VirtualkeyboardFrm(addr, minVal, maxVal);
                            virtualkeyboardFrm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("数值范围格式错误，无法解析！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("第三列内容为空或不包含'-'");
                    }
                 
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (await ModbusRtuHelper.Instance.ReadRegistersAsync((byte)addr.SlaveAddress, (ushort)addr.StartAddress, (ushort)addr.Length))[0].ToString();
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
                if (taskIndex < 0 || taskIndex > AddressTable.GetLength(1))
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
                addr.StartAddress = finalAddress;

                VirtualkeyboardFrm virtualkeyboardFrm = new VirtualkeyboardFrm(addr, 0, 10000);
                virtualkeyboardFrm.ShowDialog();
                UpdateModbusAddress();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, LogType.Error);
            }

        }

        private void TaskParametersUI_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await LoadTaskParameters();
            });
        }
    }
}
