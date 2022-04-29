using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryProgram
{
    class Exception
    {
        Regex regex;
        string pattern;
        string patternAfter;
        public Exception()
        {

        }

        public bool IsBookId(string bookId) // bookid 예외
        {
            if (bookId.Equals("0"))
            {
                return false;
            }

            pattern = @"^[0-9]{1,5}$";

            if (Regex.IsMatch(bookId, pattern))
            {
                return true;
            }

            return false;

        }

        public bool IsBookName(string bookName) // 책제목 예외
        {
            pattern = @"^[a-zA-Z가-힣.,+#]{1,20}$";

            if (Regex.IsMatch(bookName, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsBookAuthor(string bookAuthor) // 저자 예외
        {
            pattern = @"^[a-zA-Z가-힣,]{1,15}$";
            
            if (Regex.IsMatch(bookAuthor, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsBookPublisher(string bookPublisher) // 출판사 예외
        {
            pattern = @"^[a-zA-Z가-힣#()]{1,10}$";
            
            if (Regex.IsMatch(bookPublisher, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsPrice(string price) // 책 가격
        {
            if (price.Equals("0"))
            {
                return false;
            }

            pattern = @"^[0-9]{1,7}$";

            if (Regex.IsMatch(price, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsQuantity(string quantity) // 책 수량
        {
            pattern = @"^[0-9]{1,5}$";

            if (Regex.IsMatch(quantity, pattern))
            {
                return true;
            }

            return false;
        }



        public bool IsMemberId(string memberId) // 회원 아이디
        {
            pattern = @"^[a-zA-Z0-9]{1,8}*$";
            
            if (Regex.IsMatch(memberId, pattern))
            {
                return true;
            }
            return false;
        }

        public bool IsPassword(string password) // 비밀번호 예외처리
        {
            pattern = @"^[0-9]{2,5}$";

            if (Regex.IsMatch(password, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsMemberName(string name) // 이름 예외처리
        {
            pattern = @"^[가-힣]{2,10}$";

            if (Regex.IsMatch(name, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsAge(string age) // 나이 예외처리, 0~150세
        {
            pattern = @"^[0-9]{1,3}$";
            if (Regex.IsMatch(age, pattern))
            {

            }
            else
            {
                return false;
            }

            int intAge = int.Parse(age);
            if(intAge >= 0 && intAge <= 150)
            {
                return true;
            }

            return false;
        }

        public bool IsPhoneNumber(string phoneNumber) // 휴대전화 예외처리
        {
            pattern = @"^01[0-9]{9}$"; // 01XXXXXXXXX 형태로

            if (Regex.IsMatch(phoneNumber, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsAddress(string address) // 주소 예외처리
        {
            switch(address.Length)
            {
                case (6):
                    {
                        return IsAddressFor6(address);
                    }
                case (7):
                    {
                        return IsAddressFor7(address);
                    }
                case (8):
                    {
                        return IsAddressFor8(address);
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private bool IsAddressFor6(string address) // 서울시 중구
        {
            pattern = @"^[가-힣]{2}시$";
            patternAfter = @"^[가-힣]{2}구$";
            if (Regex.IsMatch(address.Substring(0, 3), pattern) && Regex.IsMatch(address.Substring(4), patternAfter))
            {
                return true;
            }

            return false;
        }

        private bool IsAddressFor7(string address) // 서울시 광진구, 경기도 부천시, 세종시 연서면, 세종시 도담동, 대구시 달성군
        {
            pattern = @"^[가-힣]{2}시|도$";
            patternAfter = @"^[가-힣]{2}구|시|군|면|동$";
            if (Regex.IsMatch(address.Substring(0, 3), pattern) && Regex.IsMatch(address.Substring(4), patternAfter))
            {
                return true;
            }

            return false;
        }

        private bool IsAddressFor8(string address) // 서울시 영등포구, 세종시 조치원읍, 경기도 남양주시, 충청북도 괴산군 
        {
            pattern = @"^[가-힣]{2}시|도$";
            patternAfter = @"^[가-힣]{3}구|시|군|읍|면|동$";
            if (Regex.IsMatch(address.Substring(0, 3), pattern) && Regex.IsMatch(address.Substring(4), patternAfter))
            {
                return true;
            }

            pattern = @"^[가-힣]{3}도$";
            patternAfter = @"^[가-힣]{2}시|군|읍|면|동$";
            if (Regex.IsMatch(address.Substring(0, 4), pattern) && Regex.IsMatch(address.Substring(5), patternAfter))
            {
                return true;
            }

            return false;
        }
    }
}
