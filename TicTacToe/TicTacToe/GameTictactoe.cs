using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameTictactoe // 게임에 필요한 요소를 담은 클래스 (공통되는 경우가 많음)
    {
        public char[] gameArray = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        ScanAndPrint scanAndPrint = new ScanAndPrint();

        public void ChooseOX() // 컴퓨터와 대결할 경우 순서를 골라야한다
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
        }
        public int CheckUserNumber(int checkedSequenceNumber) // 순서 입력 받기
        {
            string[] sequenceNumbers = { "1", "2" }; // 메뉴 번호를 배열에 저장 후 CheckNumber 함수에서 번호 확인할 때 사용
            bool isSequenceNumber = false; // 메뉴 번호를 제대로 입력받았는지 확인을 위한 변수
            string unknownSequenceNumber = "";

            while (isSequenceNumber == false)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("              원하시는 순서의 번호를 입력하세요 : ");
                unknownSequenceNumber = Console.ReadLine();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine();
                isSequenceNumber = scanAndPrint.CheckMenuNumber(isSequenceNumber, sequenceNumbers, unknownSequenceNumber);
            }

            return int.Parse(unknownSequenceNumber);
        }
        public void PlayOfUser(char choosedSign) // 유저 게임 버전
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                              " + choosedSign + "의 차례");
            Console.WriteLine("----------------------------------------------------------------------");
            PrintGameMatrix();
            string[] matrixNumberToCompare = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string userMatrixNumber = "";
            bool isUserMatrixNumber = false;
            bool isCorrectNumber = false;

            while (isUserMatrixNumber == false)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("                 원하시는 칸의 번호를 입력하세요 : ");
                userMatrixNumber = Console.ReadLine();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine();
                isCorrectNumber = scanAndPrint.CheckMenuNumber(isCorrectNumber, matrixNumberToCompare, userMatrixNumber);
                if (isCorrectNumber == true)
                {
                    isUserMatrixNumber = CheckUserMatrixNumber(userMatrixNumber, isUserMatrixNumber);
                    isCorrectNumber = false; // 오류 방지
                }
            }

            gameArray[int.Parse(userMatrixNumber) - 1] = choosedSign;
            if(CheckWin() == 1) // 이겼는지 체크
            {
                Console.Clear();
                PrintGameMatrix();
                Console.WriteLine();
                Console.WriteLine(choosedSign + "가 이겼습니다!");
                Console.WriteLine();
            }

        }
        
        public bool CheckUserMatrixNumber(string userMatrixNumber, bool isUserMatrixNumber) // 게임에서 중복된 칸을 선택할 수 없으므로 그것을 판별하는 함수
        {
            if (gameArray[int.Parse(userMatrixNumber) - 1] - '0' == int.Parse(userMatrixNumber))
            { // 칸 안에 숫자(인 문자)가 들어있을 경우, 칸 선택이 가능하다
                isUserMatrixNumber = true;
            }
            else
            {
                Console.Write("         이미 표시된 칸입니다. 다른 칸의 번호를 선택하세요!");
                Console.WriteLine();
            }
            return isUserMatrixNumber;

        }
        public void PlayOfComputer(char computerSign, char userSign) // 컴퓨터 게임 버전
        {
            Random makeRandomNumber = new Random(); // 난수를 만들어야 하기 때문
            bool isComputerMatrixNumber = false;
            int computerMatrixNumber = 0; // 컴퓨터가 표시하고자 하는 곳의 숫자
            Console.Clear();
            while (isComputerMatrixNumber == false)
            {
                computerMatrixNumber = CheckComputerNumberToGame(computerSign);
                if (computerMatrixNumber > 0)
                {
                    isComputerMatrixNumber = CheckComputrMatrixNumber(computerMatrixNumber, isComputerMatrixNumber);

                }
                if (isComputerMatrixNumber == true) break;

                computerMatrixNumber = CheckComputerNumberToGame(userSign);
                if (computerMatrixNumber > 0)
                {
                    isComputerMatrixNumber = CheckComputrMatrixNumber(computerMatrixNumber, isComputerMatrixNumber);
                }
                if (isComputerMatrixNumber == true) break;

                computerMatrixNumber = CheckCompuerNumberTogame2(computerSign);
                if (computerMatrixNumber > 0)
                {
                    isComputerMatrixNumber = CheckComputrMatrixNumber(computerMatrixNumber, isComputerMatrixNumber);
                }
                if (isComputerMatrixNumber == true) break;

                computerMatrixNumber = makeRandomNumber.Next(1, 10); // 굳이 이기기 위해 놓을 곳이 없을 때 난수 발생
                isComputerMatrixNumber = CheckComputrMatrixNumber(computerMatrixNumber, isComputerMatrixNumber);
            }
            gameArray[computerMatrixNumber - 1] = computerSign;

            if (CheckWin() == 1)
            {
                Console.Clear();
                PrintGameMatrix();
                Console.WriteLine();
                Console.WriteLine("컴퓨터가 이겼습니다!");
                Console.WriteLine();
            }

        }
        public int CheckCompuerNumberTogame2(char sign) // 이길 수 있는 가능성이 있는 곳에 기호를 표시하기 위한 함수
        {
            Random makeRandomNumber2 = new Random();
            int randomNumberIndex;
            for (int matrixIndex = 0;matrixIndex < 9;matrixIndex++)
            {
                if (gameArray[matrixIndex] == sign)
                {
                    switch (matrixIndex)
                    {
                        case 0:
                            {
                                int [] array = { 1, 2, 3, 4, 5, 7, 9 };
                                randomNumberIndex = makeRandomNumber2.Next(0, 7);
                                return array[randomNumberIndex];
                            }
                        case 1:
                            {
                                int[] array = { 1, 2, 3, 5, 8};
                                randomNumberIndex = makeRandomNumber2.Next(0, 5);
                                return array[randomNumberIndex];
                            }
                        case 2:
                            {
                                int[] array = { 1, 2, 3, 5, 6, 7, 9 };
                                randomNumberIndex = makeRandomNumber2.Next(0, 7);
                                return array[randomNumberIndex];
                            }
                        case 3:
                            {
                                int[] array = { 1, 4, 5, 6, 7};
                                randomNumberIndex = makeRandomNumber2.Next(0, 5);
                                return array[randomNumberIndex];
                            }
                        case 5:
                            {
                                int[] array = { 3, 4, 5, 6, 9};
                                randomNumberIndex = makeRandomNumber2.Next(0, 5);
                                return array[randomNumberIndex];
                            }
                        case 6:
                            {
                                int[] array = { 1, 3, 4, 5, 7, 8, 9 };
                                randomNumberIndex = makeRandomNumber2.Next(0, 7);
                                return array[randomNumberIndex];
                            }
                        case 7:
                            {
                                int[] array = { 2, 5, 7, 8, 9 };
                                randomNumberIndex = makeRandomNumber2.Next(0, 5);
                                return array[randomNumberIndex];
                            }
                        case 8:
                            {
                                int[] array = { 1, 3, 5, 6, 7, 8, 9 };
                                randomNumberIndex = makeRandomNumber2.Next(0, 7);
                                return array[randomNumberIndex];
                            }
                        case 4:
                            {
                                int[] array = { 1, 2, 3, 5, 6, 7, 8, 9 };
                                randomNumberIndex = makeRandomNumber2.Next(0, 8);
                                return array[randomNumberIndex];
                            }

                    }
                } 
            }
            return 0;
        }
        public int CheckComputerNumberToGame(char sign)
        {
            int checkedMatrixNumber = 0;

            int matrixIndexToCheck = 0; 
            int countSign = 0;
            checkedMatrixNumber = CheckComputerNumberRow(sign, matrixIndexToCheck, countSign);
            if (checkedMatrixNumber > 0) return checkedMatrixNumber;

            matrixIndexToCheck = 0;
            countSign = 0;
            checkedMatrixNumber = CheckComputerNumberColumn(sign, matrixIndexToCheck, countSign);
            if (checkedMatrixNumber > 0) return checkedMatrixNumber;

            matrixIndexToCheck = 0;
            countSign = 0;
            checkedMatrixNumber = CheckComputerNumberDiagonal(sign, matrixIndexToCheck, countSign);
            if (checkedMatrixNumber > 0) return checkedMatrixNumber;

            return 0; // 상대방을 굳이 막을 필요없거나 이길 기미가 아직은 안보이는 상태
        }
        private int CheckComputerNumberRow(char sign, int matrixIndexToCheck, int countSign)
        {
            int index = 0;
            for (int count = 0; count < 3; count++)
            { // 가로는 3줄이므로 3번 반복
                for (int loopCount = matrixIndexToCheck; loopCount < matrixIndexToCheck + 3; loopCount++)
                {
                    if (gameArray[loopCount] == sign) countSign++;
                    else index = loopCount; 
                }

                if (countSign == 2) // 가로 한줄에 같은 문자 두개가 있을 경우
                {
                    return index + 1;
                }
                matrixIndexToCheck += 3;
                countSign = 0; // 횟수 측정을 위한 count 변수를 0으로 초기화
            }

            return 0;
        }
        private int CheckComputerNumberColumn(char sign, int matrixIndexToCheck, int countSign) // 세로 줄 체크
        {
            int index = 0;
            for (int count = 0; count < 3; count++)
            { // 세로는 3줄이므로 3번 반복
                for (int loopCount = matrixIndexToCheck; loopCount < matrixIndexToCheck + 7; loopCount += 3)
                {
                    if (gameArray[loopCount] == sign) countSign++;
                    else index = loopCount;
                }

                if (countSign == 2)
                {
                    return index + 1;
                }
                matrixIndexToCheck += 1;
                countSign = 0; 
            }

            return 0;
        }
        private int CheckComputerNumberDiagonal(char sign, int matrixIndexToCheck, int countSign) // 대각선 체크
        {
            int index = 0;
            for (int loopCount = matrixIndexToCheck; loopCount < 9; loopCount += 4)
            {
                if (gameArray[loopCount] == sign) countSign++;
                else index = loopCount;
            }
            
            if (countSign == 2) // 2번 비교해서 대각선 한줄의 문자가 모두 같을 경우
            {
                return index + 1;
            }

            matrixIndexToCheck = 2;
            countSign = 0;
            for (int loopCount = matrixIndexToCheck; loopCount < 7; loopCount += 2)
            {
                if (gameArray[loopCount] == sign) countSign++;
                else index = loopCount;
            }
            
            if (countSign == 2) 
            {
                return index + 1;
            }
            return 0;
        }

        public bool CheckComputrMatrixNumber(int randomMatrixNumber, bool isComputerMatrixNumber)
        {
            if (gameArray[randomMatrixNumber - 1] - '0' == randomMatrixNumber)
            {
                isComputerMatrixNumber = true;
            }
            return isComputerMatrixNumber;
        }

        public void PrintGameMatrix() // 게임 화면에 출력되는 게임 화면
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
            if (checkWinGame == 1) return 1; // 이기면 바로 1 반환

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
        private int CheckRowWin (int matrixIndexToCheck, int semiWinCount) // 가로 줄 체크
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
        private int CheckColumnWin(int matrixIndexToCheck, int semiWinCount) // 세로 줄 체크
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
        private int CheckDiagonalWin(int matrixIndexToCheck, int semiWinCount) // 대각선 체크
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
            for (int loopCount = matrixIndexToCheck + 2; loopCount < 7; loopCount += 2)
            {
                if (gameArray[matrixIndexToCheck] == gameArray[loopCount]) semiWinCount++;
                if (semiWinCount == 2) // 2번 비교해서 대각선 한줄의 문자가 모두 같을 경우
                {
                    return 1;
                }
            }
            return 0;
        }
        public void ClearArray() // 한 세트가 끝나면 다음 게임을 위해 배열을 처음으로 돌려놓는 함수
        {
            for (int arrayIndex = 0; arrayIndex < 9; arrayIndex++) 
            {
                string temporaryString = (arrayIndex + 1).ToString();
                gameArray[arrayIndex] = temporaryString[0];
            }
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

        }
    }
}
