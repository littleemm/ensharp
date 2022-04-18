using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class BasicViewElement
    {
        public void PrintLibraryMain()
        {
            Console.SetWindowSize(60, 28);
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
            Console.WriteLine("                                                           ");
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
            Console.WriteLine("                       3. EXIT");
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
            Console.WriteLine("                                                           ");
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
            Console.WriteLine("                                                           ");
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

        private void PrintSignUpPage() // 회원가입 페이지 메인
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                      ");
            Console.WriteLine("                         S I G N U P                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("       ID(8자리 이내, 영어, 숫자 가능) :                 ");
            Console.WriteLine();
            Console.WriteLine("       PW(5자리 이내, 숫자만 가능)        :                  ");
            Console.WriteLine();
            Console.WriteLine("       이름(8자리 이내, 한글만)   :                  ");
            Console.WriteLine();
            Console.WriteLine("       나이(0~150, 숫자만 입력)  :                  ");
            Console.WriteLine();
            Console.WriteLine("       휴대폰 번호(-제외)        :                  ");
            Console.WriteLine();
            Console.WriteLine("       주소 (ex. 서울시 광진구)  :                   ");

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

        public void PrintWarningSentence(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("             [조건에 맞춰서 다시 입력해주세요.]              ");
            Console.ResetColor();
        }

        public void ClearLine(int line, int width)
        {
            Console.SetCursorPosition(width, Console.CursorTop - line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
