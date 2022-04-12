using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowMemberPage
    {
        ScanBasicElement scanMiniElement;
        ShowSignUp showSignUp;
        ShowLogin showMemberLogin;
        ScanKey scanKey;

        private int menuNumber;
        private string[] menuNumberArray;
        public ShowMemberPage()
        {
            scanMiniElement = new ScanBasicElement();
            showMemberLogin = new ShowLogin();
            showSignUp = new ShowSignUp();
            scanKey = new ScanKey();

            menuNumberArray = new string[] { "1", "2" };
        }

        public void ShowMemberMain()
        {
            Console.Clear();
            PrintMemberPage();
            menuNumber = scanMiniElement.SelectMenu(menuNumberArray);

            switch (menuNumber)
            {
                case 1:
                    {
                        showMemberLogin.ShowLoginPage();
                        break;
                    }
                case 2:
                    {
                        showSignUp.ShowJoinPage();
                        break;
                    }
            }

            scanKey.ExitProgram();
        }

        private void PrintMemberPage()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                    ");
            Console.WriteLine("                         MEMBER PAGE                       ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                         1. LOGIN                          ");
            Console.WriteLine("                         2. SIGN UP                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
