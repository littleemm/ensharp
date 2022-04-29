using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace LibraryProgram
{
    class DatabaseMember
    {
        private MySqlConnection connection;
        public DatabaseMember()
        {
            connection = new MySqlConnection(Constant.STRING_CONNECTION);
        }
       
        public bool SelectMember(string query, string id, string password) // 불러오기
        {
            connection.Open();
            
            List<string>[] element = new List<string>[2];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["id"].ToString());
                element[1].Add(dataReader["password"].ToString());
            }
            
            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(id))
                {
                    if (element[0][i].Equals(id) && element[1][i].Equals(password))
                {
                        dataReader.Close();
                        connection.Close();
                        return true;
                    }
                }
            }

            dataReader.Close();
            connection.Close();

            return false;
        }

        public void InsertMember(MemberVO memberVO) // 등록
        {
            string query = Constant.INSERT_QUERY_MEMBER +
                "Value('" +  memberVO.Id + "', '" + memberVO.Password + "', '" + memberVO.Name + "', '" +
                memberVO.Age + "', '" + memberVO.PhoneNumber + "', '" + memberVO.Address + "', '" + "0');";

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void UpdateMember(string address, string phoneNumber, string id) // 주소, 번호만 변경
        {
            string query = "";

            if (phoneNumber.Length > 0 && address.Length > 0)
            {
                query = Constant.UPDATE_QUERY_MEMBER + "SET phoneNumber = '" + phoneNumber + "', " +
                    "address = '" + address + "' WHERE id = '" + id + "';";
            }
            if (phoneNumber.Length > 0 && address.Length == 0)
            {
                query = Constant.UPDATE_QUERY_MEMBER + "SET phoneNumber = '" + phoneNumber +
                    "' WHERE id = '" + id + "';";
            }
            if (phoneNumber.Length == 0 && address.Length > 0)
            {
                query = Constant.UPDATE_QUERY_MEMBER + "SET address = '" + address +
                    "' WHERE id = '" + id + "';";
            }

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void DeleteMember(string id) // 회원 삭제
        {
            string query = Constant.DELETE_QUERY_MEMBER + "WHERE id = '" + id + "';";

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void SelectMemberOfList(string id)
        {
            connection.Open();

            List<string>[] element = new List<string>[6];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBER, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["id"].ToString());
                element[1].Add(dataReader["name"].ToString());
                element[2].Add(dataReader["age"].ToString());
                element[3].Add(dataReader["address"].ToString());
                element[4].Add(dataReader["phoneNumber"].ToString());
                element[5].Add(dataReader["bookCount"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Contains(id))
                {
                    Console.WriteLine("      ID      :  " + element[0][i]);
                    Console.WriteLine("     NAME     :  " + element[1][i]);
                    Console.WriteLine("      AGE     :  " + element[2][i] + "세");
                    Console.WriteLine("   ADDRESS    :  " + element[3][i]);
                    Console.WriteLine(" PHONE NUMBER :  " + element[4][i]);
                    Console.WriteLine("  BOOK COUNT  :  " + element[5][i] + "권");
                    Console.WriteLine("==============================================================================");
                }
            }
            
            dataReader.Close();
            connection.Close();
        }

        public void SelectMemberList()
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBER, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine("      ID      :  " + dataReader["id"].ToString());
                Console.WriteLine("     NAME     :  " + dataReader["name"].ToString());
                Console.WriteLine("      AGE     :  " + dataReader["age"].ToString() + "세");
                Console.WriteLine("   ADDRESS    :  " + dataReader["address"].ToString());
                Console.WriteLine(" PHONE NUMBER :  " + dataReader["phoneNumber"].ToString());
                Console.WriteLine("  BOOK COUNT  :  " + dataReader["bookCount"].ToString() + "권");
                Console.WriteLine("==============================================================================");
            }

            dataReader.Close();
            connection.Close();
        }

        public bool IsMemberId(string memberId)
        {
            connection.Open();

            List<string> element = new List<string>();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBER, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element.Add(dataReader["id"].ToString());
            }

            for (int i = 0; i < element.Count; i++)
            {
                if (element[i].Equals(memberId))
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

        public bool IsSearchedMemberId(string memberId)
        {
            connection.Open();

            List<string> element = new List<string>();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBER, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element.Add(dataReader["id"].ToString());
            }

            for (int i = 0; i < element.Count; i++)
            {
                if (element[i].Contains(memberId))
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
