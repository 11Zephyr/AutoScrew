using AutoScrewSys.Base;

namespace ZimaBlueScrew
{
    partial class LoadFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadFrm));
            this.zRoundPanel3 = new ZimaBlueUI.ZRoundPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.versionlabel = new System.Windows.Forms.Label();
            this.zmProgressBar1 = new AutoScrewSys.Base.ZMProgressBar();
            this.zRoundPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // zRoundPanel3
            // 
            resources.ApplyResources(this.zRoundPanel3, "zRoundPanel3");
            this.zRoundPanel3.BackColor = System.Drawing.Color.Transparent;
            this.zRoundPanel3.Controls.Add(this.label9);
            this.zRoundPanel3.Controls.Add(this.versionlabel);
            this.zRoundPanel3.Controls.Add(this.zmProgressBar1);
            this.zRoundPanel3.Name = "zRoundPanel3";
            this.zRoundPanel3.PanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.zRoundPanel3.PanelBorderColor = System.Drawing.Color.White;
            this.zRoundPanel3.PanelBorderRadius = 15F;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Name = "label9";
            // 
            // versionlabel
            // 
            resources.ApplyResources(this.versionlabel, "versionlabel");
            this.versionlabel.BackColor = System.Drawing.Color.Transparent;
            this.versionlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.versionlabel.Name = "versionlabel";
            // 
            // zmProgressBar1
            // 
            resources.ApplyResources(this.zmProgressBar1, "zmProgressBar1");
            this.zmProgressBar1.Depth = 0;
            this.zmProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.zmProgressBar1.Name = "zmProgressBar1";
            this.zmProgressBar1.Step = 1;
            this.zmProgressBar1.Value = 5;
            // 
            // LoadFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.zRoundPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadFrm";
            this.Opacity = 0.8D;
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.LoadFrm_Load);
            this.zRoundPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZMProgressBar zmProgressBar1;
        private ZimaBlueUI.ZRoundPanel zRoundPanel3;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.Label label9;
    }
}