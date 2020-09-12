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
    public partial class FRM_KeyBoardUI : Form
    {
        const int MaxTextLength = 24;
        List<Button> btnList_Digit = new List<Button>();
        List<Button> btnList_Letter = new List<Button>();
        enum Shift { UPPER, LOWER }
        enum ShiftState { NONE, ONETIME, CONTINUOUS }
        ShiftState shiftState { get; set; }
        
        public FRM_KeyBoardUI(string inputType = "", string initialText = "", bool inputPassword = false)
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
        private void Frm_KeyBoardUI_Load(object sender, EventArgs e)
        {
            shiftState = ShiftState.NONE;

            Lbl_invisible1.Text = "";
            Lbl_invisible2.Text = "";
            Lbl_invisible3.Text = "";
            Lbl_invisible4.Text = "";
            Lbl_invisible5.Text = "";

            // Shift 작동을 위한 List 등록
            btnList_Digit.Add(Btn_Key_1); btnList_Digit.Add(Btn_Key_2);
            btnList_Digit.Add(Btn_Key_3); btnList_Digit.Add(Btn_Key_4);
            btnList_Digit.Add(Btn_Key_5); btnList_Digit.Add(Btn_Key_6);
            btnList_Digit.Add(Btn_Key_7); btnList_Digit.Add(Btn_Key_8);
            btnList_Digit.Add(Btn_Key_9); btnList_Digit.Add(Btn_Key_0);
            btnList_Digit.Add(Btn_Key_Bar);
            // Shift 작동을 위한 List 등록
            btnList_Letter.Add(Btn_Key_A); btnList_Letter.Add(Btn_Key_B);
            btnList_Letter.Add(Btn_Key_C); btnList_Letter.Add(Btn_Key_D);
            btnList_Letter.Add(Btn_Key_E); btnList_Letter.Add(Btn_Key_F);
            btnList_Letter.Add(Btn_Key_G); btnList_Letter.Add(Btn_Key_H);
            btnList_Letter.Add(Btn_Key_I); btnList_Letter.Add(Btn_Key_J);
            btnList_Letter.Add(Btn_Key_K); btnList_Letter.Add(Btn_Key_L);
            btnList_Letter.Add(Btn_Key_M); btnList_Letter.Add(Btn_Key_N);
            btnList_Letter.Add(Btn_Key_O); btnList_Letter.Add(Btn_Key_P);
            btnList_Letter.Add(Btn_Key_Q); btnList_Letter.Add(Btn_Key_R);
            btnList_Letter.Add(Btn_Key_S); btnList_Letter.Add(Btn_Key_T);
            btnList_Letter.Add(Btn_Key_U); btnList_Letter.Add(Btn_Key_V);
            btnList_Letter.Add(Btn_Key_W); btnList_Letter.Add(Btn_Key_X);
            btnList_Letter.Add(Btn_Key_Y); btnList_Letter.Add(Btn_Key_Z);

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
                if (shiftState == ShiftState.ONETIME)
                    ChangeShiftState(ShiftState.NONE);
            }
        }

        private void Btn_Key_BackSpace_Click(object sender, EventArgs e)
        {
            if (Txt_Input.Text.Length > 0)
                Txt_Input.Text = Txt_Input.Text.Substring(0, Txt_Input.Text.Length - 1);
        }

        private void Btn_Key_Shift_Click(object sender, EventArgs e)
        {
            if(shiftState == ShiftState.NONE)
                ChangeShiftState(ShiftState.ONETIME);
            else if(shiftState == ShiftState.ONETIME)
                ChangeShiftState(ShiftState.CONTINUOUS);
            else if(shiftState == ShiftState.CONTINUOUS)
                ChangeShiftState(ShiftState.NONE);
        }
        private void ChangeShiftState(ShiftState state)
        {
            switch (state)
            {
                case ShiftState.NONE:
                    Shift_Key(Shift.LOWER);
                    shiftState = ShiftState.NONE;
                    Btn_Key_ShiftL.ForeColor = SystemColors.ControlText;
                    Btn_Key_ShiftL.BackColor = SystemColors.ControlLight;
                    Btn_Key_ShiftR.ForeColor = SystemColors.ControlText;
                    Btn_Key_ShiftR.BackColor = SystemColors.ControlLight;
                    break;
                case ShiftState.ONETIME:
                    Shift_Key(Shift.UPPER);
                    shiftState = ShiftState.ONETIME;
                    Btn_Key_ShiftL.ForeColor = SystemColors.ControlText;
                    Btn_Key_ShiftL.BackColor = SystemColors.ControlDark;
                    Btn_Key_ShiftR.ForeColor = SystemColors.ControlText;
                    Btn_Key_ShiftR.BackColor = SystemColors.ControlDark;
                    break;
                case ShiftState.CONTINUOUS:
                    Shift_Key(Shift.UPPER);
                    shiftState = ShiftState.CONTINUOUS;
                    Btn_Key_ShiftL.ForeColor = SystemColors.ControlLightLight;
                    Btn_Key_ShiftL.BackColor = SystemColors.ControlDarkDark;
                    Btn_Key_ShiftR.ForeColor = SystemColors.ControlLightLight;
                    Btn_Key_ShiftR.BackColor = SystemColors.ControlDarkDark;
                    break;
            }
        }
        private void Shift_Key(Shift shift)
        {
            foreach(Button button in btnList_Letter)
            {
                if (shift == Shift.UPPER)
                    button.Text = button.Text.ToUpper();
                else if (shift == Shift.LOWER)
                    button.Text = button.Text.ToLower();
            }
            foreach(Button button in btnList_Digit)
            {
                button.Text = GetShiftedDigit(button.Text, shift);
            }
        }
        private string GetShiftedDigit(string digit, Shift shift)
        {
            if (digit.Length != 1)
                return digit;
            if(shift == Shift.UPPER)
            {
                switch (digit)
                {
                    case "1":
                        return "!";
                    case "2":
                        return "@";
                    case "3":
                        return "#";
                    case "4":
                        return "$";
                    case "5":
                        return "%";
                    case "6":
                        return "^";
                    case "7":
                        return "&";
                    case "8":
                        return "*";
                    case "9":
                        return "(";
                    case "0":
                        return ")";
                    case "-":
                        return "_";
                }
            }
            else if (shift == Shift.LOWER)
            {
                switch (digit)
                {
                    case "!":
                        return "1";
                    case "@":
                        return "2";
                    case "#":
                        return "3";
                    case "$":
                        return "4";
                    case "%":
                        return "5";
                    case "^":
                        return "6";
                    case "&":
                        return "7";
                    case "*":
                        return "8";
                    case "(":
                        return "9";
                    case ")":
                        return "0";
                    case "_":
                        return "-";
                }
            }
            
            return digit;
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
