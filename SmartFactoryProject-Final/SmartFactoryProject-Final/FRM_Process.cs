
using SmartFactoryProject_Final.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartFactoryProject_Final
{
    public partial class FRM_Process : Form
    {
        public FRM_Process(Form parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }

        #region ---- Initialize
        private void Frm_Process_Load(object sender, EventArgs e)
        {
            SetLayout();
            Initialize();
        }
        
        private void Initialize()
        {
            Tim_PerSec.Enabled = true;
            Tim_PerSec.Interval = 1000;
            Tim_Per3Sec.Enabled = true;
            Tim_Per3Sec.Interval = 3000;
            Cmb_Order.SelectedIndex = -1;
            Cmb_Machine.SelectedIndex = -1;

            SetRealTime();
            LoadOrders();
            InitializeChart();
        }

        private void SetLayout()
        {
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection resSect = ini["Resources"];
            string bgResPath = System.IO.Directory.GetCurrentDirectory() + $@"{resSect["ResourceFolder"]}{resSect["BGFolder"]}";
            // 부모 폼의 Mdi Container에 크기를 맞춘다
            this.Location = new Point(0, 0);
            this.Size = new Size(this.MdiParent.ClientSize.Width - this.MdiParent.Padding.Left - this.MdiParent.Padding.Right,
                                 this.MdiParent.ClientSize.Height - this.MdiParent.Padding.Top - this.MdiParent.Padding.Bottom);
            this.BackgroundImage = Image.FromFile(bgResPath + @"\bg_USER_SEL_Simple.png");

            ControlLayout ctrlLayout = new ControlLayout();
            ctrlLayout.Control_Positioning(Lbl_CurrentTime, this.Size, 0.07f, 0.15f);
            ctrlLayout.Control_Sizing(Txt_CurrentTime, this.Size, 0.1f, 0.05f);
            ctrlLayout.Control_Positioning(Txt_CurrentTime, this.Size, 0.12f, 0.15f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Positioning(Lbl_Order, this.Size, 0.07f, 0.2f);
            ctrlLayout.Control_Sizing(Cmb_Order, this.Size, 0.2f, 0.05f);
            ctrlLayout.Control_Positioning(Cmb_Order, this.Size, 0.12f, 0.2f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Positioning(Lbl_ItemCode, this.Size, 0.07f, 0.25f);
            ctrlLayout.Control_Sizing(Txt_ItemCode, this.Size, 0.2f, 0.05f);
            ctrlLayout.Control_Positioning(Txt_ItemCode, this.Size, 0.12f, 0.25f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Positioning(Lbl_ItemName, this.Size, 0.07f, 0.3f);
            ctrlLayout.Control_Sizing(Txt_ItemName, this.Size, 0.2f, 0.05f);
            ctrlLayout.Control_Positioning(Txt_ItemName, this.Size, 0.12f, 0.3f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Positioning(Lbl_Proc, this.Size, 0.07f, 0.35f);
            ctrlLayout.Control_Sizing(Txt_ProcName, this.Size, 0.1f, 0.05f);
            ctrlLayout.Control_Positioning(Txt_ProcName, this.Size, 0.12f, 0.35f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Sizing(Cmb_Machine, this.Size, 0.1f, 0.05f);
            ctrlLayout.Control_Positioning(Cmb_Machine, this.Size, 0.22f, 0.35f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Positioning(Lbl_TargetAmount, this.Size, 0.18f, 0.4f, ControlLayout.HorizontalSiding.Right);
            ctrlLayout.Control_Sizing(Txt_TargetAmount, this.Size, 0.1f, 0.05f);
            ctrlLayout.Control_Positioning(Txt_TargetAmount, this.Size, 0.2f, 0.4f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Positioning(Lbl_TotalAmount, this.Size, 0.2f, 0.44f, ControlLayout.HorizontalSiding.Right);
            ctrlLayout.Control_Sizing(Txt_TotalAmount, this.Size, 0.08f, 0.05f);
            ctrlLayout.Control_Positioning(Txt_TotalAmount, this.Size, 0.22f, 0.44f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Positioning(Lbl_NormalAmount, this.Size, 0.2f, 0.48f, ControlLayout.HorizontalSiding.Right);
            ctrlLayout.Control_Sizing(Txt_NormalAmount, this.Size, 0.08f, 0.05f);
            ctrlLayout.Control_Positioning(Txt_NormalAmount, this.Size, 0.22f, 0.48f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Positioning(Lbl_DefectAmount, this.Size, 0.2f, 0.52f, ControlLayout.HorizontalSiding.Right);
            ctrlLayout.Control_Sizing(Txt_DefectAmount, this.Size, 0.08f, 0.05f);
            ctrlLayout.Control_Positioning(Txt_DefectAmount, this.Size, 0.22f, 0.52f, ControlLayout.HorizontalSiding.Left);
            ctrlLayout.Control_Sizing(Btn_OrderStart, this.Size, 0.1f, 0.25f);
            ctrlLayout.Control_Positioning(Btn_OrderStart, this.Size, 0.4f, 0.3f);
            ctrlLayout.Control_Positioning(Lbl_Dies, this.Size, 0.5f, 0.15f, ControlLayout.HorizontalSiding.Center, ControlLayout.VerticalSiding.Top);
            ctrlLayout.Control_Sizing(Pic_Dies, this.Size, 0.3f, 0.3f);
            ctrlLayout.Control_Positioning(Pic_Dies, this.Size, 0.55f, 0.15f, ControlLayout.HorizontalSiding.Left, ControlLayout.VerticalSiding.Top);
            ctrlLayout.Control_Sizing(Tab_Data, this.Size, 0.5f, 0.35f);
            ctrlLayout.Control_Positioning(Tab_Data, this.Size, 0.5f, 0.8f);
        }

        #endregion

        #region ---- Reset
        public void Reset()
        {
            Stop();
            Txt_ItemCode.Text = "";
            Txt_ItemName.Text = "";
            Txt_TargetAmount.Text = "";
            Txt_TotalAmount.Text = "";
            Txt_NormalAmount.Text = "";
            Txt_DefectAmount.Text = "";
            Txt_ProcName.Text = "";
            Cmb_Order.DataSource = null;
            Cmb_Machine.DataSource = null;
        }

        private void Stop()
        {
            Tim_PerSec.Enabled = false;
            Tim_Per3Sec.Enabled = false;
        }

        #endregion

        #region ---- Display Infomations (화면상에 정보들을 보여주기 위한 함수)
        /// <summary>
        /// DB로부터 작업지시 목록을 가져와 ComboBox에 할당하는 함수
        /// 완료되지 않은 품목에 대해서만 출력한다
        /// (생산이 일부만 이뤄진 경우에 대해서 구분할 수단을 추가해야함) 
        /// </summary>
        private void LoadOrders()
        {
            DBConnect dbConnect = new DBConnect();
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection dbSection = ini[DBConnect.IniSectionName];

            string cmdText = $@"Select Orders.{dbSection["OrderTB_No"]},
                                       Orders.{dbSection["OrderTB_Date"]},
                                       Items.{dbSection["ItemTB_Name"]},
                                       Orders.{dbSection["OrderTB_Amount"]}
                                  from {dbSection["OrderTB"]} as Orders
                                  Inner Join {dbSection["ItemTB"]} as Items
                                          On Orders.{dbSection["OrderTB_Item"]} = Items.{dbSection["ItemTB_No"]}
                                       Where Orders.{dbSection["OrderTB_No"]} NOT IN 
                                                (Select {dbSection["OutputTB_Order"]} from {dbSection["OutputTB"]})";

            DataSet orderSet = dbConnect.Search(cmdText);
            if (orderSet == null)
                return;

            Dictionary<string, string> orderList = new Dictionary<string, string>();
            foreach (DataRow row in orderSet.Tables[0].Rows)
            {
                orderList.Add($"{row[0].ToString()} - {row[1].ToString().Substring(0, 10)} {row[2].ToString()} {row[3].ToString()}개",
                              row[0].ToString());
            }

            Cmb_Order.DataSource = new BindingSource(orderList, null);
            Cmb_Order.DisplayMember = "Key";    // 일자 + 생산품목 및 그 개수에 대한 정보를 Display한다
            Cmb_Order.ValueMember = "Value";    // 작업지시 코드를 Value로 한다
        }

        /// <summary>
        /// DB에서 받은 데이터를 가지고 선택한 작업지시에 대한 정보를 출력한다
        /// </summary>
        private void Cmb_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnect dbConnect = new DBConnect();
            IniFile ini = new IniFile();
            ini.Load(IniData.SettingIniFile);
            IniSection dbSection = ini[DBConnect.IniSectionName];

            string commandText = $@"Select O.{dbSection["OrderTB_Date"]}, O.{dbSection["OrderTB_Item"]}, I.{dbSection["ItemTB_Name"]},
                                           O.{dbSection["OrderTB_Amount"]}, O.{dbSection["OrderTB_Proc"]}, P.{dbSection["Code_ProcTB_Name"]}
                                      from {dbSection["OrderTB"]} as O
                                      Inner Join {dbSection["ItemTB"]} as I
                                              on O.{dbSection["OrderTB_Item"]} = I.{dbSection["ItemTB_No"]}
                                      Inner Join {dbSection["Code_ProcTB"]} as P
                                              on O.{dbSection["OrderTB_Proc"]} = P.{dbSection["Code_ProcTB_Code"]}
                                              where O.{dbSection["OrderTB_No"]} = @Code";

            SqlCommand command = new SqlCommand(commandText);

            KeyValuePair<string, string> keyvalPair = (KeyValuePair<string, string>)Cmb_Order.SelectedItem;
            SqlParameter param_Code = new SqlParameter("@Code", SqlDbType.VarChar, 20);
                         param_Code.Value = keyvalPair.Value;
            
            command.Parameters.Add(param_Code);

            DataSet orderData = dbConnect.Search(command);
            if (orderData == null)
                return;

            SqlParameter param_ProcCode = new SqlParameter("@ProcCode", SqlDbType.VarChar, 20);
                         param_ProcCode.Value = orderData.Tables[0].Rows[0][4].ToString();
            command.Parameters.Add(param_ProcCode);

            command.CommandText = $@"Select {dbSection["Code_MachTB_Code"]}, {dbSection["Code_MachTB_Name"]}
                                       from {dbSection["Code_MachTB"]}
                                      where {dbSection["Code_MachTB_RefProc"]} = @ProcCode";

            DataSet machData = dbConnect.Search(command);
            if (machData == null)
                return;

            // DB에서 받은 데이터를 가지고 선택한 작업지시에 대한 정보를 출력한다
            Txt_ItemCode.Text = orderData.Tables[0].Rows[0][1].ToString();
            Txt_ItemName.Text = orderData.Tables[0].Rows[0][2].ToString();
            Txt_TargetAmount.Text = orderData.Tables[0].Rows[0][3].ToString();
            Txt_ProcName.Text = orderData.Tables[0].Rows[0][5].ToString();

            Dictionary<string, string> machList = new Dictionary<string, string>();
            foreach(DataRow row in machData.Tables[0].Rows)
            {
                machList.Add(row[1].ToString(), row[0].ToString());
            }
            Cmb_Machine.DataSource = new BindingSource(machList, null);
            Cmb_Machine.DisplayMember = "Key";
            Cmb_Machine.ValueMember = "Value";
        }
        #endregion

        #region ---- Periodic Operations (타이머 및 타이머를 통해 주기적으로 실행되는 함수)
        int ticks = 0;
        private void Tim_PerSec_Tick(object sender, EventArgs e)
        {
            SetRealTime();
            GetDataFromPLC();
            ticks++;
            if(ticks >= 5)
            {
                ticks = 0;
            }
            
        }

        /// <summary>
        /// 서버의 시간을 받아 표시하기 위한 함수
        /// </summary>
        private void SetRealTime()
        {
            if (false)
            {

            }
            Txt_CurrentTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// PLC로부터 데이터를 받아오는 함수
        /// </summary>
        private void GetDataFromPLC()
        {
            if(Cmb_Order.SelectedIndex > 0)
            {
                GetProdData();
                GetTemperData();
            }
        }

        /// <summary>
        /// PLC로부터 생산현황에 대한 정보를 받아오는 함수
        /// </summary>
        private void GetProdData()
        {

        }

        /// <summary>
        /// PLC로부터 온도 관련 정보를 받아오는 함수
        /// </summary>
        private void GetTemperData()
        {

        }

        private void Tim_Per3Sec_Tick(object sender, EventArgs e)
        {
            ViewQualityData();
        }

        // 3초 주기로 저장
        private void SaveDataToDB()
        {
            
        }

        #endregion

        #region ---- Chart
        List<String> QualityNames = new List<string>();
        private void InitializeChart()
        {
            IniFile iniFile = new IniFile();
            iniFile.Load(IniData.SettingIniFile);
            IniSection dbSection = iniFile[DBConnect.IniSectionName];

            DBConnect connect = new DBConnect();
            SqlCommand command = new SqlCommand();
            command.CommandText = $@"Select {dbSection["QMasTB_Code"]}, {dbSection["QMasTB_Name"]}, {dbSection["QMasTB_Min"]}, {dbSection["QMasTB_Max"]}
                                       from {dbSection["QMasTB"]}";
            DataSet datas = connect.Search(command);
            ControlLayout ctrlLayout = new ControlLayout();
            foreach(DataRow row in datas.Tables[0].Rows)
            {
                Tab_Data.TabPages.Add(row[0].ToString(), row[1].ToString());

                Chart cht = new Chart();
                cht.ChartAreas.Add($"{row[0].ToString()}Area");
                cht.Legends.Add(row[0].ToString());
                cht.Series.Add(row[0].ToString());
                cht.Series[row[0].ToString()].ChartType = SeriesChartType.Line;
                cht.Series[row[0].ToString()].BorderWidth = 4;
                cht.Series[row[0].ToString()].ChartArea = $"{row[0].ToString()}Area";
                cht.Series[row[0].ToString()].Legend = row[0].ToString();
                cht.Series[row[0].ToString()].LegendText = row[0].ToString();
                cht.Series[row[0].ToString()].XValueType = ChartValueType.DateTime;
                cht.ChartAreas[$"{row[0].ToString()}Area"].AxisX.LabelStyle.Format = "HH시 mm분";

                // 품질 경계를 표시하기 위한 코드
                double min = double.Parse(row[2].ToString());
                double max = double.Parse(row[3].ToString());
                double minborder = (min * 1.5) - (max * 0.5);
                double maxborder = (max * 1.5) - (min * 0.5);
                cht.ChartAreas[$"{row[0].ToString()}Area"].AxisY.Minimum = minborder;
                cht.ChartAreas[$"{row[0].ToString()}Area"].AxisY.Maximum = maxborder;
                cht.ChartAreas[$"{row[0].ToString()}Area"].AxisY.Interval = (max - min) * 0.5;
                StripLine line = new StripLine();
                line.Interval = 0;
                line.StripWidth = (max - min) * 0.5;
                line.BackColor = Color.Salmon;
                line.IntervalOffset = minborder;
                StripLine line2 = new StripLine();
                line2.Interval = 0;
                line2.StripWidth = (max - min) * 0.5;
                line2.BackColor = Color.Salmon;
                line2.IntervalOffset = max;
                cht.ChartAreas[$"{row[0].ToString()}Area"].AxisY.StripLines.Add(line);
                cht.ChartAreas[$"{row[0].ToString()}Area"].AxisY.StripLines.Add(line2);

                //cht.ChartAreas[$"{row[0].ToString()}Area"].AxisX.IntervalType = DateTimeIntervalType.Seconds;
                //cht.ChartAreas[$"{row[0].ToString()}Area"].AxisX.Interval = 3;
                ctrlLayout.Control_Sizing(cht, this.Size, 0.5f, 0.3f);
                Tab_Data.TabPages[row[0].ToString()].Controls.Add(cht);
            }
        }

        private void ViewQualityData()
        {
            IniFile iniFile = new IniFile();
            iniFile.Load(IniData.SettingIniFile);
            IniSection dbSection = iniFile[DBConnect.IniSectionName];
            IniSection equipSection = iniFile["Equipment"];

            DBConnect connect = new DBConnect();
            for(int i = 0; i < Tab_Data.TabPages.Count; i++)
            {
                TabPage page = Tab_Data.TabPages[i];
                SqlCommand command = new SqlCommand();
                command.CommandText = $@"Select Top 30 {dbSection["QConTB_Date"]}, {dbSection["QConTB_Val"]}
                                           from {dbSection["QConTB"]}
                                          Where {dbSection["QConTB_Mach"]} = @Mach AND
                                                {dbSection["QConTB_QM"]} = @QMcode
                                          Order by {dbSection["QConTB_Date"]} DESC";
                SqlParameter param_Mach = new SqlParameter("@Mach", SqlDbType.VarChar, 20);
                             param_Mach.Value = equipSection["Mach_Code"].ToString();
                command.Parameters.Add(param_Mach);
                SqlParameter param_QMcode = new SqlParameter("@QMcode", SqlDbType.VarChar, 20);
                             param_QMcode.Value = page.Name;
                command.Parameters.Add(param_QMcode);
                DataSet qualityDatas = connect.Search(command);

                Chart cht = page.Controls[0] as Chart;

                int retry = cht.Series[page.Name].Points.Count;
                for (int j = 0; j < retry; j++)
                {
                    cht.Series[page.Name].Points.RemoveAt(0);
                }

                foreach (DataRow row in qualityDatas.Tables[0].Rows)
                {
                    int year = int.Parse(row[0].ToString().Substring(0, 4));
                    int month = int.Parse(row[0].ToString().Substring(5, 2));
                    int day = int.Parse(row[0].ToString().Substring(8, 2));
                    int hour = int.Parse(row[0].ToString().Substring(11, 2));
                    int minute = int.Parse(row[0].ToString().Substring(14, 2));
                    int sec = int.Parse(row[0].ToString().Substring(17, 2));
                    DateTime time = new DateTime(year, month, day, hour, minute, sec);
                    cht.Series[page.Name].Points.AddXY(time, float.Parse(row[1].ToString()));

                    // 경고용으로 글자를 붉게 칠하는 코드
                    Graphics graphic = Tab_Data.CreateGraphics();
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    Rectangle rect = Tab_Data.GetTabRect(i);
                    if(Tab_Data.SelectedIndex != i)
                        rect.Offset(0, 2);
                    graphic.DrawString(page.Text, page.Font, Brushes.Red, rect, format);
                }

                //time.ToOADate() - X축 값과 동일한 시간인지 비교하기 위한 Datetime->Double 변환함수
            }


            /*
            string str1 = "2020-09-12 17:09:12";
            string str2 = "2020-09-12 18:09:12";
            int cmp = str1.CompareTo(str2); //str이 더 뒤면 양수, 이전이면 음수가 나옴
            */
        }
        #endregion

        private void Txt_DefectAmount_Click(object sender, EventArgs e)
        {
            // 물품이 생산중인지 여기서 확인해 생산중이 아니라면 키패드가 나오지 않게 하는게 좋겠음
            FRM_NumPadUI numpad = new FRM_NumPadUI();
            if (numpad.ShowDialog() == DialogResult.OK)
                Txt_DefectAmount.Text = numpad.GetInputText();
        }

        private void Txt_DefectAmount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_DefectAmount.Text))
                return;

            int currentProd;
            int defectAmount = int.Parse(Txt_DefectAmount.Text);
            if (int.TryParse(Txt_TotalAmount.Text, out currentProd) && defectAmount <= currentProd)
            {
                Txt_NormalAmount.Text = (currentProd - defectAmount).ToString();
            }
            else
            {
                // 괄호 내 문장은 Txt_DefectAmount_Click 함수 내에 물품 생산 여부를 확인하는 코드가 들어가면 지워질 예정
                FRM_MessageBox.Show("(생산 중이 아니거나 )입력한 불량품의 수가 너무 많습니다", "잘못된 입력 확인");
                Txt_DefectAmount.Text = "";
                return;
            }
        }
    }
}
