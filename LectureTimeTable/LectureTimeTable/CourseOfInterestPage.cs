using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CourseOfInterestPage // '관심 과목 담기' 선택 후 (visible)
    {   
        private string[] array;
        private string number;

        private CourseOfInterestController courseOfInterestController;

        public CourseOfInterestPage()
        {
            array = new string[] { "1", "2", "3", "4" };

            courseOfInterestController = new CourseOfInterestController(81, 20);
             // 58,  16
        }

        public void ShowCourseOfInterestPage(ViewElement viewElement, NumberCheckingController numberChecking)
        {
            Console.Clear();
            viewElement.PrintCourseOfInterest();
            number = numberChecking.CheckMenuNumber(array, viewElement);
            courseOfInterestController.SelectMenu(int.Parse(number), viewElement);

        }
    }
}
