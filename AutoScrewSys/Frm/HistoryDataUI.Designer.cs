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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.listHisData = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.materialComboBox2 = new MaterialSkin.Controls.MaterialComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.materialComboBox3 = new MaterialSkin.Controls.MaterialComboBox();
            this.materialButtonpro4 = new MaterialSkin.Controls.MaterialButtonpro();
            this.materialButtonpro5 = new MaterialSkin.Controls.MaterialButtonpro();
            this.materialButtonpro6 = new MaterialSkin.Controls.MaterialButtonpro();
            this.materialButtonpro7 = new MaterialSkin.Controls.MaterialButtonpro();
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
            this.panel1.Location = new System.Drawing.Point(152, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 663);
            this.panel1.TabIndex = 9;
            // 
            // chartWaveData
            // 
            this.chartWaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.chartWaveData.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Aquamarine;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Red;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.GreenYellow;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Num";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("思源黑体 CN Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.SystemColors.Window;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Red;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Orange;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Torque";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.SystemColors.Window;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 90F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 10F;
            this.chartWaveData.ChartAreas.Add(chartArea1);
            this.chartWaveData.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.ShadowColor = System.Drawing.Color.Black;
            this.chartWaveData.Legends.Add(legend1);
            this.chartWaveData.Location = new System.Drawing.Point(0, 345);
            this.chartWaveData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartWaveData.Name = "chartWaveData";
            this.chartWaveData.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series1.BackImageTransparentColor = System.Drawing.Color.WhiteSmoke;
            series1.BackSecondaryColor = System.Drawing.Color.Black;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Color = System.Drawing.Color.Lime;
            series1.Legend = "Legend1";
            series1.LegendText = "Kgf";
            series1.Name = "Series1";
            series1.ShadowColor = System.Drawing.Color.Black;
            this.chartWaveData.Series.Add(series1);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            this.PositionView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PositionView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PositionView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PositionView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PositionView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PositionView.ColumnHeadersHeight = 32;
            this.PositionView.Dock = System.Windows.Forms.DockStyle.Top;
            this.PositionView.EnableHeadersVisualStyles = false;
            this.PositionView.GridColor = System.Drawing.Color.Black;
            this.PositionView.Location = new System.Drawing.Point(0, 0);
            this.PositionView.MultiSelect = false;
            this.PositionView.Name = "PositionView";
            this.PositionView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PositionView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.PositionView.RowHeadersVisible = false;
            this.PositionView.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PositionView.RowsDefaultCellStyle = dataGridViewCellStyle4;
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
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.flowLayoutPanel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(152, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1163, 58);
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
            this.btnRefreshListBox.Size = new System.Drawing.Size(105, 49);
            this.btnRefreshListBox.TabIndex = 202;
            this.btnRefreshListBox.Text = "刷新列表";
            this.btnRefreshListBox.UseVisualStyleBackColor = true;
            this.btnRefreshListBox.Click += new System.EventHandler(this.btnRefreshListBox_Click);
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
            this.tabPage2.Controls.Add(this.flowLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1318, 727);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label1);
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.materialComboBox2);
            this.flowLayoutPanel4.Controls.Add(this.label3);
            this.flowLayoutPanel4.Controls.Add(this.materialComboBox3);
            this.flowLayoutPanel4.Controls.Add(this.materialButtonpro4);
            this.flowLayoutPanel4.Controls.Add(this.materialButtonpro5);
            this.flowLayoutPanel4.Controls.Add(this.materialButtonpro6);
            this.flowLayoutPanel4.Controls.Add(this.materialButtonpro7);
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
            // materialComboBox2
            // 
            this.materialComboBox2.AutoResize = false;
            this.materialComboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.materialComboBox2.Borderwidht = 7;
            this.materialComboBox2.ComboxColor = System.Drawing.Color.White;
            this.materialComboBox2.Commodel = 0;
            this.materialComboBox2.Depth = 0;
            this.materialComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialComboBox2.DropDownHeight = 217;
            this.materialComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox2.DropDownWidth = 121;
            this.materialComboBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.materialComboBox2.FormattingEnabled = true;
            this.materialComboBox2.IntegralHeight = false;
            this.materialComboBox2.ItemHeight = 43;
            this.materialComboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.materialComboBox2.Location = new System.Drawing.Point(237, 3);
            this.materialComboBox2.MaxDropDownItems = 5;
            this.materialComboBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.materialComboBox2.Name = "materialComboBox2";
            this.materialComboBox2.ShowScrollbar = false;
            this.materialComboBox2.Size = new System.Drawing.Size(137, 49);
            this.materialComboBox2.StartIndex = 0;
            this.materialComboBox2.TabIndex = 211;
            this.materialComboBox2.Triangle = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label3.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(380, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 58);
            this.label3.TabIndex = 212;
            this.label3.Text = "信息列表:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialComboBox3
            // 
            this.materialComboBox3.AutoResize = false;
            this.materialComboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.materialComboBox3.Borderwidht = 7;
            this.materialComboBox3.ComboxColor = System.Drawing.Color.White;
            this.materialComboBox3.Commodel = 0;
            this.materialComboBox3.Depth = 0;
            this.materialComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialComboBox3.DropDownHeight = 217;
            this.materialComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox3.DropDownWidth = 121;
            this.materialComboBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.materialComboBox3.FormattingEnabled = true;
            this.materialComboBox3.IntegralHeight = false;
            this.materialComboBox3.ItemHeight = 43;
            this.materialComboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.materialComboBox3.Location = new System.Drawing.Point(497, 3);
            this.materialComboBox3.MaxDropDownItems = 5;
            this.materialComboBox3.MouseState = MaterialSkin.MouseState.OUT;
            this.materialComboBox3.Name = "materialComboBox3";
            this.materialComboBox3.ShowScrollbar = false;
            this.materialComboBox3.Size = new System.Drawing.Size(137, 49);
            this.materialComboBox3.StartIndex = 0;
            this.materialComboBox3.TabIndex = 213;
            this.materialComboBox3.Triangle = true;
            // 
            // materialButtonpro4
            // 
            this.materialButtonpro4.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.materialButtonpro4.ButtonColor = System.Drawing.Color.White;
            this.materialButtonpro4.Buttonmodel = 0;
            this.materialButtonpro4.ClickColor = System.Drawing.Color.White;
            this.materialButtonpro4.Constant = 0;
            this.materialButtonpro4.Depth = 0;
            this.materialButtonpro4.Location = new System.Drawing.Point(640, 3);
            this.materialButtonpro4.MaxV = 0;
            this.materialButtonpro4.MinV = 0;
            this.materialButtonpro4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonpro4.Name = "materialButtonpro4";
            this.materialButtonpro4.Size = new System.Drawing.Size(105, 49);
            this.materialButtonpro4.TabIndex = 214;
            this.materialButtonpro4.Text = "刷新列表";
            this.materialButtonpro4.UseVisualStyleBackColor = true;
            // 
            // materialButtonpro5
            // 
            this.materialButtonpro5.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.materialButtonpro5.ButtonColor = System.Drawing.Color.White;
            this.materialButtonpro5.Buttonmodel = 0;
            this.materialButtonpro5.ClickColor = System.Drawing.Color.White;
            this.materialButtonpro5.Constant = 0;
            this.materialButtonpro5.Depth = 0;
            this.materialButtonpro5.Location = new System.Drawing.Point(751, 3);
            this.materialButtonpro5.MaxV = 0;
            this.materialButtonpro5.MinV = 0;
            this.materialButtonpro5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonpro5.Name = "materialButtonpro5";
            this.materialButtonpro5.Size = new System.Drawing.Size(105, 49);
            this.materialButtonpro5.TabIndex = 215;
            this.materialButtonpro5.Text = "显示信息";
            this.materialButtonpro5.UseVisualStyleBackColor = true;
            // 
            // materialButtonpro6
            // 
            this.materialButtonpro6.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.materialButtonpro6.ButtonColor = System.Drawing.Color.White;
            this.materialButtonpro6.Buttonmodel = 0;
            this.materialButtonpro6.ClickColor = System.Drawing.Color.White;
            this.materialButtonpro6.Constant = 0;
            this.materialButtonpro6.Depth = 0;
            this.materialButtonpro6.Location = new System.Drawing.Point(862, 3);
            this.materialButtonpro6.MaxV = 0;
            this.materialButtonpro6.MinV = 0;
            this.materialButtonpro6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonpro6.Name = "materialButtonpro6";
            this.materialButtonpro6.Size = new System.Drawing.Size(105, 49);
            this.materialButtonpro6.TabIndex = 216;
            this.materialButtonpro6.Text = "导出信息";
            this.materialButtonpro6.UseVisualStyleBackColor = true;
            // 
            // materialButtonpro7
            // 
            this.materialButtonpro7.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.materialButtonpro7.ButtonColor = System.Drawing.Color.White;
            this.materialButtonpro7.Buttonmodel = 0;
            this.materialButtonpro7.ClickColor = System.Drawing.Color.White;
            this.materialButtonpro7.Constant = 0;
            this.materialButtonpro7.Depth = 0;
            this.materialButtonpro7.Location = new System.Drawing.Point(973, 3);
            this.materialButtonpro7.MaxV = 0;
            this.materialButtonpro7.MinV = 0;
            this.materialButtonpro7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonpro7.Name = "materialButtonpro7";
            this.materialButtonpro7.Size = new System.Drawing.Size(105, 49);
            this.materialButtonpro7.TabIndex = 217;
            this.materialButtonpro7.Text = "清除日志";
            this.materialButtonpro7.UseVisualStyleBackColor = true;
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
        private MaterialSkin.Controls.MaterialComboBox materialComboBox2;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox3;
        private MaterialSkin.Controls.MaterialButtonpro materialButtonpro4;
        private MaterialSkin.Controls.MaterialButtonpro materialButtonpro5;
        private MaterialSkin.Controls.MaterialButtonpro materialButtonpro6;
        private MaterialSkin.Controls.MaterialButtonpro materialButtonpro7;
    }
}
