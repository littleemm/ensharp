﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class DoAdministratorMode
    {
        ScanBasicElement scanMiniElement;
        ManageBook manageBook;
        ManageMember manageMember;

        private int menuNumber;
        private string[] menuNumberArray = { "1", "2" };

        public DoAdministratorMode()
        {
            scanMiniElement = new ScanBasicElement();
            manageBook = new ManageBook();
            manageMember = new ManageMember();
        }
        
        public void ShowAdministratorMode()
        {
            Console.Clear();
            PrintAdministratorMode();
            menuNumber = scanMiniElement.SelectMenu(menuNumberArray);

            switch (menuNumber)
            {
                case 1:
                    {
                        manageBook.ShowManageBook();
                        break;
                    }
                case 2:
                    {
                        manageMember.ShowManageMember();
                        break;
                    }
            }
        }
        public void PrintAdministratorMode()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                    ");
            Console.WriteLine("                      ADMINISTRATOR MODE                   ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      1. MANAGE BOOK                        ");
            Console.WriteLine("                      2. MANAGE MEMBER                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
