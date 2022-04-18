using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class BookViewElement
    {
        public void PrintRegistration()
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
            Console.WriteLine();
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        ID   : ");
            Console.WriteLine("                       NAME  : ");
            Console.WriteLine("                      AUTHOR : ");
            Console.WriteLine("                   PUBLISHER : ");
            Console.WriteLine("                      PRICE  : ");
            Console.WriteLine("         QUANTITY(2 이상 불가): ");
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

        public void PrintDeleteBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     DELETE A BOOK T_T                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void InformBookList()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("                       B O O K L I S T                      ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine();

        }

        public void SearchBook()
        {
            Console.WriteLine();
            Console.WriteLine("   책 제목 / 저자 / 출판사 : ");
            Console.WriteLine();
        }

    }
}
