namespace SmartFactoryProject_Final
{
    partial class FRM_Process
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
            this.components = new System.ComponentModel.Container();
            this.Lbl_CurrentTime = new System.Windows.Forms.Label();
            this.Lbl_Order = new System.Windows.Forms.Label();
            this.Lbl_Proc = new System.Windows.Forms.Label();
            this.Lbl_ItemCode = new System.Windows.Forms.Label();
            this.Lbl_ItemName = new System.Windows.Forms.Label();
            this.Lbl_TotalAmount = new System.Windows.Forms.Label();
            this.Lbl_NormalAmount = new System.Windows.Forms.Label();
            this.Lbl_DefectAmount = new System.Windows.Forms.Label();
            this.Txt_DefectAmount = new System.Windows.Forms.TextBox();
            this.Txt_NormalAmount = new System.Windows.Forms.TextBox();
            this.Txt_TotalAmount = new System.Windows.Forms.TextBox();
            this.Txt_ItemCode = new System.Windows.Forms.TextBox();
            this.Txt_ItemName = new System.Windows.Forms.TextBox();
            this.Cmb_Order = new System.Windows.Forms.ComboBox();
            this.Txt_ProcName = new System.Windows.Forms.TextBox();
            this.Cmb_Machine = new System.Windows.Forms.ComboBox();
            this.Txt_CurrentTime = new System.Windows.Forms.TextBox();
            this.Tim_PerSec = new System.Windows.Forms.Timer(this.components);
            this.Btn_OrderStart = new System.Windows.Forms.Button();
            this.Lbl_Dies = new System.Windows.Forms.Label();
            this.Pic_Dies = new System.Windows.Forms.PictureBox();
            this.Txt_TargetAmount = new System.Windows.Forms.TextBox();
            this.Lbl_TargetAmount = new System.Windows.Forms.Label();
            this.Tim_Per3Sec = new System.Windows.Forms.Timer(this.components);
            this.Tab_Data = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Dies)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_CurrentTime
            // 
            this.Lbl_CurrentTime.AutoSize = true;
            this.Lbl_CurrentTime.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CurrentTime.Location = new System.Drawing.Point(150, 132);
            this.Lbl_CurrentTime.Name = "Lbl_CurrentTime";
            this.Lbl_CurrentTime.Size = new System.Drawing.Size(72, 15);
            this.Lbl_CurrentTime.TabIndex = 0;
            this.Lbl_CurrentTime.Text = "현재 시각";
            // 
            // Lbl_Order
            // 
            this.Lbl_Order.AutoSize = true;
            this.Lbl_Order.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Order.Location = new System.Drawing.Point(153, 202);
            this.Lbl_Order.Name = "Lbl_Order";
            this.Lbl_Order.Size = new System.Drawing.Size(67, 15);
            this.Lbl_Order.TabIndex = 1;
            this.Lbl_Order.Text = "작업지시";
            // 
            // Lbl_Proc
            // 
            this.Lbl_Proc.AutoSize = true;
            this.Lbl_Proc.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Proc.Location = new System.Drawing.Point(565, 202);
            this.Lbl_Proc.Name = "Lbl_Proc";
            this.Lbl_Proc.Size = new System.Drawing.Size(92, 15);
            this.Lbl_Proc.TabIndex = 2;
            this.Lbl_Proc.Text = "공정 및 기기";
            // 
            // Lbl_ItemCode
            // 
            this.Lbl_ItemCode.AutoSize = true;
            this.Lbl_ItemCode.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_ItemCode.Location = new System.Drawing.Point(168, 242);
            this.Lbl_ItemCode.Name = "Lbl_ItemCode";
            this.Lbl_ItemCode.Size = new System.Drawing.Size(37, 15);
            this.Lbl_ItemCode.TabIndex = 4;
            this.Lbl_ItemCode.Text = "품번";
            // 
            // Lbl_ItemName
            // 
            this.Lbl_ItemName.AutoSize = true;
            this.Lbl_ItemName.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_ItemName.Location = new System.Drawing.Point(168, 282);
            this.Lbl_ItemName.Name = "Lbl_ItemName";
            this.Lbl_ItemName.Size = new System.Drawing.Size(37, 15);
            this.Lbl_ItemName.TabIndex = 5;
            this.Lbl_ItemName.Text = "품명";
            // 
            // Lbl_TotalAmount
            // 
            this.Lbl_TotalAmount.AutoSize = true;
            this.Lbl_TotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_TotalAmount.Location = new System.Drawing.Point(148, 360);
            this.Lbl_TotalAmount.Name = "Lbl_TotalAmount";
            this.Lbl_TotalAmount.Size = new System.Drawing.Size(72, 15);
            this.Lbl_TotalAmount.TabIndex = 6;
            this.Lbl_TotalAmount.Text = "총 생산량";
            // 
            // Lbl_NormalAmount
            // 
            this.Lbl_NormalAmount.AutoSize = true;
            this.Lbl_NormalAmount.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_NormalAmount.Location = new System.Drawing.Point(347, 330);
            this.Lbl_NormalAmount.Name = "Lbl_NormalAmount";
            this.Lbl_NormalAmount.Size = new System.Drawing.Size(57, 15);
            this.Lbl_NormalAmount.TabIndex = 7;
            this.Lbl_NormalAmount.Text = "양품 수";
            // 
            // Lbl_DefectAmount
            // 
            this.Lbl_DefectAmount.AutoSize = true;
            this.Lbl_DefectAmount.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_DefectAmount.Location = new System.Drawing.Point(332, 360);
            this.Lbl_DefectAmount.Name = "Lbl_DefectAmount";
            this.Lbl_DefectAmount.Size = new System.Drawing.Size(72, 15);
            this.Lbl_DefectAmount.TabIndex = 8;
            this.Lbl_DefectAmount.Text = "불량품 수";
            // 
            // Txt_DefectAmount
            // 
            this.Txt_DefectAmount.BackColor = System.Drawing.Color.Khaki;
            this.Txt_DefectAmount.Location = new System.Drawing.Point(410, 356);
            this.Txt_DefectAmount.Name = "Txt_DefectAmount";
            this.Txt_DefectAmount.Size = new System.Drawing.Size(100, 25);
            this.Txt_DefectAmount.TabIndex = 9;
            this.Txt_DefectAmount.Click += new System.EventHandler(this.Txt_DefectAmount_Click);
            this.Txt_DefectAmount.TextChanged += new System.EventHandler(this.Txt_DefectAmount_TextChanged);
            // 
            // Txt_NormalAmount
            // 
            this.Txt_NormalAmount.Location = new System.Drawing.Point(410, 325);
            this.Txt_NormalAmount.Name = "Txt_NormalAmount";
            this.Txt_NormalAmount.Size = new System.Drawing.Size(100, 25);
            this.Txt_NormalAmount.TabIndex = 10;
            // 
            // Txt_TotalAmount
            // 
            this.Txt_TotalAmount.Location = new System.Drawing.Point(226, 356);
            this.Txt_TotalAmount.Name = "Txt_TotalAmount";
            this.Txt_TotalAmount.Size = new System.Drawing.Size(100, 25);
            this.Txt_TotalAmount.TabIndex = 11;
            // 
            // Txt_ItemCode
            // 
            this.Txt_ItemCode.Location = new System.Drawing.Point(250, 237);
            this.Txt_ItemCode.Name = "Txt_ItemCode";
            this.Txt_ItemCode.Size = new System.Drawing.Size(260, 25);
            this.Txt_ItemCode.TabIndex = 12;
            // 
            // Txt_ItemName
            // 
            this.Txt_ItemName.Location = new System.Drawing.Point(250, 277);
            this.Txt_ItemName.Name = "Txt_ItemName";
            this.Txt_ItemName.Size = new System.Drawing.Size(260, 25);
            this.Txt_ItemName.TabIndex = 13;
            // 
            // Cmb_Order
            // 
            this.Cmb_Order.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Order.FormattingEnabled = true;
            this.Cmb_Order.Location = new System.Drawing.Point(250, 197);
            this.Cmb_Order.Name = "Cmb_Order";
            this.Cmb_Order.Size = new System.Drawing.Size(260, 23);
            this.Cmb_Order.TabIndex = 14;
            this.Cmb_Order.SelectedIndexChanged += new System.EventHandler(this.Cmb_Order_SelectedIndexChanged);
            // 
            // Txt_ProcName
            // 
            this.Txt_ProcName.Location = new System.Drawing.Point(685, 197);
            this.Txt_ProcName.Name = "Txt_ProcName";
            this.Txt_ProcName.Size = new System.Drawing.Size(158, 25);
            this.Txt_ProcName.TabIndex = 15;
            // 
            // Cmb_Machine
            // 
            this.Cmb_Machine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Machine.FormattingEnabled = true;
            this.Cmb_Machine.Location = new System.Drawing.Point(864, 197);
            this.Cmb_Machine.Name = "Cmb_Machine";
            this.Cmb_Machine.Size = new System.Drawing.Size(158, 23);
            this.Cmb_Machine.TabIndex = 16;
            // 
            // Txt_CurrentTime
            // 
            this.Txt_CurrentTime.Location = new System.Drawing.Point(250, 127);
            this.Txt_CurrentTime.Name = "Txt_CurrentTime";
            this.Txt_CurrentTime.ReadOnly = true;
            this.Txt_CurrentTime.Size = new System.Drawing.Size(200, 25);
            this.Txt_CurrentTime.TabIndex = 17;
            // 
            // Tim_PerSec
            // 
            this.Tim_PerSec.Interval = 1000;
            this.Tim_PerSec.Tick += new System.EventHandler(this.Tim_PerSec_Tick);
            // 
            // Btn_OrderStart
            // 
            this.Btn_OrderStart.Location = new System.Drawing.Point(864, 127);
            this.Btn_OrderStart.Name = "Btn_OrderStart";
            this.Btn_OrderStart.Size = new System.Drawing.Size(158, 46);
            this.Btn_OrderStart.TabIndex = 18;
            this.Btn_OrderStart.Text = "작업개시";
            this.Btn_OrderStart.UseVisualStyleBackColor = true;
            // 
            // Lbl_Dies
            // 
            this.Lbl_Dies.AutoSize = true;
            this.Lbl_Dies.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Dies.Location = new System.Drawing.Point(570, 237);
            this.Lbl_Dies.Name = "Lbl_Dies";
            this.Lbl_Dies.Size = new System.Drawing.Size(87, 15);
            this.Lbl_Dies.TabIndex = 19;
            this.Lbl_Dies.Text = "금형 이미지";
            // 
            // Pic_Dies
            // 
            this.Pic_Dies.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Pic_Dies.Location = new System.Drawing.Point(685, 237);
            this.Pic_Dies.Name = "Pic_Dies";
            this.Pic_Dies.Size = new System.Drawing.Size(337, 191);
            this.Pic_Dies.TabIndex = 20;
            this.Pic_Dies.TabStop = false;
            // 
            // Txt_TargetAmount
            // 
            this.Txt_TargetAmount.Location = new System.Drawing.Point(226, 325);
            this.Txt_TargetAmount.Name = "Txt_TargetAmount";
            this.Txt_TargetAmount.Size = new System.Drawing.Size(100, 25);
            this.Txt_TargetAmount.TabIndex = 22;
            // 
            // Lbl_TargetAmount
            // 
            this.Lbl_TargetAmount.AutoSize = true;
            this.Lbl_TargetAmount.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_TargetAmount.Location = new System.Drawing.Point(133, 330);
            this.Lbl_TargetAmount.Name = "Lbl_TargetAmount";
            this.Lbl_TargetAmount.Size = new System.Drawing.Size(87, 15);
            this.Lbl_TargetAmount.TabIndex = 21;
            this.Lbl_TargetAmount.Text = "목표 생산량";
            // 
            // Tim_Per3Sec
            // 
            this.Tim_Per3Sec.Interval = 3000;
            this.Tim_Per3Sec.Tick += new System.EventHandler(this.Tim_Per3Sec_Tick);
            // 
            // Tab_Data
            // 
            this.Tab_Data.Location = new System.Drawing.Point(52, 434);
            this.Tab_Data.Name = "Tab_Data";
            this.Tab_Data.SelectedIndex = 0;
            this.Tab_Data.Size = new System.Drawing.Size(1084, 393);
            this.Tab_Data.TabIndex = 24;
            // 
            // FRM_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1258, 973);
            this.Controls.Add(this.Tab_Data);
            this.Controls.Add(this.Txt_TargetAmount);
            this.Controls.Add(this.Lbl_TargetAmount);
            this.Controls.Add(this.Pic_Dies);
            this.Controls.Add(this.Lbl_Dies);
            this.Controls.Add(this.Btn_OrderStart);
            this.Controls.Add(this.Txt_CurrentTime);
            this.Controls.Add(this.Cmb_Machine);
            this.Controls.Add(this.Txt_ProcName);
            this.Controls.Add(this.Cmb_Order);
            this.Controls.Add(this.Txt_ItemName);
            this.Controls.Add(this.Txt_ItemCode);
            this.Controls.Add(this.Txt_TotalAmount);
            this.Controls.Add(this.Txt_NormalAmount);
            this.Controls.Add(this.Txt_DefectAmount);
            this.Controls.Add(this.Lbl_DefectAmount);
            this.Controls.Add(this.Lbl_NormalAmount);
            this.Controls.Add(this.Lbl_TotalAmount);
            this.Controls.Add(this.Lbl_ItemName);
            this.Controls.Add(this.Lbl_ItemCode);
            this.Controls.Add(this.Lbl_Proc);
            this.Controls.Add(this.Lbl_Order);
            this.Controls.Add(this.Lbl_CurrentTime);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Process";
            this.Text = "Frm_Process";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Process_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Dies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_CurrentTime;
        private System.Windows.Forms.Label Lbl_Order;
        private System.Windows.Forms.Label Lbl_Proc;
        private System.Windows.Forms.Label Lbl_ItemCode;
        private System.Windows.Forms.Label Lbl_ItemName;
        private System.Windows.Forms.Label Lbl_TotalAmount;
        private System.Windows.Forms.Label Lbl_NormalAmount;
        private System.Windows.Forms.Label Lbl_DefectAmount;
        private System.Windows.Forms.TextBox Txt_DefectAmount;
        private System.Windows.Forms.TextBox Txt_NormalAmount;
        private System.Windows.Forms.TextBox Txt_TotalAmount;
        private System.Windows.Forms.TextBox Txt_ItemCode;
        private System.Windows.Forms.TextBox Txt_ItemName;
        private System.Windows.Forms.ComboBox Cmb_Order;
        private System.Windows.Forms.TextBox Txt_ProcName;
        private System.Windows.Forms.ComboBox Cmb_Machine;
        private System.Windows.Forms.TextBox Txt_CurrentTime;
        private System.Windows.Forms.Timer Tim_PerSec;
        private System.Windows.Forms.Button Btn_OrderStart;
        private System.Windows.Forms.Label Lbl_Dies;
        private System.Windows.Forms.PictureBox Pic_Dies;
        private System.Windows.Forms.TextBox Txt_TargetAmount;
        private System.Windows.Forms.Label Lbl_TargetAmount;
        private System.Windows.Forms.Timer Tim_Per3Sec;
        private System.Windows.Forms.TabControl Tab_Data;
    }
}