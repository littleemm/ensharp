using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ScanAndPrint
    {
        public void PrintMenu() // TicTacToe 메인 메뉴 프린트
         {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                                 MENU                                 ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("    1: vs Computer : 컴퓨터와 당신이 게임을 진행합니다.");
            Console.WriteLine("    2: vs User : 당신 혼자 혹은 옆에 있는 사람과 게임을 진행합니다.     ");
            Console.WriteLine("    3: Score Board");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
        }
        public void ScanMenuNumber() // 메뉴 번호 입력받기
        {
            char[] menuNumberArray = { '1', '2', '3' }; // 메뉴 번호를 배열에 저장 후 CheckNumber 함수에서 번호 확인할 때 사용
            bool isMenuNumber = false; // 메뉴 번호를 제대로 입력받았는지 확인을 위한 변수
            string unknownNumber = "";
            int checkedMenuNumber;

            while (isMenuNumber == true)
            {
                Console.Write("원하시는 메뉴의 번호를 입력하세요 : ");
                unknownNumber = Console.ReadLine();
                CheckMenuNumber(isMenuNumber, menuNumberArray, unknownNumber);
            }

            checkedMenuNumber = int.Parse(unknownNumber);
        }
        public void CheckMenuNumber(bool isMenuNumber, char[] menuNumberArray, string unknownNumber) // 메뉴 번호가 맞는지 확인하는 함수
        {
            for (int menuNumberIndex = 0; menuNumberIndex < menuNumberArray.Length; menuNumberIndex++)
            {
                if (unknownNumber.Equals(menuNumberArray[menuNumberIndex]))
                {
                    isMenuNumber = true;
                }
                else
                {
                    
                }
            }
        }
        public void CheckAndPrintMore(string unknownNumber)
        {
            string[] reasonOfLoop = { };
            char[] smallAlphabet = { };
            char[] bigAlphabet = { };
        }
        public void ScanOX()
        {

        }
    }
}
