using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowJoin
    {
        ScanJoinElement scanJoinElement = new ScanJoinElement();
        public void ShowJoinPage()
        {
            Console.Clear();
            PrintJoinPage();
            scanJoinElement.ScanJoinInformation();
        }
        public void PrintJoinPage() // 회원가입 페이지 메인
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                      ");
            Console.WriteLine("                         J O I N U S                          ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
