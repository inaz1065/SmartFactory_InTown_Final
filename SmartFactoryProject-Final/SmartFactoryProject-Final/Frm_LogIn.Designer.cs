namespace SmartFactoryProject_Final
{
    partial class FRM_LogIn
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_ID = new System.Windows.Forms.TextBox();
            this.Txt_PW = new System.Windows.Forms.TextBox();
            this.Btn_LogIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 22F);
            this.label1.Location = new System.Drawing.Point(39, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 22F);
            this.label2.Location = new System.Drawing.Point(28, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "PW";
            // 
            // Txt_ID
            // 
            this.Txt_ID.BackColor = System.Drawing.Color.Khaki;
            this.Txt_ID.Font = new System.Drawing.Font("굴림", 22F);
            this.Txt_ID.Location = new System.Drawing.Point(138, 38);
            this.Txt_ID.Name = "Txt_ID";
            this.Txt_ID.Size = new System.Drawing.Size(355, 50);
            this.Txt_ID.TabIndex = 4;
            this.Txt_ID.Click += new System.EventHandler(this.Txt_ID_Click);
            // 
            // Txt_PW
            // 
            this.Txt_PW.BackColor = System.Drawing.Color.Khaki;
            this.Txt_PW.Font = new System.Drawing.Font("굴림", 22F);
            this.Txt_PW.Location = new System.Drawing.Point(138, 113);
            this.Txt_PW.Name = "Txt_PW";
            this.Txt_PW.PasswordChar = '●';
            this.Txt_PW.Size = new System.Drawing.Size(355, 50);
            this.Txt_PW.TabIndex = 5;
            this.Txt_PW.Click += new System.EventHandler(this.Txt_PW_Click);
            // 
            // Btn_LogIn
            // 
            this.Btn_LogIn.Location = new System.Drawing.Point(533, 38);
            this.Btn_LogIn.Name = "Btn_LogIn";
            this.Btn_LogIn.Size = new System.Drawing.Size(125, 125);
            this.Btn_LogIn.TabIndex = 6;
            this.Btn_LogIn.Text = "로그인";
            this.Btn_LogIn.UseVisualStyleBackColor = true;
            this.Btn_LogIn.Click += new System.EventHandler(this.Btn_LogIn_Click);
            // 
            // Frm_LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 208);
            this.Controls.Add(this.Btn_LogIn);
            this.Controls.Add(this.Txt_PW);
            this.Controls.Add(this.Txt_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_LogIn";
            this.ShowIcon = false;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_ID;
        private System.Windows.Forms.TextBox Txt_PW;
        private System.Windows.Forms.Button Btn_LogIn;
    }
}

