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
        BookDTO bookDTO;
        Exception exception;
        NaverBookAPI naverBookAPI;
        DatabaseLog databaseLog;
        LogDTO logDTO;
        KeyReader keyReader;
 
        
        public BookAdministration(BasicViewElement viewElement, BookViewElement bookViewElement, MenuSelection menuSelection, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            bookDTO = new BookDTO("", "", "", "", "", "", "", "");
            naverBookAPI = new NaverBookAPI();
            this.viewElement = viewElement;
            this.bookViewElement = bookViewElement;
            this.menuSelection = menuSelection;
            this.databaseBook = databaseBook;
            this.exception = exception;
            this.databaseLog = databaseLog;
            this.logDTO = logDTO;
            this.keyReader = keyReader;
        }

        public string RegisterBook()
        {
            Console.SetWindowSize(65, 30);
            bookViewElement.PrintRegistration();
            bool isBookValue = false;

            while (isBookValue == false)
            {
                bookDTO.Id = keyReader.ReadKeyBasic(37, 13, bookDTO.Id);
                if (bookDTO.Id == "\\n") return "\\n";
                isBookValue = databaseBook.IsBookId(bookDTO.Id);

                if (isBookValue == true)
                {
                    viewElement.PrintSameDataSentence(25, 10);
                    Console.SetCursorPosition(37, 13);
                    viewElement.ClearLine(0, 13);
                    isBookValue = false;
                    continue;
                }

                isBookValue = exception.IsBookId(bookDTO.Id);
                if (isBookValue  == false)
                {
                    PrintFalse(37, 13);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(11, 25);

            while (isBookValue == false)
            {
                bookDTO.Name = keyReader.ReadKeyBasic(37, 15, bookDTO.Name);
                if (bookDTO.Name == "\\n") return "\\n";

                isBookValue = exception.IsBookName(bookDTO.Name);
                if (isBookValue == false)
                {
                    PrintFalse(37, 15);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(11, 25);

            while (isBookValue == false)
            {
                bookDTO.Author = keyReader.ReadKeyBasic(37, 17, bookDTO.Author);
                if (bookDTO.Author == "\\n") return "\\n";

                isBookValue = exception.IsBookAuthor(bookDTO.Author);
                if (isBookValue == false)
                {
                    PrintFalse(37, 17);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(11, 25);

            while (isBookValue == false)
            {
                bookDTO.Publisher = keyReader.ReadKeyBasic(37, 19, bookDTO.Publisher);
                if (bookDTO.Publisher == "\\n") return "\\n";

                isBookValue = exception.IsBookPublisher(bookDTO.Publisher);
                if (isBookValue == false)
                {
                    PrintFalse(37, 19);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(11, 25);

            while (isBookValue == false)
            {
                bookDTO.Price = keyReader.ReadKeyBasic(37, 21, bookDTO.Price);
                if (bookDTO.Price == "\\n") return "\\n";

                isBookValue = exception.IsPrice(bookDTO.Price);
                if (isBookValue == false)
                {
                    PrintFalse(37, 21);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(11, 25);

            while (isBookValue == false)
            {
                bookDTO.Pubdate = keyReader.ReadKeyBasic(37, 23, bookDTO.Pubdate);
                if (bookDTO.Pubdate == "\\n") return "\\n";

                isBookValue = exception.IsDate(bookDTO.Pubdate);
                if (isBookValue == false)
                {
                    PrintFalse(37, 23);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(11, 25);

            while (isBookValue == false)
            {
                bookDTO.Isbn = keyReader.ReadKeyBasic(37, 25, bookDTO.Isbn);
                if (bookDTO.Isbn == "\\n") return "\\n";

                isBookValue = exception.IsIsbn(bookDTO.Isbn);
                if (isBookValue == false)
                {
                    PrintFalse(37, 25);
                }
            }

            isBookValue = false;
            viewElement.ClearLineEasy(11, 25);

            while (isBookValue == false)
            {
                bookDTO.Quantity = keyReader.ReadKeyBasic(37, 27, bookDTO.Quantity);
                if (bookDTO.Quantity == "\\n") return "\\n";

                isBookValue = exception.IsQuantity(bookDTO.Quantity);
                if (isBookValue == false)
                {
                    PrintFalse(37, 27);
                }
            }

            viewElement.ClearLineEasy(10, 8);

            databaseBook.InsertBook(bookDTO);
            bookViewElement.PrintSuccessMessage("등록");

            logDTO.User = "관리자";
            logDTO.History = "도서 Id " + bookDTO.Id + "인 도서 ''" + bookDTO.Name + "'' 추가";
            databaseLog.InsertLog(logDTO);

            return "";
        }

        public string EditBook()
        {
            bookViewElement.PrintEditBook();
            bookViewElement.PrintEditBookForm();
            viewElement.PrintLine();
            databaseBook.SelectBookList();

            string bookId = "", bookPrice = "", bookQuantity = "";
            bool isBookValue = false;

            while (isBookValue == false)
            {
                bookId = keyReader.ReadKeyBasic(30, 13, bookId);
                if (bookId == "\\n") return "\\n";

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
                bookPrice = keyReader.ReadKeyBasic(30, 15, bookPrice);
                if (bookPrice == "\\n") return "\\n";

                if (bookPrice == "")
                {
                    break;
                }

                isBookValue = exception.IsCtrlZ(bookPrice);
                if (isBookValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 15);
                    viewElement.ClearLine(0, 30);
                    continue;
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
                bookQuantity = keyReader.ReadKeyBasic(30, 17, bookQuantity);
                if (bookQuantity == "\\n") return "\\n";

                if (bookQuantity == "")
                {
                    break;
                }

                isBookValue = exception.IsCtrlZ(bookQuantity);
                if (isBookValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 17);
                    viewElement.ClearLine(0, 30);
                    continue;
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
                bookViewElement.PrintSuccessMessage("수정");

                AddEditLogToDatabase(bookQuantity, bookPrice);
            }

            else
            {
                bookViewElement.PrintEditFailMessage();
            }

            return "";
        }

        public string DeleteBook()
        {
            bookViewElement.PrintDeleteBook();
            bookViewElement.PrintBookIdForm();
            viewElement.PrintLine();
            databaseBook.SelectBookList();

            string bookId = "";
            bool isBookValue = false;

            while (isBookValue == false)
            {
                bookId = keyReader.ReadKeyBasic(30, 13, bookId);
                if (bookId == "\\n") return "\\n";

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
                
                isBookValue = DatabaseMemberBook.databaseMemberBook.IsMemberCheckedOut(bookId, "bookId");
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

            logDTO.User = "관리자";
            logDTO.History = "ID " + bookId + " 도서 삭제";
            databaseLog.InsertLog(logDTO);

            return "";
        }

        public string SearchBook()
        {
            string bookValue = "";
            bookViewElement.InformBookList();
            bookViewElement.SearchBook();
            viewElement.PrintLine(); 
            databaseBook.SelectBookList();

            while (Constant.IS_CTRL_Z)
            {
                bookValue = keyReader.ReadKeyBasic(29, 6, bookValue);
                if (bookValue == "\\n") return "\\n";

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
            viewElement.PrintLine(); 
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
                    viewElement.ClearLine(0, 29);
                    Console.SetCursorPosition(29, 6);
                    viewElement.ClearLine(0, 29);
                    continue;
                }
                break;
            }
            Console.SetCursorPosition(0, 7);
            viewElement.ClearLine(0, 0);
            Console.SetCursorPosition(0, 6);
            viewElement.ClearLine(0, 0);
            Console.SetCursorPosition(0, 2);
            viewElement.ClearLine(0, 0);
            Console.SetCursorPosition(0, 1);
            viewElement.ClearLine(0, 0);
            Console.SetCursorPosition(0, 0);
            viewElement.ClearLine(0, 0);
            bookViewElement.InformNaverBookListAfter();
            bookViewElement.AddNaverBookForm();

            logDTO.User = "관리자";
            logDTO.History = "NAVER 책 검색에서 ''" + bookTitle + "'' 도서 검색";
            databaseLog.InsertLog(logDTO);

            naverBookAPI.SearchNaverAPI(bookTitle, bookQuantity);
            while (isBookValue == false)
            {
                string isbn = "";
                isbn = keyReader.ReadKeyBasic(37, 8, isbn);
                if (isbn == "\\n") return "\\n";

                isBookValue = IsIsbn(isbn, bookTitle, bookQuantity, isBookValue);
                if (isBookValue == false)
                {
                    Console.SetCursorPosition(50, 4);
                    bookViewElement.PrintIsbnFailMessage();
                    Console.SetCursorPosition(37, 8);
                    viewElement.ClearLine(0, 37);
                }

            }
            Console.SetCursorPosition(70, 4);
            bookViewElement.PrintLongSuccessMessage();

            return "";
        }

        public void PrintList()
        {
            bookViewElement.InformBookList();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseBook.SelectBookList();
            Console.SetCursorPosition(0, 0);
        }
        
        public void PrintCheckOutList()
        {
            bookViewElement.InformCheckOutList();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            DatabaseMemberBook.databaseMemberBook.SelectMemberBookList();
            Console.SetCursorPosition(0, 0);
        }

        private void PrintFalse(int x, int y)
        {
            Console.SetCursorPosition(25, 10);
            bookViewElement.PrintWarningMessage();
            Console.SetCursorPosition(x, y);
            viewElement.ClearLine(0, x);
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
                viewElement.ClearLine(0, 0);

                Console.SetCursorPosition(0, 6);
                viewElement.ClearLine(0, 0);
                Console.SetCursorPosition(0, 8);
                viewElement.ClearLine(0, 0);
                Console.SetCursorPosition(0, 7);
                bookViewElement.PrintRegisterNaverBook();

                while (isBookValue == false)
                {
                    Console.SetCursorPosition(37, 7);
                    bookId = Console.ReadLine();
                    isBookValue = databaseBook.IsBookId(bookId);

                    if (isBookValue == true)
                    {
                        Console.SetCursorPosition(45, 4);
                        bookViewElement.PrintLongWarningMessage();
                        Console.SetCursorPosition(37, 7);
                        viewElement.ClearLine(0, 37);
                        isBookValue = false;
                        continue;
                    }

                    isBookValue = exception.IsBookId(bookId);
                    if (isBookValue == false)
                    {
                        Console.SetCursorPosition(45, 4);
                        bookViewElement.PrintLongWarningMessage();
                        Console.SetCursorPosition(37, 7);
                        viewElement.ClearLine(0, 37);
                    }
                }

                isBookValue = false;
                viewElement.ClearLineEasy(5, 0);

                while (isBookValue == false)
                {
                    Console.SetCursorPosition(37, 9);
                    bookCount = Console.ReadLine();

                    isBookValue = exception.IsQuantity(bookCount);
                    if (isBookValue == false)
                    {
                        Console.SetCursorPosition(45, 4);
                        bookViewElement.PrintLongWarningMessage();
                        Console.SetCursorPosition(37, 9);
                        viewElement.ClearLine(0, 37);
                    }
                }
                viewElement.ClearLineEasy(5, 0);
                ConnectDatabase(bookTitle, bookQuantity, isbn, bookId, bookCount);
                return true;
            }
            return false;
        }

        private void ConnectDatabase(string title, string display, string isbn, string id, string quantity)
        {
            BookDTO bookDTO = naverBookAPI.SetBookDTO(title, display, isbn);
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
    }
}
