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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorFrm));
            this.customPanel1 = new ZimaBlueUI.CustomPanel();
            this.lblTorqueUnit = new System.Windows.Forms.Label();
            this.ElecBatchPower = new System.Windows.Forms.Label();
            this.AlarmInfoStr = new System.Windows.Forms.Label();
            this.ScrewResultStr = new System.Windows.Forms.Label();
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
            this.customPanel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // customPanel1
            // 
            resources.ApplyResources(this.customPanel1, "customPanel1");
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
            this.customPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.RowCount = 2;
            // 
            // lblTorqueUnit
            // 
            resources.ApplyResources(this.lblTorqueUnit, "lblTorqueUnit");
            this.lblTorqueUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblTorqueUnit.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoScrewSys.Properties.Settings.Default, "TorqueUnit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblTorqueUnit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTorqueUnit.Name = "lblTorqueUnit";
            this.lblTorqueUnit.Text = global::AutoScrewSys.Properties.Settings.Default.TorqueUnit;
            // 
            // ElecBatchPower
            // 
            resources.ApplyResources(this.ElecBatchPower, "ElecBatchPower");
            this.ElecBatchPower.BackColor = System.Drawing.Color.Transparent;
            this.ElecBatchPower.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ElecBatchPower.Name = "ElecBatchPower";
            // 
            // AlarmInfoStr
            // 
            resources.ApplyResources(this.AlarmInfoStr, "AlarmInfoStr");
            this.AlarmInfoStr.BackColor = System.Drawing.Color.Transparent;
            this.AlarmInfoStr.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AlarmInfoStr.Name = "AlarmInfoStr";
            // 
            // ScrewResultStr
            // 
            resources.ApplyResources(this.ScrewResultStr, "ScrewResultStr");
            this.ScrewResultStr.BackColor = System.Drawing.Color.Transparent;
            this.ScrewResultStr.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AutoScrewSys.Properties.Settings.Default, "ResultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ScrewResultStr.ForeColor = global::AutoScrewSys.Properties.Settings.Default.ResultBackColor;
            this.ScrewResultStr.Name = "ScrewResultStr";
            // 
            // Torque
            // 
            resources.ApplyResources(this.Torque, "Torque");
            this.Torque.BackColor = System.Drawing.Color.Transparent;
            this.Torque.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Torque.Name = "Torque";
            // 
            // LapsNum
            // 
            resources.ApplyResources(this.LapsNum, "LapsNum");
            this.LapsNum.BackColor = System.Drawing.Color.Transparent;
            this.LapsNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LapsNum.Name = "LapsNum";
            // 
            // RotateSpeed
            // 
            resources.ApplyResources(this.RotateSpeed, "RotateSpeed");
            this.RotateSpeed.BackColor = System.Drawing.Color.Transparent;
            this.RotateSpeed.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RotateSpeed.Name = "RotateSpeed";
            // 
            // TaskNumber
            // 
            resources.ApplyResources(this.TaskNumber, "TaskNumber");
            this.TaskNumber.BackColor = System.Drawing.Color.Transparent;
            this.TaskNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TaskNumber.Name = "TaskNumber";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Name = "label16";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Name = "label8";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Name = "label15";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Name = "label4";
            // 
            // btnTorqueMode
            // 
            resources.ApplyResources(this.btnTorqueMode, "btnTorqueMode");
            this.btnTorqueMode.AngleColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnTorqueMode.ButtonColor = System.Drawing.Color.White;
            this.btnTorqueMode.Buttonmodel = 0;
            this.btnTorqueMode.ClickColor = System.Drawing.Color.White;
            this.btnTorqueMode.Constant = 0;
            this.btnTorqueMode.Depth = 0;
            this.btnTorqueMode.MaxV = 0;
            this.btnTorqueMode.MinV = 0;
            this.btnTorqueMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTorqueMode.Name = "btnTorqueMode";
            this.btnTorqueMode.UseVisualStyleBackColor = true;
            this.btnTorqueMode.Click += new System.EventHandler(this.btnTorqueMode_Click);
            // 
            // btnFreeMove
            // 
            resources.ApplyResources(this.btnFreeMove, "btnFreeMove");
            this.btnFreeMove.AngleColor = System.Drawing.Color.Transparent;
            this.btnFreeMove.ButtonColor = System.Drawing.Color.White;
            this.btnFreeMove.Buttonmodel = 0;
            this.btnFreeMove.ClickColor = System.Drawing.Color.White;
            this.btnFreeMove.Constant = 0;
            this.btnFreeMove.Depth = 0;
            this.btnFreeMove.MaxV = 0;
            this.btnFreeMove.MinV = 0;
            this.btnFreeMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFreeMove.Name = "btnFreeMove";
            this.btnFreeMove.UseVisualStyleBackColor = true;
            this.btnFreeMove.Click += new System.EventHandler(this.btnFreeMove_Click);
            // 
            // btnLoosenMove
            // 
            resources.ApplyResources(this.btnLoosenMove, "btnLoosenMove");
            this.btnLoosenMove.AngleColor = System.Drawing.Color.Transparent;
            this.btnLoosenMove.ButtonColor = System.Drawing.Color.White;
            this.btnLoosenMove.Buttonmodel = 0;
            this.btnLoosenMove.ClickColor = System.Drawing.Color.White;
            this.btnLoosenMove.Constant = 0;
            this.btnLoosenMove.Depth = 0;
            this.btnLoosenMove.MaxV = 0;
            this.btnLoosenMove.MinV = 0;
            this.btnLoosenMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoosenMove.Name = "btnLoosenMove";
            this.btnLoosenMove.UseVisualStyleBackColor = true;
            this.btnLoosenMove.Click += new System.EventHandler(this.btnLoosenMove_Click);
            // 
            // btnTightenMove
            // 
            resources.ApplyResources(this.btnTightenMove, "btnTightenMove");
            this.btnTightenMove.AngleColor = System.Drawing.Color.Transparent;
            this.btnTightenMove.ButtonColor = System.Drawing.Color.White;
            this.btnTightenMove.Buttonmodel = 0;
            this.btnTightenMove.ClickColor = System.Drawing.Color.White;
            this.btnTightenMove.Constant = 0;
            this.btnTightenMove.Depth = 0;
            this.btnTightenMove.MaxV = 0;
            this.btnTightenMove.MinV = 0;
            this.btnTightenMove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTightenMove.Name = "btnTightenMove";
            this.btnTightenMove.UseVisualStyleBackColor = true;
            this.btnTightenMove.Click += new System.EventHandler(this.btnTightenMove_Click);
            // 
            // flowLayoutPanel5
            // 
            resources.ApplyResources(this.flowLayoutPanel5, "flowLayoutPanel5");
            this.flowLayoutPanel5.Controls.Add(this.lblTightenSignal);
            this.flowLayoutPanel5.Controls.Add(this.lblLoosenSignal);
            this.flowLayoutPanel5.Controls.Add(this.lblLdlingSignal);
            this.flowLayoutPanel5.Controls.Add(this.lblBusySignal);
            this.flowLayoutPanel5.Controls.Add(this.lblEndSignal);
            this.flowLayoutPanel5.Controls.Add(this.lblAlarmSignal);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            // 
            // lblTightenSignal
            // 
            resources.ApplyResources(this.lblTightenSignal, "lblTightenSignal");
            this.lblTightenSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblTightenSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTightenSignal.Name = "lblTightenSignal";
            this.lblTightenSignal.Tag = "BackColor";
            // 
            // lblLoosenSignal
            // 
            resources.ApplyResources(this.lblLoosenSignal, "lblLoosenSignal");
            this.lblLoosenSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblLoosenSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLoosenSignal.Name = "lblLoosenSignal";
            this.lblLoosenSignal.Tag = "BackColor";
            // 
            // lblLdlingSignal
            // 
            resources.ApplyResources(this.lblLdlingSignal, "lblLdlingSignal");
            this.lblLdlingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblLdlingSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLdlingSignal.Name = "lblLdlingSignal";
            this.lblLdlingSignal.Tag = "BackColor";
            // 
            // lblBusySignal
            // 
            resources.ApplyResources(this.lblBusySignal, "lblBusySignal");
            this.lblBusySignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblBusySignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBusySignal.Name = "lblBusySignal";
            this.lblBusySignal.Tag = "BackColor";
            // 
            // lblEndSignal
            // 
            resources.ApplyResources(this.lblEndSignal, "lblEndSignal");
            this.lblEndSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblEndSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEndSignal.Name = "lblEndSignal";
            this.lblEndSignal.Tag = "BackColor";
            // 
            // lblAlarmSignal
            // 
            resources.ApplyResources(this.lblAlarmSignal, "lblAlarmSignal");
            this.lblAlarmSignal.BackColor = System.Drawing.Color.DarkGray;
            this.lblAlarmSignal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAlarmSignal.Name = "lblAlarmSignal";
            this.lblAlarmSignal.Tag = "BackColor";
            // 
            // MonitorFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.btnFreeMove);
            this.Controls.Add(this.btnLoosenMove);
            this.Controls.Add(this.btnTightenMove);
            this.Controls.Add(this.btnTorqueMode);
            this.Controls.Add(this.customPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonitorFrm";
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