using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    class CourseRegistrationController : CourseOfInterestController
    {
        private CourseVO courseVO;
        private string[] array;

        public CourseRegistrationController(int positionX, int positionY) : base(positionX, positionY)
        {
            courseVO = new CourseVO("", "", "", "", "", "", "");
            array = new string[] { "1", "2", "3", "4", "5" };
        }

        private void SearchRegistrationCourse(ViewElement viewElement)
        {
            miniViewElement.PrintCourseRegistrationSearching();
            menuNumber = CheckNumber(array, viewElement);
            Console.Clear();
            switch (menuNumber)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        miniViewElement.PrintCourseSearchingOfMajor();
                        nextIndex = CheckNumber(array, viewElement);
                        courseVO.Major = major[nextIndex - 1];
                        break;
                    }
                case 3:
                    {
                        miniViewElement.PrintCourseSearchingOfNumber();
                        CheckClassNumber(viewElement);
                        break;
                    }
                case 4:
                    {
                        miniViewElement.PrintCourseSearchingOfName();
                        courseVO.NameOfCourse = CheckName(74, 20, viewElement);
                        break;
                    }
                case 5:
                    {
                        miniViewElement.PrintCourseSearchingOfProfessor();
                        courseVO.NameOfProfessor = CheckName(72, 20, viewElement);
                        break;
                    }
            }

            if (menuNumber == 1)
            {
                
            }
            else
            {
                SearchUserCourse(viewElement);
            }
        }

    
        public new void SelectMenu(int number, ViewElement viewElement) // 수강신청 관련 메뉴 집합
        {
            Console.Clear();
            switch (number) ///// 매직넘버 수정하기
            {
                case Constant.COURSE_TIME_INQUIRY: // 과목 검색 및 추가
                    {
                        SearchRegistrationCourse(viewElement);
                        break;
                    }
                case Constant.COURSE_OF_INTEREST: // 신청 과목 조회
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
