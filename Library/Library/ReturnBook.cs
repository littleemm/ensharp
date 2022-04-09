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

        public void ShowReturnBook()
        {
            Console.Clear();
            PrintCheckOutBook();
            bookName = ScanFindBook(isBookName);
            bookListIndex = FindListIndex(bookName);
            SuccessReturnBook(bookListIndex);
        }

        public void PrintCheckOutBook()
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

        public void SuccessReturnBook(int bookListIndex)
        {
            setBookData.bookList[bookListIndex].Quantity = "1";
            Console.WriteLine(setBookData.bookList[bookListIndex].Quantity);
        }
    }
}
