using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
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
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "/log.txt";
        public DatabaseLog()
        {
            connection = new MySqlConnection(Constant.STRING_CONNECTION);
        }

        public void WriteLog()
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_LOG, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            StreamWriter writer;
            string id = "", user = "", history = "";

            if (File.Exists(path))
            {
                writer = File.AppendText(path);
                writer.WriteLine(id + " " + dataReader["date"].ToString() + " " +
               dataReader["time"].ToString() + " " + user + " " +
               history);
            }
            else
            {
                writer = File.CreateText(path);
                SortLog(dataReader, id, user, history);
                writer.WriteLine(id + " " + dataReader["date"].ToString() + " " +
                dataReader["time"].ToString() + " " + user + " " +
                history);
            }

            writer.Close();
            dataReader.Close();
            connection.Close();
        }

        public bool IsLogFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;

            }
            return false;
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
            string id = "", user = "", history = "";

            SortLog(dataReader, id, user, history);

            Console.WriteLine(id + " " + dataReader["date"].ToString() + " " +
                dataReader["time"].ToString() + " " + user + " " +
                history);

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

        private void SortLog(MySqlDataReader dataReader, string id, string user, string history)
        {
            while (dataReader.Read())
            {
                // id를 정렬하기 위해 공백을 채우는 과정 (4자리 채우기)
                id = dataReader["id"].ToString();
                if (dataReader["id"].ToString().Length < 4)
                {
                    for (int i = 1; i <= 4 - dataReader["id"].ToString().Length; i++)
                    {
                        id += " ";
                    }
                }

                // user를 정렬하기 위해 공백을 채우는 과정 (8자리 채우기)
                user = dataReader["user"].ToString();
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


                // history를 정렬해야 하는데 너무 긴 경우를 대비해 길이 25이하로 제한
                history = dataReader["history"].ToString(); ;
                if (dataReader["history"].ToString().Length > 25)
                {
                    history = dataReader["history"].ToString().Substring(0, 25) + "...";
                }
            }
        }
    }
}
