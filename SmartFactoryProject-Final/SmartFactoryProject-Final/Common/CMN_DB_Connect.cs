using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFactoryProject_Final.Common
{
    class DBConnect
    {
        //ini파일 내의 섹션명
        public const string IniSectionName = "DBConnect";
        //ini파일 내의 매개변수 명
        public const string Param_DB_IP = "DatabaseIP";
        public const string Param_DB_Name = "DatabaseName";
        public const string Param_Security = "Security";
        public const string Param_DB_ID = "DatabaseID";
        public const string Param_DB_PW = "DatabasePW";
        
        public static string GetConString()
        {
            IniFile iniFile = new IniFile();
            iniFile.Load(IniData.SettingIniFile);
            IniSection dbSection = iniFile[IniSectionName];
            return $"Data Source={dbSection[Param_DB_IP]};" +
                   $"Initial Catalog={dbSection[Param_DB_Name]};" +
                   $"Persist Security Info={dbSection[Param_Security]};" +
                   $"User ID={dbSection[Param_DB_ID]};" +
                   $"Password={dbSection[Param_DB_PW]}";
        }

        /// <summary>
        /// 주어진 쿼리문을 실행해 그 결과를 DataSet으로 리턴하는 함수
        /// </summary>
        /// <param name="commandText">입력 쿼리문</param>
        /// <param name="dataset">출력 DataSet</param>
        /// <returns>통신이 정상적으로 이루어졌는지의 여부</returns>
        public bool Search(string commandText, out DataSet dataset)
        {
            SqlCommand command = new SqlCommand(commandText);
            return Search(command, out dataset);
        }

        /// <summary>
        /// SqlCommand를 실행해 그 결과를 DataSet으로 리턴하는 함수
        /// </summary>
        /// <param name="command">입력 SqlCommand</param>
        /// <param name="dataset">출력 DataSet</param>
        /// <returns>통신이 정상적으로 이루어졌는지의 여부</returns>
        public bool Search(SqlCommand command, out DataSet dataset)
        {
            SqlConnection connection = null;
            DataSet result = null;
            SqlDataAdapter adapter = null;

            try
            {
                using (connection = new SqlConnection(GetConString()))
                {
                    command.Connection = connection;
                    command.Connection.Open();
                    command.CommandTimeout = 1000;

                    adapter = new SqlDataAdapter(command);
                    result = new DataSet();
                    adapter.Fill(result, "TB_result");

                    command.Connection.Close();
                }

                if (result.Tables[0].Rows.Count > 0)
                    dataset = result;
                else
                    dataset = null;
            }
            catch (Exception excep)
            {
                string className = nameof(DBConnect);
                string funcName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                string logText = string.Concat(excep.Message.ToString(), Environment.NewLine,
                                               command.Connection.ConnectionString, Environment.NewLine,
                                               command.CommandText);
                Log.WriteLog(Log.LogType.Error, className, funcName, logText);
                dataset = null;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 멘토님이 주신 코드에서 긁어온 저장 프로시저용 코드지만 아직 안쓰고 있음
        /// </summary>
        /// <param name="PROC"></param>
        /// <param name="PARAM"></param>
        /// <returns></returns>
        public DataSet Search(string PROC, object[] PARAM)
        {
            DataSet DS = null;
            SqlConnection CONN = null;
            SqlCommand CMD = null;
            SqlDataAdapter DAP = null;

            string connectString = GetConString();
            string commandText = "";

            try
            {
                commandText = "EXEC " + PROC;

                if (PARAM != null)
                {
                    string p = "";
                    for (int i = 0; i < PARAM.Length; i++)
                    {
                        p = PARAM[i].ToString().Replace("'", "");
                        commandText += (i > 0 ? ", " : " ") + "'" + p + "'";
                    }
                }

                DS = new DataSet();
                CMD = new SqlCommand();
                DAP = new SqlDataAdapter();

                CONN = new SqlConnection(connectString);
                CONN.Open();

                CMD.Connection = CONN;
                CMD.CommandText = commandText;

                DAP.SelectCommand = CMD;
                DAP.SelectCommand.CommandTimeout = 1000;

                DAP.Fill(DS, "LIST");

                if (DS.Tables.Count > 1)
                {
                    for (int k = 0; k < DS.Tables.Count; k++)
                    {
                        DS.Tables[k].TableName = "LIST_" + (k + 1).ToString();
                    }
                }

                return DS;
            }
            catch (Exception excep)
            {
                // Log 기록
                string className = nameof(DBConnect);
                string funcName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                string logText = string.Concat(excep.Message.ToString(), Environment.NewLine,
                                               connectString, Environment.NewLine,
                                               commandText);
                Log.WriteLog(Log.LogType.Error, className, funcName, logText);
                return null;
            }
            finally
            {
                if (CONN != null)
                {
                    if (CONN.State == ConnectionState.Open)
                    {
                        CONN.Close();
                    }
                    CONN.Dispose();
                }

                if (DS != null)
                {
                    DS.Dispose();
                }

                if (DAP != null)
                {
                    DAP.Dispose();
                }

                if (CMD != null)
                {
                    CMD.Dispose();
                }
            }
        }
    }
}
