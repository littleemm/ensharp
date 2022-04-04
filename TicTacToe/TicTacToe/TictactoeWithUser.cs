using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TictactoeWithUser
    {
        GameTictactoe gameWithUser = new GameTictactoe();
        ShowScoreboard scoreCountWithUser = new ShowScoreboard();
        char[] signArray = { 'X', 'O'};
        public void StartGameWithUser()
        {
            int userSequenceNumber = 0; // 할당?

            gameWithUser.ChooseOX();
            userSequenceNumber = gameWithUser.CheckUserNumber(userSequenceNumber);
            progressGameWithUser(userSequenceNumber);

        }
        public void progressGameWithUser(int userSequenceNumber)
        {
            Console.WriteLine("X가 먼저 시작합니다.");
            LoopGameWithUser();
        }
        public void LoopGameWithUser()
        {
            gameWithUser.PlayOfUser(signArray[0]);
            for (int countGame = 0; countGame < 9 / 2; countGame++)
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
            }
        }

    }
}
