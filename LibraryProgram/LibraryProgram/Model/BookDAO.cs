using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace LibraryProgram
{
    class BookDAO
    {
        private static MySqlConnection connection;

        public BookDAO()
        {
            connection = new MySqlConnection(Constant.STRING_CONNECTION);
        }

        public void InsertBook(BookDTO bookDTO) // 등록
        {
            string query = string.Format(Constant.INSERT_QUERY_BOOK, bookDTO.Id, bookDTO.Name, bookDTO.Author, bookDTO.Publisher, bookDTO.Price, bookDTO.Pubdate, bookDTO.Isbn, bookDTO.Quantity);

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
                query = string.Format(Constant.UPDATE_QUERY_BOOK_PRICE_QUANTITY, price, quantity, id);
            }
            if (price.Length > 0 && quantity.Length == 0)
            {
                query = string.Format(Constant.UPDATE_QUERY_BOOK_PRICE, price, id);
            }
            if (price.Length == 0 && quantity.Length > 0)
            {
                query = string.Format(Constant.UPDATE_QUERY_BOOK_QUANTITY, quantity, id);
            }

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void DeleteBook(string id) // 도서 삭제
        {
            string query = string.Format(Constant.DELETE_QUERY_BOOK, id);

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
            int dataCount = 0;

            string query = string.Format(Constant.SELECT_QUERY_BOOK_WHERE_ID, bookId);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                ++dataCount;
            }

            if (dataCount > 0)
            {
                dataReader.Close();
                connection.Close();
                return true;
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
        private void ShowDatabaseOf(List<string>[] bookList, int index)
        { // 데이터베이스 정보 출력 (일부)
            Console.WriteLine("      ID      :  " + bookList[0][index]);
            Console.WriteLine("     NAME     :  " + bookList[1][index]);
            Console.WriteLine("    AUTHOR    :  " + bookList[2][index]);
            Console.WriteLine("  PUBLISHER   :  " + bookList[3][index]);
            Console.WriteLine("    PRICE     :  " + bookList[4][index] + "\\");
            Console.WriteLine("   PUBDATE    :  " + bookList[5][index]);
            Console.WriteLine("     ISBN     :  " + bookList[6][index]);
            Console.WriteLine("   QUANTITY   :  " + bookList[7][index]);
            Console.WriteLine("==============================================================================");
        }
    }
}
