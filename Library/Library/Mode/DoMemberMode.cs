using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class DoMemberMode
    {
        ScanBasicElement scanMiniMenuElement;
        SearchBook searchBook;
        PrintBookList printBooks;
        CheckOutBook checkOutBook;
        ReturnBook returnBook;
        ShowMyPage showPage;

        private int menuNumber;
        private string[] menuNumberArray;

        public DoMemberMode()
        {
            scanMiniMenuElement = new ScanBasicElement();
            searchBook = new SearchBook();
            printBooks = new PrintBookList();
            checkOutBook = new CheckOutBook();
            returnBook = new ReturnBook();
            showPage = new ShowMyPage();

            menuNumberArray = new string[] { "1", "2", "3", "4", "5" };
        }

        public void ShowMemberMode(int listIndex)
        {
            Console.Clear();
            PrintMemberMode();
            menuNumber = scanMiniMenuElement.SelectMenu(menuNumberArray);

            switch (menuNumber)
            {
                case 1:
                    {
                        searchBook.ShowBookSearching();
                        break;
                    }
                case 2:
                    {
                        printBooks.PrintBookMain();
                        break;
                    }
                case 3:
                    {
                        checkOutBook.ShowCheckOutBook(listIndex);
                        break;
                    }
                case 4:
                    {
                        returnBook.ShowReturnBook(listIndex);
                        break;
                    }
                case 5:
                    {
                        showPage.PrintMyPage(listIndex);
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
            Console.WriteLine("                     2. BOOK LIST                          ");
            Console.WriteLine("                     3. CHECK OUT BOOK                     ");
            Console.WriteLine("                     4. RETURN BOOK                        ");
            Console.WriteLine("                     5. MY PAGE                            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }
}
