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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryDataUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHisLog = new ZimaBlueUI.ZRoundButton();
            this.btnHisData = new ZimaBlueUI.ZRoundButton();
            this.hisFrmTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.listHisData = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxResult = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTorque = new ZimaBlueUI.ZtextBoxRua();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCircle = new ZimaBlueUI.ZtextBoxRua();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSnSearchBox = new ZimaBlueUI.ZtextBoxRua();
            this.lblScrews = new System.Windows.Forms.Label();
            this.btnRefreshListBox = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnSearch = new MaterialSkin.Controls.MaterialButtonpro();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.PositionView = new System.Windows.Forms.DataGridView();
            this.chartWaveData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstLogContent = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLogType = new MaterialSkin.Controls.MaterialComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFileList = new MaterialSkin.Controls.MaterialComboBox();
            this.btnClearLog = new MaterialSkin.Controls.MaterialButtonpro();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.hisFrmTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWaveData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.hisFrmTabControl, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btnHisLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnHisData, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // btnHisLog
            // 
            resources.ApplyResources(this.btnHisLog, "btnHisLog");
            this.btnHisLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHisLog.EXBorderRadius = 5F;
            this.btnHisLog.EXButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHisLog.Isbackcplor = false;
            this.btnHisLog.Name = "btnHisLog";
            this.btnHisLog.ReverseButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisLog.Click += new System.EventHandler(this.btnHisLog_Click);
            // 
            // btnHisData
            // 
            resources.ApplyResources(this.btnHisData, "btnHisData");
            this.btnHisData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHisData.EXBorderRadius = 5F;
            this.btnHisData.EXButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisData.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHisData.Isbackcplor = false;
            this.btnHisData.Name = "btnHisData";
            this.btnHisData.ReverseButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHisData.Click += new System.EventHandler(this.btnHisData_Click);
            // 
            // hisFrmTabControl
            // 
            resources.ApplyResources(this.hisFrmTabControl, "hisFrmTabControl");
            this.hisFrmTabControl.Controls.Add(this.tabPage1);
            this.hisFrmTabControl.Controls.Add(this.tabPage2);
            this.hisFrmTabControl.Depth = 0;
            this.hisFrmTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.hisFrmTabControl.Multiline = true;
            this.hisFrmTabControl.Name = "hisFrmTabControl";
            this.hisFrmTabControl.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel4);
            this.tabPage1.Name = "tabPage1";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.listHisData, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // listHisData
            // 
            resources.ApplyResources(this.listHisData, "listHisData");
            this.listHisData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.listHisData.ForeColor = System.Drawing.SystemColors.Window;
            this.listHisData.FormattingEnabled = true;
            this.listHisData.Name = "listHisData";
            this.listHisData.SelectedIndexChanged += new System.EventHandler(this.listHisData_SelectedIndexChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Name = "label9";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this.comboBoxResult, 8, 0);
            this.tableLayoutPanel7.Controls.Add(this.label6, 7, 0);
            this.tableLayoutPanel7.Controls.Add(this.textBoxTorque, 6, 0);
            this.tableLayoutPanel7.Controls.Add(this.label5, 5, 0);
            this.tableLayoutPanel7.Controls.Add(this.textBoxCircle, 4, 0);
            this.tableLayoutPanel7.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.tbxSnSearchBox, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.lblScrews, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnRefreshListBox, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnSearch, 9, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // comboBoxResult
            // 
            resources.ApplyResources(this.comboBoxResult, "comboBoxResult");
            this.comboBoxResult.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResult.FormattingEnabled = true;
            this.comboBoxResult.Items.AddRange(new object[] {
            resources.GetString("comboBoxResult.Items"),
            resources.GetString("comboBoxResult.Items1"),
            resources.GetString("comboBoxResult.Items2"),
            resources.GetString("comboBoxResult.Items3")});
            this.comboBoxResult.Name = "comboBoxResult";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Name = "label6";
            // 
            // textBoxTorque
            // 
            resources.ApplyResources(this.textBoxTorque, "textBoxTorque");
            this.textBoxTorque.BackColor = System.Drawing.Color.Black;
            this.textBoxTorque.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxTorque.Name = "textBoxTorque";
            this.textBoxTorque.ReadOnly = false;
            this.textBoxTorque.Tag = "Text";
            this.textBoxTorque.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.textBoxTorque.TextBorderColor = System.Drawing.SystemColors.Window;
            this.textBoxTorque.TextBorderRadius = 5;
            this.textBoxTorque.TextBorderSize = 1;
            this.textBoxTorque.TextBorderWidth = 2;
            this.textBoxTorque.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InputTextBox_MouseDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Name = "label5";
            // 
            // textBoxCircle
            // 
            resources.ApplyResources(this.textBoxCircle, "textBoxCircle");
            this.textBoxCircle.BackColor = System.Drawing.Color.Black;
            this.textBoxCircle.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxCircle.Name = "textBoxCircle";
            this.textBoxCircle.ReadOnly = false;
            this.textBoxCircle.Tag = "Text";
            this.textBoxCircle.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.textBoxCircle.TextBorderColor = System.Drawing.SystemColors.Window;
            this.textBoxCircle.TextBorderRadius = 5;
            this.textBoxCircle.TextBorderSize = 1;
            this.textBoxCircle.TextBorderWidth = 2;
            this.textBoxCircle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InputTextBox_MouseDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Name = "label4";
            // 
            // tbxSnSearchBox
            // 
            resources.ApplyResources(this.tbxSnSearchBox, "tbxSnSearchBox");
            this.tbxSnSearchBox.BackColor = System.Drawing.Color.Black;
            this.tbxSnSearchBox.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxSnSearchBox.Name = "tbxSnSearchBox";
            this.tbxSnSearchBox.ReadOnly = false;
            this.tbxSnSearchBox.Tag = "Text";
            this.tbxSnSearchBox.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tbxSnSearchBox.TextBorderColor = System.Drawing.SystemColors.Window;
            this.tbxSnSearchBox.TextBorderRadius = 5;
            this.tbxSnSearchBox.TextBorderSize = 1;
            this.tbxSnSearchBox.TextBorderWidth = 2;
            this.tbxSnSearchBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InputTextBox_MouseDown);
            // 
            // lblScrews
            // 
            resources.ApplyResources(this.lblScrews, "lblScrews");
            this.lblScrews.BackColor = System.Drawing.Color.Transparent;
            this.lblScrews.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblScrews.Name = "lblScrews";
            // 
            // btnRefreshListBox
            // 
            resources.ApplyResources(this.btnRefreshListBox, "btnRefreshListBox");
            this.btnRefreshListBox.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnRefreshListBox.ButtonColor = System.Drawing.Color.White;
            this.btnRefreshListBox.Buttonmodel = 0;
            this.btnRefreshListBox.ClickColor = System.Drawing.Color.White;
            this.btnRefreshListBox.Constant = 0;
            this.btnRefreshListBox.Depth = 0;
            this.btnRefreshListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnRefreshListBox.MaxV = 0;
            this.btnRefreshListBox.MinV = 0;
            this.btnRefreshListBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshListBox.Name = "btnRefreshListBox";
            this.btnRefreshListBox.UseVisualStyleBackColor = true;
            this.btnRefreshListBox.Click += new System.EventHandler(this.btnRefreshListBox_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSearch.ButtonColor = System.Drawing.Color.White;
            this.btnSearch.Buttonmodel = 0;
            this.btnSearch.ClickColor = System.Drawing.Color.White;
            this.btnSearch.Constant = 0;
            this.btnSearch.Depth = 0;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSearch.MaxV = 0;
            this.btnSearch.MinV = 0;
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.PositionView, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.chartWaveData, 0, 1);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // PositionView
            // 
            resources.ApplyResources(this.PositionView, "PositionView");
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
            this.PositionView.EnableHeadersVisualStyles = false;
            this.PositionView.GridColor = System.Drawing.Color.Black;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PositionView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.PositionView.RowTemplate.Height = 30;
            this.PositionView.ShowCellErrors = false;
            this.PositionView.ShowCellToolTips = false;
            this.PositionView.ShowEditingIcon = false;
            this.PositionView.ShowRowErrors = false;
            this.PositionView.TabStop = false;
            this.PositionView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PositionView_CellClick);
            // 
            // chartWaveData
            // 
            resources.ApplyResources(this.chartWaveData, "chartWaveData");
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
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.ShadowColor = System.Drawing.Color.Black;
            this.chartWaveData.Legends.Add(legend1);
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
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage2.Controls.Add(this.lstLogContent);
            this.tabPage2.Controls.Add(this.flowLayoutPanel4);
            this.tabPage2.Name = "tabPage2";
            // 
            // lstLogContent
            // 
            resources.ApplyResources(this.lstLogContent, "lstLogContent");
            this.lstLogContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lstLogContent.ForeColor = System.Drawing.SystemColors.Window;
            this.lstLogContent.FormattingEnabled = true;
            this.lstLogContent.Name = "lstLogContent";
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(this.flowLayoutPanel4, "flowLayoutPanel4");
            this.flowLayoutPanel4.Controls.Add(this.label1);
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.cmbLogType);
            this.flowLayoutPanel4.Controls.Add(this.label3);
            this.flowLayoutPanel4.Controls.Add(this.cmbFileList);
            this.flowLayoutPanel4.Controls.Add(this.btnClearLog);
            this.flowLayoutPanel4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Name = "label2";
            // 
            // cmbLogType
            // 
            resources.ApplyResources(this.cmbLogType, "cmbLogType");
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
            this.cmbLogType.Items.AddRange(new object[] {
            resources.GetString("cmbLogType.Items"),
            resources.GetString("cmbLogType.Items1"),
            resources.GetString("cmbLogType.Items2")});
            this.cmbLogType.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbLogType.Name = "cmbLogType";
            this.cmbLogType.ShowScrollbar = false;
            this.cmbLogType.StartIndex = 0;
            this.cmbLogType.Triangle = true;
            this.cmbLogType.SelectedIndexChanged += new System.EventHandler(this.cmbLogType_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Name = "label3";
            // 
            // cmbFileList
            // 
            resources.ApplyResources(this.cmbFileList, "cmbFileList");
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
            this.cmbFileList.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbFileList.Name = "cmbFileList";
            this.cmbFileList.ShowScrollbar = false;
            this.cmbFileList.StartIndex = 0;
            this.cmbFileList.Triangle = true;
            this.cmbFileList.SelectedIndexChanged += new System.EventHandler(this.cmbFileList_SelectedIndexChanged);
            // 
            // btnClearLog
            // 
            resources.ApplyResources(this.btnClearLog, "btnClearLog");
            this.btnClearLog.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnClearLog.ButtonColor = System.Drawing.Color.White;
            this.btnClearLog.Buttonmodel = 0;
            this.btnClearLog.ClickColor = System.Drawing.Color.White;
            this.btnClearLog.Constant = 0;
            this.btnClearLog.Depth = 0;
            this.btnClearLog.MaxV = 0;
            this.btnClearLog.MinV = 0;
            this.btnClearLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // HistoryDataUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "HistoryDataUI";
            this.Load += new System.EventHandler(this.HistoryDataUI_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.hisFrmTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PositionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWaveData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl hisFrmTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialComboBox cmbLogType;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialComboBox cmbFileList;
        private MaterialSkin.Controls.MaterialButtonpro btnClearLog;
        private System.Windows.Forms.ListBox lstLogContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZimaBlueUI.ZRoundButton btnHisLog;
        private ZimaBlueUI.ZRoundButton btnHisData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListBox listHisData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DataGridView PositionView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWaveData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.ComboBox comboBoxResult;
        private System.Windows.Forms.Label label6;
        private ZimaBlueUI.ZtextBoxRua textBoxTorque;
        private System.Windows.Forms.Label label5;
        private ZimaBlueUI.ZtextBoxRua textBoxCircle;
        private System.Windows.Forms.Label label4;
        private ZimaBlueUI.ZtextBoxRua tbxSnSearchBox;
        private System.Windows.Forms.Label lblScrews;
        private MaterialSkin.Controls.MaterialButtonpro btnRefreshListBox;
        private MaterialSkin.Controls.MaterialButtonpro btnSearch;
    }
}
