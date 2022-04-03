using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TictactoeWithUser
    {
        GameTictactoe gameWithUser = new GameTictactoe();
        char[] signArray = { 'X', 'O'};
        public void StartGameWithUser()
        {
            int userSequenceNumber = 0; // 할당?

            gameWithUser.ChooseOX();
            gameWithUser.CheckUserNumber(userSequenceNumber);
            progressGameWithUser(userSequenceNumber);

        }
        public void progressGameWithUser(int userSequenceNumber)
        {
            switch (userSequenceNumber)
            {
                case 1:
                    {
                        Console.WriteLine("순서 번호를 입력한 사람이 먼저 시작합니다.");
                        LoopGameWithUser();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("순서 번호를 입력하지 않은 사람이 먼저 시작합니다.");
                        LoopGameWithUser();
                        break;
                    }
            }
        }
        public void LoopGameWithUser()
        {
            for (int countGame = 0; countGame < 9 / 2; countGame++)
            {
                gameWithUser.PlayOfUser(signArray[0]);
                gameWithUser.PlayOfUser(signArray[1]);
            }
        }

    }
}
