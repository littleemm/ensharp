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

        public LoginAdministrationPage()
        {
            isPersonalInformation = false;
        }

        public int CheckPersonalInformation(int x, int y, string myInformation) // 입력 및 정보 체크
        {
            Console.SetCursorPosition(x, y);

            while (isPersonalInformation == false) {

                information = Console.ReadLine();

                if (information == myInformation) /////// 입력 제한 예외처리 하자
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

            return myInformation.Length;
        }

        private void ClearLine(int line, int width)
        { 
            Console.SetCursorPosition(width, Console.CursorTop - line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
