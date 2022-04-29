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
        MemberViewElement memberViewElement;
        DatabaseMember databaseMember;
        DatabaseBook databaseBook;
        Exception exception;

        public MemberMode(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, DatabaseBook databaseBook, Exception exception)
        {
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseMember = databaseMember;
            this.databaseBook = databaseBook;
            this.exception = exception;

            bookViewElement = new BookViewElement();
            memberViewElement = new MemberViewElement();
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
                        EditMyInformation(id);
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

            while (Constant.IS_CTRL_Z)
            {
                Console.SetCursorPosition(29, 6);
                bookValue = Console.ReadLine();
                if (string.IsNullOrEmpty(bookValue?.Trim()))
                { // ctrl + z 체크
                    bookViewElement.PrintSearchWarningMessage(3, 4);
                    Console.SetCursorPosition(29, 6);
                    viewElement.ClearLine(0, 29);
                    continue;
                }
                break;
            }
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
                viewElement.ClearLine(3, 25);

                isBook = DatabaseMemberBook.databaseMemberBook.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }
                isBook = exception.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }
                isBook = DatabaseMemberBook.databaseMemberBook.IsBookCount(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintCountFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }

                isBook = DatabaseMemberBook.databaseMemberBook.IsCheckedOutBook(bookId, id);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintCheckedOutFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                }
            }

            viewElement.ClearLineEasy(3, 29);
            DatabaseMemberBook.databaseMemberBook.InsertMemberBook(bookId, id);

            Console.SetCursorPosition(33, 3);
            bookViewElement.PrintCheckOutSuccessMessage(dueDate.ToString("yyyy-MM-dd"));

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
            DatabaseMemberBook.databaseMemberBook.SelectMemberBook(id);

            while (isBook == false)
            {
                Console.SetCursorPosition(33, 6);
                bookId = Console.ReadLine();
                viewElement.ClearLine(3, 25);

                isBook = DatabaseMemberBook.databaseMemberBook.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                }

                isBook = exception.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }
            }

            viewElement.ClearLineEasy(3, 29);

            while (isBook == true)
            {
                isBook = DatabaseMemberBook.databaseMemberBook.IsCheckedOutBook(bookId, id);
                if (isBook == true)
                {
                    Console.SetCursorPosition(29, 3);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);

                    Console.SetCursorPosition(33, 6);
                    bookId = Console.ReadLine();
                    viewElement.ClearLine(3, 25);
                }
            }

            viewElement.ClearLineEasy(3, 29);

            DatabaseMemberBook.databaseMemberBook.DeleteMemberBook(bookId, id);

            Console.SetCursorPosition(33, 3);
            bookViewElement.PrintReturnSuccessMessage();
        }

        private void EditMyInformation(string id)
        {
            memberViewElement.PrintEditMember();
            memberViewElement.PrintEditMineForm();

            string address = "", number = "";
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(30, 13);
                address = Console.ReadLine();

                isMemberValue = exception.IsCtrlZ(address);
                if (isMemberValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 13);
                    viewElement.ClearLine(0, 30);
                    continue;
                }

                if (address.Length == 0)
                {
                    break;
                }

                isMemberValue = exception.IsAddress(address);
                if (isMemberValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 13);
                    viewElement.ClearLine(0, 30);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(11, 2);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(30, 15);
                number = Console.ReadLine();

                isMemberValue = exception.IsCtrlZ(number);
                if (isMemberValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 15);
                    viewElement.ClearLine(0, 30);
                    continue;
                }

                if (number.Length == 0)
                {
                    break;
                }

                isMemberValue = exception.IsPhoneNumber(number);
                if (isMemberValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 15);
                    viewElement.ClearLine(0, 30);
                }
            }

            viewElement.ClearLineEasy(11, 2);

            if (address.Length > 0 || number.Length > 0)
            {
                databaseMember.UpdateMember(address, number, id);
                Console.SetCursorPosition(1, 11);
                memberViewElement.PrintEditSuccessMessage();
            }

            else
            {
                memberViewElement.PrintEditFailMessage();
            }
        }
       
    }
}
