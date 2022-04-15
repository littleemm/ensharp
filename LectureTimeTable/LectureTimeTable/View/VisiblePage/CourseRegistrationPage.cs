using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CourseRegistrationPage : CourseOfInterestPage
    {
        CourseRegistrationController courseRegistrationController;

        public CourseRegistrationPage()
        {
            courseRegistrationController = new CourseRegistrationController(70, 19);
        }
        public void ShowCourseRegistrationPage(ViewElement viewElement, NumberCheckingController numberChecking)
        {
            Console.Clear();
            viewElement.PrintCourseRegistration();
            number = numberChecking.CheckMenuNumber(array, viewElement);
            courseRegistrationController.SelectMenu(int.Parse(number), viewElement);
        }
    }
}
