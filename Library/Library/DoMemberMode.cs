using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class DoMemberMode
    {
        ScanBasicElement scanMiniMenuElement;

        private int menuNumber;
        private string[] menuNumberArray = { "1", "2" };

        public DoMemberMode()
        {
            scanMiniMenuElement = new ScanBasicElement();
        }

        public void ShowAdministratorMode()
        {
            Console.Clear();
            PrintMemberMode();
            menuNumber = scanMiniMenuElement.SelectMenu(menuNumberArray);

            switch (menuNumber)
            {
                case 1:
                    {
                      
                        break;
                    }
                case 2:
                    {
                        break;
                    }
            }
        }
        public void PrintMemberMode()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                    ");
            Console.WriteLine("                        L I B R A R Y                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     1. SEARCH BOOK                        ");
            Console.WriteLine("                     2. CHECK OUT BOOK                     ");
            Console.WriteLine("                     3. RETURN BOOK                        ");
            Console.WriteLine("                     4. MY PAGE                            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
