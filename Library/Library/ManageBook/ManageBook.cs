using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ManageBook
    {
        ScanBasicElement scanBookInformation = new ScanBasicElement();
        RegisterBook registerBook = new RegisterBook();
        EditBook editBook = new EditBook();
        DeleteBook deleteBook = new DeleteBook();

        private string[] menuNumberArray = { "1", "2", "3" };
        private int menuNumber;

        public ManageBook()
        {

        }

        public void ShowManageBook()
        {
            PrintManageBookMenu();
            menuNumber = scanBookInformation.SelectMenu(menuNumberArray);
            switch (menuNumber)
            {
                case 1:
                    {
                        registerBook.RegisterNewBook();
                        break;
                    }
                case 2:
                    {
                        editBook.EditLibraryBook();
                        break;
                    }
                case 3:
                    {
                        deleteBook.DeleteLibraryBook();
                        break;
                    }
            }
        }

        public void PrintManageBookMenu()
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
