using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ManageMember
    {
        ScanBasicElement scanMemberInformation;
        RegisterMember registerMember;
        EditMember editMember;
        DeleteMember deleteMember;
        SearchMember searchMember;
        PrintMemberList printMemberList;

        private string[] menuNumberArray;
        private int menuNumber;

        public ManageMember()
        {
            scanMemberInformation = new ScanBasicElement();
            registerMember = new RegisterMember();
            editMember = new EditMember();
            deleteMember = new DeleteMember();
            searchMember = new SearchMember();
            printMemberList = new PrintMemberList();

            menuNumberArray = new string[]{ "1", "2", "3", "4", "5" };
        }
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
                        searchMember.ShowMemberSearching();
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
