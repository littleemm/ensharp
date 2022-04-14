using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CourseOfInterestController 
    {
        int positionX;
        int positionY;
        private string division;

        private MiniViewElement miniViewElement;

        
        public CourseOfInterestController(int positionX, int positionY) 
        {
            this.positionX = positionX;
            this.positionY = positionY;

            miniViewElement = new MiniViewElement();
        }

        public void CheckDivisionNumber(string[] numberArray, int x, int y)
        {
            SelectCondition(x, y);
            ScanNumberOrKey(numberArray, positionX, positionY);
        }

        public void CheckDivisionName(int x, int y)
        {
            SelectCondition(x, y);

        }

        public void SelectCondition(int x, int y)
        {
            Console.SetCursorPosition(5, 7);
            Console.BackgroundColor = ConsoleColor.Blue;
            
        }

        public void ScanNumberOrKey(string[] numberArray, int x, int y) // 
        {
            Console.SetCursorPosition(x, y);
        }

        public void ScanName(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            division = Console.ReadLine();
            if (division.Length == 0) // 매직넘버 ENTER
            {

            }
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

        public void SelectMenu(int number) 
        {
            Console.Clear();
            switch (number) ///// 매직넘버 수정하ㅏ기
            {
                case Constant.COURSE_TIME_INQUIRY: // 관심과목 검색 및 추가
                    {
                        miniViewElement.PrintCourseSearching();
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
