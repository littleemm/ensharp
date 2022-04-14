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
        private string[] numberArray;

        public MenuSelectionController()
        {
            numberArray = new string[] { "1", "2", "3", "4"};
        }

        public string ScanMenuNumber(int x, int y)
        {
            Console.SetCursorPosition(x, y);

            number = Console.ReadLine();

            return number;
        }

        public bool IsMenuNumber(string number)
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
            switch(number)
            {
                case Constant.COURSE_TIME_INQUIRY: // 강의시간표 조회
                    {
                        break;
                    }
                case Constant.COURSE_OF_INTEREST: // 관심과목 담기
                    {
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
