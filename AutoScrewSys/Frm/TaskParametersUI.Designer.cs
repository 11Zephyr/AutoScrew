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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.TaskLists = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvStepView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialButtonpro7 = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnReadParam = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnFreeMove = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnLoosenMove = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnTightenMove = new MaterialSkin.Controls.MaterialButtonpro();
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
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            this.dgvStepView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvStepView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStepView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.dgvStepView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStepView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvStepView.ColumnHeadersHeight = 32;
            this.dgvStepView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvStepView.EnableHeadersVisualStyles = false;
            this.dgvStepView.GridColor = System.Drawing.Color.Black;
            this.dgvStepView.Location = new System.Drawing.Point(3, 3);
            this.dgvStepView.MultiSelect = false;
            this.dgvStepView.Name = "dgvStepView";
            this.dgvStepView.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStepView.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvStepView.RowHeadersVisible = false;
            this.dgvStepView.RowHeadersWidth = 20;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStepView.RowsDefaultCellStyle = dataGridViewCellStyle18;
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
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn4.HeaderText = "步骤";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle16;
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
            this.panel1.Controls.Add(this.materialButtonpro7);
            this.panel1.Controls.Add(this.btnReadParam);
            this.panel1.Controls.Add(this.btnFreeMove);
            this.panel1.Controls.Add(this.btnLoosenMove);
            this.panel1.Controls.Add(this.btnTightenMove);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Location = new System.Drawing.Point(397, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 195);
            this.panel1.TabIndex = 69;
            // 
            // materialButtonpro7
            // 
            this.materialButtonpro7.AngleColor = System.Drawing.Color.Transparent;
            this.materialButtonpro7.ButtonColor = System.Drawing.Color.White;
            this.materialButtonpro7.Buttonmodel = 0;
            this.materialButtonpro7.ClickColor = System.Drawing.Color.White;
            this.materialButtonpro7.Constant = 0;
            this.materialButtonpro7.Depth = 0;
            this.materialButtonpro7.Location = new System.Drawing.Point(725, 77);
            this.materialButtonpro7.MaxV = 0;
            this.materialButtonpro7.MinV = 0;
            this.materialButtonpro7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonpro7.Name = "materialButtonpro7";
            this.materialButtonpro7.Size = new System.Drawing.Size(94, 43);
            this.materialButtonpro7.TabIndex = 162;
            this.materialButtonpro7.Text = "写入驱动";
            this.materialButtonpro7.UseVisualStyleBackColor = true;
            // 
            // btnReadParam
            // 
            this.btnReadParam.AngleColor = System.Drawing.Color.Transparent;
            this.btnReadParam.ButtonColor = System.Drawing.Color.White;
            this.btnReadParam.Buttonmodel = 0;
            this.btnReadParam.ClickColor = System.Drawing.Color.White;
            this.btnReadParam.Constant = 0;
            this.btnReadParam.Depth = 0;
            this.btnReadParam.Location = new System.Drawing.Point(606, 77);
            this.btnReadParam.MaxV = 0;
            this.btnReadParam.MinV = 0;
            this.btnReadParam.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReadParam.Name = "btnReadParam";
            this.btnReadParam.Size = new System.Drawing.Size(94, 43);
            this.btnReadParam.TabIndex = 163;
            this.btnReadParam.Text = "读取驱动";
            this.btnReadParam.UseVisualStyleBackColor = true;
            this.btnReadParam.Click += new System.EventHandler(this.btnReadParam_Click);
            // 
            // btnFreeMove
            // 
            this.btnFreeMove.AngleColor = System.Drawing.Color.Transparent;
            this.btnFreeMove.ButtonColor = System.Drawing.Color.White;
            this.btnFreeMove.Buttonmodel = 0;
            this.btnFreeMove.ClickColor = System.Drawing.Color.White;
            this.btnFreeMove.Constant = 0;
            this.btnFreeMove.Depth = 0;
            this.btnFreeMove.Location = new System.Drawing.Point(257, 70);
            this.btnFreeMove.MaxV = 0;
            this.btnFreeMove.MinV = 0;
            this.btnFreeMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFreeMove.Name = "btnFreeMove";
            this.btnFreeMove.Size = new System.Drawing.Size(121, 50);
            this.btnFreeMove.TabIndex = 3;
            this.btnFreeMove.Text = "自由";
            this.btnFreeMove.UseVisualStyleBackColor = true;
            this.btnFreeMove.Click += new System.EventHandler(this.btnFreeMove_Click);
            // 
            // btnLoosenMove
            // 
            this.btnLoosenMove.AngleColor = System.Drawing.Color.Transparent;
            this.btnLoosenMove.ButtonColor = System.Drawing.Color.White;
            this.btnLoosenMove.Buttonmodel = 0;
            this.btnLoosenMove.ClickColor = System.Drawing.Color.White;
            this.btnLoosenMove.Constant = 0;
            this.btnLoosenMove.Depth = 0;
            this.btnLoosenMove.Location = new System.Drawing.Point(130, 70);
            this.btnLoosenMove.MaxV = 0;
            this.btnLoosenMove.MinV = 0;
            this.btnLoosenMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoosenMove.Name = "btnLoosenMove";
            this.btnLoosenMove.Size = new System.Drawing.Size(121, 50);
            this.btnLoosenMove.TabIndex = 2;
            this.btnLoosenMove.Text = "拧松";
            this.btnLoosenMove.UseVisualStyleBackColor = true;
            this.btnLoosenMove.Click += new System.EventHandler(this.btnLoosenMove_Click);
            // 
            // btnTightenMove
            // 
            this.btnTightenMove.AngleColor = System.Drawing.Color.Transparent;
            this.btnTightenMove.ButtonColor = System.Drawing.Color.White;
            this.btnTightenMove.Buttonmodel = 0;
            this.btnTightenMove.ClickColor = System.Drawing.Color.White;
            this.btnTightenMove.Constant = 0;
            this.btnTightenMove.Depth = 0;
            this.btnTightenMove.Location = new System.Drawing.Point(3, 70);
            this.btnTightenMove.MaxV = 0;
            this.btnTightenMove.MinV = 0;
            this.btnTightenMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTightenMove.Name = "btnTightenMove";
            this.btnTightenMove.Size = new System.Drawing.Size(121, 50);
            this.btnTightenMove.TabIndex = 1;
            this.btnTightenMove.Text = "拧紧";
            this.btnTightenMove.UseVisualStyleBackColor = true;
            this.btnTightenMove.Click += new System.EventHandler(this.btnTightenMove_Click);
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
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            this.dgvParam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvParam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParam.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.dgvParam.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvParam.ColumnHeadersHeight = 32;
            this.dgvParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamName,
            this.Value,
            this.Range,
            this.Unit,
            this.Remark});
            this.dgvParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParam.EnableHeadersVisualStyles = false;
            this.dgvParam.GridColor = System.Drawing.Color.Black;
            this.dgvParam.Location = new System.Drawing.Point(142, 209);
            this.dgvParam.MultiSelect = false;
            this.dgvParam.Name = "dgvParam";
            this.dgvParam.ReadOnly = true;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParam.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvParam.RowHeadersVisible = false;
            this.dgvParam.RowHeadersWidth = 20;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(142)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvParam.RowsDefaultCellStyle = dataGridViewCellStyle24;
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
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ParamName.DefaultCellStyle = dataGridViewCellStyle21;
            this.ParamName.HeaderText = "名称";
            this.ParamName.MinimumWidth = 6;
            this.ParamName.Name = "ParamName";
            this.ParamName.ReadOnly = true;
            this.ParamName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ParamName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Value.DefaultCellStyle = dataGridViewCellStyle22;
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
        private MaterialSkin.Controls.MaterialButtonpro btnFreeMove;
        private MaterialSkin.Controls.MaterialButtonpro btnLoosenMove;
        private MaterialSkin.Controls.MaterialButtonpro btnTightenMove;
        private MaterialSkin.Controls.MaterialButtonpro materialButtonpro7;
        private MaterialSkin.Controls.MaterialButtonpro btnReadParam;
        private System.Windows.Forms.DataGridView dgvParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}
