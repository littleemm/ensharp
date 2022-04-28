using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MemberMode
    {
        BasicViewElement viewElement;
        MenuSelection menuSelection;
        BookViewElement bookViewElement;
        DatabaseBook databaseBook;

        public MemberMode(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseBook databaseBook)
        {
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseBook = databaseBook;

            bookViewElement = new BookViewElement();
        }

        public void ShowMemberPage()
        {
            Console.Clear();
            viewElement.PrintMemberMode();
            SelectMenu();
        }

        private void SelectMenu()
        {
            string number = menuSelection.CheckMenuNumber(46, 24, Constant.ARRAY_FIVE);
            Console.Clear();
            switch (int.Parse(number))
            {
                case Constant.SEARCH_BOOK:
                    {
                        SearchBook();
                        break;
                    }
                case Constant.BOOKLIST:
                    {
                        PrintList();
                        break;
                    }
                case Constant.CHECKOUT:
                    {
                        CheckOutBook();
                        break;
                    }
                case Constant.RETURN:
                    {

                        break;
                    }
                case Constant.MYPAGE:
                    {
                        break;
                    }
            }

            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                ShowMemberPage();
            }
        }

        private void SearchBook()
        {
            string bookValue;
            bookViewElement.InformBookList();
            bookViewElement.SearchBook();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookList();

            Console.SetCursorPosition(29, 6);
            bookValue = Console.ReadLine();
            viewElement.ClearButtomLine(11, 8);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookOfList(bookValue);
        }

        private void PrintList()
        {
            bookViewElement.InformBookList();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookList();
            Console.SetCursorPosition(0, 0);
        }

        private void CheckOutBook()
        {
            string bookId;

            bookViewElement.InformBookList();
            bookViewElement.PrintCheckOutBookIdForm();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookList();

            Console.SetCursorPosition(33, 6);
            bookId = Console.ReadLine();
        }

        private void ReturnBook()
        {
            string bookId;

            
        }

    }
}
