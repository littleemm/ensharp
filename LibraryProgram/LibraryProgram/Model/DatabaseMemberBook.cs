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

            string query = string.Format(Constant.SELECT_QUERY_MEMBERBOOK_WHERE_MEMBERID, memberId);

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine("   REGISTRATION NUMBER  :  " + dataReader["id"].ToString());
                Console.WriteLine("         BOOK ID        :  " + dataReader["bookId"].ToString());
                Console.WriteLine("        BOOK NAME       :  " + dataReader["bookName"].ToString());
                Console.WriteLine("        PUBLISHER       :  " + dataReader["bookPublisher"].ToString());
                Console.WriteLine("     CHECK OUT DATE     :  " + dataReader["checkOutDate"].ToString());
                Console.WriteLine("        DUE DATE        :  " + dataReader["dueDate"].ToString());
                Console.WriteLine("==============================================================================");
            }

            dataReader.Close();
            connection.Close();
        }

        public void InsertMemberBook(string bookId, string memberId) // 대출하기
        {
            string bookName = "", bookPublisher = "";

            connection.Open();

            string query = string.Format(Constant.SELECT_QUERY_BOOK_WHERE_ID, bookId);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                bookName = dataReader["name"].ToString();
                bookPublisher = dataReader["publisher"].ToString();
            }

            dataReader.Close();
            connection.Close();

            InsertMemberBook(memberId, bookId, bookName, bookPublisher);
        }

        private void InsertMemberBook(string memberId, string bookId, string bookName, string bookPublisher)
        { // 대여한 책 데이터베이스에 집어넣기
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
            int dataCount = 0;
            
            string query = string.Format(Constant.DELETE_QUERY_MEMBERBOOK_WHERE_BOOKID_MEMBERID, memberId, bookId);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                ++dataCount;
            }

            if (dataCount > 0)
            {
                UpdateBookCount(memberId, "Return");
                UpdateBookQuantity(bookId, "Return");

                dataReader.Close();
                connection.Close();
                return true;
            }

            dataReader.Close();
            connection.Close();

            return false;
        }

        public bool IsBookId(string bookId) // 존재하는 bookId인지 확인
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
            
            if (dataCount > 0) // 존재하는 bookId일 경우
            {
                dataReader.Close();
                connection.Close();
                return true;
            }

            dataReader.Close();
            connection.Close();
            return false;
        }

        public bool IsBookCount(string bookId) // 남아있는 권수 확인 (book에서)
        {
            connection.Open();
            string quantity = "";
            
            string query = string.Format(Constant.SELECT_QUERY_BOOK_WHERE_ID, bookId);
            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_BOOK, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                quantity = dataReader["quantity"].ToString();
            }

            if (int.Parse(quantity) > 0)
            {
                dataReader.Close();
                connection.Close();
                return true;
            } 

            dataReader.Close();
            connection.Close();
            return false;
        }

        public bool IsCheckedOutBook(string bookId, string memberId) // 원래 빌렸던 책인지 확인 (memberBook에서)
        {
            connection.Open();
            int dataCount = 0;

            string query = string.Format(Constant.DELETE_QUERY_MEMBERBOOK_WHERE_BOOKID_MEMBERID, memberId, bookId);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                ++dataCount;
            }

            if(dataCount > 0)
            {
                dataReader.Close();
                connection.Close();
                return false;
            }

            dataReader.Close();
            connection.Close();
            return true;
        }

        private void UpdateBookCount(string memberId, string condition) // 자신이 빌린 책의 권수 조정
        {
            int bookCount = 0;

            connection.Open();
            
            string query = string.Format(Constant.SELECT_QUERY_MEMBER_WHERE_ID, memberId);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                bookCount = int.Parse(dataReader["bookCount"].ToString()); 
            }

            dataReader.Close();

            if (condition.Equals("CheckOut"))
            { // 대출하는 경우
                bookCount++;
                query = string.Format(Constant.UPDATE_QUERY_MEMBER_BOOKCOUNT, bookCount.ToString(), memberId);

            }
            else if (condition.Equals("Return"))
            { // 반납하는 경우
                bookCount--;
                query = string.Format(Constant.UPDATE_QUERY_MEMBER_BOOKCOUNT, bookCount.ToString(), memberId);

            }

            command = new MySqlCommand(query, connection);
            MySqlDataReader bookCountDataReader = command.ExecuteReader();

            bookCountDataReader.Close();
            connection.Close();
        }

        private void UpdateBookQuantity(string bookId, string condition) // 책의 잔여 수량 조정
        {
            int quantity = 0;

            connection.Open();
            
            string query = string.Format(Constant.SELECT_QUERY_BOOK_WHERE_ID, bookId);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                quantity = int.Parse(dataReader["quantity"].ToString());
            }

            dataReader.Close();

            if (condition.Equals("CheckOut"))
            { // 대출하는 경우
                quantity--;
                query = string.Format(Constant.UPDATE_QUERY_BOOK_QUANTITY, quantity.ToString(), bookId);
            }

            else if (condition.Equals("Return"))
            { // 반납하는 경우
                quantity++;
                query = string.Format(Constant.UPDATE_QUERY_BOOK_QUANTITY, quantity.ToString(), bookId);
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
            int dataCount = 0;
            
            string query = "";
            if (id.Equals("bookId"))
            {
                query = string.Format(Constant.SELECT_QUERY_MEMBERBOOK_WHERE_BOOKID, memberOrBookId);
            }
            else if (id.Equals("memberId"))
            {
                query = string.Format(Constant.SELECT_QUERY_MEMBERBOOK_WHERE_MEMBERID, memberOrBookId);
            }
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
                return false;
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

