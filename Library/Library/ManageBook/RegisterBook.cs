using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class RegisterBook : FindRegisterException
    {
        BookVO bookVO;
        SetBookData bookData;

        private bool isValue;

        public RegisterBook()
        { // 생성자
            bookVO = new BookVO();
            bookData = new SetBookData();

            isValue = false;
        }

        public void RegisterNewBook()
        {
            Console.Clear();
            PrintRegisterBook();
            ScanRegisterBook();
        }
        private void PrintRegisterBook()
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

        private void ScanRegisterBook()
        {
            bookVO.Name = ScanName();
            bookVO.Id = ScanId(); 
            bookVO.Publisher = ScanPublisher();
            bookVO.Author = ScanAuthor(); 
            bookVO.Price = ScanPrice(); 
            bookVO.Quantity = ScanQuantity(); 

            bookData.bookList.Add(new BookVO(bookVO.Name, bookVO.Id, bookVO.Publisher, bookVO.Author, bookVO.Price, bookVO.Quantity));
        }

        private string ScanName()
        {
            while (isValue == false)
            {
                Console.Write("                 책 이름 : ");
                bookVO.Name = Console.ReadLine();
                isValue = IsId(bookVO.Name);

            }
            isValue = false;
            return bookVO.Name;
        }
        private string ScanId()
        {
            while (isValue == false)
            {
                Console.Write("                  아이디 : ");
                bookVO.Id = Console.ReadLine();
                isValue = IsId(bookVO.Id);
            }
            isValue = false;
            return bookVO.Id;

        }

        private string ScanPublisher()
        {
            Console.Write("                   출판사 : ");
            bookVO.Publisher = Console.ReadLine();
            return bookVO.Publisher;
        }

        private string ScanAuthor()
        {
            Console.Write("                   저자 : ");
            bookVO.Author = Console.ReadLine();
            return bookVO.Author;
        }

        private string ScanPrice()
        {
            while (isValue == false)
            {
                Console.Write("                   가격 : ");
                bookVO.Price = Console.ReadLine();
                isValue = IsPrice(bookVO.Price);
            }
            isValue = false;
            return bookVO.Price;
        }
 

        private string ScanQuantity()
        {
            Console.Write("                   수량 : ");
            bookVO.Publisher = Console.ReadLine();
            return bookVO.Quantity;
        }

    }
}
