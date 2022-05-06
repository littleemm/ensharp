using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace LibraryProgram
{
    class DatabaseMemberBook
    {
        static public DatabaseMemberBook databaseMemberBook = new DatabaseMemberBook();
        private MySqlConnection connection;
        private DatabaseMemberBook()
        {
            connection = new MySqlConnection(Constant.STRING_CONNECTION);
        }

        public static DatabaseMemberBook getInstance() //써보기
        {
            return databaseMemberBook;
        }

        public void SelectMemberBook(string memberId) // 자신이 빌린책 불러오기
        {
            connection.Open();

            List<string>[] element = new List<string>[7];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBERBOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["memberId"].ToString());
                element[1].Add(dataReader["id"].ToString());
                element[2].Add(dataReader["bookId"].ToString());
                element[3].Add(dataReader["bookName"].ToString());
                element[4].Add(dataReader["bookPublisher"].ToString());
                element[5].Add(dataReader["checkOutDate"].ToString());
                element[6].Add(dataReader["dueDate"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(memberId))
                {
                    Console.WriteLine("   REGISTRATION NUMBER  :  " + element[1][i]);
                    Console.WriteLine("         BOOK ID        :  " + element[2][i]);
                    Console.WriteLine("        BOOK NAME       :  " + element[3][i]);
                    Console.WriteLine("        PUBLISHER       :  " + element[4][i]);
                    Console.WriteLine("     CHECK OUT DATE     :  " + element[5][i]);
                    Console.WriteLine("        DUE DATE        :  " + element[6][i]);
                    Console.WriteLine("==============================================================================");
                }
            }

            dataReader.Close();
            connection.Close();
        }

        public void InsertMemberBook(string bookId, string memberId) // 대출하기
        {
            string bookName = "", bookPublisher = "";

            connection.Open();

            List<string>[] element = new List<string>[3];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_BOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["name"].ToString());
                element[1].Add(dataReader["publisher"].ToString());
                element[2].Add(dataReader["id"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[2][i].Equals(bookId))
                {
                    bookName = element[0][i];
                    bookPublisher = element[1][i];
                    break;
                }
            }

            dataReader.Close();
            connection.Close();

            InsertMemberBook(memberId, bookId, bookName, bookPublisher);
        }

        private void InsertMemberBook(string memberId, string bookId, string bookName, string bookPublisher)
        {
            DateTime today = DateTime.Today;
            DateTime due = today.AddDays(7);

            string query = string.Format(Constant.INSERT_QUERY_MEMBERBOOK, memberId, bookId, bookName, bookPublisher, today.ToString("yyyy-MM-dd"), due.ToString("yyyy-MM-dd"));

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();

            UpdateBookCount(memberId, "CheckOut");
            UpdateBookQuantity(bookId, "CheckOut");
        }

        public bool DeleteMemberBook(string bookId, string memberId) // 반납하기
        {
            connection.Open();
            
            List<string>[] element = new List<string>[7];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBERBOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["memberId"].ToString());
                element[1].Add(dataReader["bookId"].ToString());
                element[2].Add(dataReader["id"].ToString());
            }

            dataReader.Close();

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(memberId) && element[1][i].Equals(bookId))
                {
                    string query = string.Format(Constant.DELETE_QUERY_MEMBERBOOK, element[2][i]);
                    command = new MySqlCommand(query, connection);
                    MySqlDataReader memberbookDataReader = command.ExecuteReader();

                    memberbookDataReader.Close();
                    connection.Close();

                    UpdateBookCount(memberId, "Return");
                    UpdateBookQuantity(bookId, "Return");

                    return true;
                }

            }

            connection.Close();

            return false;
        }

        public bool IsBookId(string bookId) // 존재하는 bookId인지 확인
        {
            connection.Open();

            List<string> element = new List<string>();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_BOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element.Add(dataReader["id"].ToString());
            }

            for (int i = 0; i < element.Count; i++)
            {
                if (element[i].Equals(bookId))
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

        public bool IsBookCount(string bookId) // 남아있는 권수 확인 (book에서)
        {
            connection.Open();

            List<string>[] element = new List<string>[2];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_BOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["id"].ToString());
                element[1].Add(dataReader["quantity"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(bookId) && int.Parse(element[1][i]) > 0)
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

        public bool IsCheckedOutBook(string bookId, string memberId) // 원래 빌렸던 책인지 확인 (memberBook에서)
        {
            connection.Open();

            List<string>[] element = new List<string>[2];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBERBOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["memberId"].ToString());
                element[1].Add(dataReader["bookId"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(memberId) && element[1][i].Equals(bookId))
                {
                    dataReader.Close();
                    connection.Close();
                    return false;
                }
            }

            dataReader.Close();
            connection.Close();
            return true;
        }

        private void UpdateBookCount(string memberId, string condition) // 자신이 빌린 책의 권수 조정
        {
            int bookCount;

            connection.Open();
            List<string>[] element = new List<string>[2];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBER, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["bookCount"].ToString());
                element[1].Add(dataReader["id"].ToString());
            }

            dataReader.Close();

            string query = "";

            for (int i = 0; i < element[1].Count; i++)
            {
                if (element[1][i].Equals(memberId) && condition.Equals("CheckOut"))
                { // 대출하는 경우
                    bookCount = int.Parse(element[0][i]);
                    bookCount++;
                    query = string.Format(Constant.UPDATE_QUERY_MEMBER_BOOKCOUNT, bookCount.ToString(), memberId);
                    break;
                }

                if (element[1][i].Equals(memberId) && condition.Equals("Return"))
                { // 반납하는 경우
                    bookCount = int.Parse(element[0][i]);
                    bookCount--;
                    query = string.Format(Constant.UPDATE_QUERY_MEMBER_BOOKCOUNT, bookCount.ToString(), memberId);
                    break;
                }
            }

            command = new MySqlCommand(query, connection);
            MySqlDataReader bookCountDataReader = command.ExecuteReader();

            bookCountDataReader.Close();
            connection.Close();
        }

        private void UpdateBookQuantity(string bookId, string condition) // 책의 잔여 수량 조정
        {
            int quantity;

            connection.Open();
            List<string>[] element = new List<string>[2];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_BOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["quantity"].ToString());
                element[1].Add(dataReader["id"].ToString());
            }

            dataReader.Close();

            string query = "";

            for (int i = 0; i < element[1].Count; i++)
            {
                if (element[1][i].Equals(bookId) && condition.Equals("CheckOut"))
                { // 대출하는 경우
                    quantity = int.Parse(element[0][i]);
                    quantity--;
                    query = string.Format(Constant.UPDATE_QUERY_BOOK_QUANTITY, quantity.ToString(), bookId);
                    break;
                }

                if (element[1][i].Equals(bookId) && condition.Equals("Return"))
                { // 반납하는 경우
                    quantity = int.Parse(element[0][i]);
                    quantity++;
                    query = string.Format(Constant.UPDATE_QUERY_BOOK_QUANTITY, quantity.ToString(), bookId);
                    break;
                }
            }

            command = new MySqlCommand(query, connection);
            MySqlDataReader bookCountDataReader = command.ExecuteReader();

            bookCountDataReader.Close();
            connection.Close();
        }

        public void SelectMemberBookList()
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBERBOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            ShowDatabase(dataReader);
            dataReader.Close();
            connection.Close();
        }

        public bool IsMemberCheckedOut(string memberOrBookId, string id) // 빌린 내역 확인
        {
            connection.Open();

            List<string> element = new List<string>();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBERBOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element.Add(dataReader[id].ToString());
            }

            for (int i = 0; i < element.Count; i++)
            {
                if (element[i].Equals(memberOrBookId))
                {
                    dataReader.Close();
                    connection.Close();
                    return false;
                }
            }

            dataReader.Close();
            connection.Close();
            return true;
        }

        private void ShowDatabase(MySqlDataReader dataReader) // 데이터베이스의 정보 출력 (모두)
        {
            while (dataReader.Read())
            {
                Console.WriteLine("      ID      :  " + dataReader["id"].ToString());
                Console.WriteLine("   BOOK ID    :  " + dataReader["bookId"].ToString());
                Console.WriteLine("  BOOK NAME   :  " + dataReader["bookName"].ToString());
                Console.WriteLine("  MEMBER ID   :  " + dataReader["memberId"].ToString());
                Console.WriteLine("  PUBLISHER   :  " + dataReader["bookPublisher"].ToString() + "\\");
                Console.WriteLine("CHECKOUT DATE :  " + dataReader["checkOutDate"].ToString());
                Console.WriteLine("   DUE DATE   :  " + dataReader["duedate"].ToString());
                Console.WriteLine("==============================================================================");
            }
        }
    }
}

