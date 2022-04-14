using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CourseOfInterestController : MenuSelectionController
    {

        public void SelectCondition(int x, int y)
        {
            Console.SetCursorPosition(5, 7);
            Console.BackgroundColor = ConsoleColor.Blue;
            ScanMenuNumber(58, 16);
        }
    }
}
