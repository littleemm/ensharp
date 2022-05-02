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
        string pattern;
        string patternAfter;

        public bool IsBookId(string bookId) // bookid 예외
        {
            if(IsCtrlZ(bookId) == false)
            {
                return false;
            }

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
            if (IsCtrlZ(bookName) == false)
            {
                return false;
            }

            pattern = @"^[a-zA-Z가-힣0-9.,+#%@$&()!?\s]{1,20}$";
            if (IsWhiteSpace(bookName) == false)
            {
                return false;
            }
            if (Regex.IsMatch(bookName, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsBookAuthor(string bookAuthor) // 저자 예외
        {
            if (IsCtrlZ(bookAuthor) == false)
            {
                return false;
            }
            pattern = @"^[a-zA-Z가-힣,.\s]{1,15}$";

            if (IsWhiteSpace(bookAuthor) == false)
            {
                return false;
            }

            if (Regex.IsMatch(bookAuthor, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsBookPublisher(string bookPublisher) // 출판사 예외
        {
            if (IsCtrlZ(bookPublisher) == false)
            {
                return false;
            }
            pattern = @"^[a-zA-Z가-힣0-9#()\s]{1,10}$";

            if (IsWhiteSpace(bookPublisher) == false)
            {
                return false;
            }

            if (Regex.IsMatch(bookPublisher, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsPrice(string price) // 책 가격
        {
            if (IsCtrlZ(price) == false)
            {
                return false;
            }
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
            if (IsCtrlZ(quantity) == false)
            {
                return false;
            }
            pattern = @"^[0-9]{1,5}$";

            if (Regex.IsMatch(quantity, pattern))
            {
                return true;
            }

            return false;
        }



        public bool IsMemberId(string memberId) // 회원 아이디
        {
            if (IsCtrlZ(memberId) == false)
            {
                return false;
            }
            pattern = @"^[a-zA-Z0-9]{1,8}$";
            
            if (Regex.IsMatch(memberId, pattern))
            {
                return true;
            }
            return false;
        }

        public bool IsPassword(string password) // 비밀번호 예외처리
        {
            if (IsCtrlZ(password) == false)
            {
                return false;
            }
            pattern = @"^[0-9]{2,5}$";

            if (Regex.IsMatch(password, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsMemberName(string name) // 이름 예외처리
        {
            if (IsCtrlZ(name) == false)
            {
                return false;
            }
            pattern = @"^[가-힣\s]{2,10}$";

            if (IsWhiteSpace(name) == false)
            {
                return false;
            }

            if (Regex.IsMatch(name, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsAge(string age) // 나이 예외처리, 0~150세
        {
            if (IsCtrlZ(age) == false)
            {
                return false;
            }
            pattern = @"^[0-9]{1,3}$";
            if (Regex.IsMatch(age, pattern))
            {

            }
            else
            {
                return false;
            }

            int intAge = int.Parse(age);
            if(intAge >= 1 && intAge <= 150)
            {
                return true;
            }

            return false;
        }

        public bool IsPhoneNumber(string phoneNumber) // 휴대전화 예외처리
        {
            if (IsCtrlZ(phoneNumber) == false)
            {
                return false;
            }
            pattern = @"^01[0-9]{9}$"; // 01XXXXXXXXX 형태로

            if (Regex.IsMatch(phoneNumber, pattern))
            {
                return true;
            }

            return false;
        }

        public bool IsAddress(string address) // 주소 예외처리
        {
            if (IsCtrlZ(address) == false)
            {
                return false;
            }
            if (IsWhiteSpace(address) == false)
            {
                return false;
            }

            pattern = @"^[가-힣\s]{6,8}$";

            if (Regex.IsMatch(address, pattern))
            {
                switch (address.Length)
                {
                    case (Constant.ADDRESS_LENGTH_IS_6):
                        {
                            return IsAddressFor6(address);
                        }
                    case (Constant.ADDRESS_LENGTH_IS_7):
                        {
                            return IsAddressFor7(address);
                        }
                    case (Constant.ADDRESS_LENGTH_IS_8):
                        {
                            return IsAddressFor8(address);
                        }
                }
            }

            return false;
            
        }

        private bool IsAddressFor6(string address) // 서울시 중구
        {
            pattern = @"^[가-힣]{2}시$";
            patternAfter = @"^[가-힣]{1}구$";
            if (Regex.IsMatch(address.Substring(0, 3), pattern) && Regex.IsMatch(address.Substring(4), patternAfter))
            {
                return true;
            }

            return false;
        }

        private bool IsAddressFor7(string address) // 서울시 광진구, 경기도 부천시, 세종시 연서면, 세종시 도담동, 대구시 달성군
        {
            string[] addressAfter = { "구", "시", "군", "면", "동" };

            pattern = @"^[가-힣]{2}시$";

            for (int i = 0; i < addressAfter.Length; i++)
            {
                patternAfter = @"^[가-힣]{2}" + addressAfter[i] + "$";
                if (Regex.IsMatch(address.Substring(0, 3), pattern) && Regex.IsMatch(address.Substring(4), patternAfter))
                {
                    return true;
                }
            }
            pattern = @"^[가-힣]{2}도$";

            for (int i = 0; i < addressAfter.Length; i++)
            {
                patternAfter = @"^[가-힣]{2}" + addressAfter[i] + "$";
                if (Regex.IsMatch(address.Substring(0, 3), pattern) && Regex.IsMatch(address.Substring(4), patternAfter))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsAddressFor8(string address) // 서울시 영등포구, 세종시 조치원읍, 경기도 남양주시, 충청북도 괴산군 
        {
            string[] addressAfter = { "구", "시", "군", "읍", "면", "동" };
            pattern = @"^[가-힣]{2}시$";

            for (int i = 0; i < addressAfter.Length; i++)
            {
                patternAfter = @"^[가-힣]{3}" + addressAfter[i] + "$";
                if (Regex.IsMatch(address.Substring(0, 3), pattern) && Regex.IsMatch(address.Substring(4), patternAfter))
                {
                    return true;
                }
            }

            pattern = @"^[가-힣]{2}도$";

            for (int i = 0; i < addressAfter.Length; i++)
            {
                patternAfter = @"^[가-힣]{3}" + addressAfter[i] + "$";
                if (Regex.IsMatch(address.Substring(0, 3), pattern) && Regex.IsMatch(address.Substring(4), patternAfter))
                {
                    return true;
                }
            }

            pattern = @"^[가-힣]{3}도$";

            for (int i = 0; i < addressAfter.Length; i++)
            {
                patternAfter = @"^[가-힣]{2}" + addressAfter[i] + "$";
                if (Regex.IsMatch(address.Substring(0, 4), pattern) && Regex.IsMatch(address.Substring(5), patternAfter))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsIsbn(string isbn)
        {
            if (IsCtrlZ(isbn) == false)
            {
                return false;
            }
            pattern = @"^[0-9]{13}$";

            if (IsWhiteSpace(isbn) == false)
            {
                return false;
            }

            if (Regex.IsMatch(isbn, pattern))
            {
                return true;
            }

            return false;
        }

        private bool IsWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            return true;
        }

        public bool IsCtrlZ(string input)
        {
            if (string.IsNullOrEmpty(input?.Trim()))
            { // ctrl + z 체크
                return false;
            }
            return true;
        }
    }
}
