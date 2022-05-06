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

        public const string SELECT_QUERY_ADMIN = "SELECT * FROM administrator";

        public const string INSERT_QUERY_BOOK = "INSERT INTO book(id, name, author, publisher, price, pubdate, isbn, quantity)Value('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');";
        public const string DELETE_QUERY_BOOK = "DELETE FROM book WHERE id = '{0}';";
        public const string SELECT_QUERY_BOOK = "SELECT * FROM book";
        public const string UPDATE_QUERY_BOOK = "UPDATE book ";
        public const string UPDATE_QUERY_BOOK_PRICE_QUANTITY = "UPDATE book SET price = '{0}', quantity = '{1}' WHERE id = '{2}';";
        public const string UPDATE_QUERY_BOOK_PRICE = "UPDATE book SET price = '{0}' WHERE id = '{1}';";
        public const string UPDATE_QUERY_BOOK_QUANTITY = "UPDATE book SET quantity = '{0}' WHERE id = '{1}';";

        public const string INSERT_QUERY_MEMBER = "INSERT INTO member(id, password, name, age, phoneNumber, address, bookCount)Value('{0}', '{1}', '{2}', '{3}, '{4}', '{5}', '0');";
        public const string SELECT_QUERY_MEMBER = "SELECT * FROM member";
        public const string DELETE_QUERY_MEMBER = "DELETE FROM member WHERE id = '{0}';";
        public const string UPDATE_QUERY_MEMBER = "UPDATE member ";
        public const string UPDATE_QUERY_MEMBER_NUMBER_ADDRESS = "UPDATE member SET phoneNumber = '{0}', address = '{1}' WHERE id = '{2}';";
        public const string UPDATE_QUERY_MEMBER_NUMBER = "UPDATE member SET phoneNumber = '{0}' WHERE id = '{1}';";
        public const string UPDATE_QUERY_MEMBER_ADDRESS = "UPDATE member SET address = '{0}' WHERE id = '{1}';";
        public const string UPDATE_QUERY_MEMBER_BOOKCOUNT = "UPDATE member SET bookCount = '{0}' WHERE id = '{1}';";

        public const string INSERT_QUERY_MEMBERBOOK = "INSERT INTO memberbook(memberId, bookId, bookName, bookPublisher, checkOutDate, dueDate)Value('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";
        public const string SELECT_QUERY_MEMBERBOOK = "SELECT * FROM memberbook";
        public const string DELETE_QUERY_MEMBERBOOK = "DELETE FROM memberbook WHERE id = '{0}';";

        public const string INSERT_QUERY_LOG = "INSERT INTO log(date, time, user, history)Value('{0}', '{1}', '{2}', '{3}');";
        public const string SELECT_QUERY_LOG = "SELECT * FROM log";
        public const string DELETE_QUERY_LOG = "DELETE FROM log WHERE id = '{0}';";
        public const string TRUNCATE_QUERY_LOG = "TRUNCATE log";

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
        public const int LOG_INIT = 1;
        public const int LOG_SAVE = 1;

        public const int EXIT_REAL = 1;
        public const int GOBACK = 2;

        public const bool ID_AND_PW_UNCORRECT = true;
        public const bool ID_AND_PW_UNCORRECT_NOW = false;
        public const bool IS_CTRL_Z = true;
        public const bool LOOP_FINAL_ESC_KEY_PRESSED = true;
        public const bool EXIT_WHEN_GO_BACK = true;

        public const string CLIENT_ID = "Gy_693vcZVxD7SqwKVzr";
        public const string CLIENT_SECRET = "SdGR7yh_9b";

        public const string PATTERN_NAME_KOR = @"^[가-힣\s]{2,25}$";
        public const string PATTERN_NAME_ENG = @"^[a-zA-Z.\s]{2,25}$";

        public const string PATTERN_PASSWORD = @"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[\W]).{5,8}$";

        public const string PATTERN_TEL_010 = @"^010[0-9]{8}$"; // 11자리 폰번호
        public const string PATTERN_TEL_0XX = @"^0[1-9]{2}[0-9]{7}$"; // 10자리 폰번호, 서울 외 전화번호
        public const string PATTERN_TEL_02 = @"^02[0-9]{7-8}$"; // 서울 전화번호

        public static string[] NAME = { "인천", "대구", "광주", "대전", "울산", "부산" };
        public static string[] NAMEOF = { "인천", "대구", "울산", "부산" };

        public const string PATTERN_ADDRESS_METROPOLITANCITY = @"^[가-힣]{2}시$";
        public const string PATTERN_ADDRESS_METROPOLITAN = @"^[가-힣]{2}광역시$";
        public const string PATTERN_ADDRESS_PROVINCE_ISLAND = @"^[가-힣]{2,3}도$";

        public const string PATTERN_ADDRESS_CITY = @"^[가-힣]{2,3}시$";
        public const string PATTERN_ADDRESS_DISTRICT = @"^[가-힣]{1,4}구$";
        public const string PATTERN_ADDRESS_COUNTY = @"^[가-힣]{2}군$";

        public const string PATTERN_ADDRESS_TOWN = @"^[가-힣]{1,3}읍$";
        public const string PATTERN_ADDRESS_TOWNSHIP = @"^[가-힣]{1,3}면$";

        public const string PATTERN_ADDRESS_ROAD_GIL = @"^[가-힣0-9]{1,9}길$";
        public const string PATTERN_ADDRESS_ROAD_RO = @"^[가-힣0-9]{1,6}로$";

        public const string PATTERN_ADDRESS_NUMBER = @"^[0-9]{1,5}$";

        public const string PATTERN_KEY_KOR = @"^[ㄱ-ㅎ가-힣]$";
    }
}
