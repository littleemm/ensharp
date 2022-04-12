using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class RegisterMember
    {
        ScanJoinElement scanJoinElement;
        public RegisterMember()
        {
            scanJoinElement = new ScanJoinElement();
        }

        public void RegisterNewMember()
        {
            Console.Clear();
            PrintRegisterMember();
            scanJoinElement.ScanJoinInformation();
        }

        private void PrintRegisterMember()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      REGISTER MEMBER                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
