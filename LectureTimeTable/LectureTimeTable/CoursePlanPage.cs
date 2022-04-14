using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CoursePlanPage
    {
        private CoursePlanSearchingController coursePlanSearchingController;

        public CoursePlanPage()
        {
            coursePlanSearchingController = new CoursePlanSearchingController(81, 19);
            // 58,  16
        }

        public void ShowCoursePlanSearchingPage(ViewElement viewElement)
        {
            Console.Clear();
            coursePlanSearchingController.SearchCourseBasic(viewElement);

        }
    }
}
