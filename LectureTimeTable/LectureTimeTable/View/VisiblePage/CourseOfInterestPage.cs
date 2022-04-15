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
        private ConsoleKeyInfo consoleKey;
        private bool isKey;

        public CourseOfInterestPage()
        {
            array = new string[] { "1", "2", "3", "4" };

            isKey = false;
            courseOfInterestController = new CourseOfInterestController(70, 19);

           
        }

        public void ShowCourseOfInterestPage(ViewElement viewElement, NumberCheckingController numberChecking)
        {
            Console.Clear();
            viewElement.PrintCourseOfInterest();
            number = numberChecking.CheckMenuNumber(array, viewElement);
            courseOfInterestController.SelectMenu(int.Parse(number), viewElement);

            while (isKey == false)
            {
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.F1)
                {
                    ShowCourseOfInterestPage(viewElement, numberChecking);
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
