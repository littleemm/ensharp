using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryProgram
{
    class KeyReader
    {
        private ConsoleKeyInfo keyInfo;

        public KeyReader()
        {
            keyInfo = new ConsoleKeyInfo();
        }

        public string ReadKeyBasic(int x, int y, string input)
        { // 입력
            Console.SetCursorPosition(x, y);
            input = "";
            keyInfo = new ConsoleKeyInfo();

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return "\\n";
                }
                else if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    input += keyInfo.KeyChar.ToString();
                    Console.Write(keyInfo.KeyChar.ToString());
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = EraseWord(input);
                }
            }

            return input;
        }

        public string ReadKeySecret(int x, int y, string input)
        { // 입력 값 * 처리
            Console.SetCursorPosition(x, y);
            input = "";
            keyInfo = new ConsoleKeyInfo();

            // 비밀번호 *처리
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return "\\n";
                }
                else if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    input += keyInfo.KeyChar.ToString();
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, (input.Length - 1));
                    Console.Write("\b \b");
                }
            }

            return input;
        }

        private string EraseWord(string input)
        {
            if (Regex.IsMatch(input.Substring(input.Length - 1), Constant.PATTERN_KEY_KOR))
            {
                input = input.Substring(0, (input.Length - 1));
                Console.Write("\b \b");
                Console.Write("\b \b");
                return input;
            }

            input = input.Substring(0, (input.Length - 1));
            Console.Write("\b \b");
            return input;
            
        }
    }
}
