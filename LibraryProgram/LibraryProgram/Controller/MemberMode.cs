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
        DatabaseMemberBook databaseMemberBook;

        public MemberMode(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseBook databaseBook)
        {
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseBook = databaseBook;

            bookViewElement = new BookViewElement();
            databaseMemberBook = new DatabaseMemberBook();
        }

        public void ShowMemberPage(string id)
        {
            Console.Clear();
            viewElement.PrintMemberMode();
            SelectMenu(id);
        }

        private void SelectMenu(string id)
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
                        CheckOutBook(id);
                        break;
                    }
                case Constant.RETURN:
                    {
                        ReturnBook(id);
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
                ShowMemberPage(id);
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

        private void CheckOutBook(string id)
        {
            string bookId = "";
            bool isBook = false;
            DateTime dueDate = DateTime.Today.AddDays(7);

            bookViewElement.InformBookList();
            bookViewElement.PrintCheckOutBookIdForm();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookList();

            while (isBook == false)
            {
                Console.SetCursorPosition(33, 6);
                bookId = Console.ReadLine();
                viewElement.ClearLine(3, 29);

                isBook = databaseMemberBook.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }
                isBook = databaseMemberBook.IsBookCount(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintCountFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }

                isBook = databaseMemberBook.IsCheckedOutBook(bookId, id);
                if (isBook == true)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintCheckedOutFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                }
            }

            databaseMemberBook.InsertMemberBook(bookId, id);

            Console.SetCursorPosition(33, 4);
            bookViewElement.PrintCheckOutSuccessMessage(dueDate.ToString());

        }

        private void ReturnBook(string id)
        {
            string bookId = "";
            bool isBook = false;

            bookViewElement.InformMemberBook(id);
            bookViewElement.PrintReturnBookIdForm();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseMemberBook.SelectMemberBook(id);

            while (isBook == false) 
            {
                Console.SetCursorPosition(33, 6);
                bookId = Console.ReadLine();
                viewElement.ClearLine(3, 29);

                isBook = databaseMemberBook.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }

                isBook = databaseMemberBook.IsCheckedOutBook(bookId, id);
                if (isBook == true)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    isBook = false;
                }
            }

            databaseMemberBook.DeleteMemberBook(bookId, id);

            Console.SetCursorPosition(33, 4);
            bookViewElement.PrintReturnSuccessMessage();
        }

    }
}
