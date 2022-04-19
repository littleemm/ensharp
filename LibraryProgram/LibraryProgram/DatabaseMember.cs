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
        private static string stringConnection = "Server=localhost;Database=ensharpstudy;Uid=root;Pwd=0000;charset=utf8";
        MySqlConnection connection;

        public DatabaseMember()
        {
            connection = new MySqlConnection(stringConnection);
        }

        public bool SelectMember(int count, string id, string pw)
        {
            connection.Open();
            string query = "SELECT * FROM member";

            List<string>[] element = new List<string>[count];

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
                    for (int j = 0; j < element[1].Count; i++)
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



    }
}
