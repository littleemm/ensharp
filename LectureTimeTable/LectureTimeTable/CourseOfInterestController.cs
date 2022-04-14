using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LectureTimeTable
{
    class CourseOfInterestController // 관심과목담기 관리 클래스
    {
        CourseVO courseVO;

        int positionX;
        int positionY;

        private int x;
        private int y;
        private int nextIndex;
        private string division;
        private string number;
        private string[] courseDivision;
        private string[] grade;
        private string[] major;
        private string[] array;
        private string[] longArray;
        private bool isNumber;
        private Regex regex;
        private Regex regexNumber;

        private MiniViewElement miniViewElement;

        
        public CourseOfInterestController(int positionX, int positionY) 
        {
            courseVO = new CourseVO("", "", "", "", "", "", "");
            regex = new Regex(@"^[0-9]{6}$");
            regexNumber = new Regex(@"^[0-9]{3}$");
            major = new string[] { "컴퓨터공학과", "소프트웨어학과", "지능기전공학부" };
            grade = new string[] { "1", "2", "3", "4" };
            courseDivision = new string[] { "공통교양필수", "전공필수", "전공선택" };

            array = new string[] { "1", "2", "3" };
            longArray = new string[] { "1", "2", "3", "4" };

            this.positionX = positionX;
            this.positionY = positionY;

            x = 30;
            y = 5;

            miniViewElement = new MiniViewElement();
        }

        public int CheckDivisionNumber(int x, int y, string[] numberArray, ViewElement viewElement) // 번호 입력
        {
            SelectCondition(x, y);
            
            while (isNumber == false)
            {
                number = ScanDivision(positionX, positionY);

                if(number.Length == 0)
                {
                    return 0;
                } // ENTER 쳤음

                isNumber = IsMenuNumber(number, numberArray);

                if (isNumber == false)
                {
                    viewElement.ClearLine(1, positionX);
                    Console.SetCursorPosition(positionX, positionY);
                    viewElement.PrintWarning(1, positionY - 2);
                }
            }

            isNumber = false;

            return int.Parse(number);
        }

        public string CheckDivisionName(int x, int y) // 이름 입력
        {
            SelectCondition(x, y);
            division = ScanDivision(positionX, positionY);
            if (division.Length == 0)
            {
                return "";
            }

            return division;
        }

        public string CheckClassNumber(int x, int y, ViewElement viewElement)
        {
            SelectCondition(x, y);
            Console.SetCursorPosition(30, 9);
            division = Console.ReadLine();

            if (division.Length == 0)
            {
                return "";
            }

            if (regex.IsMatch(division))
            {
                courseVO.Number = division;
            }

            Console.SetCursorPosition(36, 9);
            division = Console.ReadLine();

            if (regex.IsMatch(division))
            {
                courseVO.NumberClass = division;
            }

        }

        public void SelectCondition(int x, int y) // 줄치기
        {
            Console.SetCursorPosition(5, 7);
            Console.BackgroundColor = ConsoleColor.Blue;
            
        }

        public string ScanDivision(int inputPositionX, int inputPositionY) // 숫자 혹은 엔터를 입력 받는 함수
        {
            Console.SetCursorPosition(inputPositionX, inputPositionY);
            division = Console.ReadLine();

            return division;
        }


        private bool IsMenuNumber(string number, string[] numberArray) // 제한된 범위의 숫자가 입력됐는지 체크
        {
            for (int arrayIndex = 0; arrayIndex < numberArray.Length; arrayIndex++)
            {
                if (string.IsNullOrEmpty(number?.Trim()))
                { // ctrl + z 체크
                    return false;
                }

                if (number.Equals(numberArray[arrayIndex]))
                { // 입력 성공
                    return true;
                }
            }
            return false;
        }

        private void SearchInterestCourse(ViewElement viewElement) 
        {
            miniViewElement.PrintCourseSearching();

            nextIndex = CheckDivisionNumber(x--, y--, array, viewElement);
            if (nextIndex > 0)
            {
                courseVO.Major = major[nextIndex - 1];
            }

            nextIndex = CheckDivisionNumber(x--, y--, array, viewElement);
            if (nextIndex > 0)
            {
                courseVO.Division = courseDivision[nextIndex - 1];
            }

            nextIndex = CheckDivisionNumber(x--, y--, longArray, viewElement);
            if (nextIndex > 0)
            {
                courseVO.Grade = grade[nextIndex - 1];
            }

            courseVO.NameOfCourse = CheckDivisionName(x--, y--);
            courseVO.NameOfProfessor = CheckDivisionName(x--, y--);
        }

        private void SearchUserInterestCourse()
        {

        }

        public void SelectMenu(int number, ViewElement viewElement) 
        {
            Console.Clear();
            switch (number) ///// 매직넘버 수정하ㅏ기
            {
                case Constant.COURSE_TIME_INQUIRY: // 관심과목 검색 및 추가
                    {
                        SearchInterestCourse(viewElement);
                        break;
                    }
                case Constant.COURSE_OF_INTEREST: // 관심과목 목록
                    {
                        
                        break;
                    }
                case Constant.COURSE_REGISTRATION: // 예상시간표
                    {
                        break;
                    }
                case Constant.MY_COURSE: // 선택 과목 삭제
                    {
                        break;
                    }
            }
        } 
    }
}
