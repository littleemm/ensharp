using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TictactoeWithUser // 유저끼리 게임할 때
    {
        GameTictactoe gameWithUser = new GameTictactoe();
        ShowScoreboard scoreCountWithUser = new ShowScoreboard();
        ScanAndPrint scanAndPrintMiniMenu = new ScanAndPrint();
        char[] signArray = { 'X', 'O' };

        public void StartGameWithUser()
        {
            ProgressGameWithUser();
            gameWithUser.ClearArray();
            GoMenuUser();

        }
        private void ProgressGameWithUser()
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
                scoreCountWithUser.DrawGameWithUser();
            }
        }
        private void GoMenuUser()
        {
            string[] miniMenuNumberArray = { "1", "2", "3" };
            gameWithUser.PrintGoMenu();
            int checkedMiniMenuNumber = scanAndPrintMiniMenu.ScanMenuNumber(miniMenuNumberArray);
            switch (checkedMiniMenuNumber)
            {
                case 1:
                    {
                        StartGameWithUser();
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
                        gameWithUser.PrintOffMenu();
                        string[] offMenuNumberArray = { "1", "2" };
                        int checkedOffNumber = scanAndPrintMiniMenu.ScanMenuNumber(offMenuNumberArray);
                        Console.Clear();
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
