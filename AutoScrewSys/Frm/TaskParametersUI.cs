using AutoScrewSys.Base;
using AutoScrewSys.Enums;
using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using AutoScrewSys.VariableName;
using DocumentFormat.OpenXml.Drawing.Charts;
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
using System.Text.RegularExpressions;
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

            btnTighten.ButtonColor = (currentState == WorkState.Tighten) ? Color.FromArgb(255, 128, 0) : Color.White;
            btnLoosen.ButtonColor = (currentState == WorkState.Loosen) ? Color.FromArgb(255, 128, 0) : Color.White;
        }
        private async void TaskLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse<TaskNumber>(TaskLists.SelectedItem.ToString(), out var task))
            {
                var addr = ModbusAddressConfig.Instance.GetAddressItem("TaskNumber");
                await ModbusRtuHelper.Instance.WriteSingleRegisterAsync(
                           (byte)addr.SlaveAddress,
                           (ushort)addr.StartAddress,
                           (ushort)task
                       );//写入任务号

                currentTask = task;
                SaveSettings();
                await Task.Run(UpdateModbusAddress);
                await Task.Run(async () =>
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

                var (success, values) = await ModbusRtuHelper.Instance.ReadRegistersAsync(
                           (byte)addr.SlaveAddress,
                           (ushort)addr.StartAddress,
                           (ushort)addr.Length
                       );
                if (dgvStepView.InvokeRequired)
                {
                    dgvStepView.Invoke(new Action(() =>
                    {
                        UpdateDgvStepView(values);
                    }));
                }
                else
                {
                    UpdateDgvStepView(values);
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

        private void UpdateDgvStepView(short[] result)
        {
            dgvStepView?.Rows?.Clear();

            Color darkRowColor = Color.FromArgb(33, 33, 33);      // 奇数行颜色
            Color lightRowColor = Color.FromArgb(55, 55, 55);     // 偶数行颜色
            Color foreColor = Color.White;                        // 字体颜色（亮背景用黑，暗背景用白）

            // 遍历 result 数组，每两个值作为一组处理
            for (int i = 0; i < result.Length; i += 2)
            {
                // 生成步骤名称，例如 Step1、Step2、Step3...
                string stepName = $"Step{i / 2 + 1}";

                // 提取当前这组的两个值
                int value1 = result[i];
                int value2 = (i + 1 < result.Length) ? result[i + 1] : -1; // 防止越界，如果缺一个补 -1

                // 根据当前状态决定哪一个是 col1、col2
                // 如果是“拧紧状态”，value1 是 col1，value2 是 col2
                // 如果不是“拧紧状态”，则反过来
                int col1 = currentState == WorkState.Tighten ? value1 : value2;
                int col2 = currentState == WorkState.Tighten ? value2 : value1;

                // 添加一行到 DataGridView，显示步骤名、col1（转成单位/100）、col2（原始值）
                int rowIndex = dgvStepView.Rows.Add(stepName, col1 / 100, col2);

                // 获取新添加的行
                var row = dgvStepView.Rows[rowIndex];

                // 设置行的背景色：奇偶行不同颜色（斑马纹效果）
                row.DefaultCellStyle.BackColor = (rowIndex % 2 == 0) ? darkRowColor : lightRowColor;

                // 设置行的前景色（字体颜色）
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
            HandleWorkStateChange(sender, WorkState.Tighten);
        }

        private void btnLoosen_Click(object sender, EventArgs e)
        {
            HandleWorkStateChange(sender, WorkState.Loosen);
        }

        private void HandleWorkStateChange(object sender, WorkState state)
        {
            currentState = state;
            SaveSettings();
            UpdateModbusAddress();

            // 设置按钮背景色
            var clickedBtn = sender as Button;

            btnTighten.ButtonColor = (currentState == WorkState.Tighten) ? Color.FromArgb(255, 128, 0) : Color.White;
            btnLoosen.ButtonColor = (currentState == WorkState.Loosen) ? Color.FromArgb(255, 128, 0) : Color.White;

        }

        private void btnFree_Click(object sender, EventArgs e)
        {
            currentState = WorkState.Free;
            SaveSettings();
            UpdateModbusAddress();
        }


        public async Task LoadTaskParameters()
        {
            int taskIndex = (int)currentTask - 1;
            if (taskIndex < 0 || taskIndex >= AddressTable.GetLength(1))
            {
                LogHelper.WriteLog("任务号索引无效！", LogType.Fault);
                return;
            }
            var paramList = GetParamList(AddrName.Default.ElecBatchPower);
            var displayList = new List<ParamDisplayModel>();

            for (int row = 0; row < paramList.Count; row++)
            {
                ushort address = AddressTable[row, taskIndex];

                var (success, values) = await ModbusRtuHelper.Instance.ReadRegistersAsync(1, address, 1);
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
            this.BeginInvoke(new Action(() =>
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
        private static readonly Dictionary<int, PowerRangeModel> PowerMap = new Dictionary<int, PowerRangeModel>
        {
            //功率                       //扭力范围                //速度
            { 30,  new PowerRangeModel { TorqueRange = "0.2-3",    SpeedRange = "10-3000" } },
            { 50,  new PowerRangeModel { TorqueRange = "0.6-4.5",  SpeedRange = "10-3000" } },
            { 100, new PowerRangeModel { TorqueRange = "1-9",      SpeedRange = "30-3000" } },
            { 200, new PowerRangeModel { TorqueRange = "3-18",     SpeedRange = "30-3000" } },
            { 400, new PowerRangeModel { TorqueRange = "10-36",    SpeedRange = "30-2000" } },
            { 600, new PowerRangeModel { TorqueRange = "15-55",    SpeedRange = "30-2000" } }
        };
        private PowerRangeModel GetPowerRange(int power)
        {
            return PowerMap.ContainsKey(power) ? PowerMap[power] : new PowerRangeModel { TorqueRange = "1-5000", SpeedRange = "1-5000" }; // 默认值
        }

        private List<ParamInfo> GetParamList(int power)
        {
            var range = GetPowerRange(power);

            return new List<ParamInfo>
            {
                new ParamInfo { Name = "拧紧旋转方向",              Range = "0-1",                 Unit = "None",   Remark = "旋转方向:0正向/1反向" },
                new ParamInfo { Name = "目标扭力mN.M",              Range = range.TorqueRange,     Unit = "mN.m",   Remark = "拧紧过程目标最大扭力,不可太小" },
                new ParamInfo { Name = "上限偏差mN.M",              Range = "0-100",               Unit = "None",   Remark = "根据目标扭力判断偏差上限" },
                new ParamInfo { Name = "下限偏差mN.M",              Range = "0-100",               Unit = "None",   Remark = "根据目标扭力判断偏差下限" },
                new ParamInfo { Name = "保持时间ms",                Range = "0-100",               Unit = "ms",     Remark = "保持时间" },
                new ParamInfo { Name = "浮高滑牙检测开关",          Range = "0-1",                 Unit = "None",   Remark = "浮高滑牙检测:0关闭/1开启" },
                new ParamInfo { Name = "浮高界定圈数（r）",         Range = "0-20",                Unit = "r",      Remark = "Above this = Float" },
                new ParamInfo { Name = "滑牙界定圈数（r）",         Range = "0-20",                Unit = "r",      Remark = "Below this = Slip" },
                new ParamInfo { Name = "触发速度切换的扭力比值",    Range = "0-100",               Unit = "%",      Remark = "触发速度切换的扭力比值" },
                new ParamInfo { Name = "切换后速度(保留参数)",      Range = "0-1000",              Unit = "%",      Remark = "触发速度切换的速度比值。" },
                new ParamInfo { Name = "扭力补偿值mN.M",            Range = "-100-100",            Unit = "mN.m",   Remark = "扭力补偿" },
                new ParamInfo { Name = "扭力免检圈数",              Range = "0-100",               Unit = "r",      Remark = "扭力免检圈数。" },
                new ParamInfo { Name = "免检圈数内扭力限定mN.M",    Range = range.TorqueRange,     Unit = "mN.m",   Remark = "免检圈数扭力" },
                new ParamInfo { Name = "拧松扭力",                  Range = range.TorqueRange,     Unit = "mN.m",   Remark = "拧松过程目标最大扭力,不可太小" },
                new ParamInfo { Name = "自由转速度",                Range = range.SpeedRange,      Unit = "r",      Remark = "自由速度" },
                new ParamInfo { Name = "自由转扭力",                Range = range.TorqueRange,     Unit = "mN.m",   Remark = "自由旋转扭力" },
                new ParamInfo { Name = "偏移角度",                  Range = "0~3600",              Unit = "0.1°",   Remark = "In 0.1° units" }
            };
        }

        /// <summary>
        /// 地址表
        /// </summary>
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

                GlobalMonitor.CheckLogin(4);
                if (Settings.Default.Login < 4) return;

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

                    if (!string.IsNullOrEmpty(cellText))
                    {
                        // 匹配形如 "-123.45 - 678.9"、"0-100"、"-50-50" 等
                        var match = Regex.Match(cellText, @"^\s*(-?\d+(\.\d+)?)\s*-\s*(-?\d+(\.\d+)?)\s*$");
                        if (match.Success)
                        {
                            minVal = double.Parse(match.Groups[1].Value);
                            maxVal = double.Parse(match.Groups[3].Value);

                            // 打开虚拟键盘窗体
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
                        MessageBox.Show("第三列内容为空");
                    }
                    var (success, values) = await ModbusRtuHelper.Instance.ReadRegistersAsync((byte)addr.SlaveAddress, (ushort)addr.StartAddress, (ushort)addr.Length);

                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = values[0].ToString();
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
                GlobalMonitor.CheckLogin(4);
                if (Settings.Default.Login < 4) return;

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
                if (columnIndex == 1) addr.Proportion = 0.01f;

                // 第三列（速度范围）
                if (e.ColumnIndex == 2)
                {
                    var rangeStr = GetPowerRange(AddrName.Default.ElecBatchPower).SpeedRange;
                    var (min, max) = ParseRange(rangeStr); // 提取扭力范围
                    var vkForm = new VirtualkeyboardFrm(addr, min, max);
                    vkForm.ShowDialog();
                }
                // 第二列（固定圈数）
                else if (e.ColumnIndex == 1)
                {
                    var vkForm = new VirtualkeyboardFrm(addr, 0, 5000); // 圈数范围固定
                    vkForm.ShowDialog();
                }

                UpdateModbusAddress();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, LogType.Error);
            }
        }
        private (double min, double max) ParseRange(string rangeStr)
        {
            if (string.IsNullOrWhiteSpace(rangeStr) || !rangeStr.Contains("-"))
                return (0, 0); // 或者抛出异常

            var parts = rangeStr.Split('-');

            if (parts.Length != 2 ||
                !double.TryParse(parts[0], out double min) ||
                !double.TryParse(parts[1], out double max))
            {
                return (0, 0); // 或者抛出异常
            }

            return (min, max);
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
