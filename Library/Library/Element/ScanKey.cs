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

        private void ExitProgram()
        {
            keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine(" 종료합니다. . .");
            }
    
        }
    }
}
