using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ManageMember
    {
        private int menuNumber;

        public void ShowManageMember()
        {
            PrintManageMemberMenu();
            menuNumber = scanBookInformation.SelectMenu(menuNumberArray);
            switch (menuNumber)
            {
                case 1:
                    {
                        registerMember.RegisterNewBook();
                        break;
                    }
                case 2:
                    {
                        editMember.EditLibraryBook();
                        break;
                    }
                case 3:
                    {
                        deleteMember.DeleteLibraryBook();
                        break;
                    }
            }
        }
        public void PrintManageMemberMenu()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        MANAGE BOOK                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      1. REGISTER BOOK                    ");
            Console.WriteLine("                      2. EDIT BOOK                        ");
            Console.WriteLine("                      3. DELETE BOOK                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
