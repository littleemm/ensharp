using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class SetBookData
    {
        public static List<BookVO> bookList = new List<BookVO>();
        public SetBookData()
        {

        }

        public static void setBookData()
        {
            bookList[0] = (new BookVO("20180601", "명품 JAVA 프로그래밍", "생능출판", "황기태", "33000", "1"));
            bookList[1] = (new BookVO("20200110", "주식 투자 무작정 따라하기", "길벗", "윤재수", "18000", "1"));
            bookList[2] = (new BookVO("20190620", "Do it! 점프 투 파이썬", "이지스퍼블리싱", "박응용", "18800", "1"));
            bookList[3] = (new BookVO("20051219", "총, 균, 쇠", "문학사상", "제레드 다이아몬드", "28000", "1"));
            bookList[4] = (new BookVO("20120102", "노인과 바다", "민음사", "어네스트 밀러 헤밍웨이", "8000", "1"));
            bookList[5] = (new BookVO("20200817", "신과 함께 저승편 1", "문학동네", "주호민", "11000", "0"));
        }
    }
}
