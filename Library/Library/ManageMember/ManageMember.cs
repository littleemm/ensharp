using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ManageMember
    {
        ScanBasicElement scanMemberInformation = new ScanBasicElement();
        RegisterMember registerMember = new RegisterMember();
        EditMember editMember = new EditMember();
        DeleteMember deleteMember = new DeleteMember();

        private string[] menuNumberArray = { "1", "2", "3" };
        private int menuNumber;

        public void ShowManageMember()
        {
            Console.Clear();
            PrintManageMemberMenu();
            menuNumber = scanMemberInformation.SelectMenu(menuNumberArray);
            switch (menuNumber)
            {
                case 1:
                    {
                        registerMember.RegisterNewMember();
                        break;
                    }
                case 2:
                    {
                        editMember.EditLibraryMember();
                        break;
                    }
                case 3:
                    {
                        deleteMember.DeleteLibraryMember();
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
