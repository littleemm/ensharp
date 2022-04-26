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
        private static string stringConnection = "Server=localhost;Database=김영림_library;Uid=root;Pwd=0000;charset=utf8;";
        private static MySqlConnection connection;

        public DatabaseMember()
        {
            connection = new MySqlConnection(stringConnection);
        }

        public bool SelectMember(string id, string pw) // 불러오기
        {
            connection.Open();
            string query = "SELECT * FROM member";

            List<string>[] element = new List<string>[100];

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
                    for (int j = 0; j < element[1].Count; j++)
                    {
                        if (element[1][i].Equals(pw))
                        {
                            return true;
                        }
                    }
                }
            }

            dataReader.Close();
            connection.Close();

            return false;
        }

        public void InsertMember(MemberVO memberVO) // 등록
        {
            string query = "INSERT INTO member(id, password, name, age, phoneNumber, address)" +
                "Value('" +  memberVO.Id + "', '" + memberVO.Password + "', '" + memberVO.Name + "', '" +
                memberVO.Age + "', '" + memberVO.PhoneNumber + "', '" + memberVO.Address + "');";

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            connection.Close();
        }

        public void UpdateMember(string address, string phoneNumber, string id) // 주소, 번호만 변경
        {
            string query = "";

            if (phoneNumber.Length > 0 && address.Length > 0)
            {
                query = "UPDATE member SET phoneNumber = '" + phoneNumber + "', " +
                    "address = '" + address + "' WHERE id = '" + id + "';";
            }
            if (phoneNumber.Length > 0 && address.Length == 0)
            {
                query = "UPDATE member SET phoneNumber = '" + phoneNumber +
                    "' WHERE id = '" + id + "';";
            }
            if (phoneNumber.Length == 0 && address.Length > 0)
            {
                query = "UPDATE member SET address = '" + address +
                    "' WHERE id = '" + id + "';";
            }

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            connection.Close();
        }

        public void DeleteMember(string id) // 회원 삭제
        {
            string query = "DELETE FROM member WHERE id = '" + id + "';";

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            connection.Close();
        }

        public void SelectMemberOfList(string id)
        {
            connection.Open();

            string query = "SELECT * FROM member";

            List<string>[] element = new List<string>[100];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["id"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Contains(id))
                {
                    Console.WriteLine("      ID      :  " + dataReader["id"].ToString());
                    Console.WriteLine("     NAME     :  " + dataReader["name"].ToString());
                    Console.WriteLine("      AGE     :  " + dataReader["age"].ToString() + "세");
                    Console.WriteLine("   ADDRESS    :  " + dataReader["address"].ToString());
                    Console.WriteLine(" PHONE NUMBER :  " + dataReader["phoneNumber"].ToString());
                    Console.WriteLine("==============================================================================");
                }
            }

            dataReader.Close();
            connection.Close();
        }

        public void SelectMemberList()
        {
            connection.Open();
            string query = "SELECT * FROM member";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine("      ID      :  " +dataReader["id"].ToString());
                Console.WriteLine("     NAME     :  " + dataReader["name"].ToString());
                Console.WriteLine("      AGE     :  " + dataReader["age"].ToString() + "세");
                Console.WriteLine("   ADDRESS    :  " + dataReader["address"].ToString());
                Console.WriteLine(" PHONE NUMBER :  " + dataReader["phoneNumber"].ToString());
                Console.WriteLine("==============================================================================");
            }

            connection.Close();
        }



    }
}
