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
            Console.WriteLine("                      5. SEARCH NAVER BOOK              ");
            Console.WriteLine("                      6. BOOK LIST                      ");
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
            Console.WriteLine("ESC: 뒤로가기                                                ");
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
            Console.WriteLine("         ID (5자 이내, 양의 정수)  : ");
            Console.WriteLine();
            Console.WriteLine("               NAME (20자 이내)    : ");
            Console.WriteLine();
            Console.WriteLine("              AUTHOR (15자 이내)   : ");
            Console.WriteLine();
            Console.WriteLine("           PUBLISHER (10자 이내)   : ");
            Console.WriteLine();
            Console.WriteLine("       PRICE (7자 이내, 양의 정수) : ");
            Console.WriteLine(); 
            Console.WriteLine("        QUANTITY (5자 이내, 숫자)  : ");
            Console.WriteLine();
        }

        public void PrintEditBook()
        {
            Console.WriteLine("ESC: 뒤로가기                                               ");
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
            Console.WriteLine("ESC: 뒤로가기                                               ");
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
            Console.WriteLine("ESC: 뒤로가기            B O O K L I S T                      ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine();

        }

        public void InformNaverBookList()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("ESC: 뒤로가기          NAVER BOOK SEARCH                      ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void InformNaverBookListAfter()
        {
            Console.WriteLine("==================================================================================================================================");
            Console.WriteLine("ESC: 뒤로가기                                            NAVER BOOK SEARCH                                                         ");
            Console.WriteLine("==================================================================================================================================");
            Console.WriteLine();

        }

        public void InformMemberBook(string id)
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("ESC: 뒤로가기          " + id + "님의 대출 내역                     ");
            Console.WriteLine("=============================================================");
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

        public void SearchNaverBook()
        {
            Console.WriteLine("          책 제목          : ");
            Console.WriteLine("            수량           : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void AddNaverBookForm()
        {

            Console.WriteLine("                                                    복사-붙여넣기를 하면 편합니다.");
            Console.WriteLine();
            Console.WriteLine("    도서 목록에 추가할 도서의 ISBN : ");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintRegisterNaverBook()
        {
            Console.WriteLine("           등록할 도서의 ID        : ");
            Console.WriteLine();
            Console.WriteLine("          등록할 도서의 수량       : ");
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("               [성공적으로 삭제되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintCheckOutSuccessMessage(string date)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   [대출이 완료되었습니다. 반납 기한은 " + date + " 입니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintCountFailMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     [잔여 수량이 0권입니다. 다른 책 ID를 입력하세요.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintCheckedOutFailMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" [같은 책은 2권 이상 대출 불가합니다. 다른 ID를 입력하세요.]");
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

        public void PrintBookIdFailMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                 [Book ID를 다시 입력하세요.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintIsbnFailMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                      [ISBN을 다시 입력하세요.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintWarningMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                [조건에 맞춰 다시 입력하세요!]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintDeleteWarningMessage(int x, int y)
        {
            Console.WriteLine();
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("           [대출중인 책은 삭제가 불가합니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintSearchWarningMessage(int x, int y)
        {
            Console.WriteLine();
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("          [올바른 입력값으로 다시 입력하세요.]");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
