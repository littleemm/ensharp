using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class BookPage
    {
        public void PrintManageBookMenu()
        {
            Console.WriteLine(" ESC: 뒤로가기                                             ");
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
            Console.WriteLine("                      7. CHECK OUT LIST                  ");
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
            Console.WriteLine(" ESC: 뒤로가기                                                  ");
            Console.WriteLine("              *                 *                 *            ");
            Console.WriteLine("                                                              ");
            Console.WriteLine("    *                  *                  *                  * ");
            Console.WriteLine("                                                              ");
            Console.WriteLine("                         REGISTER A BOOK                      ");
            Console.WriteLine("                                                              ");
            Console.WriteLine("    *                  *                  *                  * ");
            Console.WriteLine("                                                              ");
            Console.WriteLine("              *                 *                 *            ");
            Console.WriteLine();
            Console.WriteLine("                                                              ");
            Console.WriteLine("                                                              ");
            Console.WriteLine("         ID (5자 이내, 양의 정수)  : ");
            Console.WriteLine();
            Console.WriteLine("               NAME (80자 이내)    : ");
            Console.WriteLine();
            Console.WriteLine("              AUTHOR (50자 이내)   : ");
            Console.WriteLine();
            Console.WriteLine("           PUBLISHER (10자 이내)   : ");
            Console.WriteLine();
            Console.WriteLine("       PRICE (7자 이내, 양의 정수) : ");
            Console.WriteLine();
            Console.WriteLine("            PUBDATE (YYYYMMDD)    : ");
            Console.WriteLine();
            Console.WriteLine("           ISBN  (13자, 양의 정수) : ");
            Console.WriteLine();
            Console.WriteLine("        QUANTITY (5자 이내, 숫자)  : ");
            Console.WriteLine();
        }

        public void PrintEditBook()
        {
            Console.WriteLine(" ESC: 뒤로가기                                              ");
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
            Console.WriteLine(" ESC: 뒤로가기                                               ");
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
            Console.WriteLine("ESC: 뒤로가기            B O O K L I S T            F1: 종료");
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

        public void InformCheckOutList()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("ESC: 뒤로가기       C H E C K O U T L I S T         F1: 종료 ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine();
        }


        private void InformMemberBook(string id)
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("ESC: 뒤로가기         " + id + "님의 대출 내역                ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintNaverBookAPIList(ApiBookDTO book)
        {
            Console.WriteLine("   TITLE   : " + book.Title);
            Console.WriteLine("  AUTHOR   : " + book.Author);
            Console.WriteLine(" PUBLISHER : " + book.Publisher);
            Console.WriteLine("   PRICE   : " + book.Price + "\\");
            Console.WriteLine("  PUBDATE  : " + book.Pubdate);
            Console.WriteLine("   ISBN    : " + book.Isbn.Substring(11));
            Console.WriteLine();
            Console.WriteLine("==================================================================================================================================");

        }

        public void PrintCheckOutBookInform()
        {
            InformBookList();
            PrintBookIdFormMemberMode("대출");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
        }

        public void PrintSearchBookInform()
        {
            InformBookList();
            SearchBook();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
        }

        public void PrintBookListInform()
        {
            InformBookList();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
        }

        public void PrintListLine()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
        }


        public void PrintReturnBookInform(string id)
        {
            InformMemberBook(id);
            PrintBookIdFormMemberMode("반납");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
        }
        public void PrintBookIdFormMemberMode(string detail)
        {
            Console.WriteLine();
            Console.WriteLine("                " + detail + "할 책 ID   : ");
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
            Console.WriteLine("        수량 (1~100)       : ");
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

        public void PrintSuccessMessage(string detail)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                [성공적으로 "+ detail +"되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintEditFailMessage(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("              [수정 내용이 없습니다!]");
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   [대출이 완료되었습니다. 반납 기한은 " + date + " 입니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintCountFailMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("       [잔여 수량이 0권입니다. 다른 ID를 입력하세요.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintCheckedOutFailMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" [같은 책은 2권 이상 대출 불가합니다. 다른 ID를 입력하세요.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintReturnSuccessMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                  [반납이 완료되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintBookIdFailMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                 [Book ID를 다시 입력하세요.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintLongSuccessMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                     [성공적으로 등록되었습니다.]");
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

        public void PrintLongWarningMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                    [조건에 맞춰 다시 입력하세요!]");
            Console.ResetColor();
            Console.WriteLine();
        }


        public void PrintWarningMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("               [조건에 맞춰 다시 입력하세요!]");
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
