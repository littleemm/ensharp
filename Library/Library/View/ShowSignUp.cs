using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowSignUp
    {
        ScanJoinElement scanJoinElement;
        private ShowMemberPage showMemberPage;
        private ConsoleKeyInfo keyInfo;

        public ShowSignUp()
        {
            scanJoinElement = new ScanJoinElement();
            showMemberPage = new ShowMemberPage();
        }
        public void ShowJoinPage()
        {
            Console.Clear();
            PrintJoinPage();
            scanJoinElement.ScanJoinInformation();
            PrintSuccess();
        }
        private void PrintJoinPage() // 회원가입 페이지 메인
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                      ");
            Console.WriteLine("                         S I G N U P                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
        private void PrintSuccess()
        {
            Console.WriteLine("                 회원 등록이 완료되었습니다!");
            keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("종료합니다. . .");
            }
            else if (keyInfo.Key == ConsoleKey.F1)
            {
                
            }
        }
    }
}
