using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CourseOfInterestPage // 관심 과목 담기 선택 후 진입한 페이지 (visible)
    {
        public void ShowCourseOfInterestPage(ViewElement viewElement)
        {
            viewElement.PrintCourseOfInterest();

        }
    }
}
