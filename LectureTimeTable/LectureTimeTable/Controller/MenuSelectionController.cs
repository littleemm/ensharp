using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class MenuSelectionController
    {
        private string number;
        private bool isMenuNumber;

        private CourseOfInterestPage courseOfInterestPage;
        private ViewElement viewElement;

        public MenuSelectionController()
        {
            courseOfInterestPage = new CourseOfInterestPage();
            viewElement = new ViewElement();
        }

        public void CheckMenuNumber(string[] numberArray) // 체크해서 넘어가는 로직
        {
            viewElement.PrintSystemPage();

            while (isMenuNumber == false)
            {
                number = ScanMenuNumber(55, 16);
                isMenuNumber = IsMenuNumber(number, numberArray);

                if (isMenuNumber == false)
                {
                    viewElement.ClearLine(1, 55);
                    Console.SetCursorPosition(55, 16);
                    viewElement.PrintWarning(1, 14);
                }
            }

            isMenuNumber = false;
            SelectMenu(int.Parse(number), viewElement);
        }

        public string ScanMenuNumber(int x, int y) // 읽기
        {
            Console.SetCursorPosition(x, y);

            number = Console.ReadLine();

            return number;
        }

        public bool IsMenuNumber(string number, string[] numberArray) // 제한된 범위의 숫자가 입력됐는지 체크
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

        public void SelectMenu(int number, ViewElement viewElement) // 다음 메뉴 고르기
        {
            switch(number)
            {
                case Constant.COURSE_TIME_INQUIRY: // 강의시간표 조회
                    {
                        
                        break;
                    }
                case Constant.COURSE_OF_INTEREST: // 관심과목 담기
                    {
                        courseOfInterestPage.ShowCourseOfInterestPage(viewElement);
                        break;
                    }
                case Constant.COURSE_REGISTRATION: // 수강신청
                    {
                        break;
                    }
                case Constant.MY_COURSE: // 수강 내역
                    {
                        break;
                    }
            }
        }
    }
}
