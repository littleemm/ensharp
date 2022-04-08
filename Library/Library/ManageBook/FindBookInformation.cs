using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class FindBookInformation
    {
        BookVO bookVO = new BookVO();
        private int bookListIndex;

        public FindBookInformation()
        {

        }
        public string ScanFindBook(bool isBookName)
        {
            while (isBookName == false)
            {
                Console.Write("                    책의 제목을 입력하세요 : ");
                bookVO.Name = Console.ReadLine();
                isBookName = IsBookName(isBookName, bookVO.Name);
            }

            return bookVO.Name;
        }
        public bool IsBookName(bool isBookName, string name)
        {
            for (int listIndex = 0; listIndex < SetBookData.bookList.Count; listIndex++)
            {
                if (name.Equals(SetBookData.bookList[listIndex].Name))
                {
                    isBookName = true;
                }
            }

            if (isBookName == false)
            {
                Console.WriteLine("            일치하는 책 제목이 없습니다! 다시 입력하세요.         ");
            }

            return isBookName;
        }

        public int FindListIndex(string name)
        {
            for (int listIndex = 0; listIndex < SetBookData.bookList.Count; listIndex++)
            {
                if (name.Equals(SetBookData.bookList[listIndex].Name))
                {
                    bookListIndex = listIndex;
                    break;
                }
            }

            return bookListIndex;
        }
    }
}
