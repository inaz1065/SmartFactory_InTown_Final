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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.label4 = new System.Windows.Forms.Label();
            this.Pic_Dies = new System.Windows.Forms.PictureBox();
            this.Txt_TargetAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Dies)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "현재 시각";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "작업지시";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "공정 및 기기";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "품번";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "품명";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "총 생산량";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(247, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "양품 수";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(232, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "불량품 수";
            // 
            // Txt_DefectAmount
            // 
            this.Txt_DefectAmount.BackColor = System.Drawing.Color.Khaki;
            this.Txt_DefectAmount.Location = new System.Drawing.Point(310, 279);
            this.Txt_DefectAmount.Name = "Txt_DefectAmount";
            this.Txt_DefectAmount.Size = new System.Drawing.Size(100, 25);
            this.Txt_DefectAmount.TabIndex = 9;
            this.Txt_DefectAmount.Click += new System.EventHandler(this.Txt_DefectAmount_Click);
            this.Txt_DefectAmount.TextChanged += new System.EventHandler(this.Txt_DefectAmount_TextChanged);
            // 
            // Txt_NormalAmount
            // 
            this.Txt_NormalAmount.Location = new System.Drawing.Point(310, 248);
            this.Txt_NormalAmount.Name = "Txt_NormalAmount";
            this.Txt_NormalAmount.Size = new System.Drawing.Size(100, 25);
            this.Txt_NormalAmount.TabIndex = 10;
            // 
            // Txt_TotalAmount
            // 
            this.Txt_TotalAmount.Location = new System.Drawing.Point(126, 279);
            this.Txt_TotalAmount.Name = "Txt_TotalAmount";
            this.Txt_TotalAmount.Size = new System.Drawing.Size(100, 25);
            this.Txt_TotalAmount.TabIndex = 11;
            // 
            // Txt_ItemCode
            // 
            this.Txt_ItemCode.Location = new System.Drawing.Point(150, 160);
            this.Txt_ItemCode.Name = "Txt_ItemCode";
            this.Txt_ItemCode.Size = new System.Drawing.Size(260, 25);
            this.Txt_ItemCode.TabIndex = 12;
            // 
            // Txt_ItemName
            // 
            this.Txt_ItemName.Location = new System.Drawing.Point(150, 200);
            this.Txt_ItemName.Name = "Txt_ItemName";
            this.Txt_ItemName.Size = new System.Drawing.Size(260, 25);
            this.Txt_ItemName.TabIndex = 13;
            // 
            // Cmb_Order
            // 
            this.Cmb_Order.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Order.FormattingEnabled = true;
            this.Cmb_Order.Location = new System.Drawing.Point(150, 120);
            this.Cmb_Order.Name = "Cmb_Order";
            this.Cmb_Order.Size = new System.Drawing.Size(260, 23);
            this.Cmb_Order.TabIndex = 14;
            this.Cmb_Order.SelectedIndexChanged += new System.EventHandler(this.Cmb_Order_SelectedIndexChanged);
            // 
            // Txt_ProcName
            // 
            this.Txt_ProcName.Location = new System.Drawing.Point(585, 120);
            this.Txt_ProcName.Name = "Txt_ProcName";
            this.Txt_ProcName.Size = new System.Drawing.Size(158, 25);
            this.Txt_ProcName.TabIndex = 15;
            // 
            // Cmb_Machine
            // 
            this.Cmb_Machine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Machine.FormattingEnabled = true;
            this.Cmb_Machine.Location = new System.Drawing.Point(764, 120);
            this.Cmb_Machine.Name = "Cmb_Machine";
            this.Cmb_Machine.Size = new System.Drawing.Size(158, 23);
            this.Cmb_Machine.TabIndex = 16;
            // 
            // Txt_CurrentTime
            // 
            this.Txt_CurrentTime.Location = new System.Drawing.Point(150, 50);
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
            this.Btn_OrderStart.Location = new System.Drawing.Point(764, 50);
            this.Btn_OrderStart.Name = "Btn_OrderStart";
            this.Btn_OrderStart.Size = new System.Drawing.Size(158, 46);
            this.Btn_OrderStart.TabIndex = 18;
            this.Btn_OrderStart.Text = "작업개시";
            this.Btn_OrderStart.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "금형";
            // 
            // Pic_Dies
            // 
            this.Pic_Dies.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Pic_Dies.Location = new System.Drawing.Point(585, 160);
            this.Pic_Dies.Name = "Pic_Dies";
            this.Pic_Dies.Size = new System.Drawing.Size(337, 191);
            this.Pic_Dies.TabIndex = 20;
            this.Pic_Dies.TabStop = false;
            // 
            // Txt_TargetAmount
            // 
            this.Txt_TargetAmount.Location = new System.Drawing.Point(126, 248);
            this.Txt_TargetAmount.Name = "Txt_TargetAmount";
            this.Txt_TargetAmount.Size = new System.Drawing.Size(100, 25);
            this.Txt_TargetAmount.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "목표 생산량";
            // 
            // Frm_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 973);
            this.Controls.Add(this.Txt_TargetAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Pic_Dies);
            this.Controls.Add(this.label4);
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
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Process";
            this.Text = "Frm_Process";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Process_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Dies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox Pic_Dies;
        private System.Windows.Forms.TextBox Txt_TargetAmount;
        private System.Windows.Forms.Label label10;
    }
}