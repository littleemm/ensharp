using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MenuSelection
    {

        public string CheckMenuNumber(string[] numberArray, ViewElement viewElement) // 체크해서 넘어가는 로직
        {
            while (isMenuNumber == false)
            {
                number = ScanMenuNumber(positionX, positionY);
                isMenuNumber = IsMenuNumber(number, numberArray);

                if (isMenuNumber == false)
                {
                    viewElement.ClearLine(1, positionX);
                    Console.SetCursorPosition(positionX, positionY);
                    viewElement.PrintWarning(1, positionY - 2);
                }
            }

            isMenuNumber = false;

            return number;
        }

        private string ScanMenuNumber(int x, int y) // 읽기
        {
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
