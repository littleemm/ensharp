﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ShowScoreboard
    {
        static List<int> scoreListComputerX = new List<int>();
        static List<int> scoreListComputerO = new List<int>();
        static List<int> scoreListUserX = new List<int>();
        static List<int> scoreListUserO = new List<int>();
        private static int countGame = 0;
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
            OffScoreBoard();
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
            Console.WriteLine();
            return sum;

        }
        public void CountScoreWithComputer(char sign)
        {
            countGame++;
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
            countGame++;
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
        public void DrawGameWithComputer()
        {
            countGame++;
            Console.WriteLine("무승부 입니다!");
            Console.WriteLine();
            scoreListComputerO.Add(0);
            scoreListComputerX.Add(0);
        }
        public void DrawGameWithUser()
        {
            countGame++;
            Console.WriteLine("무승부 입니다!");
            Console.WriteLine();
            scoreListUserO.Add(0);
            scoreListUserX.Add(0);
        }
        public void OffScoreBoard()
        {
            ScanAndPrint scanAndPrintBoard = new ScanAndPrint();
            GameTictactoe tictactoeScoreBoard = new GameTictactoe();
            string[] offMenuNumberArray = { "1", "2" };
            PrintOffBoardMenu();
            int checkedOffNumber = scanAndPrintBoard.ScanMenuNumber(offMenuNumberArray);
            if (checkedOffNumber == 1)
            {
                switch (countGame)
                {
                    case 0:
                        {
                            scanAndPrintBoard.ShowMain();
                            break;
                        }
                    default:
                        {
                            scanAndPrintBoard.ShowMainAgain();
                            break;
                        }
                }
            }
            else
            {
                tictactoeScoreBoard.PrintOffMenu();
                checkedOffNumber = scanAndPrintBoard.ScanMenuNumber(offMenuNumberArray);
                switch(checkedOffNumber)
                {
                    case 1:
                        {
                            Console.WriteLine("종료합니다. . .");
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            PrintScoreBoard();
                            break;
                        }
                }
            }
        }
        public void PrintOffBoardMenu()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                             1: 메인 메뉴로");
            Console.WriteLine("                             2: 종료");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}
