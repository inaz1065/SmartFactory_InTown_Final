using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFactoryProject_Final.Common
{
    public partial class FRM_MessageBox : Form
    {
        public enum MessageBoxType { Normal,    // 단순히 메시지를 전달하기 위한 타입
                                     OkCancel,  // 메시지를 전달하고 거기에 대해 확인, 취소라는 답을 얻기 위한 타입
                                     YesNo      // 한가지를 묻고 거기에 예, 아니오라는 답을 얻기 위한 타입
                                   }
        private MessageBoxType type;
        public FRM_MessageBox(MessageBoxType type = MessageBoxType.Normal)
        {
            InitializeComponent();
            this.type = type;
        }

        public static void Show(string content, string title = "Message", MessageBoxType type = MessageBoxType.Normal)
        {
            FRM_MessageBox message = new FRM_MessageBox();
            message.Lbl_Title.Text = title;
            message.Lbl_Content.Text = content;
            message.ShowDialog();
        }

        private void FRM_MessageBox_Load(object sender, EventArgs e)
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string bgResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["BGFolder"]}";
            this.BackgroundImage = Image.FromFile(bgResPath + @"\bg_msg.gif");

            ControlLayout ctrlLayout = new ControlLayout();
            ctrlLayout.Control_Sizing(Pnl_Drag, this.Size, 1, 0.2f);
            ctrlLayout.Control_Positioning(Pnl_Drag, this.Size, 0.5f, 0.1f);
            ctrlLayout.Control_Sizing(Lbl_Title, this.Size, 0.95f, 0.15f);
            ctrlLayout.Control_Positioning(Lbl_Title, this.Size, 0.5f, 0.105f);
            Lbl_Title.ForeColor = Color.Black;
            ctrlLayout.Control_Sizing(Lbl_Content, this.Size, 0.95f, 0.55f);
            ctrlLayout.Control_Positioning(Lbl_Content, this.Size, 0.5f, 0.5f);

            switch (this.type)
            {
                case MessageBoxType.Normal:         // 첫번째 버튼을 종료 버튼으로서 사용하고 두번째 버튼은 사용하지 않음
                    ctrlLayout.Control_Sizing(Btn_First, this.Size, 0.3f, 0.15f);
                    ctrlLayout.Control_Positioning(Btn_First, this.Size, 0.5f, 0.9f);
                    ctrlLayout.MakeCurvedBorder(Btn_First, Btn_First.Width / 8, Btn_First.Height / 4);
                    Btn_First.MouseDown += Btn_Exit_MouseDown;
                    Btn_First.MouseUp += Btn_Exit_MouseUp;
                    Btn_First.Click += Btn_Exit_Click;
                    SetBtn_Exit_Image(Btn_First, false);

                    Btn_Second.Dispose();
                    break;
                case MessageBoxType.OkCancel:       // 첫번째 버튼을 확인 버튼으로, 두번째 버튼을 취소 버튼으로 사용함
                    ctrlLayout.Control_Sizing(Btn_First, this.Size, 0.3f, 0.15f);
                    ctrlLayout.Control_Positioning(Btn_First, this.Size, 0.3f, 0.9f);
                    Btn_First.MouseDown += Btn_OK_MouseDown;
                    Btn_First.MouseUp += Btn_OK_MouseUp;
                    Btn_First.Click += Btn_OK_Click;
                    SetBtn_OK_Image(Btn_First, false);

                    ctrlLayout.Control_Sizing(Btn_Second, this.Size, 0.3f, 0.15f);
                    ctrlLayout.Control_Positioning(Btn_Second, this.Size, 0.7f, 0.9f);
                    Btn_Second.MouseDown += Btn_Cancel_MouseDown;
                    Btn_Second.MouseUp += Btn_Cancel_MouseUp;
                    Btn_Second.Click += Btn_Exit_Click;
                    SetBtn_Exit_Image(Btn_Second, false);
                    break;
                case MessageBoxType.YesNo:
                    ctrlLayout.Control_Sizing(Btn_First, this.Size, 0.3f, 0.15f);
                    ctrlLayout.Control_Positioning(Btn_First, this.Size, 0.3f, 0.9f);
                    Btn_First.MouseDown += Btn_Yes_MouseDown;
                    Btn_First.MouseUp += Btn_Yes_MouseUp;
                    Btn_First.Click += Btn_Yes_Click;
                    SetBtn_Yes_Image(Btn_First, false);

                    ctrlLayout.Control_Sizing(Btn_Second, this.Size, 0.3f, 0.15f);
                    ctrlLayout.Control_Positioning(Btn_Second, this.Size, 0.7f, 0.9f);
                    Btn_Second.MouseDown += Btn_No_MouseDown;
                    Btn_Second.MouseUp += Btn_No_MouseUp;
                    Btn_Second.Click += Btn_No_Click;
                    SetBtn_No_Image(Btn_Second, false);
                    break;
            }
        }

        #region ---- Btn_Exit
        private void Btn_Exit_MouseDown(object sender, MouseEventArgs e)
        {
            SetBtn_Exit_Image(sender as Button, true);
        }

        private void Btn_Exit_MouseUp(object sender, MouseEventArgs e)
        {
            SetBtn_Exit_Image(sender as Button, false);
        }

        private void SetBtn_Exit_Image(Control ctrl, bool pressed)
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string textResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["TextFolder"]}";

            if (pressed)
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn닫기_R.png");
            else
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn닫기_R.png");
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region ---- Btn_OK
        private void Btn_OK_MouseDown(object sender, MouseEventArgs e)
        {
            SetBtn_OK_Image(sender as Button, true);
        }

        private void Btn_OK_MouseUp(object sender, MouseEventArgs e)
        {
            SetBtn_OK_Image(sender as Button, false);
        }

        private void SetBtn_OK_Image(Control ctrl, bool pressed)
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string textResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["TextFolder"]}";

            if (pressed)
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn_확인_press.png");
            else
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn_확인_nomal.png");
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
        #region ---- Btn_Cancel
        private void Btn_Cancel_MouseDown(object sender, MouseEventArgs e)
        {
            SetBtn_Cancel_Image(sender as Button, true);
        }

        private void Btn_Cancel_MouseUp(object sender, MouseEventArgs e)
        {
            SetBtn_Cancel_Image(sender as Button, false);
        }

        private void SetBtn_Cancel_Image(Control ctrl, bool pressed)
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string textResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["TextFolder"]}";

            if (pressed)
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn_취소_press.png");
            else
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn_취소_nomal.png");
        }

        // Click 이벤트 함수는 Btn_Exit의 것을 사용한다
        #endregion

        #region ---- Btn_Yes (할당할 이미지의 지정이 필요)
        private void Btn_Yes_MouseDown(object sender, MouseEventArgs e)
        {
            SetBtn_Yes_Image(sender as Button, true);
        }

        private void Btn_Yes_MouseUp(object sender, MouseEventArgs e)
        {
            SetBtn_Yes_Image(sender as Button, false);
        }

        private void SetBtn_Yes_Image(Control ctrl, bool pressed)
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string textResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["TextFolder"]}";

            if (pressed)
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn닫기_R.png");
            else
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn닫기_R.png");
        }

        private void Btn_Yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion
        #region ---- Btn_No (할당할 이미지의 지정이 필요)
        private void Btn_No_MouseDown(object sender, MouseEventArgs e)
        {
            SetBtn_No_Image(sender as Button, true);
        }

        private void Btn_No_MouseUp(object sender, MouseEventArgs e)
        {
            SetBtn_No_Image(sender as Button, false);
        }

        private void SetBtn_No_Image(Control ctrl, bool pressed)
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string textResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["TextFolder"]}";

            if (pressed)
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn닫기_R.png");
            else
                ctrl.BackgroundImage = Image.FromFile(textResPath + @"\btn닫기_R.png");
        }

        private void Btn_No_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion

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