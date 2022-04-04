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
        public void StartGameWithComputer()
        {
            int userSequenceNumber = 0; // 할당?

            gameWithComputer.ChooseOX();
            userSequenceNumber = gameWithComputer.CheckUserNumber(userSequenceNumber);
            progressGameWithComputer(userSequenceNumber);

        }
        public void progressGameWithComputer (int userSequenceNumber)
        {
            switch (userSequenceNumber)
            {
                case 1:
                    {
                        Console.WriteLine("당신이 먼저 시작합니다.");

                        gameWithComputer.PlayOfUser(signArray[0]);
                        for (int countGame = 0; countGame < 9 / 2; countGame++)
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
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("컴퓨터가 먼저 시작합니다.");
                        gameWithComputer.PlayOfComputer(signArray[0]);
                        for (int countGame = 0; countGame < 9 / 2; countGame++)
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
                        }
                        break;
                    }
            }
        }
    }
}
