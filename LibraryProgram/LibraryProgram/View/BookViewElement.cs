using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class BookViewElement
    {
        public void PrintManageBookMenu()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        MANAGE BOOK                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      1. REGISTER BOOK                    ");
            Console.WriteLine("                      2. EDIT BOOK                        ");
            Console.WriteLine("                      3. DELETE BOOK                      ");
            Console.WriteLine("                      4. SEARCH BOOK                      ");
            Console.WriteLine("                      5. BOOK LIST                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine();
            Console.WriteLine("          원하시는 기능의 번호를 입력하세요 :                  ");
            Console.WriteLine();
            Console.WriteLine("                                                           ");
        }

        public void PrintRegistration()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      REGISTER A BOOK                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine();
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        ID   : ");
            Console.WriteLine();
            Console.WriteLine("                       NAME  : ");
            Console.WriteLine();
            Console.WriteLine("                      AUTHOR : ");
            Console.WriteLine();
            Console.WriteLine("                   PUBLISHER : ");
            Console.WriteLine();
            Console.WriteLine("                      PRICE  : ");
            Console.WriteLine();
            Console.WriteLine("                    QUANTITY : ");
            Console.WriteLine();
        }

        public void PrintEditBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     EDIT BOOK QUANTITY                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void PrintEditBookForm()
        {
            Console.WriteLine();
            Console.WriteLine("                  BOOK ID   : ");
            Console.WriteLine();
            Console.WriteLine("                   PRICE    : ");
            Console.WriteLine();
            Console.WriteLine("                 QUANTITY   : ");
            Console.WriteLine();
        }

        public void PrintDeleteBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     DELETE A BOOK T_T                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void PrintBookIdForm()
        {
            Console.WriteLine();
            Console.WriteLine("                  BOOK ID   : ");
            Console.WriteLine();
        }

        public void InformBookList()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("                       B O O K L I S T                      ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine();

        }

        public void InformMemberBook(string id)
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("                    " + id + "님의 대출 내역                     ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine();

        }

        public void PrintCheckOutBookIdForm()
        {
            Console.WriteLine();
            Console.WriteLine("                대출할 책 ID   : ");
            Console.WriteLine();
        }

        public void PrintReturnBookIdForm()
        {
            Console.WriteLine();
            Console.WriteLine("                반납할 책 ID   : ");
            Console.WriteLine();
        }

        public void SearchBook()
        {
            Console.WriteLine();
            Console.WriteLine("   책 제목 / 저자 / 출판사 : ");
            Console.WriteLine();
        }

        public void PrintRegistrationSuccessMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                [성공적으로 등록되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintEditSuccessMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                [성공적으로 수정되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintEditFailMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                 [수정 내용이 없습니다!]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintDeleteSuccessMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                [성공적으로 삭제되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintCheckOutSuccessMessage(string date)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("        [대출이 완료되었습니다. 반납 기한은 " + date + " 입니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintReturnSuccessMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                  [반납이 완료되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
