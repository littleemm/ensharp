using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class SetBookData
    {
        public List<BookVO> bookList = new List<BookVO>();
        public SetBookData()
        {
            bookList.Add(new BookVO("1", "명품 JAVA 프로그래밍", "생능출판", "황기태", "33000", "1"));
            bookList.Add(new BookVO("2", "주식 투자 무작정 따라하기", "길벗", "윤재수", "18000", "1"));
            bookList.Add(new BookVO("3", "Do it! 점프 투 파이썬", "이지스퍼블리싱", "박응용", "18800", "1"));
            bookList.Add(new BookVO("4", "총, 균, 쇠", "문학사상", "제레드 다이아몬드", "28000", "1"));
     
            bookList.Add(new BookVO("6", "신과 함께 저승편 1", "문학동네", "주호민", "11000", "0"));
        }
    }
}
