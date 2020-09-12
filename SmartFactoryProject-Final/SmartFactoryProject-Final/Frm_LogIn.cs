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
                MessageBox.Show("ID와 PW를 모두 입력해 주세요");
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
                MessageBox.Show("입력하신 ID 또는 PW가 맞지 않습니다");
            }
        }
    }
}