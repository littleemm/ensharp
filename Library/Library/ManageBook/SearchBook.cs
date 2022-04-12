using System;
using System.Collections.Generic;
using System.Text;

namespace Library 
{
    class SearchBook
    {
        BookVO bookVO;
        SetBookData bookData;
        private ScanBasicElement scanBasicElement;
        private FindBookInformation findSearchBookInformation;
        
        private bool isBookValue; // 일치하는 책 제목인지 판별
        private int bookListIndex; // 책 제목에 따른 리스트 인덱스
        private string bookValue; // 책 이름
        private string[] menuNumberArray;
        private int menuNumber;

        public SearchBook()
        {
            bookVO = new BookVO();
            bookData = new SetBookData();
            scanBasicElement = new ScanBasicElement();
            findSearchBookInformation = new FindBookInformation();

            isBookValue = false;
            bookValue = "";
            menuNumberArray = new string[] { "1", "2", "3"};
        }
        public void ShowBookSearching()
        {
            Console.Clear();
            PrintSearchBook();
            menuNumber = scanBasicElement.SelectMenu(menuNumberArray);

            switch (menuNumber)
            {
                case 1:
                    {
                        bookListIndex = FindIndexByName();
                        break;
                    }
                case 2:
                    {
                        bookListIndex = FindIndexByPublisher();
                        break;
                    }
                case 3:
                    {
                        bookListIndex = FindIndexByAuthor();
                        break;
                    }
            }

            SearchBookInformation(bookListIndex);

            
        }

        public void PrintSearchBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                         SEARCH BOOK                       ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        1. NAME                            ");
            Console.WriteLine("                        2. PUBLISHER                       ");
            Console.WriteLine("                        3. AUTHOR                          ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        private int FindIndexByName()
        {
            bookValue = findSearchBookInformation.ScanFindBookByName(isBookValue);
            bookListIndex = findSearchBookInformation.FindListIndex(bookValue);
            return bookListIndex;
        }

        private int FindIndexByPublisher()
        {
            bookValue = findSearchBookInformation.ScanFindBookByPublisher(isBookValue);
            bookListIndex = findSearchBookInformation.FindListIndex(bookValue);
            return bookListIndex;
        }

        private int FindIndexByAuthor()
        {
            bookValue = findSearchBookInformation.ScanFindBookByAuthor(isBookValue);
            bookListIndex = findSearchBookInformation.FindListIndex(bookValue);
            return bookListIndex;
        }

        private void SearchBookInformation(int bookListIndex)
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("       책  제  목 : " + bookData.bookList[bookListIndex].Name);
            Console.WriteLine("       저  자  명 : " + bookData.bookList[bookListIndex].Author);
            Console.WriteLine("       출  판  사 : " + bookData.bookList[bookListIndex].Publisher);
            Console.WriteLine("       가      격 : " + bookData.bookList[bookListIndex].Price);
            Console.WriteLine("       아  이  디 : " + bookData.bookList[bookListIndex].Id);
            Console.WriteLine("=============================================================");
        }
    }
}
