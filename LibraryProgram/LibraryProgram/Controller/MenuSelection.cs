using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MenuSelection
    {

        BasicViewElement viewElement;
        private ConsoleKeyInfo keyInfo;
        public MenuSelection(BasicViewElement viewElement)
        {
            keyInfo = new ConsoleKeyInfo();
            this.viewElement = viewElement;
        }

        public string CheckMenuNumber(int x, int y, string[] numberArray) // 체크해서 넘어가는 로직
        {
            string number = "";
            bool isMenuNumber = false;

            while (isMenuNumber == false)
            {
                number = ScanMenuNumber(x, y);
                isMenuNumber = IsMenuNumber(number, numberArray);

                if (isMenuNumber == false)
                {
                    viewElement.ClearLine(1, x);
                    Console.SetCursorPosition(x, y);
                    viewElement.PrintWarningSentence(1, y - 2);
                }
            }

            isMenuNumber = false;

            return number;
        }
        public string CheckMenuKey(int x, int y, string[] numberArray)
        { // 키 체크
            string number = "";
            bool isMenuNumber = false;

            while (isMenuNumber == false)
            {
                number = ScanMenuKey(x, y);
                if (number.Equals("0"))
                {
                    return number;
                }
                isMenuNumber = IsMenuNumber(number, numberArray);

                if (isMenuNumber == false)
                {
                    viewElement.ClearLine(1, x);
                    Console.SetCursorPosition(x, y);
                    viewElement.PrintWarningSentence(1, y - 2);
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

        private string ScanMenuKey(int x, int y) // 키 받을 함수
        {
            string number = "";
            Console.SetCursorPosition(x, y);

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    number += keyInfo.KeyChar.ToString();
                    Console.Write(keyInfo.KeyChar.ToString());
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && number.Length > 0)
                {
                    number = number.Substring(0, (number.Length - 1));
                    Console.Write("\b \b");
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return "0";
                }
            }

            if(number == "0")
            {
                ScanMenuKey(x, y);
            }

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
