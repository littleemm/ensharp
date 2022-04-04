using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ScanAndPrint // 메인에 표시되는 내용 위주를 담은 클래스
    {
        public void ShowMain() // 초기에 메인에 표시되는 함수
        {
            PrintMenu();
            string[] menuNumberArray = { "1", "2", "3" }; // 메뉴 번호를 배열에 저장 후 CheckNumber 함수에서 번호 확인할 때 사용
            int checkedMenuNumber = ScanMenuNumber(menuNumberArray);
            SelectMenu(checkedMenuNumber);
        }
        public void ShowMainAgain() // 한번이라도 게임을 실행한 적이 있을 때 ShowMain()이 아닌 이 함수에 들어온다
        {
            PrintMenu();
            string[] menuNumberArray = { "1", "2", "3" }; // 메뉴 번호를 배열에 저장 후 CheckNumber 함수에서 번호 확인할 때 사용
            int checkedMenuNumber = ScanMenuNumber(menuNumberArray);
            SelectMenuAgain(checkedMenuNumber);
        }
        private void PrintMenu() // TicTacToe 메인 메뉴 프린트
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
        public int ScanMenuNumber(string[] menuNumberArray) // 메뉴 번호 입력받기
        {
            
            bool isMenuNumber = false; // 메뉴 번호를 제대로 입력받았는지 확인을 위한 변수
            string unknownNumber = ""; // 입력될 메뉴 번호 (다른 문자가 입력될 수 있어 string)

            while (isMenuNumber == false)
            {
                Console.Write("원하시는 메뉴의 번호를 입력하세요 : ");
                unknownNumber = Console.ReadLine();
                Console.WriteLine();
                isMenuNumber = CheckMenuNumber(isMenuNumber, menuNumberArray, unknownNumber);
            }
            return int.Parse(unknownNumber);
        }
        public bool CheckMenuNumber(bool isMenuNumber, string[] menuNumberArray, string unknownNumber) // 메뉴 번호가 맞는지 확인하는 함수
        {
            for (int menuNumberIndex = 0; menuNumberIndex < menuNumberArray.Length; menuNumberIndex++)
            {
                if (string.IsNullOrEmpty(unknownNumber?.Trim())) // ctrl+Z 입력되어도 오류 방지
                {
                    break;
                }
                if (unknownNumber.Equals(menuNumberArray[menuNumberIndex]))
                {
                    isMenuNumber = true;
                }
            }

            if (isMenuNumber == false)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("                          다시 입력해주세요!                           ");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine();
            }

            return isMenuNumber;
        }
           
        private void SelectMenu(int checkedMenuNumber) // 초기에 메뉴를 고르게 하는 함수
        {
            switch(checkedMenuNumber)
            {
                case 1: // 컴퓨터와 게임
                    {
                        TictactoeWithComputer tictactoeWithComputer = new TictactoeWithComputer();
                        tictactoeWithComputer.StartGameWithComputer();
                        break;
                    }
                case 2: // 유저끼리 게임
                    {
                        TictactoeWithUser tictactoeWithUser = new TictactoeWithUser();
                        tictactoeWithUser.StartGameWithUser();
                        break;
                    }
                case 3: // 점수판으로 이동
                    {
                        ShowScoreboard showScoreboard = new ShowScoreboard();
                        showScoreboard.PrintScoreBoard();
                        break;
                    }
            }
        }
        private void SelectMenuAgain(int checkedMenuNumber) // 게임을 두번 이상 했을 경우 메뉴를 고르게 하는 함수
        {
            switch (checkedMenuNumber)
            {
                case 1:
                    {
                        TictactoeWithComputer tictactoeWithComputer = new TictactoeWithComputer();
                        tictactoeWithComputer.StartGameWithComputerAgain();
                        break;
                    }
                case 2:
                    {
                        TictactoeWithUser tictactoeWithUser = new TictactoeWithUser();
                        tictactoeWithUser.StartGameWithUserAgain();
                        break;
                    }
                case 3:
                    {
                        ShowScoreboard showScoreboard = new ShowScoreboard();
                        showScoreboard.PrintScoreBoard();
                        break;
                    }
            }
        }


    }
}
