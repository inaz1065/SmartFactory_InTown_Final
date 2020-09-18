using SmartFactoryProject_Final.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFactoryProject_Final
{
    public partial class FRM_Main : Form
    {
        public const float LeftPadding = 0.1f;
        public const float TopPadding = 0.15f;

        Form mdiForm { get; set; }
        FRM_Process frm_process { get; set; }

        public FRM_Main()
        {
            InitializeComponent();
        }
        
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            LogIn(FRM_LogIn.LoginMode.ExitWhenFailed);
            SetLayout();
        }
        
        private void SetLayout()
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            IniSection equipSect = ini["Equipment"];
            string bgResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["BGFolder"]}";
            string textResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["TextFolder"]}";

            this.Location = new Point(this.Left, 0);
            this.Size = new Size(int.Parse(equipSect["Width"].ToString()), int.Parse(equipSect["Height"].ToString()));
            ControlLayout ctrlLayout = new ControlLayout();
            this.Padding = new Padding(ctrlLayout.GetXPosByRatio(this.Size, LeftPadding), ctrlLayout.GetYPosByRatio(this.Size, TopPadding), 0, 0);

            Pnl_Drag.BackgroundImage = Image.FromFile(bgResPath + @"\bg_box2_NoBorder.png");
            ctrlLayout.Control_Sizing(Pnl_Drag, this.Size, 1, 0.15f);

            ctrlLayout.Control_Sizing(Btn_Process, this.Size, 0.075f, 0.05f);
            ctrlLayout.Control_Positioning(Btn_Process, this.Size, 0.05f, 0.2f);
            Btn_Process.BackgroundImage = Image.FromFile(textResPath + @"\btn_s작업지시_nomal.png");
            Btn_Process.Text = "";

            ctrlLayout.Control_Sizing(Btn_Logout, this.Size, 0.075f, 0.05f);
            ctrlLayout.Control_Positioning(Btn_Logout, this.Size, 0.9f, 0.1f);
            Btn_Logout.BackgroundImage = Image.FromFile(textResPath + @"\Logout.png");
            Btn_Logout.Text = "";

            ctrlLayout.Control_Sizing(Btn_Exit, this.Size, 0.05f, 0.05f);
            ctrlLayout.Control_Positioning(Btn_Exit, this.Size, 1, 0.1f, ControlLayout.HorizontalSiding.Right);
            Btn_Exit.BackgroundImage = Image.FromFile(textResPath + @"\Exit.png");
            Btn_Exit.Text = "";

        }

        #region ---- Login & Logout
        private bool LogIn(FRM_LogIn.LoginMode loginMode)
        {
            FRM_LogIn login = new FRM_LogIn();
            DialogResult result = login.ShowDialog();
            if(result != DialogResult.OK)
            {
                if (loginMode == FRM_LogIn.LoginMode.ExitWhenFailed)
                    this.Close();
                //Environment.Exit(0);    // 로그아웃 후 로그인 폼을 껐을 때 종종 다음과 같은 예외가 발생중
                                        // 특히 로그아웃 -> 로그인을 여러번 반복했을 때 고확률로 발생함
                                        // System.ComponentModel.Win32Exception: '창 핸들을 만드는 동안 오류가 발생했습니다'
                                        // 주로 사용자 개체를 10000개 이상 생성하는 경우에 발생한다고 하는데
                                        // 이 프로그램은 그렇게 많은 개체를 생성하지 않아 원인은 불명
                else
                    return false;
            }
            return true;
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("정말로 로그아웃하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Opacity = 0;
                Reset();
                LogIn(FRM_LogIn.LoginMode.ExitWhenFailed);
                if (this.IsDisposed)    // Login 함수의 결과로 이 폼이 Close될 경우 DisPose되므로 
                    return;
                Restart();
                this.Opacity = 100;
            }
        }
        #endregion

        private void Reset()
        {
            if (mdiForm != null)
                mdiForm.Hide();
        }
        private void Restart()
        {
            if(mdiForm != null)
                mdiForm.Show();
        }

        private void Btn_Process_Click(object sender, EventArgs e)
        {
            if (frm_process == null)
                frm_process = new FRM_Process(this);
            mdiForm = frm_process;
            frm_process.Show();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
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
