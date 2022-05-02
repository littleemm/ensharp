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
        private static MySqlConnection connection;

        public DatabaseBook()
        {
            connection = new MySqlConnection(Constant.STRING_CONNECTION);
        }

        public void InsertBook(BookVO bookVO) // 등록
        {
            string query = Constant.INSERT_QUERY_BOOK +
                "Value('" + bookVO.Id + "', '" + bookVO.Name + "', '" + bookVO.Author + "', '" +
                bookVO.Publisher + "', '" + bookVO.Price + "', '" + bookVO.Pubdate + "', '" +
                bookVO.Isbn + "', '" + bookVO.Quantity + "');";

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void UpdateBook(string price, string quantity, string id) // 수량, 가격만 변경
        {
            string query = "";

            if (price.Length > 0 && quantity.Length > 0) // if - else if 로
            {
                query = Constant.UPDATE_QUERY_BOOK + "SET price = '" + price + "', " +
                    "quantity = '" + quantity + "' WHERE id = '" + id + "';";
            }
            if (price.Length > 0 && quantity.Length == 0)
            {
                query = Constant.UPDATE_QUERY_BOOK + "SET price = '" + price +
                    "' WHERE id = '" + id + "';";
            }
            if (price.Length == 0 && quantity.Length > 0)
            {
                query = Constant.UPDATE_QUERY_BOOK + "SET quantity  = '" + quantity +
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
            string query = Constant.DELETE_QUERY_BOOK + "WHERE id = '" + id + "';";

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void SelectBookOfList(string value) // 리스트에서 검색하기 위한 것
        {
            connection.Open();

            List<string>[] element = new List<string>[8];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_BOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["id"].ToString());
                element[1].Add(dataReader["name"].ToString());
                element[2].Add(dataReader["author"].ToString());
                element[3].Add(dataReader["publisher"].ToString());
                element[4].Add(dataReader["price"].ToString());
                element[5].Add(dataReader["pubdate"].ToString());
                element[6].Add(dataReader["isbn"].ToString());
                element[7].Add(dataReader["quantity"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[1][i].Contains(value)) // 책 제목이 일부 포함되면 출력
                {
                    ShowDatabaseOf(element, i);
                }

                else if (element[2][i].Contains(value)) // 저자 이름이 일부 포함되면 출력
                {
                    ShowDatabaseOf(element, i);
                }

                else if (element[3][i].Contains(value)) // 출판사명이 일부 포함되면 출력
                {
                    ShowDatabaseOf(element, i);
                }
            }

            dataReader.Close();
            connection.Close();
        }

        public void SelectBookList() // 리스트 검색
        {
            connection.Open();
            
            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_BOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            ShowDatabase(dataReader);
            dataReader.Close();
            connection.Close();
        }

        public bool IsBookId(string bookId) // 등록된 bookID와 중복되는지 체크
        {
            connection.Open();

            List<string> element = new List<string>();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_BOOK, connection);
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

        private void ShowDatabase(MySqlDataReader dataReader) // 데이터베이스의 정보 출력 (모두)
        {
            while (dataReader.Read())
            {
                Console.WriteLine("      ID      :  " + dataReader["id"].ToString());
                Console.WriteLine("     NAME     :  " + dataReader["name"].ToString());
                Console.WriteLine("    AUTHOR    :  " + dataReader["author"].ToString());
                Console.WriteLine("  PUBLISHER   :  " + dataReader["publisher"].ToString());
                Console.WriteLine("    PRICE     :  " + dataReader["price"].ToString() + "\\");
                Console.WriteLine("   PUBDATE    :  " + dataReader["pubdate"].ToString());
                Console.WriteLine("     ISBN     :  " + dataReader["isbn"].ToString());
                Console.WriteLine("   QUANTITY   :  " + dataReader["quantity"].ToString());
                Console.WriteLine("==============================================================================");
            }
        }
        private void ShowDatabaseOf(List<string>[] element, int index)
        { // 데이터베이스 정보 출력 (일부)
            Console.WriteLine("      ID      :  " + element[0][index]);
            Console.WriteLine("     NAME     :  " + element[1][index]);
            Console.WriteLine("    AUTHOR    :  " + element[2][index]);
            Console.WriteLine("  PUBLISHER   :  " + element[3][index]);
            Console.WriteLine("    PRICE     :  " + element[4][index] + "\\");
            Console.WriteLine("   PUBDATE    :  " + element[5][index]);
            Console.WriteLine("     ISBN     :  " + element[6][index]);
            Console.WriteLine("   QUANTITY   :  " + element[7][index]);
            Console.WriteLine("==============================================================================");
        }
    }
}
