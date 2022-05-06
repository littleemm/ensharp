using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class LogViewElement
    {
        public void PrintManageLogMenu()
        {
            Console.WriteLine("   ESC: 뒤로가기                                            ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                         MANAGE LOG                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                    1. EDIT LOG   (부분 삭제)              ");
            Console.WriteLine("                    2. INIT LOG   (로그 초기화)            ");
            Console.WriteLine("                    3. SAVE LOG   (txt 파일 저장)       ");
            Console.WriteLine("                    4. DELETE LOG (txt 파일 삭제)            ");
            Console.WriteLine("                    5. LOG LIST                        ");
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

        public void PrintLogListSign()
        {
            Console.WriteLine("=====================================================================================");
            Console.WriteLine("ESC: 뒤로가기                           L O G L I S T                                 ");
            Console.WriteLine("=====================================================================================");
        }

        public void PrintDeleteLogList(string detail)
        {
            Console.WriteLine("                                               ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     " + detail + "하시겠습니까?            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                       1.  예              ");
            Console.WriteLine("                       2. 아니오 (뒤로가기)           ");
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

        public void PrintLogListColumn()
        {
            Console.WriteLine(" ID |   DATE   |  TIME  |  USER  |                     HISTORY                      |");
        }

        public void PrintEditForm()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("        삭제할 LOG ID : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintWarningMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                [LOG ID를 다시 입력하세요!]                    ");
            Console.ResetColor();
        }

        public void PrintSuccessMessage(string detail, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  [" + detail + "에 성공했습니다! ESC 키를 누르면 뒤로 갑니다.]           ");
            Console.ResetColor();
        }

        public void PrintFailMessage(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        [파일이 없습니다. ESC 키를 누르면 뒤로 갑니다.]              ");
            Console.ResetColor();
        }
    }
}
