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
        PrintMemberList printMemberList = new PrintMemberList();

        private string[] menuNumberArray = { "1", "2", "3", "4", "5" };
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
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        printMemberList.PrintMemberMain();
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
            Console.WriteLine("                        MANAGE MEMBER                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     1. REGISTER MEMBER                    ");
            Console.WriteLine("                     2. EDIT MEMBER                        ");
            Console.WriteLine("                     3. DELETE MEMBER                      ");
            Console.WriteLine("                     4. SEARCH MEMBER                      ");
            Console.WriteLine("                     5. MEMBER LIST                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
