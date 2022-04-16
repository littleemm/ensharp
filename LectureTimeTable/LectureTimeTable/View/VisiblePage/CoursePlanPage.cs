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
        private ConsoleKeyInfo consoleKey;
        private bool isKey;

        public CoursePlanPage()
        {
            isKey = false;
            coursePlanSearchingController = new CoursePlanSearchingController(83, 19);
            // 58,  16
        }

        public void ShowCoursePlanSearchingPage(ViewElement viewElement, FirstMenuPage firstMenuPage)
        {
            Console.Clear();
            coursePlanSearchingController.SearchCourseBasic(viewElement, firstMenuPage);

            while (isKey == false)
            {
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.F1)
                {
                    ShowCoursePlanSearchingPage(viewElement, firstMenuPage);
                    break;
                }
                if (consoleKey.Key == ConsoleKey.Escape) // 종료
                {
                    break;
                }

                isKey = false;
            }
        }
    }
}
