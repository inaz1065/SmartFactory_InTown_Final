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
        FRM_Process frm_process { get; set; }

        public FRM_Main()
        {
            InitializeComponent();
        }
        
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            LogIn(FRM_LogIn.LoginMode.ExitWhenFailed);
            Initialize();
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
                if (this.IsDisposed)
                    return;
                Initialize();
                this.Opacity = 100;
            }
        }
        #endregion

        private void Reset()
        {
            if (frm_process != null)
            {
                frm_process.Close();
                frm_process = null;
            }
        }
        private void Initialize()
        {

        }

        private void Btn_Process_Click(object sender, EventArgs e)
        {
            if (frm_process == null)
                frm_process = new FRM_Process(this);
            frm_process.Show();
        }
    }
}
