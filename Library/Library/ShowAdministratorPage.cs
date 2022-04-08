using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowAdministratorPage
    { // 관리자 로그인 성공 후 페이지 내부

        ScanBasicElement scanAdministratorElement;
        DoAdministratorMode doAdministratorMode;
        private int menuNumber;
        private string[] menuNumberArray = { "1", "2" };

        public ShowAdministratorPage()
        { // 생성자
            scanAdministratorElement = new ScanBasicElement();
            doAdministratorMode = new DoAdministratorMode();
            menuNumber = 0;
        }
        
        public void ShowAdministrator()
        {
            Console.Clear();
            PrintAdministrator();
            menuNumber = scanAdministratorElement.SelectMenu(menuNumberArray);

            switch (menuNumber)
            {
                case 1:
                    {
                        doAdministratorMode.ShowAdministratorMode();
                        break;
                    }
                case 2:
                    {
                        
                        break;
                    }
            }
        }
        
        public void PrintAdministrator()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                    ");
            Console.WriteLine("                      ADMINISTRATOR PAGE                   ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                    1. ADMINISTRATOR MODE                  ");
            Console.WriteLine("                       2. MEMBER MODE                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }


    }
}
