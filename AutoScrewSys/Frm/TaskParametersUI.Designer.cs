namespace AutoScrewSys.Frm
{
    partial class TaskParametersUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.TaskLists = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvStepView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTighten = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnLoosen = new MaterialSkin.Controls.MaterialButtonpro();
            this.dgvParam = new System.Windows.Forms.DataGridView();
            this.ParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStepView)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParam)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.TaskLists);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(142, 753);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 73);
            this.label9.TabIndex = 199;
            this.label9.Text = "任务列表";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaskLists
            // 
            this.TaskLists.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.TaskLists.ForeColor = System.Drawing.SystemColors.Window;
            this.TaskLists.FormattingEnabled = true;
            this.TaskLists.ItemHeight = 29;
            this.TaskLists.Location = new System.Drawing.Point(3, 76);
            this.TaskLists.Name = "TaskLists";
            this.TaskLists.Size = new System.Drawing.Size(140, 671);
            this.TaskLists.TabIndex = 3;
            this.TaskLists.SelectedIndexChanged += new System.EventHandler(this.TaskLists_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dgvStepView);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(142, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1236, 209);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // dgvStepView
            // 
            this.dgvStepView.AllowUserToAddRows = false;
            this.dgvStepView.AllowUserToDeleteRows = false;
            this.dgvStepView.AllowUserToResizeColumns = false;
            this.dgvStepView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            this.dgvStepView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStepView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStepView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.dgvStepView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStepView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStepView.ColumnHeadersHeight = 32;
            this.dgvStepView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStepView.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStepView.EnableHeadersVisualStyles = false;
            this.dgvStepView.GridColor = System.Drawing.Color.Black;
            this.dgvStepView.Location = new System.Drawing.Point(3, 3);
            this.dgvStepView.MultiSelect = false;
            this.dgvStepView.Name = "dgvStepView";
            this.dgvStepView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStepView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStepView.RowHeadersVisible = false;
            this.dgvStepView.RowHeadersWidth = 20;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStepView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvStepView.RowTemplate.Height = 30;
            this.dgvStepView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvStepView.ShowCellErrors = false;
            this.dgvStepView.ShowCellToolTips = false;
            this.dgvStepView.ShowEditingIcon = false;
            this.dgvStepView.ShowRowErrors = false;
            this.dgvStepView.Size = new System.Drawing.Size(388, 195);
            this.dgvStepView.TabIndex = 68;
            this.dgvStepView.TabStop = false;
            this.dgvStepView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStepView_CellClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "步骤";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn5.HeaderText = "圈数";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "速度";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Location = new System.Drawing.Point(397, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 195);
            this.panel1.TabIndex = 69;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnTighten);
            this.flowLayoutPanel3.Controls.Add(this.btnLoosen);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(836, 65);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnTighten
            // 
            this.btnTighten.AngleColor = System.Drawing.Color.Transparent;
            this.btnTighten.ButtonColor = System.Drawing.Color.White;
            this.btnTighten.Buttonmodel = 0;
            this.btnTighten.ClickColor = System.Drawing.Color.White;
            this.btnTighten.Constant = 0;
            this.btnTighten.Depth = 0;
            this.btnTighten.Location = new System.Drawing.Point(3, 3);
            this.btnTighten.MaxV = 0;
            this.btnTighten.MinV = 0;
            this.btnTighten.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTighten.Name = "btnTighten";
            this.btnTighten.Size = new System.Drawing.Size(277, 53);
            this.btnTighten.TabIndex = 0;
            this.btnTighten.Text = "拧紧";
            this.btnTighten.UseVisualStyleBackColor = true;
            this.btnTighten.Click += new System.EventHandler(this.btnTighten_Click);
            // 
            // btnLoosen
            // 
            this.btnLoosen.AngleColor = System.Drawing.Color.Transparent;
            this.btnLoosen.ButtonColor = System.Drawing.Color.White;
            this.btnLoosen.Buttonmodel = 0;
            this.btnLoosen.ClickColor = System.Drawing.Color.White;
            this.btnLoosen.Constant = 0;
            this.btnLoosen.Depth = 0;
            this.btnLoosen.Location = new System.Drawing.Point(286, 3);
            this.btnLoosen.MaxV = 0;
            this.btnLoosen.MinV = 0;
            this.btnLoosen.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoosen.Name = "btnLoosen";
            this.btnLoosen.Size = new System.Drawing.Size(276, 53);
            this.btnLoosen.TabIndex = 1;
            this.btnLoosen.Text = "拧松";
            this.btnLoosen.UseVisualStyleBackColor = true;
            this.btnLoosen.Click += new System.EventHandler(this.btnLoosen_Click);
            // 
            // dgvParam
            // 
            this.dgvParam.AllowUserToAddRows = false;
            this.dgvParam.AllowUserToDeleteRows = false;
            this.dgvParam.AllowUserToResizeColumns = false;
            this.dgvParam.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            this.dgvParam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvParam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParam.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.dgvParam.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvParam.ColumnHeadersHeight = 32;
            this.dgvParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamName,
            this.Value,
            this.Range,
            this.Unit,
            this.Remark});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParam.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParam.EnableHeadersVisualStyles = false;
            this.dgvParam.GridColor = System.Drawing.Color.Black;
            this.dgvParam.Location = new System.Drawing.Point(142, 209);
            this.dgvParam.MultiSelect = false;
            this.dgvParam.Name = "dgvParam";
            this.dgvParam.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParam.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvParam.RowHeadersVisible = false;
            this.dgvParam.RowHeadersWidth = 20;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvParam.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvParam.RowTemplate.Height = 30;
            this.dgvParam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvParam.ShowCellErrors = false;
            this.dgvParam.ShowCellToolTips = false;
            this.dgvParam.ShowEditingIcon = false;
            this.dgvParam.ShowRowErrors = false;
            this.dgvParam.Size = new System.Drawing.Size(1236, 544);
            this.dgvParam.TabIndex = 69;
            this.dgvParam.TabStop = false;
            this.dgvParam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParam_CellClick);
            // 
            // ParamName
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ParamName.DefaultCellStyle = dataGridViewCellStyle10;
            this.ParamName.HeaderText = "名称";
            this.ParamName.MinimumWidth = 6;
            this.ParamName.Name = "ParamName";
            this.ParamName.ReadOnly = true;
            this.ParamName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ParamName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Value.DefaultCellStyle = dataGridViewCellStyle11;
            this.Value.HeaderText = "参数";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Range
            // 
            this.Range.HeaderText = "范围";
            this.Range.MinimumWidth = 6;
            this.Range.Name = "Range";
            this.Range.ReadOnly = true;
            this.Range.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Range.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // TaskParametersUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.dgvParam);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.Name = "TaskParametersUI";
            this.Size = new System.Drawing.Size(1378, 753);
            this.Load += new System.EventHandler(this.TaskParametersUI_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStepView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox TaskLists;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvStepView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private MaterialSkin.Controls.MaterialButtonpro btnTighten;
        private MaterialSkin.Controls.MaterialButtonpro btnLoosen;
        private System.Windows.Forms.DataGridView dgvParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}
