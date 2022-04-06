using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ShowFirst // 메인에 표시되는 내용 위주를 담은 클래스
    {
        PrintAll printAll = new PrintAll();
        PrintGameElement printElement = new PrintGameElement();
        string[] offMenuNumberArray = { "1", "2" };
        string[] menuNumberArray = { "1", "2", "3", "4" }; // 메뉴 번호를 배열에 저장 후 CheckNumber 함수에서 번호 확인할 때 사용
        public void ShowMain() // 초기에 메인에 표시되는 함수
        {
            Console.SetWindowSize(70, 30);
            printAll.PrintMenu();
            int checkedMenuNumber = ScanMenuNumber(menuNumberArray);
            SelectMenu(checkedMenuNumber);
        }
        public void ShowMainAgain() // 한번이라도 게임을 실행한 적이 있을 때 ShowMain()이 아닌 이 함수에 들어온다
        {
            printAll.PrintMenu();
            int checkedMenuNumber = ScanMenuNumber(menuNumberArray);
            SelectMenuAgain(checkedMenuNumber);
        }
        public bool IsMenuNumber(bool isMenuNumber, string[] menuNumberArray, string unknownNumber) // 메뉴 번호가 맞는지 확인하는 함수
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
                printAll.PrintToScanAgain();
            }

            return isMenuNumber;
        }
        public int ScanMenuNumber(string[] menuNumberArray) // 메뉴 번호 입력받기
        {
            bool isMenuNumber = false; // 메뉴 번호를 제대로 입력받았는지 확인을 위한 변수
            string unknownNumber = ""; // 입력될 메뉴 번호 (다른 문자가 입력될 수 있어 string)

            while (isMenuNumber == false)
            {
                Console.Write("                원하시는 메뉴의 번호를 입력하세요 : ");
                unknownNumber = Console.ReadLine();
                Console.WriteLine();
                printAll.ClearLine(2);
                isMenuNumber = IsMenuNumber(isMenuNumber, menuNumberArray, unknownNumber);
            }
            return int.Parse(unknownNumber);
        }

        private void SelectMenu(int checkedMenuNumber) // 초기에 메뉴를 고르게 하는 함수
        {
            switch (checkedMenuNumber)
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
                case 4:
                    {
                        Console.Clear();
                        printElement.PrintOffMenu();
                        int checkedOffNumber = ScanMenuNumber(offMenuNumberArray);
                        Console.Clear();
                        if (checkedOffNumber == 1)
                        {
                            Console.WriteLine("종료합니다. . .");
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            ShowMain();
                        }
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
                        tictactoeWithUser.StartGameWithUser();
                        break;
                    }
                case 3:
                    {
                        ShowScoreboard showScoreboard = new ShowScoreboard();
                        showScoreboard.PrintScoreBoard();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        printElement.PrintOffMenu();
                        int checkedOffNumber = ScanMenuNumber(offMenuNumberArray);
                        Console.Clear();
                        if (checkedOffNumber == 1)
                        {
                            Console.WriteLine("종료합니다. . .");
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            ShowMainAgain();
                        }
                        break;
                    }
            }
        }


    }
}