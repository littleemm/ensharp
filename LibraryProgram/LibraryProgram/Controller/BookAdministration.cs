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
        DatabaseMemberBook databaseMemberBook;
        BookVO bookVO;
        Exception exception;

        public BookAdministration(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseBook databaseBook, DatabaseMemberBook databaseMemberBook, Exception exception)
        {
            bookViewElement = new BookViewElement();
            bookVO = new BookVO("", "", "", "", "", "");
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseBook = databaseBook;
            this.exception = exception;
            this.databaseMemberBook = databaseMemberBook;
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

                if (isBookValue == true)
                {
                    viewElement.PrintSameDataSentence(25, 10);
                    Console.SetCursorPosition(37, 13);
                    viewElement.ClearLine(0, 13);
                    isBookValue = false;
                    continue;
                }

                isBookValue = exception.IsBookId(bookVO.Id);
                if (isBookValue  == false)
                {
                    PrintFalse(37, 13);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(10, 25);

            while (isBookValue == false)
            {
                Console.SetCursorPosition(37, 15);
                bookVO.Name = Console.ReadLine();
                
                isBookValue = exception.IsBookName(bookVO.Name);
                if (isBookValue == false)
                {
                    PrintFalse(37, 15);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(10, 25);

            while (isBookValue == false)
            {
                Console.SetCursorPosition(37, 17);
                bookVO.Author = Console.ReadLine();
                
                isBookValue = exception.IsBookAuthor(bookVO.Author);
                if (isBookValue == false)
                {
                    PrintFalse(37, 17);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(10, 25);

            while (isBookValue == false)
            {
                Console.SetCursorPosition(37, 19);
                bookVO.Publisher = Console.ReadLine();
                
                isBookValue = exception.IsBookPublisher(bookVO.Publisher);
                if (isBookValue == false)
                {
                    PrintFalse(37, 19);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(10, 25);

            while (isBookValue == false)
            {
                Console.SetCursorPosition(37, 21);
                bookVO.Price = Console.ReadLine();

                isBookValue = exception.IsPrice(bookVO.Price);
                if (isBookValue == false)
                {
                    PrintFalse(37, 21);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(10, 25);

            while (isBookValue == false)
            {
                Console.SetCursorPosition(37, 23);
                bookVO.Quantity = Console.ReadLine();

                isBookValue = exception.IsQuantity(bookVO.Quantity);
                if (isBookValue == false)
                {
                    PrintFalse(37, 23);
                }
            }

            viewElement.ClearLineEasy(11, 8);

            databaseBook.InsertBook(bookVO);
            bookViewElement.PrintRegistrationSuccessMessage();
        }

        private void EditBook()
        {
            bookViewElement.PrintEditBook();
            bookViewElement.PrintEditBookForm();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookList();

            string bookId = "", bookPrice = "", bookQuantity = "";
            bool isBookValue = false;

            while (isBookValue == false)
            {
                Console.SetCursorPosition(30, 13);
                bookId = Console.ReadLine();
                isBookValue = databaseBook.IsBookId(bookId);

                if (isBookValue == false)
                {
                    PrintFalse(30, 13);
                    continue;
                }

                isBookValue = exception.IsBookId(bookId);
                if (isBookValue == false)
                {
                    PrintFalse(30, 13);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(10, 25);

            while (isBookValue == false)
            {
                Console.SetCursorPosition(30, 15);
                bookPrice = Console.ReadLine();

                if(bookPrice.Length == 0)
                {
                    break;
                }

                isBookValue = exception.IsPrice(bookPrice);
                if (isBookValue == false)
                {
                    PrintFalse(30, 15);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(10, 25);

            while (isBookValue == false)
            {
                Console.SetCursorPosition(30, 17);
                bookQuantity = Console.ReadLine();

                if (bookQuantity.Length == 0)
                {
                    break;
                }

                isBookValue = exception.IsQuantity(bookQuantity);
                if (isBookValue == false)
                {
                    PrintFalse(30, 17);
                }
            }
            viewElement.ClearLineEasy(10, 25);

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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookList();

            string bookId = "";
            bool isBookValue = false;

            while (isBookValue == false)
            {
                Console.SetCursorPosition(30, 13);
                bookId = Console.ReadLine();
                isBookValue = databaseBook.IsBookId(bookId);

                if (isBookValue == false)
                {
                    PrintFalse(30, 13);
                    continue;
                }

                isBookValue = exception.IsBookId(bookId);
                if (isBookValue == false)
                {
                    PrintFalse(30, 13);
                    continue;
                }
                
                isBookValue = databaseMemberBook.IsMemberCheckedOut(bookId, "bookId");
                if (isBookValue == false)
                {
                    bookViewElement.PrintDeleteWarningMessage(3, 11);
                    Console.SetCursorPosition(30, 13);
                    viewElement.ClearLine(0, 30);
                }
            }

            viewElement.ClearLineEasy(11, 3);
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

        private void PrintFalse(int x, int y)
        {
            Console.SetCursorPosition(25, 10);
            bookViewElement.PrintWarningMessage();
            Console.SetCursorPosition(x, y);
            viewElement.ClearLine(0, x);
        }
    }
}
