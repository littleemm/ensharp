using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ReturnBook : FindBookInformation
    {
        BookVO bookVO;
        SearchBook searchYourBook;
        PrintBookList printYourBook;
        SetBookData setBookData;


        private bool isBookName;
        private string bookName;
        private int bookListIndex;

        public ReturnBook()
        {
            bookVO = new BookVO();
            searchYourBook = new SearchBook();
            printYourBook = new PrintBookList();
            setBookData = new SetBookData();
            isBookName = false;
        }

        public void ShowReturnBook(int memberListIndex)
        {
            Console.Clear();
            PrintReturnBook();
            bookName = ScanFindBookByName(isBookName);
            bookListIndex = FindListIndex(bookName);
            SucceedReturnBook(bookListIndex, memberListIndex);
        }

        private void PrintReturnBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                    YOU CAN RETURN A BOOK                  ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void SucceedReturnBook(int bookListIndex, int memberListIndex)
        {
            ClearLine(2);
            Console.WriteLine("                성공적으로 처리되었습니다!");
            setBookData.bookList[bookListIndex].Quantity = "1";
        }
    }
}
