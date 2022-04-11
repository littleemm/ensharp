using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class FindRegisterException
    {
        private int countId;
        private int countPrice;

        public FindRegisterException()
        {
            countId = 0;
        }
        public bool IsId(string id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                for (char number = '0'; number <= '9'; number++)
                {
                    if (id[i] == number)
                    {
                        countId++;
                        break;
                    }
                }
            }

            if (id.Length == countId)
            {
                return true;
            }

            ClearLine(2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                   숫자로 된 아이디를 입력하세요!");
            Console.ResetColor();
            return false;
        }

        public bool IsPrice (string price)
        {
            for (int i = 0; i < price.Length; i++)
            {
                for (char number = '0'; number <= '9'; number++)
                {
                    if (price[i] == number)
                    {
                        countId++;
                        break;
                    }
                }
            }

            if (price.Length == countId && int.Parse(price) != 0)
            {
                return true;
            }

            ClearLine(2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                 0이 아닌 정수 가격으로 다시 입력하세요!");
            Console.ResetColor();

            return false;
        }

        private void ClearLine(int line)
        { // 라인 한줄씩 청소
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
