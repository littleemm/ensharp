using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class BookAdministration
    {
        BookViewElement bookViewElement;
        BasicViewElement viewElement;
        MenuSelection menuSelection;
        DatabaseBook databaseBook;
        BookVO bookVO;
        Exception exception;

        public BookAdministration(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseBook databaseBook, Exception exception)
        {
            bookViewElement = new BookViewElement();
            bookVO = new BookVO("", "", "", "", "", "");
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseBook = databaseBook;
            this.exception = exception;
        }

        public void SelectBookAdministration()
        {
            Console.Clear();
            bookViewElement.PrintManageBookMenu();
            string number = menuSelection.CheckMenuNumber(46, 23, Constant.ARRAY_FIVE);
            Console.Clear();
            switch(int.Parse(number))
            {
                case Constant.REGISTRATION: 
                    {
                        RegisterBook();
                        break;
                    }
                case Constant.EDIT:
                    {
                        EditBook();
                        break;
                    }
                case Constant.DELETE:
                    {
                        DeleteBook();
                        break;
                    }
                case Constant.SEARCH:
                    {
                        SearchBook();
                        break;
                    }
                case Constant.LIST:
                    {
                        PrintList();
                        break;
                    }
            }

            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                SelectBookAdministration();
            }
        }

        private void RegisterBook()
        {
            bookViewElement.PrintRegistration();
            bool isBookValue = false;

            while (isBookValue == false)
            {
                Console.SetCursorPosition(37, 13);
                bookVO.Id = Console.ReadLine();
                isBookValue = databaseBook.IsBookId(bookVO.Id);

                if (isBookValue == false)
                {
                    Console.SetCursorPosition(25, 10);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(37, 13);
                    viewElement.ClearLine(0, 37);
                }
            }
            

            Console.SetCursorPosition(37, 15);
            bookVO.Name = Console.ReadLine();

            Console.SetCursorPosition(37, 17);
            bookVO.Author = Console.ReadLine();

            Console.SetCursorPosition(37, 19); 
            bookVO.Publisher = Console.ReadLine();

            Console.SetCursorPosition(37, 21);
            bookVO.Price = Console.ReadLine();

            Console.SetCursorPosition(37, 23);
            bookVO.Quantity = Console.ReadLine();

            databaseBook.InsertBook(bookVO);
            bookViewElement.PrintRegistrationSuccessMessage();
        }

        private void EditBook()
        {
            bookViewElement.PrintEditBook();
            bookViewElement.PrintEditBookForm();

            string bookId, bookPrice, bookQuantity;

            Console.SetCursorPosition(30, 13);
            bookId = Console.ReadLine();

            Console.SetCursorPosition(30, 15);
            bookPrice = Console.ReadLine();

            Console.SetCursorPosition(30, 17);
            bookQuantity = Console.ReadLine();

            if (bookPrice.Length > 0 || bookQuantity.Length > 0)
            {
                databaseBook.UpdateBook(bookPrice, bookQuantity, bookId);
                bookViewElement.PrintEditSuccessMessage();
            }

            else
            {
                bookViewElement.PrintEditFailMessage();
            }
        }

        private void DeleteBook()
        {
            bookViewElement.PrintDeleteBook();
            bookViewElement.PrintBookIdForm();

            string bookId;
            Console.SetCursorPosition(30, 13);
            bookId = Console.ReadLine();

            databaseBook.DeleteBook(bookId);
            bookViewElement.PrintDeleteSuccessMessage();
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
    }
}
