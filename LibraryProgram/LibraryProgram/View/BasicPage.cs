using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LibraryProgram
{
    class BasicPage
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ProgramConsole = GetConsoleWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr intPtr, int value, int x, int y, int x2, int y2, int flag);
        // 콘솔 창 위치 설정
        public void PrintLibraryMain()
        {
            Console.SetWindowSize(60, 28);
            SetWindowPos(ProgramConsole, 0, 280, 100, 0, 0, 0x0001);
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                      ");
            Console.WriteLine("                        L I B R A R Y                       ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                    1. ADMINISTRATOR MODE                  ");
            Console.WriteLine("                    2. MEMBER MODE                         ");
            Console.WriteLine("                    3. EXIT                                ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("          원하시는 기능의 번호를 입력하세요 :                  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                           ");
        }

        public void PrintAdministratorPage() // 관리자 모드 선택
        {
            Console.WriteLine(" ESC: 뒤로가기                                             ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                    ");
            Console.WriteLine("                     ADMINISTRATOR PAGE                       ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                       1. MANAGE MEMBER                          ");
            Console.WriteLine("                       2. MANAGE BOOK                            ");
            Console.WriteLine("                       3. MANAGE LOG                            ");
            Console.WriteLine("                       4. EXIT");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("          원하시는 기능의 번호를 입력하세요 :                  ");
            Console.WriteLine();
            Console.WriteLine("                                                           ");
        }

        public void PrintMemberPage() // 멤버모드에서만 선택
        {
            Console.WriteLine(" ESC: 뒤로가기                                             ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                    ");
            Console.WriteLine("                         MEMBER PAGE                       ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                         1. LOGIN                          ");
            Console.WriteLine("                         2. SIGN UP                        ");
            Console.WriteLine("                         3. EXIT");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("          원하시는 기능의 번호를 입력하세요 :                  ");
            Console.WriteLine();
            Console.WriteLine("                                                           ");
        }

        public void PrintLoginPage() // 로그인 페이지 메인
        {
            Console.WriteLine(" ESC: 처음 화면으로                                        ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                      ");
            Console.WriteLine("                      L O G I N P A G E                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine();
            Console.WriteLine("                   ID (8자리 이내) :                              ");
            Console.WriteLine();
            Console.WriteLine("                   PW (5자리 이내) :                              ");
        }

        public void PrintSignUpPage() // 회원가입 페이지 메인
        {
            Console.WriteLine(" ESC: 뒤로가기                                                     ");
            Console.WriteLine("                  *                 *                 *            ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("        *                  *                  *                  * ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                             W E L C O M E T O                      ");
            Console.WriteLine("                                S I G N U P                        ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("        *                  *                  *                  * ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                  *                 *                 *            ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     ID (8자 이내, 영어·숫자 가능)     :                 ");
            Console.WriteLine();
            Console.WriteLine("  PW (5~8자, 영어·숫자·특수문자 포함) :                  ");
            Console.WriteLine();
            Console.WriteLine("            이름 (25자 이내)            :                  ");
            Console.WriteLine();
            Console.WriteLine("        나이(1~150, 숫자만 입력)        :                  ");
            Console.WriteLine();
            Console.WriteLine("            전화번호(-제외)             :                  ");
            Console.WriteLine();
            Console.WriteLine("       도로명 주소 (건물 번호까지)      :                   ");
            Console.WriteLine(" ex. 서울특별시 서초구 반포대로23길 6 ");

        }

        public void PrintMemberMode()
        {
            Console.WriteLine(" ESC: 처음 화면으로                                          ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                    ");
            Console.WriteLine("                        L I B R A R Y                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     1. SEARCH BOOK                        ");
            Console.WriteLine("                     2. BOOK LIST                          ");
            Console.WriteLine("                     3. CHECK OUT BOOK                     ");
            Console.WriteLine("                     4. RETURN BOOK                        ");
            Console.WriteLine("                     5. EDIT ADDRESS / PHONE               ");
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

        public void PrintExit()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        G O O D B Y E                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void PrintExitForm()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        ARE YOU SURE ?                      ");
            Console.WriteLine("                             T_T                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                           1. YES                          ");
            Console.WriteLine("                           2. NO                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("          원하시는 기능의 번호를 입력하세요 :                  ");
            Console.WriteLine();
            Console.WriteLine("                                                            ");
        }

        public void PrintWarningSentence(int x, int y, string detail)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                [" + detail + "]              ");
            Console.ResetColor();
        }

        public void ClearLine(int line, int width)
        {
            Console.SetCursorPosition(width, Console.CursorTop - line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }

        public void ClearLineEasy(int line, int width)
        {
            Console.SetCursorPosition(width, line);
            ClearLine(0, width);
        }

        public void ClearButtomLine(int line, int againLine)
        {
            for (int i = line; i < 200; i++) 
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, againLine);
        }

        public void PrintAfterWork()
        {
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine(" 아무 키: 뒤로가기                                 F1: 종료 ");
        }

        public void PrintLine()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
        }
    }
}
