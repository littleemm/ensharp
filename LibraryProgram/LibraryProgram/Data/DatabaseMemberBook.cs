﻿using System;
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
        private static string stringConnection = "Server=localhost;Database=김영림_library;Uid=root;Pwd=0000;charset=utf8;";
        private MySqlConnection connection;
        public DatabaseMemberBook()
        {
            connection = new MySqlConnection(stringConnection);
        }
        public void SelectMemberBook(string memberId) // 자신이 빌린책 불러오기
        {
            connection.Open();
            string query = "SELECT * FROM memberbook";

            List<string>[] element = new List<string>[7];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
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
            string query = "SELECT * FROM book";
            string bookName = "", bookPublisher = "";
            DateTime today = DateTime.Today;
            DateTime due = today.AddDays(7);

            connection.Open();

            List<string>[] element = new List<string>[3];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["name"].ToString());
                element[1].Add(dataReader["publisher"].ToString());
                element[2].Add(dataReader["id"].ToString());
            }

            for (int i=0;i<element[0].Count;i++)
            {
                if (element[2][i].Equals(bookId))
                {
                    bookName = element[0][i];
                    bookPublisher = element[1][i];
                    break;
                }
            }

            query = "INSERT INTO member(memebrId, bookId, bookName, bookPublisher, checkOutDate, dueDate)" +
             "Value('" + memberId + "', '" + bookId + "', '" + bookPublisher + "', '" +
             today.ToString() + "', '" + due.ToString() + "');";

            command = new MySqlCommand(query, connection);
            dataReader = command.ExecuteReader();

            UpdateBookCount(memberId, "CheckOut");

            connection.Close();
        }
        public bool DeleteMemberBook(string bookId, string memberId) // 반납하기
        {
            connection.Open();
            string query = "SELECT * FROM memberbook";

            List<string>[] element = new List<string>[7];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["memberId"].ToString());
                element[1].Add(dataReader["bookId"].ToString());
                element[2].Add(dataReader["id"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(memberId) && element[1][i].Equals(bookId))
                {
                    query = "DELETE FROM memberbook WHERE id = '" + element[2][i] + "';";
                    command = new MySqlCommand(query, connection);
                    dataReader = command.ExecuteReader();
                    UpdateBookCount(memberId, "Return");

                    return true;
                }
            }

            connection.Close();

            return false;
        }

        public bool IsBookId(string bookId) // 존재하는 bookId인지 확인
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
                if (element[i].Equals(bookId))
                {
                    return true;
                }
            }

            connection.Close();
            return false;
        }

        public bool IsBookCount(string bookId) // 남아있는 권수 확인 (book에서)
        {
            string query = "SELECT * FROM book";
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
                element[1].Add(dataReader["quantity"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(bookId) && int.Parse(element[1][i]) > 0)
                {
                    return true;
                }
            }

            connection.Close();
            return false;
        }

        public bool IsCheckedOutBook(string bookId, string memberId) // 원래 빌렸던 책인지 확인 (memberBook에서)
        {
            string query = "SELECT * FROM memberBook";
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
                element[0].Add(dataReader["memberId"].ToString());
                element[1].Add(dataReader["bookId"].ToString());
            }

            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(memberId) && element[1][i].Equals(bookId))
                {
                    return false;
                }
            }

            connection.Close();
            return true;
        }

        private void UpdateBookCount(string memberId, string condition) // 자신이 빌린 책의 권수 조정
        {
            int bookCount;
            string query = "SELECT * FROM member";

            connection.Open();
            List<string>[] element = new List<string>[2];

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["bookCount"].ToString());
                element[1].Add(dataReader["id"].ToString());
            }

            for (int i=0;i<element[1].Count;i++)
            {
                if (element[1][i].Equals(memberId) && condition.Equals("CheckOut"))
                { // 대출하는 경우
                    bookCount = int.Parse(element[0][i]);
                    bookCount++;
                    query = "UPDATE member SET bookCount = '" + bookCount.ToString() +
                  "' WHERE id = '" + memberId + "';";
                    break;
                }

                if (element[1][i].Equals(memberId) && condition.Equals("Return"))
                { // 반납하는 경우
                    bookCount = int.Parse(element[0][i]);
                    bookCount--;
                    query = "UPDATE member SET bookCount = '" + bookCount.ToString() +
                  "' WHERE id = '" + memberId + "';";
                    break;
                }
            }

            command = new MySqlCommand(query, connection);
            dataReader = command.ExecuteReader();

            connection.Close();
        }
    }
}
