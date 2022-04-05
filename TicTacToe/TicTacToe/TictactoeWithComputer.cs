using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TictactoeWithComputer // 유저와 컴퓨터가 게임할 때
    {
        GameTictactoe gameWithComputer = new GameTictactoe();
        ShowScoreboard scoreCountWithComputer = new ShowScoreboard();
        ScanAndPrint scanAndPrintMiniMenu = new ScanAndPrint();
        char[] signArray = { 'X', 'O' };
        private static int userSequenceNumber = 0; // 게임 횟수 측정을 위한 static 변수

        public void StartGameWithComputer() // 초기 게임 시작
        {
            gameWithComputer.ChooseOX();
            userSequenceNumber = gameWithComputer.CheckUserNumber(userSequenceNumber);
            ProgressGameWithComputer(userSequenceNumber);
            gameWithComputer.ClearArray();
            GoMenuComputer();

        }
        public void StartGameWithComputerAgain() // 게임을 두번 이상으로 하는 경우 (메뉴 1, 2 게임 중 하나라도)
        {
            if (userSequenceNumber == 0) // 한번이라도 컴퓨터와 게임을 한 적이 없는 경우 이 과정을 거쳐 순서를 정해야 한다.
            {
                gameWithComputer.ChooseOX();
                userSequenceNumber = gameWithComputer.CheckUserNumber(userSequenceNumber);
            }
            ProgressGameWithComputer(userSequenceNumber);
            gameWithComputer.ClearArray();
            GoMenuComputer();
        }
        private void ProgressGameWithComputer (int userSequenceNumber) // 게임을 진행시키는 함수
        {
            int countGame = 0;
            switch (userSequenceNumber)
            {
                case 1:
                    {
                        Console.Clear();

                        gameWithComputer.PlayOfUser(signArray[0]);
                        for (int count = 0; count < 9 / 2; count++)
                        {
                            gameWithComputer.PlayOfComputer(signArray[1], signArray[0]);
                            if (gameWithComputer.CheckWin() == 1)
                            {
                                scoreCountWithComputer.CountScoreWithComputer(signArray[1]);
                                break;
                            }
                            gameWithComputer.PlayOfUser(signArray[0]);
                            if (gameWithComputer.CheckWin() == 1)
                            {
                                scoreCountWithComputer.CountScoreWithComputer(signArray[0]);
                                break;
                            }
                            countGame += 2;
                        }

                        if (countGame == 8)
                        {
                            scoreCountWithComputer.DrawGameWithComputer();
                        }
                        break;
                    }
                case 2:
                    {
                        gameWithComputer.PlayOfComputer(signArray[0], signArray[1]);
                        for (int count = 0; count < 9 / 2; count++)
                        {
                            gameWithComputer.PlayOfUser(signArray[1]);
                            if (gameWithComputer.CheckWin() == 1)
                            {
                                scoreCountWithComputer.CountScoreWithComputer(signArray[1]);
                                break;
                            }
                            gameWithComputer.PlayOfComputer(signArray[0], signArray[1]);
                            if (gameWithComputer.CheckWin() == 1)
                            {
                                scoreCountWithComputer.CountScoreWithComputer(signArray[0]);
                                break;
                            }
                            countGame += 2;
                        }

                        if (countGame == 8) // 무승부일 경우 (원래는 9번 표시를 주고받지만 반복문 때문에 8번으로 측정)
                        {
                            scoreCountWithComputer.DrawGameWithComputer(); // 무승부
                        }
                        break;
                    }
            }
        }
        private void GoMenuComputer() // 게임이 끝났으므로 다음 행동을 위해 메뉴를 불러오는 함수
        {
            string[] miniMenuNumberArray = { "1", "2", "3" };
            gameWithComputer.PrintGoMenu();
            int checkedMiniMenuNumber = scanAndPrintMiniMenu.ScanMenuNumber(miniMenuNumberArray);
            switch (checkedMiniMenuNumber)
            {
                case 1:
                    {
                        Console.WriteLine("게임을 다시 시작합니다. . .");
                        Console.WriteLine();
                        StartGameWithComputerAgain();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        scanAndPrintMiniMenu.ShowMainAgain();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        gameWithComputer.PrintOffMenu();
                        string[] offMenuNumberArray = { "1", "2" };
                        int checkedOffNumber = scanAndPrintMiniMenu.ScanMenuNumber(offMenuNumberArray);
                        Console.Clear();
                        if (checkedOffNumber == 1)
                        {
                            Console.WriteLine("종료합니다. . .");
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            GoMenuComputer();
                        }

                        break;
                    }
            }

        }
    }
}
