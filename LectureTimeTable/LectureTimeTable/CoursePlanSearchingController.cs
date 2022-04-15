using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    class CoursePlanSearchingController
    {
        CourseVO courseVO;

        int positionX;
        int positionY;

        private int nextIndex;
        private string division;
        private string number;
        private string[] courseDivision;
        private string[] grade;
        private string[] major;
        private string[] array;
        private string[] longArray;
        private bool isNumber;
        private ConsoleKeyInfo consoleKey;

        private MiniViewElement miniViewElement;


        public CoursePlanSearchingController(int positionX, int positionY)
        {
            courseVO = new CourseVO("", "", "", "", "", "", "");
            major = new string[] { "컴퓨터공학과", "소프트웨어학과", "지능기전공학부" };
            grade = new string[] { "1", "2", "3", "4" };
            courseDivision = new string[] { "공통교양필수", "전공필수", "전공선택" };

            array = new string[] { "1", "2", "3" };
            longArray = new string[] { "1", "2", "3", "4" };

            this.positionX = positionX;
            this.positionY = positionY;

            miniViewElement = new MiniViewElement();
        }

        public int CheckDivisionNumber(string[] numberArray, ViewElement viewElement) // 번호 입력
        {
            Console.ResetColor();
            while (isNumber == false)
            {
                number = ScanDivision(positionX, positionY);

                if (number.Length == 0)
                {
                    return 0;
                } // ENTER 쳤음

                isNumber = IsMenuNumber(number, numberArray, viewElement);

                if (isNumber == false)
                {
                    viewElement.ClearLine(1, positionX);
                    Console.SetCursorPosition(positionX, positionY);
                    viewElement.PrintWarning(1, positionY - 2);
                }
            }

            isNumber = false;

            return int.Parse(number);
        }

        public string CheckDivisionName(ViewElement viewElement) // 이름 입력
        {
            division = ScanDivision(positionX, positionY);
            if (division.Length == 0)
            {
                return "";
            }

            viewElement.ClearLine(1, positionX);
            Console.SetCursorPosition(positionX, positionY);

            return division;
        }

        public string ScanDivision(int inputPositionX, int inputPositionY) // 숫자 혹은 엔터를 입력 받는 함수
        {
            Console.SetCursorPosition(inputPositionX, inputPositionY);
            division = Console.ReadLine();

            return division;
        }


        private bool IsMenuNumber(string number, string[] numberArray, ViewElement viewElement) // 제한된 범위의 숫자가 입력됐는지 체크
        {
            for (int arrayIndex = 0; arrayIndex < numberArray.Length; arrayIndex++)
            {
                if (string.IsNullOrEmpty(number?.Trim()))
                { // ctrl + z 체크
                    return false;
                }

                if (number.Equals(numberArray[arrayIndex]))
                { // 입력 성공
                    Console.SetCursorPosition(1, 18);
                    viewElement.ClearLine(0, 0);
                    return true;
                }
            }
            return false;
        }

        private void GobackOrGoExit(FirstMenuPage firstMenuPage)
        {
            Console.SetCursorPosition(positionX, positionY);
            consoleKey = Console.ReadKey(true);
            if (consoleKey.Key == ConsoleKey.F1)
            {
                firstMenuPage.ShowMenuSelection(firstMenuPage);
            }
            Console.SetCursorPosition(positionX, positionY);
        }

        private void SearchCourse(ViewElement viewElement, FirstMenuPage firstMenuPage)
        {
            miniViewElement.PrintCourseSearching();

            GobackOrGoExit(firstMenuPage);

            nextIndex = CheckDivisionNumber(array, viewElement);
            if (nextIndex > 0)
            {
                courseVO.Major = major[nextIndex - 1];
            }

            GobackOrGoExit(firstMenuPage);

            nextIndex = CheckDivisionNumber(array, viewElement);
            if (nextIndex > 0)
            {
                courseVO.Division = courseDivision[nextIndex - 1];
            }

            GobackOrGoExit(firstMenuPage);

            nextIndex = CheckDivisionNumber(longArray, viewElement);
            if (nextIndex > 0)
            {
                courseVO.Grade = grade[nextIndex - 1];
            }

            GobackOrGoExit(firstMenuPage);

            courseVO.NameOfCourse = CheckDivisionName(viewElement);

            GobackOrGoExit(firstMenuPage);
            courseVO.NameOfProfessor = CheckDivisionName(viewElement);
            GobackOrGoExit(firstMenuPage);
        }

        private void SearchUserCourse(ViewElement viewElement, FirstMenuPage firstMenuPage)
        {
            Console.Clear();
            try
            {
                Excel.Application application = new Excel.Application();

                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2022년도 1학기 강의시간표.xlsx");

                Excel.Sheets sheets = workbook.Sheets;

                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;

                Excel.Range cellRange1 = worksheet.get_Range("A1", "E5") as Excel.Range;
                Excel.Range cellRange2 = worksheet.get_Range("F1", "J5") as Excel.Range;
                Excel.Range cellRange3 = worksheet.get_Range("K1", "L5") as Excel.Range;

                Array data1 = cellRange1.Cells.Value2;
                Array data2 = cellRange2.Cells.Value2;
                Array data3 = cellRange3.Cells.Value2;

                for (int j = 1; j < 5; j++)
                {
                    Console.Write(" " + data1.GetValue(1, j) + " ");
                }
                Console.Write("   " + data1.GetValue(1, 5) + "       " + data2.GetValue(1, 1) + "   " + data2.GetValue(1, 2) + " " + data2.GetValue(1, 3) + " " + data2.GetValue(1, 4) + "  " + data2.GetValue(1, 5) + "  " + data3.GetValue(1, 1) + " " + data3.GetValue(1, 2));
                Console.WriteLine();

                // 데이터 출력
                for (int i = 2; i < 6; i++)
                {
                    for (int j = 1; j < 6; j++)
                    {
                        Console.Write(" " + data1.GetValue(i, j) + "  ");
                    }

                    for (int j = 1; j < 6; j++)
                    {
                        Console.Write(" " + data2.GetValue(i, j) + "  ");
                    }

                    for (int j = 1; j < 3; j++)
                    {
                        Console.Write(" " + data3.GetValue(i, j) + "  ");
                    }
                    Console.WriteLine();
                }

                // 모든 워크북 닫기
                application.Workbooks.Close();

                // application 종료
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.SetCursorPosition(0, 0);
            GobackOrGoExit(firstMenuPage);
        }

        public void SearchCourseBasic(ViewElement viewElement, FirstMenuPage firstMenuPage)
        {
            SearchCourse(viewElement, firstMenuPage);
            SearchUserCourse(viewElement, firstMenuPage);
        }
    }
}
