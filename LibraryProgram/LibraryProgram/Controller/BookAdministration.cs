using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class BookAdministration 
    {
        BookPage bookViewElement;
        BasicPage basicPage;
        BookDAO databaseBook;
        BookDTO bookDTO;
        Exception exception;
        NaverBookAPI naverBookAPI;
        LogDAO databaseLog;
        LogDTO logDTO;
        KeyReader keyReader;
 
        
        public BookAdministration(BasicPage basicPage, BookPage bookViewElement, MenuSelection menuSelection, BookDAO databaseBook, Exception exception, LogDAO databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            bookDTO = new BookDTO("", "", "", "", "", "", "", "");
            naverBookAPI = new NaverBookAPI();
            this.basicPage = basicPage;
            this.bookViewElement = bookViewElement;
            this.databaseBook = databaseBook;
            this.exception = exception;
            this.databaseLog = databaseLog;
            this.logDTO = logDTO;
            this.keyReader = keyReader;
        }

        public string RegisterBook() // 책 등록
        {
            Console.SetWindowSize(65, 30);
            bookViewElement.PrintRegistration();
            bool isBookValue = false;

            while (!isBookValue)
            {
                bookDTO.Id = keyReader.ReadKeyBasic(37, 13, bookDTO.Id); // 아이디 입력
                if (bookDTO.Id == "\\n") // esc 체크
                {
                    return "\\n";
                }
                isBookValue = databaseBook.IsBookId(bookDTO.Id);

                if (isBookValue)
                {
                    basicPage.PrintWarningSentence(9, 11, "이미 존재하는 아이디입니다.");
                    Console.SetCursorPosition(37, 13);
                    basicPage.ClearLine(0, 37);
                    isBookValue = false;
                    continue;
                }

                isBookValue = exception.IsBookId(bookDTO.Id);
                if (!isBookValue)
                {
                    PrintFalse(37, 13);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 5);

            while (!isBookValue)
            {
                bookDTO.Name = keyReader.ReadKeyBasic(37, 15, bookDTO.Name); // 제목 입력
                if (bookDTO.Name == "\\n") 
                {
                    return "\\n";
                }

                isBookValue = exception.IsBookName(bookDTO.Name);
                if (!isBookValue)
                {
                    PrintFalse(37, 15);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 25);

            while (!isBookValue)
            {
                bookDTO.Author = keyReader.ReadKeyBasic(37, 17, bookDTO.Author); // 작가 입력
                if (bookDTO.Author == "\\n")
                {
                    return "\\n";
                }

                isBookValue = exception.IsBookAuthor(bookDTO.Author);
                if (isBookValue == false)
                {
                    PrintFalse(37, 17);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 5);

            while (!isBookValue)
            {
                bookDTO.Publisher = keyReader.ReadKeyBasic(37, 19, bookDTO.Publisher); // 출판사 입력
                if (bookDTO.Publisher == "\\n")
                {
                    return "\\n";
                }

                isBookValue = exception.IsBookPublisher(bookDTO.Publisher);
                if (!isBookValue)
                {
                    PrintFalse(37, 19);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 5);

            while (!isBookValue)
            {
                bookDTO.Price = keyReader.ReadKeyBasic(37, 21, bookDTO.Price); // 가격 입력
                if (bookDTO.Price == "\\n")
                {
                    return "\\n";
                }

                isBookValue = exception.IsPrice(bookDTO.Price);
                if (!isBookValue)
                {
                    PrintFalse(37, 21);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 5);

            while (!isBookValue)
            {
                bookDTO.Pubdate = keyReader.ReadKeyBasic(37, 23, bookDTO.Pubdate); // 출판일 입력
                if (bookDTO.Pubdate == "\\n")
                {
                    return "\\n";
                }

                isBookValue = exception.IsDate(bookDTO.Pubdate);
                if (!isBookValue)
                {
                    PrintFalse(37, 23);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 25);

            while (!isBookValue)
            {
                bookDTO.Isbn = keyReader.ReadKeyBasic(37, 25, bookDTO.Isbn); // isbn 입력
                if (bookDTO.Isbn == "\\n")
                {
                    return "\\n";
                }

                isBookValue = exception.IsIsbn(bookDTO.Isbn);
                if (!isBookValue)
                {
                    PrintFalse(37, 25);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 5);

            while (!isBookValue)
            {
                bookDTO.Quantity = keyReader.ReadKeyBasic(37, 27, bookDTO.Quantity); // 수량 입력
                if (bookDTO.Quantity == "\\n")
                {
                    return "\\n";
                }

                isBookValue = exception.IsQuantity(bookDTO.Quantity);
                if (!isBookValue)
                {
                    PrintFalse(37, 27);
                }
            }

            basicPage.ClearLineEasy(11, 5);

            databaseBook.InsertBook(bookDTO); // 데이터베이스 삽입 
            bookViewElement.PrintSuccessMessage("등록");

            logDTO.User = "관리자";
            logDTO.History = "도서 Id " + bookDTO.Id + "인 도서 ''" + bookDTO.Name + "'' 추가";
            databaseLog.InsertLog(logDTO); // 로그 기록

            basicPage.PrintAfterWork();
            return "";
        }

        public string EditBook() // 책 정보 수정
        {
            bookViewElement.PrintEditBook();
            bookViewElement.PrintEditBookForm();
            basicPage.PrintLine();
            databaseBook.SelectBookList();

            AlertEmptyData(3, 11, Constant.SELECT_QUERY_BOOK); // 데이터 없을 경우 

            string bookId = "", bookPrice = "", bookQuantity = "";
            bool isBookValue = false;

            while (!isBookValue)
            { // bookID 입력 및 체크
                bookId = keyReader.ReadKeyBasic(30, 13, bookId);
                if (bookId == "\\n")
                {
                    return "\\n";
                }

                isBookValue = databaseBook.IsBookId(bookId);
                if (!isBookValue)
                {
                    PrintFalse(30, 13);
                    continue;
                }

                isBookValue = exception.IsBookId(bookId);
                if (!isBookValue)
                {
                    PrintFalse(30, 13);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 0);

            while (!isBookValue)
            { // 도서 가격 입력 및 체크
                bookPrice = keyReader.ReadKeyBasic(30, 15, bookPrice);
                if (bookPrice == "\\n")
                {
                    return "\\n";
                }

                if (bookPrice == "")
                { // 엔터만 입력되었을 경우 (수정 안한다는 의미)
                    break;
                }

                isBookValue = exception.IsPrice(bookPrice);
                if (!isBookValue)
                {
                    PrintFalse(30, 15);
                }
            }

            isBookValue = false;
            basicPage.ClearLineEasy(11, 0);

            while (!isBookValue)
            { // 도서 수량 입력 및 체크
                bookQuantity = keyReader.ReadKeyBasic(30, 17, bookQuantity);
                if (bookQuantity == "\\n")
                {
                    return "\\n";
                }

                if (bookQuantity == "")
                { // 엔터만 입력되었을 경우
                    break;
                }

                isBookValue = exception.IsQuantity(bookQuantity);
                if (!isBookValue)
                {
                    PrintFalse(30, 17);
                }
            }

            basicPage.ClearLineEasy(11, 0);

            if (bookPrice.Length > 0 || bookQuantity.Length > 0)
            {
                databaseBook.UpdateBook(bookPrice, bookQuantity, bookId);
                bookViewElement.PrintSuccessMessage("수정");

                AddEditLogToDatabase(bookQuantity, bookPrice);
            }

            else
            { // 두 데이터 모두 엔터가 들어왔으면 수정된 것 x
                bookViewElement.PrintEditFailMessage(5, 11);
            }

            basicPage.PrintAfterWork();

            return "";
        }

        public string DeleteBook() // 도서 삭제
        {
            bookViewElement.PrintDeleteBook();
            bookViewElement.PrintBookIdForm();
            basicPage.PrintLine();
            databaseBook.SelectBookList();

            AlertEmptyData(3, 11, Constant.SELECT_QUERY_BOOK); // 도서 데이터 없을 경우

            string bookId = "";
            bool isBookValue = false;

            while (!isBookValue)
            {
                bookId = keyReader.ReadKeyBasic(30, 13, bookId); // 아이디 입력
                if (bookId == "\\n")
                {
                    return "\\n";
                }

                isBookValue = databaseBook.IsBookId(bookId);

                if (!isBookValue)
                {
                    PrintFalse(30, 13);
                    continue;
                }

                isBookValue = exception.IsBookId(bookId);
                if (!isBookValue)
                {
                    PrintFalse(30, 13);
                    continue;
                }
                
                isBookValue = MemberBookDAO.memberBookDAO.IsMemberCheckedOut(bookId, "bookId");
                if (!isBookValue) // 선택한 도서가 대출된 책인지 확인
                {
                    bookViewElement.PrintDeleteWarningMessage(3, 11);
                    Console.SetCursorPosition(30, 13);
                    basicPage.ClearLine(0, 30);
                }
            }

            basicPage.ClearLineEasy(11, 5);
            databaseBook.DeleteBook(bookId);
            bookViewElement.PrintDeleteSuccessMessage();

            logDTO.User = "관리자";
            logDTO.History = "ID " + bookId + " 도서 삭제";
            databaseLog.InsertLog(logDTO); // 로그 기록

            basicPage.PrintAfterWork();

            return "";
        }

        public string SearchBook() // 도서 검색
        {
            string bookValue = "";
            bookViewElement.InformBookList();
            bookViewElement.SearchBook();
            basicPage.PrintLine(); 
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
            basicPage.PrintLine(); 
            databaseBook.SelectBookOfList(bookValue);
            Console.SetCursorPosition(0, 0);

            logDTO.User = "관리자";
            logDTO.History = "''" + bookValue + "'' 도서 검색";
            databaseLog.InsertLog(logDTO);

            return "";
        }

        public string SearchNaverBook()
        {
            string bookTitle = "", bookQuantity = "";
            bool isBookValue = false;

            bookViewElement.InformNaverBookList();
            bookViewElement.SearchNaverBook();

            while (Constant.IS_CTRL_Z)
            {
                bookTitle = keyReader.ReadKeyBasic(29, 6, bookTitle);
                if (bookTitle == "\\n") return "\\n";

                bookQuantity = keyReader.ReadKeyBasic(29, 7, bookQuantity);
                if (bookQuantity == "\\n") return "\\n";

                if (string.IsNullOrEmpty(bookTitle?.Trim()) || string.IsNullOrEmpty(bookQuantity?.Trim()) || exception.IsBookCount(bookQuantity) == false)
                { // ctrl + z 체크
                    bookViewElement.PrintSearchWarningMessage(3, 4);
                    Console.SetCursorPosition(29, 7);
                    basicPage.ClearLine(0, 29);
                    Console.SetCursorPosition(29, 6);
                    basicPage.ClearLine(0, 29);
                    continue;
                }
                break;
            }
            Console.SetCursorPosition(0, 7);
            basicPage.ClearLine(0, 0);
            Console.SetCursorPosition(0, 6);
            basicPage.ClearLine(0, 0);
            Console.SetCursorPosition(0, 2);
            basicPage.ClearLine(0, 0);
            Console.SetCursorPosition(0, 1);
            basicPage.ClearLine(0, 0);
            Console.SetCursorPosition(0, 0);
            basicPage.ClearLine(0, 0);
            bookViewElement.InformNaverBookListAfter();
            bookViewElement.AddNaverBookForm();

            logDTO.User = "관리자";
            logDTO.History = "NAVER 책 검색에서 ''" + bookTitle + "'' 도서 검색";
            databaseLog.InsertLog(logDTO);

            naverBookAPI.SearchNaverAPI(bookTitle, bookQuantity);
            while (!isBookValue)
            {
                string isbn = "";
                isbn = keyReader.ReadKeyBasic(37, 8, isbn);
                if (isbn == "\\n") return "\\n";

                isBookValue = IsIsbn(isbn, bookTitle, bookQuantity, isBookValue);
                if (!isBookValue)
                {
                    Console.SetCursorPosition(50, 4);
                    bookViewElement.PrintIsbnFailMessage();
                    Console.SetCursorPosition(37, 8);
                    basicPage.ClearLine(0, 37);
                }

            }
            Console.SetCursorPosition(70, 4);
            bookViewElement.PrintLongSuccessMessage();

            return "";
        }

        public void PrintList()
        {
            bookViewElement.InformBookList();
            AlertEmptyData(3, 4, Constant.SELECT_QUERY_MEMBERBOOK);
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookList();
            Console.SetCursorPosition(0, 0);
        }
        
        public void PrintCheckOutList()
        {
            bookViewElement.InformCheckOutList();
            AlertEmptyData(3, 4, Constant.SELECT_QUERY_MEMBERBOOK);
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            MemberBookDAO.memberBookDAO.SelectMemberBookList();
            Console.SetCursorPosition(0, 0);
        }

        private void PrintFalse(int x, int y)
        {
            Console.SetCursorPosition(0, 11);
            bookViewElement.PrintWarningMessage();
            Console.SetCursorPosition(x, y);
            basicPage.ClearLine(0, x);
        }

        private bool IsIsbn(string isbn, string bookTitle, string bookQuantity, bool isBookValue)
        { // isbn 입력시 맞는 isbn이면 데이터베이스 등록까지 완료 후 true 반환, 그렇지 않으면 false 반환
            string bookId = "", bookCount = "";

            if (exception.IsIsbn(isbn) == false)
            {
                return false;
            }
            if (naverBookAPI.IsIsbnData(bookTitle, bookQuantity, isbn) == true)
            {
                Console.SetCursorPosition(50, 5);
                basicPage.ClearLine(0, 0);

                Console.SetCursorPosition(0, 6);
                basicPage.ClearLine(0, 0);
                Console.SetCursorPosition(0, 8);
                basicPage.ClearLine(0, 0);
                Console.SetCursorPosition(0, 7);
                bookViewElement.PrintRegisterNaverBook();

                while (!isBookValue)
                {
                    Console.SetCursorPosition(37, 7);
                    bookId = Console.ReadLine();
                    isBookValue = databaseBook.IsBookId(bookId);

                    if (!isBookValue)
                    {
                        Console.SetCursorPosition(45, 4);
                        bookViewElement.PrintLongWarningMessage();
                        Console.SetCursorPosition(37, 7);
                        basicPage.ClearLine(0, 37);
                        isBookValue = false;
                        continue;
                    }

                    isBookValue = exception.IsBookId(bookId);
                    if (!isBookValue)
                    {
                        Console.SetCursorPosition(45, 4);
                        bookViewElement.PrintLongWarningMessage();
                        Console.SetCursorPosition(37, 7);
                        basicPage.ClearLine(0, 37);
                    }
                }

                isBookValue = false;
                basicPage.ClearLineEasy(5, 0);

                while (!isBookValue)
                {
                    Console.SetCursorPosition(37, 9);
                    bookCount = Console.ReadLine();

                    isBookValue = exception.IsQuantity(bookCount);
                    if (!isBookValue)
                    {
                        Console.SetCursorPosition(45, 4);
                        bookViewElement.PrintLongWarningMessage();
                        Console.SetCursorPosition(37, 9);
                        basicPage.ClearLine(0, 37);
                    }
                }
                basicPage.ClearLineEasy(5, 0);
                ConnectDatabase(bookTitle, bookQuantity, isbn, bookId, bookCount);
                return true;
            }
            return false;
        }

        private void ConnectDatabase(string title, string display, string isbn, string id, string quantity)
        {
            BookDTO bookDTO = naverBookAPI.GetBookDTO(title, display, isbn);
            bookDTO.Id = id;
            bookDTO.Quantity = quantity;
            databaseBook.InsertBook(bookDTO);

            logDTO.User = "관리자";
            logDTO.History = "NAVER 책에서 ''" + bookDTO.Name + "'' 도서 추가";
            databaseLog.InsertLog(logDTO);
        }
        
        private void AddEditLogToDatabase(string quantity, string price)
        {
            logDTO.User = "관리자";

            if (quantity.Length > 0 && price.Length == 0)
            {
                logDTO.History = "도서 수량을 ''" + quantity + "''(으)로 수정";
            }

            else if (quantity.Length == 0 && price.Length > 0)
            {
                logDTO.History = "도서 가격을 ''" + price + "''(으)로 수정";
            }

            else if (quantity.Length > 0 && price.Length > 0)
            {
                logDTO.History = "도서 수량을 ''" + quantity + "''(으)로 수정, " +
                    "도서 가격을 ''" + price + "''(으)로 수정";
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
