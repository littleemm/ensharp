using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class EditBook
    {
        BookVO bookVO;
        SetBookData bookData;
        FindBookInformation findEditBookInformation;

        private bool isBookName; // 일치하는 책 제목인지 판별
        private int bookListIndex; // 책 제목에 따른 리스트 인덱스
        private string bookName; // 책 이름

        public EditBook()
        {
            bookVO = new BookVO();
            bookData = new SetBookData();
            findEditBookInformation = new FindBookInformation();

            isBookName = false;
            bookName = "";
        }

        public void EditLibraryBook() // 수량 수정
        {
            Console.Clear();
            PrintEditBook();
            bookName = findEditBookInformation.ScanFindBookByName(isBookName);
            bookListIndex = findEditBookInformation.FindListIndex(bookName);
            EditBookQuantity(bookListIndex);
        }

        public void PrintEditBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     EDIT BOOK QUANTITY                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void EditBookQuantity(int listIndex) // 수량 변경
        {
            Console.Write("                  수량을 입력하세요 : ");
            bookVO.Quantity = Console.ReadLine(); ///////// 예외처리

            bookData.bookList[listIndex].Quantity = bookVO.Quantity;       
        }
    }
}
