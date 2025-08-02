namespace AutoScrewSys.Frm
{
    partial class HistoryDataUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHisData = new ZimaBlueUI.ZRoundButton();
            this.btnHisLog = new ZimaBlueUI.ZRoundButton();
            this.hisFrmTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartWaveData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PositionView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshListBox = new MaterialSkin.Controls.MaterialButtonpro();
            this.lblScrews = new System.Windows.Forms.Label();
            this.tbxSnSearchBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCircle = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTorque = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxResult = new System.Windows.Forms.ComboBox();
            this.btnSearch = new MaterialSkin.Controls.MaterialButtonpro();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.listHisData = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstLogContent = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLogType = new MaterialSkin.Controls.MaterialComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFileList = new MaterialSkin.Controls.MaterialComboBox();
            this.btnClearLog = new MaterialSkin.Controls.MaterialButtonpro();
            this.flowLayoutPanel1.SuspendLayout();
            this.hisFrmTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWaveData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionView)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnHisData);
            this.flowLayoutPanel1.Controls.Add(this.btnHisLog);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(52, 753);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnHisData
            // 
            this.btnHisData.BackColor = System.Drawing.Color.DimGray;
            this.btnHisData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHisData.EXBorderRadius = 5F;
            this.btnHisData.EXButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisData.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.btnHisData.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHisData.Isbackcplor = false;
            this.btnHisData.Location = new System.Drawing.Point(3, 3);
            this.btnHisData.Name = "btnHisData";
            this.btnHisData.ReverseButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisData.Size = new System.Drawing.Size(47, 378);
            this.btnHisData.TabIndex = 5;
            this.btnHisData.Text = "历\n史\n数\n据";
            this.btnHisData.Click += new System.EventHandler(this.btnHisData_Click);
            // 
            // btnHisLog
            // 
            this.btnHisLog.BackColor = System.Drawing.Color.DimGray;
            this.btnHisLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHisLog.EXBorderRadius = 5F;
            this.btnHisLog.EXButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisLog.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.btnHisLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHisLog.Isbackcplor = false;
            this.btnHisLog.Location = new System.Drawing.Point(3, 387);
            this.btnHisLog.Name = "btnHisLog";
            this.btnHisLog.ReverseButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisLog.Size = new System.Drawing.Size(47, 362);
            this.btnHisLog.TabIndex = 7;
            this.btnHisLog.Text = "历\n史\n日\n志";
            this.btnHisLog.Click += new System.EventHandler(this.btnHisLog_Click);
            // 
            // hisFrmTabControl
            // 
            this.hisFrmTabControl.Controls.Add(this.tabPage1);
            this.hisFrmTabControl.Controls.Add(this.tabPage2);
            this.hisFrmTabControl.Depth = 0;
            this.hisFrmTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hisFrmTabControl.Location = new System.Drawing.Point(52, 0);
            this.hisFrmTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.hisFrmTabControl.Multiline = true;
            this.hisFrmTabControl.Name = "hisFrmTabControl";
            this.hisFrmTabControl.SelectedIndex = 0;
            this.hisFrmTabControl.Size = new System.Drawing.Size(1326, 753);
            this.hisFrmTabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.flowLayoutPanel3);
            this.tabPage1.Controls.Add(this.flowLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1318, 727);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartWaveData);
            this.panel1.Controls.Add(this.PositionView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(152, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 669);
            this.panel1.TabIndex = 9;
            // 
            // chartWaveData
            // 
            this.chartWaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.chartWaveData.BorderlineColor = System.Drawing.Color.Black;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea4.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Aquamarine;
            chartArea4.AxisX.LineColor = System.Drawing.Color.Red;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorTickMark.LineColor = System.Drawing.Color.GreenYellow;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.Title = "Num";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("思源黑体 CN Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            chartArea4.AxisX.TitleForeColor = System.Drawing.SystemColors.Window;
            chartArea4.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea4.AxisY.LabelAutoFitMinFontSize = 8;
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea4.AxisY.LineColor = System.Drawing.Color.Red;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Orange;
            chartArea4.AxisY.MaximumAutoSize = 100F;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.AxisY.Title = "Torque";
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.TitleForeColor = System.Drawing.SystemColors.Window;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 90F;
            chartArea4.Position.Width = 100F;
            chartArea4.Position.Y = 10F;
            this.chartWaveData.ChartAreas.Add(chartArea4);
            this.chartWaveData.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend4.BackColor = System.Drawing.Color.Transparent;
            legend4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            legend4.ForeColor = System.Drawing.Color.White;
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            legend4.ShadowColor = System.Drawing.Color.Black;
            this.chartWaveData.Legends.Add(legend4);
            this.chartWaveData.Location = new System.Drawing.Point(0, 351);
            this.chartWaveData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartWaveData.Name = "chartWaveData";
            this.chartWaveData.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series4.BackImageTransparentColor = System.Drawing.Color.WhiteSmoke;
            series4.BackSecondaryColor = System.Drawing.Color.Black;
            series4.BorderColor = System.Drawing.Color.Transparent;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series4.Color = System.Drawing.Color.Lime;
            series4.Legend = "Legend1";
            series4.LegendText = "Kgf";
            series4.Name = "Series1";
            series4.ShadowColor = System.Drawing.Color.Black;
            this.chartWaveData.Series.Add(series4);
            this.chartWaveData.Size = new System.Drawing.Size(1163, 318);
            this.chartWaveData.TabIndex = 68;
            this.chartWaveData.Text = "chart1";
            // 
            // PositionView
            // 
            this.PositionView.AllowUserToAddRows = false;
            this.PositionView.AllowUserToDeleteRows = false;
            this.PositionView.AllowUserToResizeColumns = false;
            this.PositionView.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            this.PositionView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.PositionView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PositionView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PositionView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PositionView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.PositionView.ColumnHeadersHeight = 32;
            this.PositionView.Dock = System.Windows.Forms.DockStyle.Top;
            this.PositionView.EnableHeadersVisualStyles = false;
            this.PositionView.GridColor = System.Drawing.Color.Black;
            this.PositionView.Location = new System.Drawing.Point(0, 0);
            this.PositionView.MultiSelect = false;
            this.PositionView.Name = "PositionView";
            this.PositionView.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PositionView.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.PositionView.RowHeadersVisible = false;
            this.PositionView.RowHeadersWidth = 20;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PositionView.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.PositionView.RowTemplate.Height = 30;
            this.PositionView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PositionView.ShowCellErrors = false;
            this.PositionView.ShowCellToolTips = false;
            this.PositionView.ShowEditingIcon = false;
            this.PositionView.ShowRowErrors = false;
            this.PositionView.Size = new System.Drawing.Size(1163, 340);
            this.PositionView.TabIndex = 67;
            this.PositionView.TabStop = false;
            this.PositionView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PositionView_CellClick);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnRefreshListBox);
            this.flowLayoutPanel3.Controls.Add(this.lblScrews);
            this.flowLayoutPanel3.Controls.Add(this.tbxSnSearchBox);
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.textBoxCircle);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.textBoxTorque);
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.comboBoxResult);
            this.flowLayoutPanel3.Controls.Add(this.btnSearch);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.flowLayoutPanel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(152, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1163, 52);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // btnRefreshListBox
            // 
            this.btnRefreshListBox.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnRefreshListBox.ButtonColor = System.Drawing.Color.White;
            this.btnRefreshListBox.Buttonmodel = 0;
            this.btnRefreshListBox.ClickColor = System.Drawing.Color.White;
            this.btnRefreshListBox.Constant = 0;
            this.btnRefreshListBox.Depth = 0;
            this.btnRefreshListBox.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshListBox.MaxV = 0;
            this.btnRefreshListBox.MinV = 0;
            this.btnRefreshListBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshListBox.Name = "btnRefreshListBox";
            this.btnRefreshListBox.Size = new System.Drawing.Size(105, 37);
            this.btnRefreshListBox.TabIndex = 202;
            this.btnRefreshListBox.Text = "刷新列表";
            this.btnRefreshListBox.UseVisualStyleBackColor = true;
            this.btnRefreshListBox.Click += new System.EventHandler(this.btnRefreshListBox_Click);
            // 
            // lblScrews
            // 
            this.lblScrews.BackColor = System.Drawing.Color.Transparent;
            this.lblScrews.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScrews.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblScrews.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblScrews.Location = new System.Drawing.Point(114, 0);
            this.lblScrews.Name = "lblScrews";
            this.lblScrews.Size = new System.Drawing.Size(79, 40);
            this.lblScrews.TabIndex = 209;
            this.lblScrews.Text = "SN 码:";
            this.lblScrews.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxSnSearchBox
            // 
            this.tbxSnSearchBox.Location = new System.Drawing.Point(199, 3);
            this.tbxSnSearchBox.Name = "tbxSnSearchBox";
            this.tbxSnSearchBox.Size = new System.Drawing.Size(266, 37);
            this.tbxSnSearchBox.TabIndex = 210;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(471, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 40);
            this.label4.TabIndex = 212;
            this.label4.Text = "圈数:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCircle
            // 
            this.textBoxCircle.Location = new System.Drawing.Point(556, 3);
            this.textBoxCircle.Name = "textBoxCircle";
            this.textBoxCircle.Size = new System.Drawing.Size(68, 37);
            this.textBoxCircle.TabIndex = 213;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(630, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 40);
            this.label5.TabIndex = 214;
            this.label5.Text = "扭力:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTorque
            // 
            this.textBoxTorque.Location = new System.Drawing.Point(715, 3);
            this.textBoxTorque.Name = "textBoxTorque";
            this.textBoxTorque.Size = new System.Drawing.Size(68, 37);
            this.textBoxTorque.TabIndex = 215;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(789, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 40);
            this.label6.TabIndex = 221;
            this.label6.Text = "结果:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxResult
            // 
            this.comboBoxResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResult.FormattingEnabled = true;
            this.comboBoxResult.Items.AddRange(new object[] {
            "无",
            "OK",
            "NG",
            "未完成"});
            this.comboBoxResult.Location = new System.Drawing.Point(874, 3);
            this.comboBoxResult.Name = "comboBoxResult";
            this.comboBoxResult.Size = new System.Drawing.Size(121, 37);
            this.comboBoxResult.TabIndex = 222;
            // 
            // btnSearch
            // 
            this.btnSearch.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSearch.ButtonColor = System.Drawing.Color.White;
            this.btnSearch.Buttonmodel = 0;
            this.btnSearch.ClickColor = System.Drawing.Color.White;
            this.btnSearch.Constant = 0;
            this.btnSearch.Depth = 0;
            this.btnSearch.Location = new System.Drawing.Point(1001, 3);
            this.btnSearch.MaxV = 0;
            this.btnSearch.MinV = 0;
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 37);
            this.btnSearch.TabIndex = 223;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.listHisData);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(149, 721);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 58);
            this.label9.TabIndex = 199;
            this.label9.Text = "数据列表";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listHisData
            // 
            this.listHisData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.listHisData.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listHisData.ForeColor = System.Drawing.SystemColors.Window;
            this.listHisData.FormattingEnabled = true;
            this.listHisData.ItemHeight = 29;
            this.listHisData.Location = new System.Drawing.Point(3, 61);
            this.listHisData.Name = "listHisData";
            this.listHisData.Size = new System.Drawing.Size(140, 642);
            this.listHisData.TabIndex = 3;
            this.listHisData.SelectedIndexChanged += new System.EventHandler(this.listHisData_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage2.Controls.Add(this.lstLogContent);
            this.tabPage2.Controls.Add(this.flowLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1318, 727);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // lstLogContent
            // 
            this.lstLogContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lstLogContent.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstLogContent.ForeColor = System.Drawing.SystemColors.Window;
            this.lstLogContent.FormattingEnabled = true;
            this.lstLogContent.ItemHeight = 29;
            this.lstLogContent.Location = new System.Drawing.Point(45, 100);
            this.lstLogContent.Name = "lstLogContent";
            this.lstLogContent.Size = new System.Drawing.Size(1245, 584);
            this.lstLogContent.TabIndex = 10;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label1);
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.cmbLogType);
            this.flowLayoutPanel4.Controls.Add(this.label3);
            this.flowLayoutPanel4.Controls.Add(this.cmbFileList);
            this.flowLayoutPanel4.Controls.Add(this.btnClearLog);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.flowLayoutPanel4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1312, 58);
            this.flowLayoutPanel4.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label1.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 58);
            this.label1.TabIndex = 205;
            this.label1.Text = "日志\n操作";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label2.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(120, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 58);
            this.label2.TabIndex = 206;
            this.label2.Text = "信息类型:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbLogType
            // 
            this.cmbLogType.AutoResize = false;
            this.cmbLogType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbLogType.Borderwidht = 7;
            this.cmbLogType.ComboxColor = System.Drawing.Color.White;
            this.cmbLogType.Commodel = 0;
            this.cmbLogType.Depth = 0;
            this.cmbLogType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbLogType.DropDownHeight = 217;
            this.cmbLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogType.DropDownWidth = 121;
            this.cmbLogType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLogType.FormattingEnabled = true;
            this.cmbLogType.IntegralHeight = false;
            this.cmbLogType.ItemHeight = 43;
            this.cmbLogType.Items.AddRange(new object[] {
            "运行日志",
            "故障日志",
            "报错日志"});
            this.cmbLogType.Location = new System.Drawing.Point(237, 3);
            this.cmbLogType.MaxDropDownItems = 5;
            this.cmbLogType.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbLogType.Name = "cmbLogType";
            this.cmbLogType.ShowScrollbar = false;
            this.cmbLogType.Size = new System.Drawing.Size(145, 49);
            this.cmbLogType.StartIndex = 0;
            this.cmbLogType.TabIndex = 211;
            this.cmbLogType.Triangle = true;
            this.cmbLogType.SelectedIndexChanged += new System.EventHandler(this.cmbLogType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label3.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(388, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 58);
            this.label3.TabIndex = 212;
            this.label3.Text = "信息列表:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFileList
            // 
            this.cmbFileList.AutoResize = false;
            this.cmbFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbFileList.Borderwidht = 7;
            this.cmbFileList.ComboxColor = System.Drawing.Color.White;
            this.cmbFileList.Commodel = 0;
            this.cmbFileList.Depth = 0;
            this.cmbFileList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbFileList.DropDownHeight = 217;
            this.cmbFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileList.DropDownWidth = 121;
            this.cmbFileList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFileList.FormattingEnabled = true;
            this.cmbFileList.IntegralHeight = false;
            this.cmbFileList.ItemHeight = 43;
            this.cmbFileList.Location = new System.Drawing.Point(505, 3);
            this.cmbFileList.MaxDropDownItems = 5;
            this.cmbFileList.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbFileList.Name = "cmbFileList";
            this.cmbFileList.ShowScrollbar = false;
            this.cmbFileList.Size = new System.Drawing.Size(248, 49);
            this.cmbFileList.StartIndex = 0;
            this.cmbFileList.TabIndex = 213;
            this.cmbFileList.Triangle = true;
            this.cmbFileList.SelectedIndexChanged += new System.EventHandler(this.cmbFileList_SelectedIndexChanged);
            // 
            // btnClearLog
            // 
            this.btnClearLog.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnClearLog.ButtonColor = System.Drawing.Color.White;
            this.btnClearLog.Buttonmodel = 0;
            this.btnClearLog.ClickColor = System.Drawing.Color.White;
            this.btnClearLog.Constant = 0;
            this.btnClearLog.Depth = 0;
            this.btnClearLog.Location = new System.Drawing.Point(759, 3);
            this.btnClearLog.MaxV = 0;
            this.btnClearLog.MinV = 0;
            this.btnClearLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(105, 49);
            this.btnClearLog.TabIndex = 217;
            this.btnClearLog.Text = "清除日志";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // HistoryDataUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.hisFrmTabControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "HistoryDataUI";
            this.Size = new System.Drawing.Size(1378, 753);
            this.Load += new System.EventHandler(this.HistoryDataUI_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.hisFrmTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartWaveData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionView)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ZimaBlueUI.ZRoundButton btnHisLog;
        private ZimaBlueUI.ZRoundButton btnHisData;
        private MaterialSkin.Controls.MaterialTabControl hisFrmTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listHisData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private MaterialSkin.Controls.MaterialButtonpro btnRefreshListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWaveData;
        private System.Windows.Forms.DataGridView PositionView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialComboBox cmbLogType;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialComboBox cmbFileList;
        private MaterialSkin.Controls.MaterialButtonpro btnClearLog;
        private System.Windows.Forms.ListBox lstLogContent;
        private System.Windows.Forms.Label lblScrews;
        private System.Windows.Forms.MaskedTextBox tbxSnSearchBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox textBoxCircle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox textBoxTorque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxResult;
        private MaterialSkin.Controls.MaterialButtonpro btnSearch;
    }
}
