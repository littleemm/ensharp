using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace LibraryProgram
{
    class DatabaseBook
    {
        private static string stringConnection = "Server=localhost;Database=김영림_library;Uid=root;Pwd=0000;charset=utf8;";
        private static MySqlConnection connection;

        public DatabaseBook()
        {
            connection = new MySqlConnection(stringConnection);
        }

        public void InsertBook(BookVO bookVO) // 등록
        {
            string query = "INSERT INTO book(id, name, author, publisher, price, quantity)" +
                "Value('" + bookVO.Id + "', '" + bookVO.Name + "', '" + bookVO.Author + "', '" +
                bookVO.Publisher + "', '" + bookVO.Price + "', '" + bookVO.Quantity + "');";

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void UpdateBook(string price, string quantity, string id) // 수량, 가격만 변경
        {
            string query = "";

            if (price.Length > 0 && quantity.Length > 0)
            {
                query = "UPDATE book SET price = '" + price + "', " +
                    "quantity = '" + quantity + "' WHERE id = '" + id + "';";
            }
            if (price.Length > 0 && quantity.Length == 0)
            {
                query = "UPDATE book SET price = '" + price +
                    "' WHERE id = '" + id + "';";
            }
            if (price.Length == 0 && quantity.Length > 0)
            {
                query = "UPDATE book SET quantity = '" + quantity +
                    "' WHERE id = '" + id + "';";
            }

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void DeleteBook(string id) // 도서 삭제
        {
            string query = "DELETE FROM book WHERE id = '" + id + "';";

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void SelectBookOfList(string value)
        {
            connection.Open();

            string query = "SELECT * FROM book";

            List<string>[] element = new List<string>[6];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["id"].ToString());
                element[1].Add(dataReader["name"].ToString());
                element[2].Add(dataReader["author"].ToString());
                element[3].Add(dataReader["publisher"].ToString());
                element[4].Add(dataReader["price"].ToString());
                element[5].Add(dataReader["quantity"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[1][i].Contains(value)) // 책 제목이 일부 포함되면 출력
                {
                    Console.WriteLine("      ID      :  " + element[0][i]);
                    Console.WriteLine("     NAME     :  " + element[1][i]);
                    Console.WriteLine("    AUTHOR    :  " + element[2][i]);
                    Console.WriteLine("  PUBLISHER   :  " + element[3][i]);
                    Console.WriteLine("    PRICE     :  " + element[4][i] + "\\");
                    Console.WriteLine("   QUANTITY   :  " + element[5][i]);
                    Console.WriteLine("==============================================================================");
                }

                else if (element[2][i].Contains(value)) // 저자 이름이 일부 포함되면 출력
                {
                    Console.WriteLine("      ID      :  " + element[0][i]);
                    Console.WriteLine("     NAME     :  " + element[1][i]);
                    Console.WriteLine("    AUTHOR    :  " + element[2][i]);
                    Console.WriteLine("  PUBLISHER   :  " + element[3][i]);
                    Console.WriteLine("    PRICE     :  " + element[4][i] + "\\");
                    Console.WriteLine("   QUANTITY   :  " + element[5][i]);
                    Console.WriteLine("==============================================================================");
                }

                else if (element[3][i].Contains(value)) // 출판사명이 일부 포함되면 출력
                {
                    Console.WriteLine("      ID      :  " + element[0][i]);
                    Console.WriteLine("     NAME     :  " + element[1][i]);
                    Console.WriteLine("    AUTHOR    :  " + element[2][i]);
                    Console.WriteLine("  PUBLISHER   :  " + element[3][i]);
                    Console.WriteLine("    PRICE     :  " + element[4][i] + "\\");
                    Console.WriteLine("   QUANTITY   :  " + element[5][i]);
                    Console.WriteLine("==============================================================================");
                }
            }

            dataReader.Close();
            connection.Close();
        }

        public void SelectBookList()
        {
            connection.Open();
            string query = "SELECT * FROM book";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine("      ID      :  " + dataReader["id"].ToString());
                Console.WriteLine("     NAME     :  " + dataReader["name"].ToString());
                Console.WriteLine("    AUTHOR    :  " + dataReader["author"].ToString());
                Console.WriteLine("  PUBLISHER   :  " + dataReader["publisher"].ToString());
                Console.WriteLine("    PRICE     :  " + dataReader["price"].ToString() + "\\");
                Console.WriteLine("   QUANTITY   :  " + dataReader["quantity"].ToString());
                Console.WriteLine("==============================================================================");
            }

            dataReader.Close();
            connection.Close();
        }

        public bool IsBookId(string bookId)
        {
            string query = "SELECT * FROM book";
            connection.Open();

            List<string> element = new List<string>();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element.Add(dataReader["id"].ToString());
            }

            for (int i=0;i<element.Count;i++)
            {
                if(element[i].Equals(bookId))
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
