using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CoursePlanPage // 강의시간표(계획서) 조회 (visible)
    {
        private CoursePlanSearchingController coursePlanSearchingController;

        public CoursePlanPage()
        {
            coursePlanSearchingController = new CoursePlanSearchingController(83, 19);
            // 58,  16
        }

        public void ShowCoursePlanSearchingPage(ViewElement viewElement, FirstMenuPage firstMenuPage)
        {
            Console.Clear();
            coursePlanSearchingController.SearchCourseBasic(viewElement, firstMenuPage);


        }
    }
}
