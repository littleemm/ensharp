﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class DeleteBook
    {
        BookVO bookVO = new BookVO();
        FindBookInformation findDeleteBookInformation = new FindBookInformation();
        private bool isBookName; // 일치하는 책 제목인지 판별
        private int bookListIndex; // 책 제목에 따른 리스트 인덱스
        private string bookName; // 책 이름

        public DeleteBook()
        {
            isBookName = false;
            bookName = "";
        }
        public void DeleteLibraryBook()
        {
            Console.Clear();
            PrintDeleteBook();
            bookName = findDeleteBookInformation.ScanFindBook(isBookName);
            bookListIndex = findDeleteBookInformation.FindListIndex(bookName);

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
        public void DeleteBookInformation(int listIndex)
        {
            SetBookData.bookList[listIndex] = null;
        }
    }
}