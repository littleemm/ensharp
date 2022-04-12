using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class PrintBookList
    {
        SetBookData printBookData;
        public PrintBookList()
        {
            printBookData = new SetBookData();
        }
        public void PrintBookMain()
        {
            Console.Clear();
            InformBookList();
            PrintBooks();
        }

        private void InformBookList()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("                       B O O K L I S T                      ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();

        }
        private void PrintBooks()
        {
            for (int i = 0; i < printBookData.bookList.Count; i++) 
            {
                Console.WriteLine("=============================================================");
                Console.WriteLine("       책  제  목 : " + printBookData.bookList[i].Name);
                Console.WriteLine("       저  자  명 : " + printBookData.bookList[i].Author);
                Console.WriteLine("       출  판  사 : " + printBookData.bookList[i].Publisher);
                Console.WriteLine("       가      격 : " + printBookData.bookList[i].Price);
                Console.WriteLine("       아  이  디 : " + printBookData.bookList[i].Id);

            }
            Console.WriteLine("=============================================================");
        }
    }
}
