using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ScanKey
    {
        private ConsoleKeyInfo keyInfo;

        public ScanKey()
        {

        }

        public void ExitProgram()
        {
            Console.WriteLine("               ESC키를 누르면 종료합니다");
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
            }
    
        }
    }
}
