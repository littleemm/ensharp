using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class PrintGameElement
    {
        public void ChooseOX() // 컴퓨터와 대결할 경우 순서 고르는 함수
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                       O 와 X 중 하나를 고르세요!                       ");
            Console.WriteLine("                      게임은 'X'가 먼저 시작합니다.                     ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                              1: X 선택                               ");
            Console.WriteLine("                              2: O 선택                               ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
        }
        public void PrintGameMatrix(char[] gameArray) // 게임 화면에 출력되는 게임 화면
        {
            Console.WriteLine("                        ----------------------");
            Console.WriteLine("                        |      |      |      |");
            Console.Write("                        |");
            for (int matrixIndex = 0; matrixIndex < 3; matrixIndex++)
            {
                Console.Write("  " + gameArray[matrixIndex] + "   |");
            }
            Console.WriteLine("                        |      |      |      |");
            Console.WriteLine("                        |      |      |      |");
            Console.WriteLine("                        ----------------------");
            Console.WriteLine("                        |      |      |      |");
            Console.Write("                        |");
            for (int matrixIndex = 3; matrixIndex < 6; matrixIndex++)
            {
                Console.Write("  " + gameArray[matrixIndex] + "   |");
            }
            Console.WriteLine("                        |      |      |      |");
            Console.WriteLine("                        |      |      |      |");
            Console.WriteLine("                        ----------------------");
            Console.WriteLine("                        |      |      |      |");
            Console.Write("                        |");
            for (int matrixIndex = 6; matrixIndex < 9; matrixIndex++)
            {
                Console.Write("  " + gameArray[matrixIndex] + "   |");
            }
            Console.WriteLine("                        |      |      |      |");
            Console.WriteLine("                        |      |      |      |");
            Console.WriteLine("                        ----------------------");
            Console.WriteLine();
            Console.WriteLine();
        }
        public void PrintGoMenu() // 게임이 끝난 직후의 메뉴 출력
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                     1: 같은 게임을 다시 시작합니다.");
            Console.WriteLine("                     2: 메인 메뉴로 돌아갑니다.");
            Console.WriteLine("                     3: 게임을 종료합니다.");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
        }
        public void PrintOffMenu() // 게임을 종료하기 전에 메뉴 출력
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                               종료할까요?");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                               1: 종료");
            Console.WriteLine("                               2: 취소");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
