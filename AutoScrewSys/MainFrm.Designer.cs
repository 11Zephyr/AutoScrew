using System.Drawing;

namespace AutoScrewSys
{
    partial class MainFm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFm));
            this.tpTitlebar = new ZimaBlueUI.Tpanel();
            this.btnToggleSize = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Panel();
            this.lblMesTextR = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.tpContainer = new ZimaBlueUI.Tpanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioBtnRunFrm = new System.Windows.Forms.RadioButton();
            this.radioBtnHistoryData = new System.Windows.Forms.RadioButton();
            this.radioBtnTaskParam = new System.Windows.Forms.RadioButton();
            this.radioBtnParamSet = new System.Windows.Forms.RadioButton();
            this.radioBtnIOMonitor = new System.Windows.Forms.RadioButton();
            this.radioBtnStatusAction = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioBtnLogin = new System.Windows.Forms.RadioButton();
            this.RT_Voltage = new System.Windows.Forms.Label();
            this.RealTVoltage = new System.Windows.Forms.Label();
            this.tpTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpTitlebar
            // 
            this.tpTitlebar.Alpha = 50;
            this.tpTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tpTitlebar.Controls.Add(this.RT_Voltage);
            this.tpTitlebar.Controls.Add(this.LogoPictureBox);
            this.tpTitlebar.Controls.Add(this.RealTVoltage);
            this.tpTitlebar.Controls.Add(this.btnToggleSize);
            this.tpTitlebar.Controls.Add(this.btnClose);
            this.tpTitlebar.Controls.Add(this.lblMesTextR);
            this.tpTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tpTitlebar.Location = new System.Drawing.Point(0, 0);
            this.tpTitlebar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tpTitlebar.Name = "tpTitlebar";
            this.tpTitlebar.PanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tpTitlebar.PanelBorderColor = System.Drawing.Color.Gray;
            this.tpTitlebar.PanelBorderRadius = 5F;
            this.tpTitlebar.PanelFont = new System.Drawing.Font("思源黑体 CN Bold", 30F);
            this.tpTitlebar.PanelOffsetY = 21F;
            this.tpTitlebar.PanelText = "";
            this.tpTitlebar.Size = new System.Drawing.Size(1535, 72);
            this.tpTitlebar.TabIndex = 1;
            this.tpTitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // btnToggleSize
            // 
            this.btnToggleSize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToggleSize.BackgroundImage")));
            this.btnToggleSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToggleSize.Location = new System.Drawing.Point(1374, 12);
            this.btnToggleSize.Name = "btnToggleSize";
            this.btnToggleSize.Size = new System.Drawing.Size(59, 52);
            this.btnToggleSize.TabIndex = 5;
            this.btnToggleSize.Click += new System.EventHandler(this.btnToggleSize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(1449, 12);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 52);
            this.btnClose.TabIndex = 4;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMesTextR
            // 
            this.lblMesTextR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblMesTextR.Font = new System.Drawing.Font("思源黑体 CN Bold", 18F, System.Drawing.FontStyle.Bold);
            this.lblMesTextR.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMesTextR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMesTextR.Location = new System.Drawing.Point(602, 6);
            this.lblMesTextR.Name = "lblMesTextR";
            this.lblMesTextR.Size = new System.Drawing.Size(386, 58);
            this.lblMesTextR.TabIndex = 39;
            this.lblMesTextR.Tag = "AccessibleName";
            this.lblMesTextR.Text = "SCREW  SYSTEM";
            this.lblMesTextR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMesTextR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(7, 7);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(149, 57);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 40;
            this.LogoPictureBox.TabStop = false;
            // 
            // tpContainer
            // 
            this.tpContainer.Alpha = 50;
            this.tpContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tpContainer.ForeColor = System.Drawing.SystemColors.Window;
            this.tpContainer.Location = new System.Drawing.Point(158, 71);
            this.tpContainer.Name = "tpContainer";
            this.tpContainer.PanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tpContainer.PanelBorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tpContainer.PanelBorderRadius = 5F;
            this.tpContainer.PanelFont = new System.Drawing.Font("思源黑体 CN Bold", 30F);
            this.tpContainer.PanelOffsetY = 21F;
            this.tpContainer.PanelText = "";
            this.tpContainer.Size = new System.Drawing.Size(1378, 753);
            this.tpContainer.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioBtnRunFrm);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnHistoryData);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnTaskParam);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnParamSet);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnIOMonitor);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnStatusAction);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 72);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(155, 753);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // radioBtnRunFrm
            // 
            this.radioBtnRunFrm.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnRunFrm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioBtnRunFrm.BackgroundImage")));
            this.radioBtnRunFrm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioBtnRunFrm.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnRunFrm.FlatAppearance.BorderSize = 0;
            this.radioBtnRunFrm.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioBtnRunFrm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnRunFrm.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnRunFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnRunFrm.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.radioBtnRunFrm.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnRunFrm.Location = new System.Drawing.Point(4, 4);
            this.radioBtnRunFrm.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnRunFrm.Name = "radioBtnRunFrm";
            this.radioBtnRunFrm.Size = new System.Drawing.Size(146, 51);
            this.radioBtnRunFrm.TabIndex = 6;
            this.radioBtnRunFrm.Tag = "0";
            this.radioBtnRunFrm.Text = "运行窗口";
            this.radioBtnRunFrm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtnRunFrm.UseVisualStyleBackColor = true;
            this.radioBtnRunFrm.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnHistoryData
            // 
            this.radioBtnHistoryData.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnHistoryData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioBtnHistoryData.BackgroundImage")));
            this.radioBtnHistoryData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioBtnHistoryData.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnHistoryData.FlatAppearance.BorderSize = 0;
            this.radioBtnHistoryData.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioBtnHistoryData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnHistoryData.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnHistoryData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnHistoryData.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.radioBtnHistoryData.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnHistoryData.Location = new System.Drawing.Point(4, 63);
            this.radioBtnHistoryData.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnHistoryData.Name = "radioBtnHistoryData";
            this.radioBtnHistoryData.Size = new System.Drawing.Size(146, 51);
            this.radioBtnHistoryData.TabIndex = 4;
            this.radioBtnHistoryData.Tag = "1";
            this.radioBtnHistoryData.Text = "历史数据";
            this.radioBtnHistoryData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtnHistoryData.UseVisualStyleBackColor = true;
            this.radioBtnHistoryData.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnTaskParam
            // 
            this.radioBtnTaskParam.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnTaskParam.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioBtnTaskParam.BackgroundImage")));
            this.radioBtnTaskParam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioBtnTaskParam.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnTaskParam.FlatAppearance.BorderSize = 0;
            this.radioBtnTaskParam.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioBtnTaskParam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnTaskParam.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnTaskParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnTaskParam.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.radioBtnTaskParam.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnTaskParam.Location = new System.Drawing.Point(4, 122);
            this.radioBtnTaskParam.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnTaskParam.Name = "radioBtnTaskParam";
            this.radioBtnTaskParam.Size = new System.Drawing.Size(146, 51);
            this.radioBtnTaskParam.TabIndex = 7;
            this.radioBtnTaskParam.Tag = "2";
            this.radioBtnTaskParam.Text = "任务参数";
            this.radioBtnTaskParam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtnTaskParam.UseVisualStyleBackColor = true;
            this.radioBtnTaskParam.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnParamSet
            // 
            this.radioBtnParamSet.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnParamSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioBtnParamSet.BackgroundImage")));
            this.radioBtnParamSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioBtnParamSet.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnParamSet.FlatAppearance.BorderSize = 0;
            this.radioBtnParamSet.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioBtnParamSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnParamSet.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnParamSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnParamSet.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.radioBtnParamSet.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnParamSet.Location = new System.Drawing.Point(4, 181);
            this.radioBtnParamSet.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnParamSet.Name = "radioBtnParamSet";
            this.radioBtnParamSet.Size = new System.Drawing.Size(146, 51);
            this.radioBtnParamSet.TabIndex = 8;
            this.radioBtnParamSet.Tag = "3";
            this.radioBtnParamSet.Text = "设置参数";
            this.radioBtnParamSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtnParamSet.UseVisualStyleBackColor = true;
            this.radioBtnParamSet.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnIOMonitor
            // 
            this.radioBtnIOMonitor.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnIOMonitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioBtnIOMonitor.BackgroundImage")));
            this.radioBtnIOMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioBtnIOMonitor.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnIOMonitor.FlatAppearance.BorderSize = 0;
            this.radioBtnIOMonitor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioBtnIOMonitor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnIOMonitor.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnIOMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnIOMonitor.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.radioBtnIOMonitor.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnIOMonitor.Location = new System.Drawing.Point(4, 240);
            this.radioBtnIOMonitor.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnIOMonitor.Name = "radioBtnIOMonitor";
            this.radioBtnIOMonitor.Size = new System.Drawing.Size(146, 51);
            this.radioBtnIOMonitor.TabIndex = 9;
            this.radioBtnIOMonitor.Text = "IO监控";
            this.radioBtnIOMonitor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtnIOMonitor.UseVisualStyleBackColor = true;
            this.radioBtnIOMonitor.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnStatusAction
            // 
            this.radioBtnStatusAction.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnStatusAction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioBtnStatusAction.BackgroundImage")));
            this.radioBtnStatusAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioBtnStatusAction.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnStatusAction.FlatAppearance.BorderSize = 0;
            this.radioBtnStatusAction.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioBtnStatusAction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnStatusAction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnStatusAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnStatusAction.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.radioBtnStatusAction.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnStatusAction.Location = new System.Drawing.Point(4, 299);
            this.radioBtnStatusAction.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnStatusAction.Name = "radioBtnStatusAction";
            this.radioBtnStatusAction.Size = new System.Drawing.Size(146, 51);
            this.radioBtnStatusAction.TabIndex = 10;
            this.radioBtnStatusAction.Text = "状态操作";
            this.radioBtnStatusAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtnStatusAction.UseVisualStyleBackColor = true;
            this.radioBtnStatusAction.Click += new System.EventHandler(this.radioBtnStatusAction_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioBtnLogin);
            this.panel1.Location = new System.Drawing.Point(3, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 393);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.tpTitlebar);
            this.panel2.Controls.Add(this.tpContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1535, 825);
            this.panel2.TabIndex = 3;
            // 
            // radioBtnLogin
            // 
            this.radioBtnLogin.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioBtnLogin.BackgroundImage")));
            this.radioBtnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioBtnLogin.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnLogin.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoScrewSys.Properties.Settings.Default, "UserLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioBtnLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radioBtnLogin.FlatAppearance.BorderSize = 0;
            this.radioBtnLogin.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioBtnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnLogin.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.radioBtnLogin.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnLogin.Location = new System.Drawing.Point(0, 342);
            this.radioBtnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtnLogin.Name = "radioBtnLogin";
            this.radioBtnLogin.Size = new System.Drawing.Size(153, 51);
            this.radioBtnLogin.TabIndex = 11;
            this.radioBtnLogin.Text = global::AutoScrewSys.Properties.Settings.Default.UserLevel;
            this.radioBtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtnLogin.UseVisualStyleBackColor = true;
            this.radioBtnLogin.Click += new System.EventHandler(this.radioBtnLogin_Click);
            // 
            // RT_Voltage
            // 
            this.RT_Voltage.BackColor = System.Drawing.Color.Transparent;
            this.RT_Voltage.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AutoScrewSys.Properties.Settings.Default, "RTVoltageColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RT_Voltage.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RT_Voltage.ForeColor = global::AutoScrewSys.Properties.Settings.Default.RTVoltageColor;
            this.RT_Voltage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RT_Voltage.Location = new System.Drawing.Point(168, 21);
            this.RT_Voltage.Name = "RT_Voltage";
            this.RT_Voltage.Size = new System.Drawing.Size(79, 33);
            this.RT_Voltage.TabIndex = 230;
            this.RT_Voltage.Text = "V (RT)";
            this.RT_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RealTVoltage
            // 
            this.RealTVoltage.BackColor = System.Drawing.Color.Transparent;
            this.RealTVoltage.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AutoScrewSys.Properties.Settings.Default, "RTVoltageColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RealTVoltage.Font = new System.Drawing.Font("思源黑体 CN Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RealTVoltage.ForeColor = global::AutoScrewSys.Properties.Settings.Default.RTVoltageColor;
            this.RealTVoltage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RealTVoltage.Location = new System.Drawing.Point(253, 21);
            this.RealTVoltage.Name = "RealTVoltage";
            this.RealTVoltage.Size = new System.Drawing.Size(88, 33);
            this.RealTVoltage.TabIndex = 229;
            this.RealTVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainFm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1535, 825);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("思源黑体 CN Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainFm_Load);
            this.tpTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ZimaBlueUI.Tpanel tpTitlebar;
        private System.Windows.Forms.Label lblMesTextR;
        private ZimaBlueUI.Tpanel tpContainer;
        private System.Windows.Forms.Panel btnClose;
        private System.Windows.Forms.Panel btnToggleSize;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioBtnRunFrm;
        private System.Windows.Forms.RadioButton radioBtnHistoryData;
        private System.Windows.Forms.RadioButton radioBtnTaskParam;
        private System.Windows.Forms.RadioButton radioBtnParamSet;
        private System.Windows.Forms.RadioButton radioBtnIOMonitor;
        private System.Windows.Forms.RadioButton radioBtnStatusAction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label RT_Voltage;
        private System.Windows.Forms.Label RealTVoltage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioBtnLogin;
    }
}

