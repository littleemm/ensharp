﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class FindBookInformation
    {
        BookVO bookVO;
        SetBookData bookData;
        private int bookListIndex;
        private string bookName;

        public FindBookInformation()
        {
            bookVO = new BookVO();
            bookData = new SetBookData();
        }
        public string ScanFindBook(bool isBookName)
        {
            while (isBookName == false)
            {
                Console.Write("              책 제목을 입력하세요 : ");
                bookVO.Name = Console.ReadLine();
                isBookName = IsBookName(isBookName, bookVO.Name);
            }

            return bookVO.Name;
        }
  
        public bool IsBookName(bool isBookName, string name)
        {
            for (int listIndex = 0; listIndex < (bookData.bookList).Count; listIndex++)
            {
                if (name.Equals(bookData.bookList[listIndex].Name))
                {
                    isBookName = true;
                }
            }

            if (isBookName == false)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("        일치하는 책 제목이 없습니다! 다시 입력하세요.         ");
                Console.ResetColor();
            }

            return isBookName;
        }

        public int FindListIndex(string name)
        {
            for (int listIndex = 0; listIndex < bookData.bookList.Count; listIndex++)
            {
                if (name.Equals(bookData.bookList[listIndex].Name))
                {
                    bookListIndex = listIndex;
                    break;
                }
            }

            return bookListIndex;
        }

        public void ClearLine(int line)
        { // 라인 한줄씩 청소
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
