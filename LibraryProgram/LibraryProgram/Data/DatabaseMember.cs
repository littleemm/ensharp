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
        private static string stringConnection = "Server=localhost;Database=ensharpstudy;Uid=root;Pwd=0000;charset=utf8;";
        private static MySqlConnection connection;

        public DatabaseMember()
        {
            connection = new MySqlConnection(stringConnection);
        }

        public bool SelectMember(string id, string pw)
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
                if (element[0][i].Contains(id))
                {
                    for (int j = 0; j < element[1].Count; j++)
                    {
                        if (element[1][i].Contains(pw))
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

        public void InsertMember(MemberVO memberVO)
        {
            string query = "INSERT INTO member(id, password, name, age, phoneNumber, address)" +
                "Value('" +  memberVO.Id + "', '" + memberVO.Password + "', '" + memberVO.Name + "', '" +
                memberVO.Age + "', '" + memberVO.PhoneNumber + "', '" + memberVO.Address + "');";

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

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
                
                if (dataReader["CheckOutBook"].ToString() == "")
                {
                    Console.WriteLine("  대출 도서   :  없음");
                    Console.WriteLine("  반납까지 -  :  해당없음");

                }
                else
                {
                    Console.WriteLine("  대출 도서   :  " + dataReader["checkOutBook"].ToString());
                    Console.WriteLine("  반납까지 -  :  " + dataReader["timeBOOk"].ToString());
                }
                Console.WriteLine("==============================================================================");
            }

            connection.Close();
        }



    }
}
