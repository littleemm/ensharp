using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class LoginAdministrationPage // 로그인 승인 관리 페이지
    {
        private string information;
        private bool isPersonalInformation;
        private ConsoleKeyInfo consoleKey;

        public LoginAdministrationPage()
        {
            information = "";
            isPersonalInformation = false;
        }

        public int CheckPersonalInformation(int x, int y, string myInformation) // 입력 및 정보 체크
        {
            Console.SetCursorPosition(x, y);

            while (isPersonalInformation == false) {

                information = Console.ReadLine();

                if (information == myInformation) 
                {
                    isPersonalInformation = true;
                }
                else
                {
                    ClearLine(1, x);
                    Console.SetCursorPosition(x, y);
                }

            }

            isPersonalInformation = false;
            information = "";

            return myInformation.Length;
        }

        public int CheckPassword(int x, int y, string password)
        {
            Console.SetCursorPosition(x, y);

            while (isPersonalInformation == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    consoleKey = Console.ReadKey(true);

                    if (consoleKey.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        break;
                    }
                    if (consoleKey.Key == ConsoleKey.Backspace)
                    {

                    }
                    else
                    {
                        information += consoleKey.KeyChar.ToString();
                        Console.Write("*");
                    }

                }
                Console.WriteLine();
                if (information == password)
                {
                    isPersonalInformation = true;
                }
                else
                {
                    ClearLine(1, x);
                    information = "";
                    Console.SetCursorPosition(x, y);
                }

            }

            isPersonalInformation = false;

            return password.Length;
        }

        private void ClearLine(int line, int width)
        { 
            Console.SetCursorPosition(width, Console.CursorTop - line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
