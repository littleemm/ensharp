using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class FindBookInformation
    {
        BookVO bookVO;
        SetBookData bookData;
        private int bookListIndex;

        public FindBookInformation()
        {
            bookVO = new BookVO();
            bookData = new SetBookData();
        }
        public string ScanFindBookByName(bool isBookName)
        {
            while (isBookName == false)
            {
                Console.Write("              책 제목을 입력하세요 : ");
                bookVO.Name = Console.ReadLine();
                isBookName = IsBookName(isBookName, bookVO.Name);
            }

            return bookVO.Name;
        }
        public string ScanFindBookByPublisher(bool isBookPublisher)
        {
            while (isBookPublisher == false)
            {
                Console.Write("             출판사명을 입력하세요 : ");
                bookVO.Publisher = Console.ReadLine();
                isBookPublisher = IsBookPublisher(isBookPublisher, bookVO.Publisher);
            }

            return bookVO.Publisher;
        }
        public string ScanFindBookByAuthor(bool isBookAuthor)
        {
            while (isBookAuthor == false)
            {
                Console.Write("              저자 이름을 입력하세요 : ");
                bookVO.Author = Console.ReadLine();
                isBookAuthor = IsBookAuthor(isBookAuthor, bookVO.Author);
            }

            return bookVO.Author;
        }

        public bool IsBookName(bool isBookName, string name)
        {
            for (int listIndex = 0; listIndex < (bookData.bookList).Count; listIndex++)
            {
                if (name.Equals(bookData.bookList[listIndex].Name))
                {
                    isBookName = true;
                }
            }

            if (isBookName == false)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("        일치하는 책 제목이 없습니다! 다시 입력하세요.         ");
                Console.ResetColor();
            }

            return isBookName;
        }

        public bool IsBookPublisher(bool isBookPublisher, string publisher)
        {
            for (int listIndex = 0; listIndex < (bookData.bookList).Count; listIndex++)
            {
                if (publisher.Equals(bookData.bookList[listIndex].Publisher))
                {
                    isBookPublisher = true;
                }
            }

            if (isBookPublisher == false)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("        일치하는 출판사가 없습니다! 다시 입력하세요.         ");
                Console.ResetColor();
            }

            return isBookPublisher;
        }

        public bool IsBookAuthor(bool isBookAuthor, string author)
        {
            for (int listIndex = 0; listIndex < (bookData.bookList).Count; listIndex++)
            {
                if (author.Equals(bookData.bookList[listIndex].Author))
                {
                    isBookAuthor = true;
                }
            }

            if (isBookAuthor == false)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("        일치하는 저자가 없습니다! 다시 입력하세요.         ");
                Console.ResetColor();
            }

            return isBookAuthor;
        }

        public int FindListIndex(string name)
        {
            for (int listIndex = 0; listIndex < bookData.bookList.Count; listIndex++)
            {
                if (name.Equals(bookData.bookList[listIndex].Name))
                {
                    bookListIndex = listIndex;
                    break;
                }
            }

            return bookListIndex;
        }

        public void ClearLine(int line)
        { // 라인 한줄씩 청소
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
