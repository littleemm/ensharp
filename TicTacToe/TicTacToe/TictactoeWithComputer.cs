using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TictactoeWithComputer
    {
        GameTictactoe gameWithComputer = new GameTictactoe();
        ShowScoreboard scoreCountWithComputer = new ShowScoreboard();
        char[] signArray = { 'X', 'O' };
        private static int userSequenceNumber = 0;
        public void StartGameWithComputer()
        {
            gameWithComputer.ChooseOX();
            userSequenceNumber = gameWithComputer.CheckUserNumber(userSequenceNumber);
            progressGameWithComputer(userSequenceNumber);
            gameWithComputer.ClearArray();
            GoMenuComputer();

        }
        public void StartGameWithComputerAgain()
        {
            if (userSequenceNumber == 0)
            {
                gameWithComputer.ChooseOX();
                userSequenceNumber = gameWithComputer.CheckUserNumber(userSequenceNumber);
            }
            progressGameWithComputer(userSequenceNumber);
            gameWithComputer.ClearArray();
            GoMenuComputer();
        }
        public void progressGameWithComputer (int userSequenceNumber)
        {
            int countGame = 0;
            switch (userSequenceNumber)
            {
                case 1:
                    {
                        Console.WriteLine("당신이 먼저 시작합니다.");

                        gameWithComputer.PlayOfUser(signArray[0]);
                        for (int count = 0; count < 9 / 2; count++)
                        {
                            gameWithComputer.PlayOfComputer(signArray[1]);
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
                        Console.WriteLine("컴퓨터가 먼저 시작합니다.");
                        gameWithComputer.PlayOfComputer(signArray[0]);
                        for (int count = 0; count < 9 / 2; count++)
                        {
                            gameWithComputer.PlayOfUser(signArray[1]);
                            if (gameWithComputer.CheckWin() == 1)
                            {
                                scoreCountWithComputer.CountScoreWithComputer(signArray[1]);
                                break;
                            }
                            gameWithComputer.PlayOfComputer(signArray[0]);
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
            }
        }
        public void GoMenuComputer()
        {
            ScanAndPrint scanAndPrintMiniMenu = new ScanAndPrint();
            string[] miniMenuNumberArray = { "1", "2", "3" };
            gameWithComputer.PrintGoMenu();
            int checkedMiniMenuNumber = scanAndPrintMiniMenu.ScanMenuNumber(miniMenuNumberArray);
            switch (checkedMiniMenuNumber)
            {
                case 1:
                    {
                        Console.WriteLine("게임을 다시 시작합니다. . .");
                        StartGameWithComputerAgain();
                        break;
                    }
                case 2:
                    {
                        scanAndPrintMiniMenu.ShowMainAgain();
                        break;
                    }
                case 3:
                    {
                        gameWithComputer.PrintOffMenu();
                        string[] offMenuNumberArray = { "1", "2" };
                        int checkedOffNumber = scanAndPrintMiniMenu.ScanMenuNumber(offMenuNumberArray);
                        if (checkedOffNumber == 1)
                        {
                            Console.WriteLine("종료합니다. . .");
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
