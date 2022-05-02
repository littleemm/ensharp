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
            Console.WriteLine("                                                           ");
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
            Console.WriteLine("                    2. DELETE LOG (전면 삭제)            ");
            Console.WriteLine("                    3. LOG LIST           ");
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

        public void PrintDeleteLogList()
        {
            Console.WriteLine("ESC: 뒤로가기                                               ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     전부 삭제하시겠습니까?                  ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                          1.  예              ");
            Console.WriteLine("                          2. 아니오            ");
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
            Console.WriteLine("                   [" + detail + "에 성공했습니다!]                    ");
            Console.ResetColor();
        }
    }
}
