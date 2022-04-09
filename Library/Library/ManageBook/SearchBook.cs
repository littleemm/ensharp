using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class SearchBook
    {
        BookVO bookVO;
        SetBookData bookData;
        FindBookInformation findSearchBookInformation;
        
        private bool isBookName; // 일치하는 책 제목인지 판별
        private int bookListIndex; // 책 제목에 따른 리스트 인덱스
        private string bookName; // 책 이름

        public SearchBook()
        {
            bookVO = new BookVO();
            bookData = new SetBookData();
            findSearchBookInformation = new FindBookInformation();

            isBookName = false;
            bookName = "";
        }
        public void ShowBookSearching()
        {
            Console.Clear();
            PrintSearchBook();
            bookName = findSearchBookInformation.ScanFindBook(isBookName);
            bookListIndex = findSearchBookInformation.FindListIndex(bookName);
            SearchBookInformation(bookListIndex);
        }

        public void PrintSearchBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                         SEARCH BOOK                       ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void SearchBookInformation(int bookListIndex)
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("       책  제  목 : " + bookData.bookList[bookListIndex].Name);
            Console.WriteLine("       저  자  명 : " + bookData.bookList[bookListIndex].Author);
            Console.WriteLine("       출  간  일 : " + bookData.bookList[bookListIndex].Id);
            Console.WriteLine("       출  판  사 : " + bookData.bookList[bookListIndex].Publisher);
            Console.WriteLine("       가      격 : " + bookData.bookList[bookListIndex].Price);
            Console.WriteLine("=============================================================");
        }
    }
}
