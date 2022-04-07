using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ManageBook
    {
        RegisterBook registerBook = new RegisterBook();
        public ManageBook()
        {

        }
        public void ShowManageBook()
        {

        }

        public void PrintDeleteBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        MANAGE BOOK                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      1. REGISTER BOOK                    ");
            Console.WriteLine("                      2. EDIT BOOK                        ");
            Console.WriteLine("                      3. DELETE BOOK                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
    }

}
