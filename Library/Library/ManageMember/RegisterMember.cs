using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class RegisterMember
    {
        MemberVO memberVO = new MemberVO();

        public void PrintRegisterMember()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      REGISTER MEMBER                      ");
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

            SetBookData.bookList[++size] = new BookVO(bookVO.Name, bookVO.Id, bookVO.Publisher, bookVO.Author, bookVO.Price, bookVO.Quantity);
        }
    }
}
