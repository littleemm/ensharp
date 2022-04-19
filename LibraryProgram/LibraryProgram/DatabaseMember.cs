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
        private static void ConnectDatabase()
        {
            
            using (MySqlConnection connection = new MySqlConnection(stringConnection))
            {
                connection.Open();
                string sql = "SELECT * FROM members";

                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {

                }

   
            }
        }

     

    }
}
