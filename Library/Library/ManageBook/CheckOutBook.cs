using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class CheckOutBook : FindBookInformation // 도서 대출
    {
        BookVO bookVO;
        MemberVO memberVO;
        SearchBook searchYourBook;
        PrintBookList printYourBook;
        SetBookData setBookData;
        SetMemberData setMemberData;


        private bool isBookName;
        private string bookName;
        private int bookListIndex;

        public CheckOutBook()
        {
            bookVO = new BookVO();
            memberVO = new MemberVO();
            searchYourBook = new SearchBook();
            printYourBook = new PrintBookList();
            setBookData = new SetBookData();
            setMemberData = new SetMemberData();

            isBookName = false;
        }

        public void ShowCheckOutBook(int memberListIndex)
        {
            Console.Clear();
            PrintCheckOutBook();
            bookName = ScanFindBook(isBookName);
            bookListIndex = FindListIndex(bookName);
            SucceedCheckOutBook(bookListIndex, memberListIndex);
        }

        public void PrintCheckOutBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                  YOU CAN CHECK OUT A BOOK                 ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void SucceedCheckOutBook(int bookListIndex, int memberListIndex)
        {
            ClearLine(2);
            Console.WriteLine("                성공적으로 처리되었습니다!");
            setBookData.bookList[bookListIndex].Quantity = "0";
        }
    }
}
