using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TictactoeWithUser
    {
        GameTictactoe gameWithUser = new GameTictactoe();
        ShowScoreboard scoreCountWithUser = new ShowScoreboard();
        char[] signArray = { 'X', 'O' };
        private static int userSequenceNumber = 0;

        public void StartGameWithUser()
        {
            gameWithUser.ChooseOX();
            userSequenceNumber = gameWithUser.CheckUserNumber(userSequenceNumber);
            progressGameWithUser(userSequenceNumber);
            gameWithUser.ClearArray();
            GoMenuUser();

        }
        public void StartGameWithUserAgain()
        {
            if (userSequenceNumber == 0)
            {
                gameWithUser.ChooseOX();
                userSequenceNumber = gameWithUser.CheckUserNumber(userSequenceNumber);
            }
            progressGameWithUser(userSequenceNumber);
            gameWithUser.ClearArray();
            GoMenuUser();
        }
        public void progressGameWithUser(int userSequenceNumber)
        {
            Console.WriteLine("X가 먼저 시작합니다.");
            LoopGameWithUser();
        }
        public void LoopGameWithUser()
        {
            int countGame = 0;
            gameWithUser.PlayOfUser(signArray[0]);
            for (int count = 0; count < 9 / 2; count++)
            {
                gameWithUser.PlayOfUser(signArray[1]);
                if (gameWithUser.CheckWin() == 1)
                {
                    scoreCountWithUser.CountScoreWithUser(signArray[1]);
                    break;
                }
                gameWithUser.PlayOfUser(signArray[0]);
                if (gameWithUser.CheckWin() == 1)
                {
                    scoreCountWithUser.CountScoreWithUser(signArray[0]);
                    break;
                }
                countGame += 2;
            }
            if (countGame == 8)
            {
                scoreCountWithUser.DrawGameWithComputer();
            }
        }
        public void GoMenuUser()
        {
            ScanAndPrint scanAndPrintMiniMenu = new ScanAndPrint();
            string[] miniMenuNumberArray = { "1", "2", "3" };
            gameWithUser.PrintGoMenu();
            int checkedMiniMenuNumber = scanAndPrintMiniMenu.ScanMenuNumber(miniMenuNumberArray);
            switch (checkedMiniMenuNumber)
            {
                case 1:
                    {
                        Console.WriteLine("게임을 다시 시작합니다. . .");
                        StartGameWithUserAgain();
                        break;
                    }
                case 2:
                    {
                        scanAndPrintMiniMenu.ShowMainAgain();
                        break;
                    }
                case 3:
                    {
                        gameWithUser.PrintOffMenu();
                        string[] offMenuNumberArray = { "1", "2" };
                        int checkedOffNumber = scanAndPrintMiniMenu.ScanMenuNumber(offMenuNumberArray);
                        if (checkedOffNumber == 1)
                        {
                            Console.WriteLine("종료합니다. . .");
                            break;
                        }
                        else
                        {
                            GoMenuUser();
                        }

                        break;
                    }
            }

        }
    }
}
