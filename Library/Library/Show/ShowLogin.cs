using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowLogin
    {
        ScanLoginElement scanLoginElement = new ScanLoginElement();
        CheckLoginInformation checkLoginInformation = new CheckLoginInformation();
        
        bool isMemberInformation;

        public ShowLogin()
        { // 생성자
            isMemberInformation = false;
        }
        public void ShowLoginPage() // 로그인 페이지 실행
        {
            Console.Clear();
            PrintLoginPage();
            scanLoginElement.ScanInformation();
        }
        public void PrintLoginPage() // 로그인 페이지 메인
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                      ");
            Console.WriteLine("                      L O G I N P A G E                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
