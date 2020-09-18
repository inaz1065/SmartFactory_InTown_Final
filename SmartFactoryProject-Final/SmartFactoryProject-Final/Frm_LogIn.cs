using SmartFactoryProject_Final.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFactoryProject_Final
{
    public partial class FRM_LogIn : Form
    {
        public enum LoginMode { ExitWhenFailed, Customize }
        public FRM_LogIn()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            SetLayout();
        }

        private void SetLayout()
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string bgResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["BGFolder"]}";
            string textResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["TextFolder"]}";

            ControlLayout ctrlLayout = new ControlLayout();
            ctrlLayout.MakeCurvedBorder(this, 18, 18);
            this.BackgroundImage = Image.FromFile(bgResPath + @"\bg_tabpage.png");

            ctrlLayout.Control_Sizing(Pnl_Drag, this.Size, 1, 0.2f);

            ctrlLayout.Control_Sizing(Pic_Title, this.Size, 0.05f, 0.1f);
            ctrlLayout.Control_Positioning(Pic_Title, this.Size, 0.1f, 0.2f);
            Pic_Title.Load(textResPath + @"\In.png");

            ctrlLayout.Control_Sizing(Lbl_Title, this.Size, 0.15f, 0.1f);
            ctrlLayout.Control_Positioning(Lbl_Title, this.Size, 0.2f, 0.2f);

            ctrlLayout.Control_Sizing(Pic_ID, this.Size, 0.1f, 0.15f);
            ctrlLayout.Control_Positioning(Pic_ID, this.Size, 0.12f, 0.4f);
            Pic_ID.Load(textResPath + @"\Key.png");
            ctrlLayout.Control_Sizing(Txt_ID, this.Size, 0.5f, 0.1f);
            ctrlLayout.Control_Positioning(Txt_ID, this.Size, 0.2f, 0.4f, ControlLayout.HorizontalSiding.Left);
            

            ctrlLayout.Control_Sizing(Pic_PW, this.Size, 0.1f, 0.15f);
            ctrlLayout.Control_Positioning(Pic_PW, this.Size, 0.12f, 0.6f);
            Pic_PW.Load(textResPath + @"\Lock.png");
            ctrlLayout.Control_Sizing(Txt_PW, this.Size, 0.5f, 0.1f);
            ctrlLayout.Control_Positioning(Txt_PW, this.Size, 0.2f, 0.6f, ControlLayout.HorizontalSiding.Left);
            

            ctrlLayout.Control_Sizing(Btn_LogIn, this.Size, 0.2f, 0.15f);
            ctrlLayout.Control_Positioning(Btn_LogIn, this.Size, 0.5f, 0.85f);
            Btn_LogIn.Text = "";
            Btn_LogIn.BackgroundImage = Image.FromFile(textResPath + @"\Login.png");
            ctrlLayout.MakeCurvedBorder(Btn_LogIn, 18, 18);

            ctrlLayout.Control_Sizing(Btn_Exit, this.Size, 0.15f, 0.15f);
            ctrlLayout.Control_Positioning(Btn_Exit, this.Size, 0.9f, 0.1f);
            Btn_Exit.BackgroundImage = Image.FromFile(textResPath + @"\Exit.png");
            ctrlLayout.MakeCurvedBorder(Btn_Exit, 18, 18);
        }

        private void ResetTxt_ID()
        {
            Txt_ID.Text = "User ID";
            Txt_ID.ForeColor = Color.LightGray;
        }

        private void ResetTxt_PW()
        {
            Txt_PW.Text = "Password";
            Txt_PW.ForeColor = Color.LightGray;
        }

        private void SetTxt_ID(string text)
        {
            Txt_ID.Text = text;
            Txt_ID.ForeColor = Color.Black;
        }

        private void SetTxt_PW(string text)
        {
            Txt_PW.Text = text;
            Txt_PW.ForeColor = Color.Black;
        }

        private void Txt_ID_Click(object sender, EventArgs e)
        {
            string text = (Txt_ID.ForeColor == Color.LightGray) ? "" : Txt_ID.Text;
            FRM_KeyBoardUI keyBoardUI = new FRM_KeyBoardUI("ID", text);
            if (keyBoardUI.ShowDialog() == DialogResult.OK)
            {
                string inputText = keyBoardUI.GetInputText();
                if (!string.IsNullOrEmpty(inputText))
                    SetTxt_ID(inputText);
                else
                    ResetTxt_ID();
            }
        }

        private void Txt_PW_Click(object sender, EventArgs e)
        {
            string text = (Txt_PW.ForeColor == Color.LightGray) ? "" : Txt_PW.Text;
            FRM_KeyBoardUI keyBoardUI = new FRM_KeyBoardUI("PW", text, true);
            if (keyBoardUI.ShowDialog() == DialogResult.OK)
            {
                string inputText = keyBoardUI.GetInputText();
                if (!string.IsNullOrEmpty(inputText))
                    SetTxt_PW(inputText);
                else
                    ResetTxt_PW();
            }
        }

        private void Btn_LogIn_Click(object sender, EventArgs e)
        {
            if (!IsLoginInfoValid())
            {
                FRM_MessageBox.Show("ID와 PW를 모두 입력해 주세요", "로그인 실패");
                return;
            }

            LogIn();
        }

        private bool IsLoginInfoValid()
        {
            if (String.IsNullOrEmpty(Txt_ID.Text) || String.IsNullOrEmpty(Txt_PW.Text))
                return false;
            else
                return true;
        }

        private void LogIn()
        {
            IniFile iniFile = new IniFile();
            iniFile.Load(IniData.SettingIniFile);
            IniSection dbSection = iniFile[DBConnect.IniSectionName];
            string commandText = $@"Select * from {dbSection["UserTB"]}
                                     where {dbSection["UserTB_ID"]} = @ID and {dbSection["UserTB_PW"]} = @Password";
            SqlCommand command = new SqlCommand(commandText);

            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.VarChar, 40);
                         paramID.Value = Txt_ID.Text;
            SqlParameter paramPW = new SqlParameter("@Password", SqlDbType.VarChar, 40);
                         paramPW.Value = Txt_PW.Text;
            command.Parameters.Add(paramID);
            command.Parameters.Add(paramPW);

            DBConnect dbConnect = new DBConnect();
            DataSet loginData;
            bool result = dbConnect.Search(command, out loginData);
            if (result && loginData != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if(result && loginData == null)
                    FRM_MessageBox.Show("입력하신 ID 또는 PW가 맞지 않습니다", "로그인 실패");
                else
                    FRM_MessageBox.Show("로그인 DB의 접속에 실패했습니다", "로그인 실패");
            }
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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