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

        public const bool ID_AND_PW_UNCORRECT = true;
    }
}
