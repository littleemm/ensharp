using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class Constant
    {
        public static string[] ARRAY_TWO = { "1", "2" };
        public static string[] ARRAY_THREE = { "1", "2", "3" };
        public static string[] ARRAY_FOUR = { "1", "2", "3", "4" };
        public static string[] ARRAY_FIVE = { "1", "2", "3", "4", "5" };
        public static string[] ARRAY_SIX = { "1", "2", "3", "4", "5", "6" };

        public static string STRING_CONNECTION = "Server=localhost;Database=younglim_library;Uid=root;Pwd=0000;charset=utf8;";

        public static string SELECT_QUERY_ADMIN = "SELECT * FROM administrator";

        public static string INSERT_QUERY_BOOK = "INSERT INTO book(id, name, author, publisher, price, quantity)";
        public static string DELETE_QUERY_BOOK = "DELETE FROM book ";
        public static string SELECT_QUERY_BOOK = "SELECT * FROM book";
        public static string UPDATE_QUERY_BOOK = "UPDATE book ";

        public static string INSERT_QUERY_MEMBER = "INSERT INTO member(id, password, name, age, phoneNumber, address, bookCount)";
        public static string SELECT_QUERY_MEMBER = "SELECT * FROM member";
        public static string DELETE_QUERY_MEMBER = "DELETE FROM member ";
        public static string UPDATE_QUERY_MEMBER = "UPDATE member ";

        public static string INSERT_QUERY_MEMBERBOOK = "INSERT INTO memberbook(memberId, bookId, bookName, bookPublisher, checkOutDate, dueDate)";
        public static string SELECT_QUERY_MEMBERBOOK = "SELECT * FROM memberbook";
        public static string DELETE_QUERY_MEMBERBOOK = "DELETE FROM memberbook ";

        public const int MEMBER_MANAGE = 1;
        public const int BOOK_MANAGE = 2;
        public const int EXIT = 3;

        public const int REGISTRATION = 1;
        public const int EDIT = 2;
        public const int DELETE = 3;
        public const int SEARCH = 4;
        public const int LIST = 5;

        public const int SEARCH_BOOK = 1;
        public const int BOOKLIST = 2;
        public const int CHECKOUT = 3;
        public const int RETURN = 4;
        public const int MYPAGE = 5;
        public const int GO_BACK_TO_ADMIN = 6;

        public const int LOGIN = 1;
        public const int SIGN_UP = 2;

        public const int ADMINISTRATOR_MODE = 1;
        public const int MEMBER_MODE = 2;

        public const int ADDRESS_LENGTH_IS_6 = 6;
        public const int ADDRESS_LENGTH_IS_7 = 7;
        public const int ADDRESS_LENGTH_IS_8 = 8;

        public const int EXIT_REAL = 1;
        public const int GOBACK = 2;

        public const bool ID_AND_PW_UNCORRECT = true;
        public const bool ID_AND_PW_UNCORRECT_NOW = false;
        public const bool IS_CTRL_Z = true;
    }
}
