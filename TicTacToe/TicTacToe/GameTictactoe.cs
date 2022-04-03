using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameTictactoe
    {
        char[] gameArray = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        public void ChooseOX()
        {
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
        }
        public void CheckUserNumber(int checkedSequenceNumber)
        {
            char[] sequenceNumbers = { '1', '2' }; // 메뉴 번호를 배열에 저장 후 CheckNumber 함수에서 번호 확인할 때 사용
            bool isSequenceNumber = false; // 메뉴 번호를 제대로 입력받았는지 확인을 위한 변수
            string unknownSequenceNumber = "";
            ScanAndPrint scanAndPrint = new ScanAndPrint();

            while (isSequenceNumber == true)
            {
                Console.Write("원하시는 순서의 번호를 입력하세요 : ");
                unknownSequenceNumber = Console.ReadLine();

                scanAndPrint.CheckMenuNumber(isSequenceNumber, sequenceNumbers, unknownSequenceNumber);
            }

            checkedSequenceNumber = int.Parse(unknownSequenceNumber);
        }
        public void PlayOfUser(char choosedSign)
        {
            string userMatrixNumber;
            bool isUserMatrixNumber = false;

            Console.Write("원하시는 칸의 번호를 입력하세요 : ");
            userMatrixNumber = Console.ReadLine();

            while (isUserMatrixNumber == true)
            {
                CheckUserMatrixNumber(userMatrixNumber, isUserMatrixNumber);
            }

            gameArray[int.Parse(userMatrixNumber) - 1] = choosedSign;
            PrintGameMatrix();

        }
        public void CheckUserMatrixNumber(string userMatrixNumber, bool isUserMatrixNumber)
        {
            
            if (gameArray[int.Parse(userMatrixNumber) - 1] == int.Parse(userMatrixNumber))
            {
                isUserMatrixNumber = true;
            }
            else
                {
                    Console.WriteLine("이미 표시된 칸입니다. 다른 칸의 번호를 선택하세요. : ");
                    userMatrixNumber = Console.ReadLine();
                }

        }
        public void PlayOfComputer(char computerSign)
        {
            Random makeRandomNumber = new Random();
            bool isComputerMatrixNumber = false;
            int randomMatrixNumber = 0; // 할당?

            while (isComputerMatrixNumber == true)
            {
                randomMatrixNumber = makeRandomNumber.Next(1, 9);
            }
            gameArray[randomMatrixNumber - 1] = computerSign;
            PrintGameMatrix();

        }
        public void CheckRandomNumber(int randomMatrixNumber, bool isComputerMatrixNumber)
        {
            if (gameArray[randomMatrixNumber - 1] == randomMatrixNumber)
            {
                isComputerMatrixNumber = true;
            }
        }

        public void PrintGameMatrix()
        {
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            for (int matrixIndex = 0;matrixIndex < 3;matrixIndex++)
            {
                Console.Write(gameArray[matrixIndex] + "   ");
            }
            Console.WriteLine("_________________________________");
            for (int matrixIndex = 3; matrixIndex < 6; matrixIndex++)
            {
                Console.Write(gameArray[matrixIndex] + "   ");
            }
            Console.WriteLine("_________________________________");
            for (int matrixIndex = 6; matrixIndex < 9; matrixIndex++)
            {
                Console.Write(gameArray[matrixIndex] + "   ");
            }
            Console.WriteLine("_________________________________");
        }
    }
}
