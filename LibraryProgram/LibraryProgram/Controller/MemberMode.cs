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
        DatabaseLog databaseLog;
        LogVO logVO;

        public MemberMode(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogVO logVO)
        {
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseMember = databaseMember;
            this.databaseBook = databaseBook;
            this.exception = exception;
            this.databaseLog = databaseLog;
            this.logVO = logVO;

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
                        SearchBook(id);
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

        private void SearchBook(string id)
        {
            string bookValue;
            bookViewElement.PrintSearchBookInform();
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
            bookViewElement.PrintListLine();
            databaseBook.SelectBookOfList(bookValue);

            logVO.User = id;
            logVO.History = "''" + bookValue + "'' 도서 검색";
            databaseLog.InsertLog(logVO);
        }

        private void PrintList()
        {
            bookViewElement.PrintBookListInform();
            databaseBook.SelectBookList();
            Console.SetCursorPosition(0, 0);
        }

        private void CheckOutBook(string id)
        {
            string bookId = "";
            bool isBook = false;
            DateTime dueDate = DateTime.Today.AddDays(7);
            bookViewElement.PrintCheckOutBookInform();
            databaseBook.SelectBookList();

            while (isBook == false)
            {
                Console.SetCursorPosition(33, 6);
                bookId = Console.ReadLine();
                Console.SetCursorPosition(0, 4);
                viewElement.ClearLine(0, 0);

                isBook = DatabaseMemberBook.databaseMemberBook.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }
                isBook = exception.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }
                isBook = DatabaseMemberBook.databaseMemberBook.IsBookCount(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintCountFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }

                isBook = DatabaseMemberBook.databaseMemberBook.IsCheckedOutBook(bookId, id);
                if (isBook == false)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintCheckedOutFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                }
            }

            viewElement.ClearLineEasy(4, 0);
            DatabaseMemberBook.databaseMemberBook.InsertMemberBook(bookId, id);

            Console.SetCursorPosition(0, 4);
            bookViewElement.PrintCheckOutSuccessMessage(dueDate.ToString("yyyy-MM-dd"));

            logVO.User = id;
            logVO.History = "ID " + bookId + " 도서 대출";
            databaseLog.InsertLog(logVO);

        }

        private void ReturnBook(string id)
        {
            string bookId = "";
            bool isBook = false;
            
            bookViewElement.PrintReturnBookInform(id); 
            DatabaseMemberBook.databaseMemberBook.SelectMemberBook(id);

            while (isBook == false)
            {
                Console.SetCursorPosition(33, 6);
                bookId = Console.ReadLine();
                Console.SetCursorPosition(0, 4);
                viewElement.ClearLine(0, 0);

                isBook = DatabaseMemberBook.databaseMemberBook.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                }

                isBook = exception.IsBookId(bookId);
                if (isBook == false)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);
                    continue;
                }
            }

            viewElement.ClearLineEasy(4, 0);

            while (isBook == true)
            {
                isBook = DatabaseMemberBook.databaseMemberBook.IsCheckedOutBook(bookId, id);
                if (isBook == true)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    viewElement.ClearLine(0, 33);

                    Console.SetCursorPosition(33, 6);
                    bookId = Console.ReadLine();
                    Console.SetCursorPosition(0, 4);
                    viewElement.ClearLine(0, 0);
                }
            }

            viewElement.ClearLineEasy(4, 0);

            DatabaseMemberBook.databaseMemberBook.DeleteMemberBook(bookId, id);

            Console.SetCursorPosition(0, 4);
            bookViewElement.PrintReturnSuccessMessage();

            logVO.User = id;
            logVO.History = "ID " + bookId + " 도서 반납";
            databaseLog.InsertLog(logVO);
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
                AddEditLogToDatabase(id, address, number);
            }

            else
            {
                memberViewElement.PrintEditFailMessage();
            }
        }

        private void AddEditLogToDatabase(string id, string address, string number)
        {
            logVO.User = id;

            if (address.Length > 0 && number.Length == 0)
            {
                logVO.History = "주소를 ''" + address + "''(으)로 수정";
            }

            else if (address.Length == 0 && number.Length > 0)
            {
                logVO.History = "전화번호를 ''" + number + "''(으)로 수정";
            }

            else if (address.Length > 0 && number.Length > 0)
            {
                logVO.History = "주소를 ''" + address + "''(으)로 수정, " +
                    "전화번호를 ''" + number + "''(으)로 수정";
            }

            databaseLog.InsertLog(logVO);
        }
      
    }
}
