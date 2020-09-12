using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFactoryProject_Final.Common
{
    public partial class FRM_NumPadUI : Form
    {
        const int MaxTextLength = 16;

        public FRM_NumPadUI(string inputType = "", string initialText = "", bool inputPassword = false)
        {
            InitializeComponent();
            Lbl_Type.Text = inputType;
            Txt_Input.Text = initialText;
            if (inputPassword)
                Txt_Input.PasswordChar = '●';
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);
        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        private void Frm_NumPadUI_Load(object sender, EventArgs e)
        {
            // 종료 버튼의 테두리를 둥글게 만들기
            IntPtr ip = CreateRoundRectRgn(0, 0, Btn_Key_EXIT.Width, Btn_Key_EXIT.Height, 15, 15);
            int i = SetWindowRgn(Btn_Key_EXIT.Handle, ip, true);
        }

        private void Btn_Key_Click(object sender, EventArgs e)
        {
            if (Txt_Input.Text.Length < MaxTextLength)
            {
                Button btnClicked = sender as Button;
                Txt_Input.Text += btnClicked.Text;
            }
        }

        private void Btn_Key_BackSpace_Click(object sender, EventArgs e)
        {
            if (Txt_Input.Text.Length > 0)
                Txt_Input.Text = Txt_Input.Text.Substring(0, Txt_Input.Text.Length - 1);
        }

        private void Btn_Key_Enter_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn_Key_EXIT_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string GetInputText()
        {
            return Txt_Input.Text;
        }

        int xPos { get; set; }
        int yPos { get; set; }
        private void Pnl_Drag_MouseDown(object sender, MouseEventArgs e)
        {
            xPos = e.X;
            yPos = e.Y;
        }
        private void Pnl_Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - xPos,
                                          this.Location.Y + e.Y - yPos);
            }
        }
    }
}
