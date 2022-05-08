using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MemberMode
    {
        BasicPage basicPage;
        MenuSelection menuSelection;
        BookPage bookViewElement;
        MemberPage memberViewElement;
        MemberDAO databaseMember;
        BookDAO databaseBook;
        Exception exception;
        LogDAO databaseLog;
        LogDTO logDTO;
        KeyReader keyReader;

        public MemberMode(BasicPage basicPage, MenuSelection menuSelection, MemberDAO databaseMember, BookDAO databaseBook, Exception exception, LogDAO databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            this.basicPage = basicPage;
            this.menuSelection = menuSelection;
            this.databaseMember = databaseMember;
            this.databaseBook = databaseBook;
            this.exception = exception;
            this.databaseLog = databaseLog;
            this.logDTO = logDTO;
            this.keyReader = keyReader;

            bookViewElement = new BookPage();
            memberViewElement = new MemberPage();
        }

        public string SearchBook(string id)
        {
            string bookValue = "";
            bookViewElement.PrintSearchBookInform();
            databaseBook.SelectBookList();

            AlertEmptyData(3, 4, Constant.SELECT_QUERY_BOOK);

            while (Constant.IS_CTRL_Z)
            {
                bookValue = keyReader.ReadKeyBasic(29, 6, bookValue);
                if (bookValue == "\\n") return "\\n";

                if (string.IsNullOrEmpty(bookValue?.Trim()))
                { // ctrl + z 체크
                    bookViewElement.PrintSearchWarningMessage(3, 4);
                    Console.SetCursorPosition(29, 6);
                    basicPage.ClearLine(0, 29);
                    continue;
                }
                break;
            }
            basicPage.ClearButtomLine(11, 8);
            bookViewElement.PrintListLine();
            databaseBook.SelectBookOfList(bookValue);

            logDTO.User = id;
            logDTO.History = "''" + bookValue + "'' 도서 검색";
            databaseLog.InsertLog(logDTO);

            return "";
        }

        public void PrintList()
        {
            bookViewElement.PrintBookListInform();
            AlertEmptyData(3, 4, Constant.SELECT_QUERY_BOOK);
            databaseBook.SelectBookList();
            Console.SetCursorPosition(0, 0);
        }

        public string CheckOutBook(string id)
        {
            string bookId = "";
            bool isBook = false;
            DateTime dueDate = DateTime.Today.AddDays(7);
            bookViewElement.PrintCheckOutBookInform();
            databaseBook.SelectBookList();

            AlertEmptyData(3, 4, Constant.SELECT_QUERY_BOOK);

            while (!isBook)
            {
                bookId = keyReader.ReadKeyBasic(33, 6, bookId);
                if (bookId == "\\n") return "\\n";

                Console.SetCursorPosition(0, 4);
                basicPage.ClearLine(0, 0);

                isBook = MemberBookDAO.memberBookDAO.IsBookId(bookId);
                if (!isBook)
                { // 같은 거 모듈화
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    basicPage.ClearLine(0, 33);
                    continue;
                }
                isBook = exception.IsBookId(bookId);
                if (!isBook)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    basicPage.ClearLine(0, 33);
                    continue;
                }
                isBook = MemberBookDAO.memberBookDAO.IsBookCount(bookId);
                if (!isBook)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintCountFailMessage();
                    Console.SetCursorPosition(33, 6);
                    basicPage.ClearLine(0, 33);
                    continue;
                }

                isBook = MemberBookDAO.memberBookDAO.IsCheckedOutBook(bookId, id);
                if (!isBook)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintCheckedOutFailMessage();
                    Console.SetCursorPosition(33, 6);
                    basicPage.ClearLine(0, 33);
                }
            }

            basicPage.ClearLineEasy(4, 0);
            MemberBookDAO.memberBookDAO.InsertMemberBook(bookId, id);

            Console.SetCursorPosition(0, 4);
            bookViewElement.PrintCheckOutSuccessMessage(dueDate.ToString("yyyy-MM-dd"));

            logDTO.User = id;
            logDTO.History = "ID " + bookId + " 도서 대출";
            databaseLog.InsertLog(logDTO);

            return "";
        }

        public string ReturnBook(string id)
        {
            string bookId = "";
            bool isBook = false;
            
            bookViewElement.PrintReturnBookInform(id); 
            MemberBookDAO.memberBookDAO.SelectMemberBook(id);
            AlertEmptyData(3, 4, string.Format(Constant.SELECT_QUERY_MEMBERBOOK_WHERE_MEMBERID, id));
            while (!isBook)
            {
                bookId = keyReader.ReadKeyBasic(33, 6, bookId);
                if (bookId == "\\n") return "\\n";
                Console.SetCursorPosition(0, 4);
                basicPage.ClearLine(0, 0);

                isBook = MemberBookDAO.memberBookDAO.IsBookId(bookId);
                if (!isBook)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    basicPage.ClearLine(0, 33);
                }

                isBook = exception.IsBookId(bookId);
                if (!isBook)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    basicPage.ClearLine(0, 33);
                    continue;
                }
            }

            basicPage.ClearLineEasy(4, 0);

            while (isBook)
            {
                isBook = MemberBookDAO.memberBookDAO.IsCheckedOutBook(bookId, id);
                if (isBook)
                {
                    Console.SetCursorPosition(0, 4);
                    bookViewElement.PrintBookIdFailMessage();
                    Console.SetCursorPosition(33, 6);
                    basicPage.ClearLine(0, 33);

                    Console.SetCursorPosition(33, 6);
                    bookId = Console.ReadLine();
                    Console.SetCursorPosition(0, 4);
                    basicPage.ClearLine(0, 0);
                }
            }

            basicPage.ClearLineEasy(4, 0);

            MemberBookDAO.memberBookDAO.DeleteMemberBook(bookId, id);

            Console.SetCursorPosition(0, 4);
            bookViewElement.PrintReturnSuccessMessage();

            logDTO.User = id;
            logDTO.History = "ID " + bookId + " 도서 반납";
            databaseLog.InsertLog(logDTO);

            return "";
        }

        public string EditMyInformation(string id)
        {
            memberViewElement.PrintEditMember();
            memberViewElement.PrintEditMineForm();

            string address = "", number = "";
            bool isMemberValue = false;

            while (!isMemberValue)
            {
                address = keyReader.ReadKeyBasic(30, 13, address);
                if (address == "\\n") return "\\n";

              

                if (address.Length == 0)
                {
                    break;
                }

                isMemberValue = exception.IsAddress(address);
                if (isMemberValue == false)
                {
                    basicPage.PrintWarningSentence(2, 11, "조건에 맞춰서 다시 입력하세요.");
                    Console.SetCursorPosition(30, 13);
                    basicPage.ClearLine(0, 30);
                }
            }

            isMemberValue = false;
            basicPage.ClearLineEasy(11, 2);

            while (!isMemberValue)
            {
                number = keyReader.ReadKeyBasic(30, 15, number);
                if (number == "\\n") return "\\n";

              

                if (number.Length == 0)
                {
                    break;
                }

                isMemberValue = exception.IsPhoneNumber(number);
                if (!isMemberValue)
                {
                    basicPage.PrintWarningSentence(2, 11, "조건에 맞춰서 다시 입력하세요.");
                    Console.SetCursorPosition(30, 15);
                    basicPage.ClearLine(0, 30);
                }
            }

            basicPage.ClearLineEasy(11, 2);

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

            basicPage.PrintAfterWork();
            return "";
        }

        private void AddEditLogToDatabase(string id, string address, string number)
        {
            logDTO.User = id;

            if (address.Length > 0 && number.Length == 0)
            {
                logDTO.History = "주소를 ''" + address + "''(으)로 수정";
            }

            else if (address.Length == 0 && number.Length > 0)
            {
                logDTO.History = "전화번호를 ''" + number + "''(으)로 수정";
            }

            else if (address.Length > 0 && number.Length > 0)
            {
                logDTO.History = "주소를 ''" + address + "''(으)로 수정, " +
                    "전화번호를 ''" + number + "''(으)로 수정";
            }

            databaseLog.InsertLog(logDTO);
        }

        private void AlertEmptyData(int x, int y, string query)
        {
            if (MemberBookDAO.memberBookDAO.CheckDataQuantity(query) == 0)
            {
                basicPage.PrintWarningSentence(x, y, "데이터가 존재하지 않습니다.");
            }
        }
    }
}
