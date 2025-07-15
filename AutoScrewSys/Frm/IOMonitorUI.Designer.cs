namespace AutoScrewSys.Frm
{
    partial class IOMonitorUI
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
            this.customPanel1 = new ZimaBlueUI.CustomPanel();
            this.SuspendLayout();
            // 
            // customPanel1
            // 
            this.customPanel1.ColumnCount = 2;
            this.customPanel1.CornerRadius = 10;
            this.customPanel1.FillColor = System.Drawing.Color.LightBlue;
            this.customPanel1.Location = new System.Drawing.Point(344, 134);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.RowCount = 7;
            this.customPanel1.Size = new System.Drawing.Size(689, 449);
            this.customPanel1.TabIndex = 0;
            // 
            // IOMonitorUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.customPanel1);
            this.Name = "IOMonitorUI";
            this.Size = new System.Drawing.Size(1378, 753);
            this.ResumeLayout(false);

        }

        #endregion

        private ZimaBlueUI.CustomPanel customPanel1;
    }
}
