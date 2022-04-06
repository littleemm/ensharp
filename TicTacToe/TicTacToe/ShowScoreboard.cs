using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ShowScoreboard
    {
        ScanAndPrint scanAndPrintBoard = new ScanAndPrint();
        GameTictactoe tictactoeScoreBoard = new GameTictactoe();

        static List<int> scoreListComputerX = new List<int>();
        static List<int> scoreListComputerO = new List<int>();
        static List<int> scoreListUserX = new List<int>();
        static List<int> scoreListUserO = new List<int>();
        private static int countGame = 0;
        public void PrintScoreBoard() // 스코어보드 켜자마자 나오는 화면
        {
            Console.Clear();
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
        public void PrintScoreBoardWithComputer() // 컴퓨터와 대결 결과 출력
        {
            int sumOfScoreX = 0;
            int sumOfScoreO = 0;
            sumOfScoreX = PrintScoreBoard(scoreListComputerX, 'X', sumOfScoreX);
            sumOfScoreO = PrintScoreBoard(scoreListComputerO, 'O', sumOfScoreO);
            CompareScore(sumOfScoreX, sumOfScoreO);
        }
        public void PrintScoreBoardWithUser() // 유저끼리 대결 결과 출력
        {
            int sumOfScoreX = 0;
            int sumOfScoreO = 0;
            sumOfScoreX = PrintScoreBoard(scoreListUserX, 'X', sumOfScoreX);
            sumOfScoreO = PrintScoreBoard(scoreListUserO, 'O', sumOfScoreO);
            CompareScore(sumOfScoreX, sumOfScoreO);
        }
        public int PrintScoreBoard(List<int> list, char sign, int sum) // 대결 결과 출력
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
        public void DrawGameWithComputer()
        {
            countGame++;
            Console.WriteLine("                        무승부 입니다!");
            Console.WriteLine();
            scoreListComputerO.Add(0);
            scoreListComputerX.Add(0);
        }
        public void DrawGameWithUser()
        {
            countGame++;
            Console.WriteLine("                        무승부 입니다!");
            Console.WriteLine();
            scoreListUserO.Add(0);
            scoreListUserX.Add(0);
        }
        private void CompareScore(int sumOfX, int sumOfO) // 점수 비교 후 바로 출력
        {
            Console.WriteLine("----------------------------------------------------------------------");
            int compareSum = sumOfX - sumOfO;
            switch (compareSum)
            {
                case 0:
                    {
                        Console.WriteLine("X : O = - : -");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("X : O = " + sumOfX + " : " + sumOfO);
                        break;
                    }
            }
            Console.WriteLine("----------------------------------------------------------------------");
        }
        private void PrintOffBoardMenu() // 스코어 보드 맨 밑 출력
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                             1: 메인 메뉴로");
            Console.WriteLine("                             2: 종료");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
        }
        private void OffScoreBoard() // 종료 키를 누른 후 한번 더 물어보는 항목
        {
            string[] offMenuNumberArray = { "1", "2" };
            PrintOffBoardMenu();
            int checkedOffNumber = scanAndPrintBoard.ScanMenuNumber(offMenuNumberArray);
            Console.Clear();
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
                Console.Clear();
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
        public void CountScoreWithComputer(char sign)
        {
            countGame++;
            switch (sign)
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
    }
}
