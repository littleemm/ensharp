using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class SelectionController
    {
        CoursePlanPage coursePlanPage;
        CourseOfInterestPage courseOfInterestPage;

        public SelectionController()
        {
            coursePlanPage = new CoursePlanPage();
            courseOfInterestPage = new CourseOfInterestPage();
        }
        public void SelectMenu(int number, ViewElement viewElement, NumberCheckingController numberChecking, FirstMenuPage firstMenuPage) // 다음 메뉴 고르기
        {
            switch (number)
            {
                case Constant.COURSE_TIME_INQUIRY: // 강의시간표 조회
                    {
                        coursePlanPage.ShowCoursePlanSearchingPage(viewElement, firstMenuPage);
                        break;
                    }
                case Constant.COURSE_OF_INTEREST: // 관심과목 담기
                    {
                        courseOfInterestPage.ShowCourseOfInterestPage(viewElement, numberChecking);
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
