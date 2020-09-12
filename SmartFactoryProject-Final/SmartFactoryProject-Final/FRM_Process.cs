
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

namespace SmartFactoryProject_Final
{
    public partial class FRM_Process : Form
    {
        public FRM_Process()
        {
            InitializeComponent();
        }

        public FRM_Process(Form parent) : this()
        {
            this.MdiParent = parent;
        }

        #region ---- Initialize
        private void Frm_Process_Load(object sender, EventArgs e)
        {
            Initialize();
        }
        
        public void Initialize()
        {
            Tim_PerSec.Enabled = true;
            Tim_PerSec.Interval = 1000;
            Cmb_Order.SelectedIndex = -1;
            Cmb_Machine.SelectedIndex = -1;

            SetRealTime();
            LoadOrders();
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

        // 3초 주기로 저장
        private void SaveDataToDB()
        {
            
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
                MessageBox.Show("(생산 중이 아니거나 )입력한 불량품의 수가 너무 많습니다");
                Txt_DefectAmount.Text = "";
                return;
            }
        }
    }
}
