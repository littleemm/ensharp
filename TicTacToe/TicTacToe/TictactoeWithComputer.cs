using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TictactoeWithComputer
    {
        GameTictactoe gameWithComputer = new GameTictactoe();
        char[] signArray = { 'X', 'O' };
        public void StartGameWithComputer()
        {
            int userSequenceNumber = 0; // 할당?

            gameWithComputer.ChooseOX();
            gameWithComputer.CheckUserNumber(userSequenceNumber);
            progressGameWithComputer(userSequenceNumber);

        }
        public void progressGameWithComputer (int userSequenceNumber)
        {
            switch (userSequenceNumber)
            {
                case 1:
                    {
                        Console.WriteLine("당신이 먼저 시작합니다.");
                        for (int countGame = 0; countGame < 9 / 2; countGame++)
                        {
                            gameWithComputer.PlayOfUser(signArray[0]);
                            gameWithComputer.PlayOfComputer(signArray[1]);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("컴퓨터가 먼저 시작합니다.");
                        for (int countGame = 0; countGame < 9 / 2; countGame++)
                        {
                            gameWithComputer.PlayOfComputer(signArray[0]);
                            gameWithComputer.PlayOfUser(signArray[1]);
                        }
                        break;
                    }
            }
        }
    }
}
