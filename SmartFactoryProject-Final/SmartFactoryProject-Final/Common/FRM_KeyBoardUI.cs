﻿using System;
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
        enum Shift { UPPER,             // 대문자를 입력하는 경우
                     LOWER              // 소문자를 입력하는 경우
                   }
        enum ShiftState { NONE,         // 소문자를 입력하는 모드
                          ONETIME,      // 대문자를 1회 입력하고 그 후 소문자 입력 모드로 돌아가는 모드
                          CONTINUOUS    // 대문자를 횟수 제한 없이 계속 입력하는 모드
                        }
        ShiftState shiftState { get; set; }
        
        public FRM_KeyBoardUI(string inputType = "", string initialText = "", bool inputPassword = false)
        {
            InitializeComponent();
            Lbl_Type.Text = inputType;
            Txt_Input.Text = initialText;
            if (inputPassword)
                Txt_Input.PasswordChar = '●';
        }

        private void Frm_KeyBoardUI_Load(object sender, EventArgs e)
        {
            ChangeShiftState(ShiftState.NONE);

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

            GetKeyImages(Shift.LOWER);

            // 텍스트 삭제 작업 & 테두리 둥글게 하는 작업을 수행
            // 텍스트는 개발 환경에서의 버튼간 구분을 쉽게 하기 위해 넣었으며
            //   실제 실행시에는 이미지와 겹쳐 안좋게 보이므로 실행시에는 삭제해야함
            FormLayout frmLayout = new FormLayout();
            frmLayout.MakeCurvedBorder(this, 18, 18);

            ControlLayout ctrlLayout = new ControlLayout();
            foreach (Button btn in btnList_Digit)
            {
                btn.Text = "";
                ctrlLayout.MakeCurvedBorder(btn, 18, 18);
            }
            foreach(Button btn in btnList_Letter)
            {
                btn.Text = "";
                ctrlLayout.MakeCurvedBorder(btn, 18, 18);
            }
            Btn_Key_BackSpace.Text = "";
            ctrlLayout.MakeCurvedBorder(Btn_Key_BackSpace, 18, 18);
            Btn_Key_ShiftL.Text = "";
            ctrlLayout.MakeCurvedBorder(Btn_Key_ShiftL, 18, 18);
            Btn_Key_ShiftR.Text = "";
            ctrlLayout.MakeCurvedBorder(Btn_Key_ShiftR, 18, 18);
            Btn_Key_Enter.Text = "";
            ctrlLayout.MakeCurvedBorder(Btn_Key_Enter, 24, 24);
            Btn_Exit.Text = "";
            ctrlLayout.MakeCurvedBorder(Btn_Exit, 12, 12);
            Txt_Input.Text = "";
            ctrlLayout.MakeCurvedBorder(Txt_Input, 15, 15);

        }

        private void Btn_Key_Click(object sender, EventArgs e)
        {
            if (Txt_Input.Text.Length < MaxTextLength)
            {
                Button btnClicked = sender as Button;
                Txt_Input.Text += (string)btnClicked.Tag;
                if (shiftState == ShiftState.ONETIME)
                    ChangeShiftState(ShiftState.NONE);
            }
        }

        private void Btn_Key_BackSpace_Click(object sender, EventArgs e)
        {
            if (Txt_Input.Text.Length > 0)
                Txt_Input.Text = Txt_Input.Text.Substring(0, Txt_Input.Text.Length - 1);
        }

        #region ---- SHIFT
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
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string keyPadResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["KeyPadFolder"]}";

            switch (state)
            {
                case ShiftState.NONE:
                    Shift_Key(Shift.LOWER);
                    shiftState = ShiftState.NONE;
                    Btn_Key_ShiftL.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_shiftL.png");
                    Btn_Key_ShiftR.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_shiftR.png");
                    break;
                case ShiftState.ONETIME:
                    Shift_Key(Shift.UPPER);
                    shiftState = ShiftState.ONETIME;
                    Btn_Key_ShiftL.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_shiftL_OT.png");
                    Btn_Key_ShiftR.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_shiftR_OT.png");
                    break;
                case ShiftState.CONTINUOUS:
                    Shift_Key(Shift.UPPER);
                    shiftState = ShiftState.CONTINUOUS;
                    Btn_Key_ShiftL.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_shiftL_CNT.png");
                    Btn_Key_ShiftR.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_shiftR_CNT.png");
                    break;
            }
        }

        private void Shift_Key(Shift shift)
        {
            foreach(Button button in btnList_Letter)
            {
                if (shift == Shift.UPPER)
                    button.Tag = ((string)(button.Tag)).ToUpper();
                else if (shift == Shift.LOWER)
                    button.Tag = ((string)(button.Tag)).ToLower();
            }
            foreach(Button button in btnList_Digit)
            {
                button.Tag = GetShiftedDigit(((string)(button.Tag)), shift);
            }
            GetKeyImages(shift);
        }

        private string GetShiftedDigit(string digit, Shift shift)
        {
            if (digit.Length != 1)
                return digit;

            if (shift == Shift.UPPER)
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

        // 버튼에 이미지를 할당하는 함수
        private void GetKeyImages(Shift shift)
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string keyPadResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["KeyPadFolder"]}";

            if (shift == Shift.UPPER)
            {
                Btn_Key_A.BackgroundImage = Image.FromFile(keyPadResPath + @"\TA.png");
                Btn_Key_B.BackgroundImage = Image.FromFile(keyPadResPath + @"\TB.png");
                Btn_Key_C.BackgroundImage = Image.FromFile(keyPadResPath + @"\TC.png");
                Btn_Key_D.BackgroundImage = Image.FromFile(keyPadResPath + @"\TD.png");
                Btn_Key_E.BackgroundImage = Image.FromFile(keyPadResPath + @"\TE.png");
                Btn_Key_F.BackgroundImage = Image.FromFile(keyPadResPath + @"\TF.png");
                Btn_Key_G.BackgroundImage = Image.FromFile(keyPadResPath + @"\TG.png");
                Btn_Key_H.BackgroundImage = Image.FromFile(keyPadResPath + @"\TH.png");
                Btn_Key_I.BackgroundImage = Image.FromFile(keyPadResPath + @"\TI.png");
                Btn_Key_J.BackgroundImage = Image.FromFile(keyPadResPath + @"\TJ.png");
                Btn_Key_K.BackgroundImage = Image.FromFile(keyPadResPath + @"\TK.png");
                Btn_Key_L.BackgroundImage = Image.FromFile(keyPadResPath + @"\TL.png");
                Btn_Key_M.BackgroundImage = Image.FromFile(keyPadResPath + @"\TM.png");
                Btn_Key_N.BackgroundImage = Image.FromFile(keyPadResPath + @"\TN.png");
                Btn_Key_O.BackgroundImage = Image.FromFile(keyPadResPath + @"\TO.png");
                Btn_Key_P.BackgroundImage = Image.FromFile(keyPadResPath + @"\TP.png");
                Btn_Key_Q.BackgroundImage = Image.FromFile(keyPadResPath + @"\TQ.png");
                Btn_Key_R.BackgroundImage = Image.FromFile(keyPadResPath + @"\TR.png");
                Btn_Key_S.BackgroundImage = Image.FromFile(keyPadResPath + @"\TS.png");
                Btn_Key_T.BackgroundImage = Image.FromFile(keyPadResPath + @"\TT.png");
                Btn_Key_U.BackgroundImage = Image.FromFile(keyPadResPath + @"\TU.png");
                Btn_Key_V.BackgroundImage = Image.FromFile(keyPadResPath + @"\TV.png");
                Btn_Key_W.BackgroundImage = Image.FromFile(keyPadResPath + @"\TW.png");
                Btn_Key_X.BackgroundImage = Image.FromFile(keyPadResPath + @"\TX.png");
                Btn_Key_Y.BackgroundImage = Image.FromFile(keyPadResPath + @"\TY.png");
                Btn_Key_Z.BackgroundImage = Image.FromFile(keyPadResPath + @"\TZ.png");
                Btn_Key_1.BackgroundImage = Image.FromFile(keyPadResPath + @"\n1_Sp.png");
                Btn_Key_2.BackgroundImage = Image.FromFile(keyPadResPath + @"\n2_Sp.png");
                Btn_Key_3.BackgroundImage = Image.FromFile(keyPadResPath + @"\n3_Sp.png");
                Btn_Key_4.BackgroundImage = Image.FromFile(keyPadResPath + @"\n4_Sp.png");
                Btn_Key_5.BackgroundImage = Image.FromFile(keyPadResPath + @"\n5_Sp.png");
                Btn_Key_6.BackgroundImage = Image.FromFile(keyPadResPath + @"\n6_Sp.png");
                Btn_Key_7.BackgroundImage = Image.FromFile(keyPadResPath + @"\n7_Sp.png");
                Btn_Key_8.BackgroundImage = Image.FromFile(keyPadResPath + @"\n8_Sp.png");
                Btn_Key_9.BackgroundImage = Image.FromFile(keyPadResPath + @"\n9_Sp.png");
                Btn_Key_0.BackgroundImage = Image.FromFile(keyPadResPath + @"\n0_Sp.png");
                Btn_Key_Bar.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_underbar.png");
            }
            else if(shift == Shift.LOWER)
            {
                Btn_Key_A.BackgroundImage = Image.FromFile(keyPadResPath + @"\TA_Little.png");
                Btn_Key_B.BackgroundImage = Image.FromFile(keyPadResPath + @"\TB_Little.png");
                Btn_Key_C.BackgroundImage = Image.FromFile(keyPadResPath + @"\TC_Little.png");
                Btn_Key_D.BackgroundImage = Image.FromFile(keyPadResPath + @"\TD_Little.png");
                Btn_Key_E.BackgroundImage = Image.FromFile(keyPadResPath + @"\TE_Little.png");
                Btn_Key_F.BackgroundImage = Image.FromFile(keyPadResPath + @"\TF_Little.png");
                Btn_Key_G.BackgroundImage = Image.FromFile(keyPadResPath + @"\TG_Little.png");
                Btn_Key_H.BackgroundImage = Image.FromFile(keyPadResPath + @"\TH_Little.png");
                Btn_Key_I.BackgroundImage = Image.FromFile(keyPadResPath + @"\TI_Little.png");
                Btn_Key_J.BackgroundImage = Image.FromFile(keyPadResPath + @"\TJ_Little.png");
                Btn_Key_K.BackgroundImage = Image.FromFile(keyPadResPath + @"\TK_Little.png");
                Btn_Key_L.BackgroundImage = Image.FromFile(keyPadResPath + @"\TL_Little.png");
                Btn_Key_M.BackgroundImage = Image.FromFile(keyPadResPath + @"\TM_Little.png");
                Btn_Key_N.BackgroundImage = Image.FromFile(keyPadResPath + @"\TN_Little.png");
                Btn_Key_O.BackgroundImage = Image.FromFile(keyPadResPath + @"\TO_Little.png");
                Btn_Key_P.BackgroundImage = Image.FromFile(keyPadResPath + @"\TP_Little.png");
                Btn_Key_Q.BackgroundImage = Image.FromFile(keyPadResPath + @"\TQ_Little.png");
                Btn_Key_R.BackgroundImage = Image.FromFile(keyPadResPath + @"\TR_Little.png");
                Btn_Key_S.BackgroundImage = Image.FromFile(keyPadResPath + @"\TS_Little.png");
                Btn_Key_T.BackgroundImage = Image.FromFile(keyPadResPath + @"\TT_Little.png");
                Btn_Key_U.BackgroundImage = Image.FromFile(keyPadResPath + @"\TU_Little.png");
                Btn_Key_V.BackgroundImage = Image.FromFile(keyPadResPath + @"\TV_Little.png");
                Btn_Key_W.BackgroundImage = Image.FromFile(keyPadResPath + @"\TW_Little.png");
                Btn_Key_X.BackgroundImage = Image.FromFile(keyPadResPath + @"\TX_Little.png");
                Btn_Key_Y.BackgroundImage = Image.FromFile(keyPadResPath + @"\TY_Little.png");
                Btn_Key_Z.BackgroundImage = Image.FromFile(keyPadResPath + @"\TZ_Little.png");
                Btn_Key_1.BackgroundImage = Image.FromFile(keyPadResPath + @"\n1.png");
                Btn_Key_2.BackgroundImage = Image.FromFile(keyPadResPath + @"\n2.png");
                Btn_Key_3.BackgroundImage = Image.FromFile(keyPadResPath + @"\n3.png");
                Btn_Key_4.BackgroundImage = Image.FromFile(keyPadResPath + @"\n4.png");
                Btn_Key_5.BackgroundImage = Image.FromFile(keyPadResPath + @"\n5.png");
                Btn_Key_6.BackgroundImage = Image.FromFile(keyPadResPath + @"\n6.png");
                Btn_Key_7.BackgroundImage = Image.FromFile(keyPadResPath + @"\n7.png");
                Btn_Key_8.BackgroundImage = Image.FromFile(keyPadResPath + @"\n8.png");
                Btn_Key_9.BackgroundImage = Image.FromFile(keyPadResPath + @"\n9.png");
                Btn_Key_0.BackgroundImage = Image.FromFile(keyPadResPath + @"\n0.png");
                Btn_Key_Bar.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_bar.png");
            }
            Btn_Key_BackSpace.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_arrow.png");
            Btn_Key_Enter.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_enter.png");
            Btn_Exit.BackgroundImage = Image.FromFile(keyPadResPath + @"\n_exit.png");
        }
        #endregion

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
