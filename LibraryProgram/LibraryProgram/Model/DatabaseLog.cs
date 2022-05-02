using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace LibraryProgram
{
    class DatabaseLog
    {
        private static MySqlConnection connection;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public DatabaseLog()
        {
            connection = new MySqlConnection(Constant.STRING_CONNECTION);
        }

        public void ExportLog()
        {
            string query = "SELECT * FROM log INTO OUTFILE '" + path + "/log.txt'" +
                "FIELDS TERMINTAED BY ','" +
                "ENCLOSED BY '\"' ESCAPED BY '\\' LINES TERMINATED BY '\n'";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
            connection.Close();
        }

        public void InsertLog(LogVO logVO) // 로그 등록
        {
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            logVO.Date = today.ToString("yyyy-MM-dd");
            logVO.Time = now.ToString("hh:mm:ss");

            string query = Constant.INSERT_QUERY_LOG +
                "Value('" + logVO.Date + "', '" + logVO.Time + "', '" + logVO.User + "', '" +
                logVO.History + "');";

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void DeleteLogList(string id) // 로그 일부 지움
        {
            string query = Constant.DELETE_QUERY_LOG + "WHERE id = '" + id + "';";

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void TruncateLogList() // 로그 내역 전면 지우기
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand(Constant.TRUNCATE_QUERY_LOG, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void SelectLogList() // 로그 리스트를 출력함
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_LOG, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                // id를 정렬하기 위해 공백을 채우는 과정 (4자리 채우기)
                string id = dataReader["id"].ToString(); 
                if (dataReader["id"].ToString().Length < 4)
                {
                    for (int i = 1; i <= 4 - dataReader["id"].ToString().Length; i++)
                    {
                        id += " ";
                    }
                }

                // user를 정렬하기 위해 공백을 채우는 과정 (8자리 채우기)
                string user = dataReader["user"].ToString();
                if (dataReader["user"].ToString().Equals("관리자"))
                {
                    user += "  ";
                }
                else if (dataReader["user"].ToString().Length < 8)
                {
                    for (int i = 1; i <= 8 - dataReader["user"].ToString().Length; i++) 
                    {
                        user += " ";
                    }
                }
             

                // history를 정렬해야 하는데 너무 긴 경우를 대비해 길이 20이하로 제한
                string history = dataReader["history"].ToString(); ;
                if (dataReader["history"].ToString().Length > 20)
                {
                    history = dataReader["history"].ToString().Substring(0,20) + "...";
                }

                Console.WriteLine(id + " " + dataReader["date"].ToString() + " " + 
                    dataReader["time"].ToString() + " " + user + " " + 
                    history);

            }

            dataReader.Close();
            connection.Close();
        }

        public bool IsLogId(string id)
        { // 실제 존재하는 logID인지 체크
            connection.Open();

            List<string> element = new List<string>();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_LOG, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element.Add(dataReader["id"].ToString());
            }

            for (int i = 0; i < element.Count; i++)
            {
                if (element[i].Equals(id))
                {
                    dataReader.Close();
                    connection.Close();
                    return true;
                }
            }

            dataReader.Close();
            connection.Close();
            return false;
        }

    }
}
