namespace SmartFactoryProject_Final
{
    partial class FRM_Main
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
            this.Btn_Logout = new System.Windows.Forms.Button();
            this.Btn_Process = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // Btn_Logout
            // 
            this.Btn_Logout.Location = new System.Drawing.Point(1179, 4);
            this.Btn_Logout.Name = "Btn_Logout";
            this.Btn_Logout.Size = new System.Drawing.Size(80, 40);
            this.Btn_Logout.TabIndex = 0;
            this.Btn_Logout.Text = "로그아웃";
            this.Btn_Logout.UseVisualStyleBackColor = true;
            this.Btn_Logout.Click += new System.EventHandler(this.Btn_Logout_Click);
            // 
            // Btn_Process
            // 
            this.Btn_Process.Location = new System.Drawing.Point(1093, 4);
            this.Btn_Process.Name = "Btn_Process";
            this.Btn_Process.Size = new System.Drawing.Size(80, 40);
            this.Btn_Process.TabIndex = 2;
            this.Btn_Process.Text = "공정확인";
            this.Btn_Process.UseVisualStyleBackColor = true;
            this.Btn_Process.Click += new System.EventHandler(this.Btn_Process_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 80);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 977);
            this.Controls.Add(this.Btn_Process);
            this.Controls.Add(this.Btn_Logout);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.Padding = new System.Windows.Forms.Padding(0, 48, 0, 0);
            this.Text = "Frm_Main";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Logout;
        private System.Windows.Forms.Button Btn_Process;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}