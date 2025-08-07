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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Panel();
            this.btnMax = new System.Windows.Forms.Panel();
            this.btnToggleSize = new System.Windows.Forms.Panel();
            this.RT_Voltage = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.RealTVoltage = new System.Windows.Forms.Label();
            this.lblMesTextR = new System.Windows.Forms.Label();
            this.tpContainer = new ZimaBlueUI.Tpanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioBtnRunFrm = new System.Windows.Forms.RadioButton();
            this.radioBtnHistoryData = new System.Windows.Forms.RadioButton();
            this.radioBtnTaskParam = new System.Windows.Forms.RadioButton();
            this.radioBtnParamSet = new System.Windows.Forms.RadioButton();
            this.radioBtnIOMonitor = new System.Windows.Forms.RadioButton();
            this.radioBtnStatusAction = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioBtnLogin = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tpTitlebar.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.tpTitlebar.Controls.Add(this.flowLayoutPanel2);
            this.tpTitlebar.Controls.Add(this.RT_Voltage);
            this.tpTitlebar.Controls.Add(this.LogoPictureBox);
            this.tpTitlebar.Controls.Add(this.RealTVoltage);
            this.tpTitlebar.Controls.Add(this.lblMesTextR);
            resources.ApplyResources(this.tpTitlebar, "tpTitlebar");
            this.tpTitlebar.Name = "tpTitlebar";
            this.tpTitlebar.PanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tpTitlebar.PanelBorderColor = System.Drawing.Color.Gray;
            this.tpTitlebar.PanelBorderRadius = 5F;
            this.tpTitlebar.PanelFont = new System.Drawing.Font("思源黑体 CN Bold", 30F);
            this.tpTitlebar.PanelOffsetY = 21F;
            this.tpTitlebar.PanelText = "";
            this.tpTitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnMax);
            this.flowLayoutPanel2.Controls.Add(this.btnToggleSize);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMax
            // 
            resources.ApplyResources(this.btnMax, "btnMax");
            this.btnMax.Name = "btnMax";
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnToggleSize
            // 
            resources.ApplyResources(this.btnToggleSize, "btnToggleSize");
            this.btnToggleSize.Name = "btnToggleSize";
            this.btnToggleSize.Click += new System.EventHandler(this.btnToggleSize_Click);
            // 
            // RT_Voltage
            // 
            this.RT_Voltage.BackColor = System.Drawing.Color.Transparent;
            this.RT_Voltage.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AutoScrewSys.Properties.Settings.Default, "RTVoltageColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.RT_Voltage, "RT_Voltage");
            this.RT_Voltage.ForeColor = global::AutoScrewSys.Properties.Settings.Default.RTVoltageColor;
            this.RT_Voltage.Name = "RT_Voltage";
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.LogoPictureBox, "LogoPictureBox");
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.TabStop = false;
            // 
            // RealTVoltage
            // 
            this.RealTVoltage.BackColor = System.Drawing.Color.Transparent;
            this.RealTVoltage.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AutoScrewSys.Properties.Settings.Default, "RTVoltageColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.RealTVoltage, "RealTVoltage");
            this.RealTVoltage.ForeColor = global::AutoScrewSys.Properties.Settings.Default.RTVoltageColor;
            this.RealTVoltage.Name = "RealTVoltage";
            // 
            // lblMesTextR
            // 
            this.lblMesTextR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            resources.ApplyResources(this.lblMesTextR, "lblMesTextR");
            this.lblMesTextR.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMesTextR.Name = "lblMesTextR";
            this.lblMesTextR.Tag = "AccessibleName";
            this.lblMesTextR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // tpContainer
            // 
            this.tpContainer.Alpha = 50;
            this.tpContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tpContainer.ForeColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tpContainer, "tpContainer");
            this.tpContainer.Name = "tpContainer";
            this.tpContainer.PanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tpContainer.PanelBorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tpContainer.PanelBorderRadius = 5F;
            this.tpContainer.PanelFont = new System.Drawing.Font("思源黑体 CN Bold", 30F);
            this.tpContainer.PanelOffsetY = 21F;
            this.tpContainer.PanelText = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.radioBtnRunFrm);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnHistoryData);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnTaskParam);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnParamSet);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnIOMonitor);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnStatusAction);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioBtnRunFrm
            // 
            resources.ApplyResources(this.radioBtnRunFrm, "radioBtnRunFrm");
            this.radioBtnRunFrm.FlatAppearance.BorderSize = 0;
            this.radioBtnRunFrm.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnRunFrm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnRunFrm.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnRunFrm.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnRunFrm.Name = "radioBtnRunFrm";
            this.radioBtnRunFrm.Tag = "0";
            this.radioBtnRunFrm.UseVisualStyleBackColor = true;
            this.radioBtnRunFrm.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnHistoryData
            // 
            resources.ApplyResources(this.radioBtnHistoryData, "radioBtnHistoryData");
            this.radioBtnHistoryData.FlatAppearance.BorderSize = 0;
            this.radioBtnHistoryData.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnHistoryData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnHistoryData.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnHistoryData.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnHistoryData.Name = "radioBtnHistoryData";
            this.radioBtnHistoryData.Tag = "1";
            this.radioBtnHistoryData.UseVisualStyleBackColor = true;
            this.radioBtnHistoryData.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnTaskParam
            // 
            resources.ApplyResources(this.radioBtnTaskParam, "radioBtnTaskParam");
            this.radioBtnTaskParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.radioBtnTaskParam.FlatAppearance.BorderSize = 0;
            this.radioBtnTaskParam.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnTaskParam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnTaskParam.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnTaskParam.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnTaskParam.Name = "radioBtnTaskParam";
            this.radioBtnTaskParam.Tag = "2";
            this.radioBtnTaskParam.UseVisualStyleBackColor = false;
            this.radioBtnTaskParam.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnParamSet
            // 
            resources.ApplyResources(this.radioBtnParamSet, "radioBtnParamSet");
            this.radioBtnParamSet.FlatAppearance.BorderSize = 0;
            this.radioBtnParamSet.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnParamSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnParamSet.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnParamSet.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnParamSet.Name = "radioBtnParamSet";
            this.radioBtnParamSet.Tag = "3";
            this.radioBtnParamSet.UseVisualStyleBackColor = true;
            this.radioBtnParamSet.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnIOMonitor
            // 
            resources.ApplyResources(this.radioBtnIOMonitor, "radioBtnIOMonitor");
            this.radioBtnIOMonitor.FlatAppearance.BorderSize = 0;
            this.radioBtnIOMonitor.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnIOMonitor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnIOMonitor.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnIOMonitor.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnIOMonitor.Name = "radioBtnIOMonitor";
            this.radioBtnIOMonitor.UseVisualStyleBackColor = true;
            this.radioBtnIOMonitor.CheckedChanged += new System.EventHandler(this.radioBtnPageChoose);
            // 
            // radioBtnStatusAction
            // 
            resources.ApplyResources(this.radioBtnStatusAction, "radioBtnStatusAction");
            this.radioBtnStatusAction.FlatAppearance.BorderSize = 0;
            this.radioBtnStatusAction.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.radioBtnStatusAction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnStatusAction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnStatusAction.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnStatusAction.Name = "radioBtnStatusAction";
            this.radioBtnStatusAction.UseVisualStyleBackColor = true;
            this.radioBtnStatusAction.Click += new System.EventHandler(this.radioBtnStatusAction_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioBtnLogin);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // radioBtnLogin
            // 
            resources.ApplyResources(this.radioBtnLogin, "radioBtnLogin");
            this.radioBtnLogin.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoScrewSys.Properties.Settings.Default, "UserLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioBtnLogin.FlatAppearance.BorderSize = 0;
            this.radioBtnLogin.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioBtnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioBtnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBtnLogin.ForeColor = System.Drawing.SystemColors.Window;
            this.radioBtnLogin.Name = "radioBtnLogin";
            this.radioBtnLogin.Text = global::AutoScrewSys.Properties.Settings.Default.UserLevel;
            this.radioBtnLogin.UseVisualStyleBackColor = true;
            this.radioBtnLogin.Click += new System.EventHandler(this.radioBtnLogin_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.tpTitlebar);
            this.panel2.Controls.Add(this.tpContainer);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // MainFm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainFm";
            this.Load += new System.EventHandler(this.MainFm_Load);
            this.Shown += new System.EventHandler(this.MainFm_Shown);
            this.Resize += new System.EventHandler(this.MainFm_Resize);
            this.tpTitlebar.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel btnMax;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

