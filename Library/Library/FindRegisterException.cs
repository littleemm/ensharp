using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class FindRegisterException
    {
        public bool CheckId(string id)
        {
            if (id.Length > 8)
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   8자 이내로 다시 입력하세요!");
                Console.ResetColor();


                return false;
            }
            return true;
        }
    }
}
