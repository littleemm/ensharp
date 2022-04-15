using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CourseOfInterestPage // '관심 과목 담기' 선택 후 (visible)
    {   
        protected string[] array;
        protected string number;

        private CourseOfInterestController courseOfInterestController;

        public CourseOfInterestPage()
        {
            array = new string[] { "1", "2", "3", "4" };

            courseOfInterestController = new CourseOfInterestController(70, 19);

           
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
