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
            FormLayout frmLayout = new FormLayout();
            frmLayout.MakeCurvedBorder(this, 18, 18);
            ControlLayout ctrlLayout = new ControlLayout();
            ctrlLayout.Control_Sizing(Lbl_ID, this.Size, 0.1f, 0.1f);
            ctrlLayout.Control_Positioning(Lbl_ID, this.Size, 0.1f, 0.4f);
            ctrlLayout.Control_Sizing(Lbl_PW, this.Size, 0.1f, 0.1f);
            ctrlLayout.Control_Positioning(Lbl_PW, this.Size, 0.1f, 0.6f);
            ctrlLayout.Control_Sizing(Txt_ID, this.Size, 0.5f, 0.1f);
            ctrlLayout.Control_Positioning(Txt_ID, this.Size, 0.2f, 0.4f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Sizing(Txt_PW, this.Size, 0.5f, 0.1f);
            ctrlLayout.Control_Positioning(Txt_PW, this.Size, 0.2f, 0.6f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Sizing(Btn_LogIn, this.Size, 0.2f, 0.4f);
            ctrlLayout.Control_Positioning(Btn_LogIn, this.Size, 0.85f, 0.5f);
            ctrlLayout.Control_Sizing(Btn_Exit, this.Size, 0.2f, 0.15f);
            ctrlLayout.Control_Positioning(Btn_Exit, this.Size, 0.85f, 0.85f);
            ctrlLayout.MakeCurvedBorder(Btn_Exit, 18, 18);
        }

        private void Txt_ID_Click(object sender, EventArgs e)
        {
            FRM_KeyBoardUI keyBoardUI = new FRM_KeyBoardUI("ID", Txt_ID.Text);
            if (keyBoardUI.ShowDialog() == DialogResult.OK)
                Txt_ID.Text = keyBoardUI.GetInputText();
        }

        private void Txt_PW_Click(object sender, EventArgs e)
        {
            FRM_KeyBoardUI keyBoardUI = new FRM_KeyBoardUI("PW", Txt_PW.Text, true);
            if (keyBoardUI.ShowDialog() == DialogResult.OK)
                Txt_PW.Text = keyBoardUI.GetInputText();
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
            DataSet loginData = dbConnect.Search(command);
            if (loginData != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                FRM_MessageBox.Show("입력하신 ID 또는 PW가 맞지 않습니다", "로그인 실패");
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