using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameTictactoe
    {
        public char[] gameArray = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
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
        public int CheckUserNumber(int checkedSequenceNumber) // 순서 입력 받기
        {
            string[] sequenceNumbers = { "1", "2" }; // 메뉴 번호를 배열에 저장 후 CheckNumber 함수에서 번호 확인할 때 사용
            bool isSequenceNumber = false; // 메뉴 번호를 제대로 입력받았는지 확인을 위한 변수
            string unknownSequenceNumber = "";
            ScanAndPrint scanAndPrint = new ScanAndPrint();

            while (isSequenceNumber == false)
            {
                Console.Write("원하시는 순서의 번호를 입력하세요 : ");
                unknownSequenceNumber = Console.ReadLine();
                Console.WriteLine();
                isSequenceNumber = scanAndPrint.CheckMenuNumber(isSequenceNumber, sequenceNumbers, unknownSequenceNumber);
            }

            return int.Parse(unknownSequenceNumber);
        }
        public void PlayOfUser(char choosedSign) // 유저 게임 버전
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                              " + choosedSign + "의 차례");
            Console.WriteLine("----------------------------------------------------------------------");
            PrintGameMatrix();
            string userMatrixNumber = "";
            bool isUserMatrixNumber = false;
            Console.WriteLine();
            Console.Write("원하시는 칸의 번호를 입력하세요 : ");

            while (isUserMatrixNumber == false)
            {
                userMatrixNumber = Console.ReadLine();
                isUserMatrixNumber = CheckUserMatrixNumber(userMatrixNumber, isUserMatrixNumber);
            }

            gameArray[int.Parse(userMatrixNumber) - 1] = choosedSign;
            if(CheckWin() == 1)
            {
                PrintGameMatrix();
                Console.WriteLine(choosedSign + "가 이겼습니다!");
            }

        }
        public bool CheckUserMatrixNumber(string userMatrixNumber, bool isUserMatrixNumber)
        {
            if (gameArray[int.Parse(userMatrixNumber) - 1] - '0' == int.Parse(userMatrixNumber))
            {
                isUserMatrixNumber = true;
            }
            else
            {
                Console.Write("이미 표시된 칸입니다. 다른 칸의 번호를 선택하세요. : ");
            }
            return isUserMatrixNumber;

        }
        public void PlayOfComputer(char computerSign) // 컴퓨터 게임 버전
        {
            Random makeRandomNumber = new Random();
            bool isComputerMatrixNumber = false;
            int randomMatrixNumber = 0; // 할당?

            while (isComputerMatrixNumber == false)
            {
                randomMatrixNumber = makeRandomNumber.Next(1, 9);
                isComputerMatrixNumber = CheckRandomNumber(randomMatrixNumber, isComputerMatrixNumber);
            }
            gameArray[randomMatrixNumber - 1] = computerSign;

            if (CheckWin() == 1)
            {
                PrintGameMatrix();
                Console.WriteLine("컴퓨터가 이겼습니다!");
            }

        }
        public bool CheckRandomNumber(int randomMatrixNumber, bool isComputerMatrixNumber)
        {
            if (gameArray[randomMatrixNumber - 1] - '0' == randomMatrixNumber)
            {
                isComputerMatrixNumber = true;
            }
            return isComputerMatrixNumber;
        }

        public void PrintGameMatrix() // 게임 화면 출력
        {
            Console.WriteLine("______________________");
            Console.WriteLine();
            for (int matrixIndex = 0;matrixIndex < 3;matrixIndex++)
            {
                Console.Write("   " + gameArray[matrixIndex] + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("______________________");
            Console.WriteLine();
            for (int matrixIndex = 3; matrixIndex < 6; matrixIndex++)
            {
                Console.Write("   " + gameArray[matrixIndex] + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("______________________");
            Console.WriteLine();
            for (int matrixIndex = 6; matrixIndex < 9; matrixIndex++)
            {
                Console.Write("   " + gameArray[matrixIndex] + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("______________________");
            Console.WriteLine();
        }
        public int CheckWin() // 이겼는지 측정하는 함수
        {
            int checkWinGame;
            
            //가로
            int matrixIndexToCheck = 0; // 칸의 인덱스 시작점을 나타내는 변수
            int semiWinCount = 0; // 우승횟수 측정을 위한 count 변수
            checkWinGame = CheckRowWin(matrixIndexToCheck, semiWinCount);
            if (checkWinGame == 1) return 1;

            //세로
            matrixIndexToCheck = 0;
            semiWinCount = 0;
            checkWinGame = CheckColumnWin(matrixIndexToCheck, semiWinCount);
            if (checkWinGame == 1) return 1;

            //대각선
            matrixIndexToCheck = 0;
            semiWinCount = 0;
            checkWinGame = CheckDiagonalWin(matrixIndexToCheck, semiWinCount);
            if (checkWinGame == 1) return 1;

            return 0; // 하나도 못 이긴 상황
        }
        public int CheckRowWin (int matrixIndexToCheck, int semiWinCount) // 가로 줄 체크
        {
            for (int count = 0; count < 3; count++)
            { // 가로는 3줄이므로 3번 반복
                for (int loopCount = matrixIndexToCheck + 1; loopCount < matrixIndexToCheck + 3; loopCount++)
                { // 비교해야할 칸은 3칸이지만, 비교는 2번만 하면 된다.
                    if (gameArray[matrixIndexToCheck] == gameArray[loopCount]) semiWinCount++;
                }

                if (semiWinCount == 2) // 2번 비교해서 가로 한줄의 문자가 모두 같을 경우
                {
                    return 1;
                }
                matrixIndexToCheck += 3;
                semiWinCount = 0; // 우승횟수 측정을 위한 count 변수를 0으로 초기화
            }

            return 0;
        }
        public int CheckColumnWin(int matrixIndexToCheck, int semiWinCount)
        {
            for (int count = 0; count < 3; count++)
            { // 세로는 3줄이므로 3번 반복
                for (int loopCount = matrixIndexToCheck + 3; loopCount < matrixIndexToCheck + 7; loopCount += 3)
                { // 비교해야할 칸은 3칸이지만, 비교는 2번만 하면 된다.
                    if (gameArray[matrixIndexToCheck] == gameArray[loopCount]) semiWinCount++;
                }

                if (semiWinCount == 2) // 2번 비교해서 가로 한줄의 문자가 모두 같을 경우
                {
                    return 1;
                }
                matrixIndexToCheck += 1;
                semiWinCount = 0; // 우승횟수 측정을 위한 count 변수를 0으로 초기화
            }

            return 0;
        }
        public int CheckDiagonalWin(int matrixIndexToCheck, int semiWinCount)
        {
            for (int loopCount = matrixIndexToCheck + 4; loopCount < 9; loopCount += 4)
            {
                if (gameArray[matrixIndexToCheck] == gameArray[loopCount]) semiWinCount++;
                if (semiWinCount == 2) // 2번 비교해서 대각선 한줄의 문자가 모두 같을 경우
                {
                    return 1;
                }
            }
            matrixIndexToCheck = 2;
            semiWinCount = 0;
            for (int loopCount = matrixIndexToCheck + 2; loopCount < 5; loopCount += 2)
            {
                if (gameArray[matrixIndexToCheck] == gameArray[loopCount]) semiWinCount++;
                if (semiWinCount == 2) // 2번 비교해서 대각선 한줄의 문자가 모두 같을 경우
                {
                    return 1;
                }
            }
            return 0;
        }
        public void ClearArray()
        {
            for (int arrayIndex = 0; arrayIndex < 9; arrayIndex++) 
            {
                string temporaryString = (arrayIndex + 1).ToString();
                gameArray[arrayIndex] = temporaryString[0];
            }
        }
        public void PrintGoMenu()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                     1: 같은 게임을 다시 시작합니다.");
            Console.WriteLine("                     2: 메인 메뉴로 돌아갑니다.");
            Console.WriteLine("                     3: 게임을 종료합니다.");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
        }
        public void PrintOffMenu()
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

        }
    }
}
