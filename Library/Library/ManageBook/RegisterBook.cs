using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class RegisterBook
    {
        BookVO bookVO = new BookVO();
        SetBookData bookData = new SetBookData();
        int size;

        public RegisterBook()
        { // 생성자
            size = (bookData.bookList).Count;
        }

        public void RegisterNewBook()
        {
            Console.Clear();
            PrintRegisterBook();
            ScanRegisterBook();
        }
        public void PrintRegisterBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      REGISTER A BOOK                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void ScanRegisterBook()
        {
            Console.Write("                   책 이름 : ");
            bookVO.Name = Console.ReadLine();
            Console.Write("                   발행연도 : ");
            bookVO.Id = Console.ReadLine(); ///////// 예외처리
            Console.Write("                   출판사 : ");
            bookVO.Publisher = Console.ReadLine();
            Console.Write("                   저자 : ");
            bookVO.Author = Console.ReadLine(); 
            Console.Write("                   가격 : ");
            bookVO.Price = Console.ReadLine(); ///////// 예외처리
            Console.Write("                   수량 : ");
            bookVO.Quantity = Console.ReadLine(); ///////// 예외처리

            bookData.bookList.Add(new BookVO(bookVO.Name, bookVO.Id, bookVO.Publisher, bookVO.Author, bookVO.Price, bookVO.Quantity));
            Console.WriteLine(bookData.bookList[size].Name);
        }
    }
}
