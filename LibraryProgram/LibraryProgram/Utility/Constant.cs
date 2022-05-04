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
        public static string[] ARRAY_SEVEN = { "1", "2", "3", "4", "5", "6", "7" };

        public static string STRING_CONNECTION = "Server=localhost;Database=younglim_library;Uid=root;Pwd=0000;charset=utf8;";

        public static string SELECT_QUERY_ADMIN = "SELECT * FROM administrator";

        public static string INSERT_QUERY_BOOK = "INSERT INTO book(id, name, author, publisher, price, pubdate, isbn, quantity)";
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

        public static string INSERT_QUERY_LOG = "INSERT INTO log(date, time, user, history)";
        public static string SELECT_QUERY_LOG = "SELECT * FROM log";
        public static string DELETE_QUERY_LOG = "DELETE FROM log ";
        public static string TRUNCATE_QUERY_LOG = "TRUNCATE log";

        public const int MEMBER_MANAGE = 1;
        public const int BOOK_MANAGE = 2;
        public const int LOG_MANAGE = 3;
        public const int EXIT = 4;

        public const int REGISTRATION = 1;
        public const int EDIT = 2;
        public const int DELETE = 3;
        public const int SEARCH = 4;
        public const int SEARCH_NAVER = 5;
        public const int LIST = 6;
        public const int MEMBER_LIST = 5;
        public const int LIST_OF_CHECKOUT = 7;

        public const int SEARCH_BOOK = 1;
        public const int BOOKLIST = 2;
        public const int CHECKOUT = 3;
        public const int RETURN = 4;
        public const int MYPAGE = 5;
        public const int GO_BACK_TO_ADMIN = 6;

        public const int EDIT_LOG = 1;
        public const int DELETE_LOG = 4;
        public const int INIT_LOG = 2;
        public const int SAVE_LOG = 3;
        public const int LOG_LIST = 5;

        public const int LOGIN = 1;
        public const int SIGN_UP = 2;

        public const int ADMINISTRATOR_MODE = 1;
        public const int MEMBER_MODE = 2;

        public const int ADDRESS_LENGTH_IS_6 = 6;
        public const int ADDRESS_LENGTH_IS_7 = 7;
        public const int ADDRESS_LENGTH_IS_8 = 8;

        public const int LOG_DELETE = 1;
        public const int EXIT_REAL = 1;
        public const int GOBACK = 2;

        public const bool ID_AND_PW_UNCORRECT = true;
        public const bool ID_AND_PW_UNCORRECT_NOW = false;
        public const bool IS_CTRL_Z = true;

        public const string CLIENT_ID = "Gy_693vcZVxD7SqwKVzr";
        public const string CLIENT_SECRET = "SdGR7yh_9b";

        public const string PATTERN_NAME_KOR = @"^[가-힣\s]{2,25}$";
        public const string PATTERN_NAME_ENG = @"^[a-zA-Z.\s]{2,25}$";

        public const string PATTERN_PASSWORD = @"^(?=.*[a-aA-Z])(?=.*[0-9])(?=.*[\W]).{5,8}$";

        public const string PATTERN_TEL_010 = @"^010[0-9]{9}$"; // 11자리 폰번호
        public const string PATTERN_TEL_0XX = @"^0[1-9]{2}[0-9]{7}$"; // 10자리 폰번호, 서울 외 전화번호
        public const string PATTERN_TEL_02 = @"^02[0-9]{7-8}$"; // 서울 전화번호
    }
}
