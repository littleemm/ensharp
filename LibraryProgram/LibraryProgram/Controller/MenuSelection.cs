using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MenuSelection
    {
        int positionX;
        int positionY;

        protected MenuSelection(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }

        protected string CheckMenuNumber(string[] numberArray, BasicViewElement viewElement) // 체크해서 넘어가는 로직
        {
            string number = "";
            bool isMenuNumber = false;

            while (isMenuNumber == false)
            {
                number = ScanMenuNumber(positionX, positionY);
                isMenuNumber = IsMenuNumber(number, numberArray);

                if (isMenuNumber == false)
                {
                    viewElement.ClearLine(1, positionX);
                    Console.SetCursorPosition(positionX, positionY);
                    viewElement.PrintWarningSentence(1, positionY - 2);
                }
            }

            isMenuNumber = false;

            return number;
        }

        private string ScanMenuNumber(int x, int y) // 읽기
        {
            string number;

            Console.SetCursorPosition(x, y);

            number = Console.ReadLine();

            return number;
        }

        private bool IsMenuNumber(string number, string[] numberArray) // 제한된 범위의 숫자가 입력됐는지 체크
        {
            for (int arrayIndex = 0; arrayIndex < numberArray.Length; arrayIndex++)
            {
                if (string.IsNullOrEmpty(number?.Trim()))
                { // ctrl + z 체크
                    return false;
                }

                if (number.Equals(numberArray[arrayIndex]))
                { // 입력 성공
                    return true;
                }

            }

            return false;
        }

    }
}
