using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ShowScoreboard
    {
        List<int> scoreListComputerX = new List<int>();
        List<int> scoreListComputerO = new List<int>();
        List<int> scoreListUserX = new List<int>();
        List<int> scoreListUserO = new List<int>();

        public void PrintScoreBoard()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                             SCOREBOARD                               ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                           사용자와 컴퓨터                             ");
            Console.WriteLine("----------------------------------------------------------------------");
            PrintScoreBoardWithComputer();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                           사용자와 사용자                             ");
            Console.WriteLine("----------------------------------------------------------------------");
            PrintScoreBoardWithUser();
        }
        public void PrintScoreBoardWithComputer()
        {
            int sumOfScoreX = 0;
            int sumOfScoreO = 0;
            sumOfScoreX = PrintScoreBoard(scoreListComputerX, 'X', sumOfScoreX);
            sumOfScoreO = PrintScoreBoard(scoreListComputerO, 'O', sumOfScoreO);
            
        }
        public void PrintScoreBoardWithUser()
        {
            int sumOfScoreX = 0;
            int sumOfScoreO = 0;
            sumOfScoreX = PrintScoreBoard(scoreListUserX, 'X', sumOfScoreX);
            sumOfScoreO = PrintScoreBoard(scoreListUserO, 'O', sumOfScoreO);
        }
        public int PrintScoreBoard(List<int> list, char sign, int sum)
        {
            Console.Write(sign + " :");
            for (int sequence = 0; sequence < list.Count; sequence++)
            {
                Console.Write(" " + list[sequence] + " ");
                sum += list[sequence];
            }
            return sum;

        }
        public void CountScoreWithComputer(char sign)
        {
            switch(sign)
            {
                case 'X':
                    {
                        scoreListComputerX.Add(1);
                        scoreListComputerO.Add(0);
                        break;
                    }
                case 'O':
                    {
                        scoreListComputerO.Add(1);
                        scoreListComputerX.Add(0);
                        break;
                    }

            }
        }
        public void CountScoreWithUser(char sign)
        {
            switch (sign)
            {
                case 'X':
                    {
                        scoreListUserX.Add(1);
                        scoreListUserO.Add(0);
                        break;
                    }
                case 'O':
                    {
                        scoreListUserO.Add(1);
                        scoreListUserX.Add(0);
                        break;
                    }

            }
        }
    }
}
