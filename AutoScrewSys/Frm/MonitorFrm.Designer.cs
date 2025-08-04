namespace AutoScrewSys.Frm
{
    partial class MonitorFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customPanel1 = new ZimaBlueUI.CustomPanel();
            this.ElecBatchPower = new System.Windows.Forms.Label();
            this.AlarmInfoStr = new System.Windows.Forms.Label();
            this.Torque = new System.Windows.Forms.Label();
            this.LapsNum = new System.Windows.Forms.Label();
            this.RotateSpeed = new System.Windows.Forms.Label();
            this.TaskNumber = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTorqueMode = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnFreeMove = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnLoosenMove = new MaterialSkin.Controls.MaterialButtonpro();
            this.btnTightenMove = new MaterialSkin.Controls.MaterialButtonpro();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTightenSignal = new System.Windows.Forms.Label();
            this.lblLoosenSignal = new System.Windows.Forms.Label();
            this.lblLdlingSignal = new System.Windows.Forms.Label();
            this.lblBusySignal = new System.Windows.Forms.Label();
            this.lblEndSignal = new System.Windows.Forms.Label();
            this.lblAlarmSignal = new System.Windows.Forms.Label();
            this.lblTorqueUnit = new System.Windows.Forms.Label();
            this.ScrewResultStr = new System.Windows.Forms.Label();
            this.customPanel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.Black;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.ColumnCount = 7;
            this.customPanel1.Controls.Add(this.lblTorqueUnit);
            this.customPanel1.Controls.Add(this.ElecBatchPower);
            this.customPanel1.Controls.Add(this.AlarmInfoStr);
            this.customPanel1.Controls.Add(this.ScrewResultStr);
            this.customPanel1.Controls.Add(this.Torque);
            this.customPanel1.Controls.Add(this.LapsNum);
            this.customPanel1.Controls.Add(this.RotateSpeed);
            this.customPanel1.Controls.Add(this.TaskNumber);
            this.customPanel1.Controls.Add(this.label16);
            this.customPanel1.Controls.Add(this.label8);
            this.customPanel1.Controls.Add(this.label15);
            this.customPanel1.Controls.Add(this.label6);
            this.customPanel1.Controls.Add(this.label7);
            this.customPanel1.Controls.Add(this.label5);
            this.customPanel1.Controls.Add(this.label4);
            this.customPanel1.CornerRadius = 10;
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.customPanel1.Location = new System.Drawing.Point(0, 153);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.RowCount = 2;
            this.customPanel1.Size = new System.Drawing.Size(904, 123);
            this.customPanel1.TabIndex = 0;
            // 
            // ElecBatchPower
            // 
            this.ElecBatchPower.BackColor = System.Drawing.Color.Transparent;
            this.ElecBatchPower.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ElecBatchPower.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ElecBatchPower.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ElecBatchPower.Location = new System.Drawing.Point(781, 74);
            this.ElecBatchPower.Name = "ElecBatchPower";
            this.ElecBatchPower.Size = new System.Drawing.Size(111, 33);
            this.ElecBatchPower.TabIndex = 227;
            this.ElecBatchPower.Text = "0";
            this.ElecBatchPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlarmInfoStr
            // 
            this.AlarmInfoStr.BackColor = System.Drawing.Color.Transparent;
            this.AlarmInfoStr.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AlarmInfoStr.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AlarmInfoStr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AlarmInfoStr.Location = new System.Drawing.Point(655, 74);
            this.AlarmInfoStr.Name = "AlarmInfoStr";
            this.AlarmInfoStr.Size = new System.Drawing.Size(111, 33);
            this.AlarmInfoStr.TabIndex = 226;
            this.AlarmInfoStr.Text = "无故障";
            this.AlarmInfoStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Torque
            // 
            this.Torque.BackColor = System.Drawing.Color.Transparent;
            this.Torque.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Torque.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Torque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Torque.Location = new System.Drawing.Point(402, 74);
            this.Torque.Name = "Torque";
            this.Torque.Size = new System.Drawing.Size(97, 33);
            this.Torque.TabIndex = 224;
            this.Torque.Text = "0";
            this.Torque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LapsNum
            // 
            this.LapsNum.BackColor = System.Drawing.Color.Transparent;
            this.LapsNum.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LapsNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LapsNum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LapsNum.Location = new System.Drawing.Point(268, 74);
            this.LapsNum.Name = "LapsNum";
            this.LapsNum.Size = new System.Drawing.Size(111, 33);
            this.LapsNum.TabIndex = 223;
            this.LapsNum.Text = "0";
            this.LapsNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RotateSpeed
            // 
            this.RotateSpeed.BackColor = System.Drawing.Color.Transparent;
            this.RotateSpeed.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RotateSpeed.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RotateSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RotateSpeed.Location = new System.Drawing.Point(141, 74);
            this.RotateSpeed.Name = "RotateSpeed";
            this.RotateSpeed.Size = new System.Drawing.Size(111, 33);
            this.RotateSpeed.TabIndex = 222;
            this.RotateSpeed.Text = "0";
            this.RotateSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaskNumber
            // 
            this.TaskNumber.BackColor = System.Drawing.Color.Transparent;
            this.TaskNumber.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TaskNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TaskNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TaskNumber.Location = new System.Drawing.Point(12, 74);
            this.TaskNumber.Name = "TaskNumber";
            this.TaskNumber.Size = new System.Drawing.Size(111, 33);
            this.TaskNumber.TabIndex = 221;
            this.TaskNumber.Text = "0";
            this.TaskNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(780, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 33);
            this.label16.TabIndex = 219;
            this.label16.Text = "驱动功率";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(654, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 33);
            this.label8.TabIndex = 218;
            this.label8.Text = "报警状态";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(525, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 33);
            this.label15.TabIndex = 217;
            this.label15.Text = "拧紧结果";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(395, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 33);
            this.label6.TabIndex = 216;
            this.label6.Text = "扭力";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(267, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 33);
            this.label7.TabIndex = 215;
            this.label7.Text = "圈数(r)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(140, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 33);
            this.label5.TabIndex = 214;
            this.label5.Text = "速度(r/m)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(11, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 33);
            this.label4.TabIndex = 213;
            this.label4.Text = "任务号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTorqueMode
            // 
            this.btnTorqueMode.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnTorqueMode.ButtonColor = System.Drawing.Color.White;
            this.btnTorqueMode.Buttonmodel = 0;
            this.btnTorqueMode.ClickColor = System.Drawing.Color.White;
            this.btnTorqueMode.Constant = 0;
            this.btnTorqueMode.Depth = 0;
            this.btnTorqueMode.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.btnTorqueMode.Location = new System.Drawing.Point(457, 43);
            this.btnTorqueMode.MaxV = 0;
            this.btnTorqueMode.MinV = 0;
            this.btnTorqueMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTorqueMode.Name = "btnTorqueMode";
            this.btnTorqueMode.Size = new System.Drawing.Size(142, 43);
            this.btnTorqueMode.TabIndex = 209;
            this.btnTorqueMode.Text = "扭力模式";
            this.btnTorqueMode.UseVisualStyleBackColor = true;
            this.btnTorqueMode.Click += new System.EventHandler(this.btnTorqueMode_Click);
            // 
            // btnFreeMove
            // 
            this.btnFreeMove.AngleColor = System.Drawing.Color.Transparent;
            this.btnFreeMove.ButtonColor = System.Drawing.Color.White;
            this.btnFreeMove.Buttonmodel = 0;
            this.btnFreeMove.ClickColor = System.Drawing.Color.White;
            this.btnFreeMove.Constant = 0;
            this.btnFreeMove.Depth = 0;
            this.btnFreeMove.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.btnFreeMove.Location = new System.Drawing.Point(309, 43);
            this.btnFreeMove.MaxV = 0;
            this.btnFreeMove.MinV = 0;
            this.btnFreeMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFreeMove.Name = "btnFreeMove";
            this.btnFreeMove.Size = new System.Drawing.Size(142, 43);
            this.btnFreeMove.TabIndex = 217;
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
            this.btnLoosenMove.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.btnLoosenMove.Location = new System.Drawing.Point(161, 43);
            this.btnLoosenMove.MaxV = 0;
            this.btnLoosenMove.MinV = 0;
            this.btnLoosenMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoosenMove.Name = "btnLoosenMove";
            this.btnLoosenMove.Size = new System.Drawing.Size(142, 43);
            this.btnLoosenMove.TabIndex = 216;
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
            this.btnTightenMove.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold);
            this.btnTightenMove.Location = new System.Drawing.Point(13, 43);
            this.btnTightenMove.MaxV = 0;
            this.btnTightenMove.MinV = 0;
            this.btnTightenMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTightenMove.Name = "btnTightenMove";
            this.btnTightenMove.Size = new System.Drawing.Size(142, 43);
            this.btnTightenMove.TabIndex = 215;
            this.btnTightenMove.Text = "拧紧";
            this.btnTightenMove.UseVisualStyleBackColor = true;
            this.btnTightenMove.Click += new System.EventHandler(this.btnTightenMove_Click);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.lblTightenSignal);
            this.flowLayoutPanel5.Controls.Add(this.lblLoosenSignal);
            this.flowLayoutPanel5.Controls.Add(this.lblLdlingSignal);
            this.flowLayoutPanel5.Controls.Add(this.lblBusySignal);
            this.flowLayoutPanel5.Controls.Add(this.lblEndSignal);
            this.flowLayoutPanel5.Controls.Add(this.lblAlarmSignal);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(14, 98);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(879, 48);
            this.flowLayoutPanel5.TabIndex = 218;
            // 
            // lblTightenSignal
            // 
            this.lblTightenSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblTightenSignal.Font = new System.Drawing.Font("思源黑体 CN Bold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTightenSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTightenSignal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTightenSignal.Location = new System.Drawing.Point(3, 3);
            this.lblTightenSignal.Margin = new System.Windows.Forms.Padding(3);
            this.lblTightenSignal.Name = "lblTightenSignal";
            this.lblTightenSignal.Size = new System.Drawing.Size(140, 40);
            this.lblTightenSignal.TabIndex = 104;
            this.lblTightenSignal.Tag = "BackColor";
            this.lblTightenSignal.Text = "拧紧信号";
            this.lblTightenSignal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoosenSignal
            // 
            this.lblLoosenSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblLoosenSignal.Font = new System.Drawing.Font("思源黑体 CN Bold", 13F, System.Drawing.FontStyle.Bold);
            this.lblLoosenSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLoosenSignal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLoosenSignal.Location = new System.Drawing.Point(149, 3);
            this.lblLoosenSignal.Margin = new System.Windows.Forms.Padding(3);
            this.lblLoosenSignal.Name = "lblLoosenSignal";
            this.lblLoosenSignal.Size = new System.Drawing.Size(140, 40);
            this.lblLoosenSignal.TabIndex = 105;
            this.lblLoosenSignal.Tag = "BackColor";
            this.lblLoosenSignal.Text = "拧松信号";
            this.lblLoosenSignal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLdlingSignal
            // 
            this.lblLdlingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblLdlingSignal.Font = new System.Drawing.Font("思源黑体 CN Bold", 13F, System.Drawing.FontStyle.Bold);
            this.lblLdlingSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLdlingSignal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLdlingSignal.Location = new System.Drawing.Point(295, 3);
            this.lblLdlingSignal.Margin = new System.Windows.Forms.Padding(3);
            this.lblLdlingSignal.Name = "lblLdlingSignal";
            this.lblLdlingSignal.Size = new System.Drawing.Size(140, 40);
            this.lblLdlingSignal.TabIndex = 106;
            this.lblLdlingSignal.Tag = "BackColor";
            this.lblLdlingSignal.Text = "空转信号";
            this.lblLdlingSignal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBusySignal
            // 
            this.lblBusySignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblBusySignal.Font = new System.Drawing.Font("思源黑体 CN Bold", 13F, System.Drawing.FontStyle.Bold);
            this.lblBusySignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBusySignal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBusySignal.Location = new System.Drawing.Point(441, 3);
            this.lblBusySignal.Margin = new System.Windows.Forms.Padding(3);
            this.lblBusySignal.Name = "lblBusySignal";
            this.lblBusySignal.Size = new System.Drawing.Size(140, 40);
            this.lblBusySignal.TabIndex = 107;
            this.lblBusySignal.Tag = "BackColor";
            this.lblBusySignal.Text = "忙碌信号";
            this.lblBusySignal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEndSignal
            // 
            this.lblEndSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblEndSignal.Font = new System.Drawing.Font("思源黑体 CN Bold", 13F, System.Drawing.FontStyle.Bold);
            this.lblEndSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEndSignal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEndSignal.Location = new System.Drawing.Point(587, 3);
            this.lblEndSignal.Margin = new System.Windows.Forms.Padding(3);
            this.lblEndSignal.Name = "lblEndSignal";
            this.lblEndSignal.Size = new System.Drawing.Size(140, 40);
            this.lblEndSignal.TabIndex = 108;
            this.lblEndSignal.Tag = "BackColor";
            this.lblEndSignal.Text = "结束信号";
            this.lblEndSignal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlarmSignal
            // 
            this.lblAlarmSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblAlarmSignal.Font = new System.Drawing.Font("思源黑体 CN Bold", 13F, System.Drawing.FontStyle.Bold);
            this.lblAlarmSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAlarmSignal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAlarmSignal.Location = new System.Drawing.Point(733, 3);
            this.lblAlarmSignal.Margin = new System.Windows.Forms.Padding(3);
            this.lblAlarmSignal.Name = "lblAlarmSignal";
            this.lblAlarmSignal.Size = new System.Drawing.Size(140, 40);
            this.lblAlarmSignal.TabIndex = 109;
            this.lblAlarmSignal.Tag = "BackColor";
            this.lblAlarmSignal.Text = "报警信号";
            this.lblAlarmSignal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTorqueUnit
            // 
            this.lblTorqueUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblTorqueUnit.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoScrewSys.Properties.Settings.Default, "TorqueUnit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblTorqueUnit.Font = new System.Drawing.Font("思源黑体 CN Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTorqueUnit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTorqueUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTorqueUnit.Location = new System.Drawing.Point(441, 16);
            this.lblTorqueUnit.Name = "lblTorqueUnit";
            this.lblTorqueUnit.Size = new System.Drawing.Size(67, 33);
            this.lblTorqueUnit.TabIndex = 228;
            this.lblTorqueUnit.Text = global::AutoScrewSys.Properties.Settings.Default.TorqueUnit;
            this.lblTorqueUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScrewResultStr
            // 
            this.ScrewResultStr.BackColor = System.Drawing.Color.Transparent;
            this.ScrewResultStr.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AutoScrewSys.Properties.Settings.Default, "ResultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ScrewResultStr.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ScrewResultStr.ForeColor = global::AutoScrewSys.Properties.Settings.Default.ResultBackColor;
            this.ScrewResultStr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ScrewResultStr.Location = new System.Drawing.Point(526, 74);
            this.ScrewResultStr.Name = "ScrewResultStr";
            this.ScrewResultStr.Size = new System.Drawing.Size(111, 33);
            this.ScrewResultStr.TabIndex = 225;
            this.ScrewResultStr.Text = "OK";
            this.ScrewResultStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MonitorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(904, 276);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.btnFreeMove);
            this.Controls.Add(this.btnLoosenMove);
            this.Controls.Add(this.btnTightenMove);
            this.Controls.Add(this.btnTorqueMode);
            this.Controls.Add(this.customPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonitorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "监控与操作";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MonitorFrm_Load);
            this.customPanel1.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZimaBlueUI.CustomPanel customPanel1;
        private MaterialSkin.Controls.MaterialButtonpro btnTorqueMode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ElecBatchPower;
        private System.Windows.Forms.Label AlarmInfoStr;
        private System.Windows.Forms.Label ScrewResultStr;
        private System.Windows.Forms.Label Torque;
        private System.Windows.Forms.Label LapsNum;
        private System.Windows.Forms.Label RotateSpeed;
        private System.Windows.Forms.Label TaskNumber;
        private MaterialSkin.Controls.MaterialButtonpro btnFreeMove;
        private MaterialSkin.Controls.MaterialButtonpro btnLoosenMove;
        private MaterialSkin.Controls.MaterialButtonpro btnTightenMove;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label lblTightenSignal;
        private System.Windows.Forms.Label lblLoosenSignal;
        private System.Windows.Forms.Label lblLdlingSignal;
        private System.Windows.Forms.Label lblBusySignal;
        private System.Windows.Forms.Label lblEndSignal;
        private System.Windows.Forms.Label lblAlarmSignal;
        private System.Windows.Forms.Label lblTorqueUnit;
    }
}