using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    class CourseRegistrationController : CourseOfInterestController
    {
        private CourseVO courseVO;
        private string[] array;

        public CourseRegistrationController(int positionX, int positionY) : base(positionX, positionY)
        {
            courseVO = new CourseVO("", "", "", "", "", "", "");
            array = new string[] { "1", "2", "3", "4", "5" };
        }

        private void SearchRegistrationCourse(ViewElement viewElement)
        {
            miniViewElement.PrintCourseRegistrationSearching();
            menuNumber = CheckNumber(array, viewElement);
            Console.Clear();
            switch (menuNumber)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        miniViewElement.PrintCourseSearchingOfMajor();
                        nextIndex = CheckNumber(array, viewElement);
                        courseVO.Major = major[nextIndex - 1];
                        break;
                    }
                case 3:
                    {
                        miniViewElement.PrintCourseSearchingOfNumber();
                        CheckClassNumber(viewElement);
                        break;
                    }
                case 4:
                    {
                        miniViewElement.PrintCourseSearchingOfName();
                        courseVO.NameOfCourse = CheckName(74, 20, viewElement);
                        break;
                    }
                case 5:
                    {
                        miniViewElement.PrintCourseSearchingOfProfessor();
                        courseVO.NameOfProfessor = CheckName(72, 20, viewElement);
                        break;
                    }
            }

            if (menuNumber == 1)
            {
                
            }
            else
            {
                SearchUserCourse(viewElement);
            }
        }

        protected new void SearchUserCourse(ViewElement viewElement) // 검색 기반 
        {
            Console.Clear();
            workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2022년도 1학기 강의시간표.xlsx");
            sheets = workbook.Sheets;
            worksheet = sheets["Sheet1"] as Excel.Worksheet;

            Excel.Range cellRange1 = worksheet.get_Range("A1", "E185") as Excel.Range;
            Excel.Range cellRange2 = worksheet.get_Range("F1", "J185") as Excel.Range;
            Excel.Range cellRange3 = worksheet.get_Range("K1", "L185") as Excel.Range;

            Array data1 = cellRange1.Cells.Value2;
            Array data2 = cellRange2.Cells.Value2;
            Array data3 = cellRange3.Cells.Value2;

            miniViewElement.PrintSelectedCourseOfInterest();

            if (CheckFirstData(courseVO) > 0)
            {
                dataNumber = CheckFirstData(courseVO);
            }
            if (CheckSecondData(courseVO) > 0)
            {
                dataNumber = CheckSecondData(courseVO);
            }
            if (CheckThirdData(courseVO) > 0)
            {
                dataNumber = CheckThirdData(courseVO);
            }

            if (dataNumber == 3)
            {
                dataClassNumber = courseVO.NumberClass;
            }

            for (int j = 1; j < 5; j++)
            {
                Console.Write(" " + data1.GetValue(1, j) + " ");
            }
            Console.Write("   " + data1.GetValue(1, 5) + "       " + data2.GetValue(1, 1) + "   " + data2.GetValue(1, 2) + " " + data2.GetValue(1, 3) + " " + data2.GetValue(1, 4) + "  " + data2.GetValue(1, 5) + "  " + data3.GetValue(1, 1) + " " + data3.GetValue(1, 2));
            Console.WriteLine(); // 시트 맨위 출력

            // 경우에 따라 데이터 출력 
            switch (dataNumber)
            {
                case 2:
                    {
                        PrintDataMajorOrCourse(dataNumber, data1, data2, data3);
                        break;
                    }
                case 5:
                    {
                        PrintDataMajorOrCourse(dataNumber, data1, data2, data3);
                        break;
                    }
                case 3:
                    {
                        PrintDataNumber(dataNumber, data1, data2, data3);
                        break;
                    }
                case 1:
                    {
                        PrintDataDivisionOrName(dataNumber, data1, data2, data3);
                        break;
                    }
            }

            memberData = "";
            dataNumber = 0;
            courseVO = new CourseVO("", "", "", "", "", "", "");

            Console.SetCursorPosition(45, 4);
            sheetNumber = Console.ReadLine();
            for (int i = 0; i < 186; i++)
            {
                if (sheetNumber.Equals(cellRange1[1, i].Value.ToString()))
                {
                    AddUserCourseOfInterest(sheetNumber, i, data1, data2, data3);
                    miniViewElement.PrintSuccessMessage(5, 6);
                    break;
                }
                if (i == 185)
                {
                    miniViewElement.PrintEmptyMessage(5, 6);
                }
            }

            application.Workbooks.Close();
            application.Quit();
        }

        public new void SelectMenu(int number, ViewElement viewElement) // 수강신청 관련 메뉴 집합
        {
            Console.Clear();
            switch (number) ///// 매직넘버 수정하기
            {
                case Constant.COURSE_TIME_INQUIRY: // 과목 검색 및 추가
                    {
                        SearchRegistrationCourse(viewElement);
                        break;
                    }
                case Constant.COURSE_OF_INTEREST: // 신청 과목 조회
                    {

                        break;
                    }
                case Constant.COURSE_REGISTRATION: // 예상시간표
                    {
                        break;
                    }
                case Constant.MY_COURSE: // 선택 과목 삭제
                    {
                        break;
                    }
            }
        }


    }
}
