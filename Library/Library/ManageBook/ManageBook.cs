using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ManageBook
    {
        ScanBasicElement scanBookInformation;
        RegisterBook registerBook;
        EditBook editBook;
        DeleteBook deleteBook;
        SearchBook searchBook;
        PrintBookList printBookList;

        private string[] menuNumberArray;
        private int menuNumber;

        public ManageBook()
        {
            scanBookInformation = new ScanBasicElement();
            registerBook = new RegisterBook();
            editBook = new EditBook();
            deleteBook = new DeleteBook();
            searchBook = new SearchBook();
            printBookList = new PrintBookList();

            menuNumberArray = new string[] { "1", "2", "3", "4", "5" };
        }

        public void ShowManageBook()
        {
            Console.Clear();
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
                case 4:
                    {
                        searchBook.ShowBookSearching();
                        break;
                    }
                case 5:
                    {
                        printBookList.PrintBookMain();
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
            Console.WriteLine("                      4. SEARCH BOOK                      ");
            Console.WriteLine("                      5. BOOK LIST                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }

}
