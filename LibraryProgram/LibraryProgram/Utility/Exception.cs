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

        public bool IsBookCount(string quantity) // 책 수량
        {
            if (IsCtrlZ(quantity) == false)
            {
                return false;
            }
            pattern = @"^[0-9]{1,3}$";

            if (Regex.IsMatch(quantity, pattern) && int.Parse(quantity) >= 1 && int.Parse(quantity) <= 100)
            {
                return true;
            }

            return false;
        }

        public bool IsDate(string date) // 책 수량
        {
            if (IsCtrlZ(date) == false)
            {
                return false;
            }
            pattern = @"^[0-9]{8}$";

            if (Regex.IsMatch(date, pattern))
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
            if (!IsCtrlZ(password))
            {
                return false;
            }

            if(Regex.IsMatch(password, Constant.PATTERN_PASSWORD))
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

            if (IsWhiteSpace(name) == false) // 전부 공백으로 입력되는 것을 방지
            {
                return false;
            }

            if (Regex.IsMatch(name, Constant.PATTERN_NAME_KOR) 
                || Regex.IsMatch(name, Constant.PATTERN_NAME_ENG))
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

            if (Regex.IsMatch(phoneNumber, Constant.PATTERN_TEL_010) 
                || Regex.IsMatch(phoneNumber, Constant.PATTERN_TEL_0XX)
                || Regex.IsMatch(phoneNumber, Constant.PATTERN_TEL_02))
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
            if (address.Length < 13)
            {
                return false;
            }

            string[] array = address.Split(' ');

            if (array[0].Equals("서울시") || array[0].Equals("서울특별시"))
            { // 서울시
                return IsSeoulAddress(array);
            }

            else if (IsMetropolitanName(array[0], Constant.NAME) && (Regex.IsMatch(array[0], Constant.PATTERN_ADDRESS_METROPOLITANCITY) || Regex.IsMatch(array[0], Constant.PATTERN_ADDRESS_METROPOLITAN)))
            { // 광역시
                return IsMetropolitanAddress(array);
            }
            else if (array[0].Equals("세종시") || array[0].Equals("세종특별자치시"))
            { // 세종시
                return IsSejongCityAddress(array);
            }

            else if (Regex.IsMatch(array[0], Constant.PATTERN_ADDRESS_PROVINCE_ISLAND) || array[0].Equals("제주특별자치도"))
            { // 도, 제주도
                return IsProvinceOrJejuAddress(array);
            }

            return false;
            
        }

        private bool IsSeoulAddress(string[] array) // 서울특별시 체크
        {
            if (IsDistrictAndCountyForSpecial(array) && IsRoad(array) && IsBuildingNumber(array))
            {
                return true;
            }
            return false;
        }

        private bool IsMetropolitanAddress(string[] array) // 광역시 체크
        {
            if (array.Length == 4 && IsDistrictAndCountyForSpecial(array) && IsRoad(array) && IsBuildingNumber(array))
            { // 인천광역시 남동구 정각로 9
                return true;
            }
            else if (array.Length == 5 && IsDistrictAndCountyForSpecial(array) && IsTownAndTownship(array) && IsRoad(array) && IsBuildingNumber(array))
            { // 대구광역시 달성군 현풍읍 테크노대로 36
                return true;
            }
            return false;
        }
        
        private bool IsSejongCityAddress(string[] array) // 세종특별자치시 체크
        {
            if (array.Length == 3 && IsRoad(array) && IsBuildingNumber(array))
            { // 세종특별자치시 갈매로 477
                return true;
            }
            else if (array.Length == 4 && IsTownAndTownship(array) && IsRoad(array) && IsBuildingNumber(array))
            { // 세종특별자치시 연서면 연서로 148
                return true;
            }
            return false;
        }

        private bool IsProvinceOrJejuAddress(string[] array) // 도 단위, 제주도 체크
        {
            if (array.Length == 4 && IsCityAndCounty(array) && IsRoad(array) && IsBuildingNumber(array))
            { // 강원도 춘천시 중앙로 1, 제주특별자치도 제주시 임항로 286
                return true;
            }
            else if (array.Length == 5 && IsCityAndCounty(array) && IsTownAndTownship(array) && IsRoad(array) && IsBuildingNumber(array))
            { // 경기도 남양주시 진접읍 해밀예당3로 38, 경상북도 울릉군 북면 울릉순환로 2620 
                return true;
            }
            else if ((array.Length == 5 || array.Length == 6) && IsCityAndCounty(array) && IsDistirct(array) && IsTownAndTownship(array) && IsRoad(array) && IsBuildingNumber(array))
            { // 경기도 안산시 단원구 화랑로 387, 경상남도 창원시 마산회원구 내서읍 삼계10길 22
                return true;
            }

            return false;
        }

        private bool IsDistrictAndCountyForSpecial(string[] array) // 구/군 체크 (특별시, 광역시)
        {
            if (array.Length == 4 && Regex.IsMatch(array[1], Constant.PATTERN_ADDRESS_DISTRICT)) // 구
            {
                return true;
            }
            else if (IsMetropolitanName(array[0], Constant.NAMEOF) && Regex.IsMatch(array[1], Constant.PATTERN_ADDRESS_COUNTY))
            { // 일부 광역시 군
                return true;
            }

            return false;
        }

        private bool IsDistirct(string[] array) // 구 체크
        {
            if ((array.Length == 5 || array.Length == 6)&& Regex.IsMatch(array[2], Constant.PATTERN_ADDRESS_DISTRICT)) // 구
            { // 경기도 안산시 단원구 화랑로 387, 경상남도 창원시 마산회원구 내서읍 삼계10길 22
                return true;
            }
            return false;
        }

        private bool IsTownAndTownship(string[] array) // 읍/면 체크 
        {
            if (array.Length == 5 && (Regex.IsMatch(array[2], Constant.PATTERN_ADDRESS_TOWN) || Regex.IsMatch(array[2], Constant.PATTERN_ADDRESS_TOWNSHIP)))
            { // 대구광역시 달성군 현풍읍 테크노대로 36, 경기도 남양주시 진접읍 해밀예당3로 38
                return true;
            }
            else if (array.Length == 6 && (Regex.IsMatch(array[3], Constant.PATTERN_ADDRESS_TOWN) || Regex.IsMatch(array[3], Constant.PATTERN_ADDRESS_TOWNSHIP)))
            { // 경상남도 창원시 마산회원구 내서읍 삼계10길 22
                return true;
            }
            else if (array.Length == 4 && (Regex.IsMatch(array[1], Constant.PATTERN_ADDRESS_TOWN) || Regex.IsMatch(array[1], Constant.PATTERN_ADDRESS_TOWNSHIP)))
            { // 세종특별자치시 조치원읍 세종로 2439, 세종특별자치시 연서면 연서로 148
                return true;
            }
            return false;
        }

        private bool IsRoad(string[] array) // 도로 체크
        {
            if (array.Length == 3 && (Regex.IsMatch(array[1], Constant.PATTERN_ADDRESS_ROAD_GIL) || Regex.IsMatch(array[1], Constant.PATTERN_ADDRESS_ROAD_RO)))
            {
                return true;
            }
            else if (array.Length == 4 && (Regex.IsMatch(array[2], Constant.PATTERN_ADDRESS_ROAD_GIL) || Regex.IsMatch(array[2], Constant.PATTERN_ADDRESS_ROAD_RO)))
            {
                return true;
            }
            else if (array.Length == 5 && (Regex.IsMatch(array[3], Constant.PATTERN_ADDRESS_ROAD_GIL) || Regex.IsMatch(array[3], Constant.PATTERN_ADDRESS_ROAD_RO)))
            {
                return true;
            }
            else if (array.Length == 6 && (Regex.IsMatch(array[4], Constant.PATTERN_ADDRESS_ROAD_GIL) || Regex.IsMatch(array[4], Constant.PATTERN_ADDRESS_ROAD_RO)))
            {
                return true;
            }
            return false;
        }

        private bool IsBuildingNumber(string[] array) // 건물 번호 체크
        { // 건물 번호는 1이상 부터
            if (array.Length == 3 && int.Parse(array[2]) > 0 && Regex.IsMatch(array[2], Constant.PATTERN_ADDRESS_NUMBER))
            {
                return true;
            }
            else if (array.Length == 4 && int.Parse(array[3]) > 0 && Regex.IsMatch(array[3], Constant.PATTERN_ADDRESS_NUMBER))
            {
                return true;
            }
            else if (array.Length == 5 && int.Parse(array[4]) > 0 && Regex.IsMatch(array[4], Constant.PATTERN_ADDRESS_NUMBER))
            {
                return true;
            }
            else if (array.Length == 6 && int.Parse(array[5]) > 0  && Regex.IsMatch(array[5], Constant.PATTERN_ADDRESS_NUMBER))
            {
                return true;
            }
            return false;
        }

        private bool IsCityAndCounty(string[] array) // 시/군 체크
        {
            if (Regex.IsMatch(array[1], Constant.PATTERN_ADDRESS_CITY) || Regex.IsMatch(array[1], Constant.PATTERN_ADDRESS_COUNTY))
            {
                return true;
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
            if (string.IsNullOrEmpty(input?.Trim()) && input != "\r\n") 
            { // ctrl + z 체크
                return false;
            }

            return true;
        }

        private bool IsMetropolitanName(string input,string[] name)
        {
            for (int i = 0; i < name.Length; i++)
            { // 광역시가 아닌 시의 이름이 들어오는 것을 막음
                if (input.Substring(0, 2).Equals(name[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
