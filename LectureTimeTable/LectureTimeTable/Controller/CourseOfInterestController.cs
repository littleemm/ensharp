using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    class CourseOfInterestController // 관심과목담기 관리 클래스
    {
        CourseVO courseVO;
        private CourseOfInterestList courseOfInterestList;
        private CourseOfInterestTimeTable courseOfInterestTimeTable;

        int positionX;
        int positionY;

        protected int nextIndex;
        protected int menuNumber;
        protected string division;
        protected string number;
        protected string sheetNumber;
        protected string[] major;
        protected bool isNumber;
        protected Regex regex;
        protected Regex regexNumber;

        public Excel.Application application;
        public Excel.Application courseOfInterestApplication;
        protected Excel.Workbook workbook;
        protected Excel.Workbook courseWorkbook;
        protected Excel.Sheets sheets;
        protected Excel.Sheets courseSheets;
        protected Excel.Worksheet worksheet;
        protected Excel.Worksheet courseWorksheet;
        protected MiniViewElement miniViewElement;

        protected int dataNumber;
        protected string memberData;
        protected string dataClassNumber;
        private string[] longArray;

        public CourseOfInterestController(int positionX, int positionY)
        {
            courseVO = new CourseVO("", "", "", "", "", "", "");
            regex = new Regex(@"^[0-9]{6}$");
            regexNumber = new Regex(@"^[0-9]{3}$");
            major = new string[] { "컴퓨터공학과", "소프트웨어학과", "지능기전공학부", "기계항공우주공학부" };
            longArray = new string[] { "1", "2", "3", "4" };
            isNumber = false;
            dataClassNumber = "";

            this.positionX = positionX;
            this.positionY = positionY;
            application = new Excel.Application();
            courseOfInterestApplication = new Excel.Application();
            miniViewElement = new MiniViewElement();
            courseOfInterestList = new CourseOfInterestList();
            courseOfInterestTimeTable = new CourseOfInterestTimeTable();
        }

        protected int CheckNumber(string[] numberArray, ViewElement viewElement) // 번호 입력
        {
            while (isNumber == false)
            {
                number = ScanDivision(positionX, positionY);

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

        protected string CheckName(int x, int y, ViewElement viewElement) // 이름 입력
        {
            division = ScanDivision(x, y);
            if (division.Length == 0)
            {
                return "";
            }

            viewElement.ClearLine(1, x);
            Console.SetCursorPosition(x, y);

            return division;
        }

        protected void CheckClassNumber(ViewElement viewElement) // 학수 번호, 분반 입력 및 체크
        {
            while (isNumber == false)
            {
                Console.SetCursorPosition(62, 18);
                courseVO.Number = Console.ReadLine();

                if (regex.IsMatch(courseVO.Number)) // 학수번호
                {
                    isNumber = true;
                    break;
                }

                viewElement.ClearLine(1, 62);
                Console.SetCursorPosition(62, 18 - 2);
                viewElement.PrintWarningSentence(1, 18 - 2);

            }
            viewElement.ClearLine(3, 16);
            isNumber = false;

            while (isNumber == false)
            {
                Console.SetCursorPosition(62, 20);
                courseVO.NumberClass = Console.ReadLine();

                if (regexNumber.IsMatch(courseVO.NumberClass)) // 분반
                {
                    isNumber = true;
                    break;
                }

                viewElement.ClearLine(1, 62);
                Console.SetCursorPosition(62, 20 - 3);
                viewElement.PrintWarningSentence(1, 20 - 3);
            }

        }

        private string ScanDivision(int inputPositionX, int inputPositionY) // 숫자를 입력 받는 함수
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
        protected int CheckFirstData(CourseVO courseVO) // 엑셀 기준 처음 부분 데이터 체크
        {
            if (courseVO.Major.Length > 0)
            {
                memberData = courseVO.Major;
                return 2; //courseVO.Major;
            }
            if (courseVO.Number.Length > 0)
            {
                memberData = courseVO.Number;
                return 3; // courseVO.Number;
            }
            if (courseVO.NameOfCourse.Length > 0)
            {
                memberData = courseVO.NameOfCourse;
                return 5; // courseVO.NameOfCourse;
            }

            return 0;
        }

        protected int CheckSecondData(CourseVO courseVO) // 엑셀 기준 중반 부분 데이터 체크
        {
            if (courseVO.Division.Length > 0)
            {
                memberData = courseVO.Division;
                return 1; // courseVO.Division;
            }
            return 0;
        }

        protected int CheckThirdData(CourseVO courseVO) // 엑셀 기준 후반 부분 데이터 체크
        {
            if (courseVO.NameOfProfessor.Length > 0)
            {
                memberData = courseVO.NameOfProfessor;
                return 1; // courseVO.NameOfProfessor;
            }

            return 0;
        }
        private void SearchInterestCourse(ViewElement viewElement) // 관심과목 분류 검색
        {
            Console.Clear();
            miniViewElement.PrintInterestCourseSearching();
            menuNumber = CheckNumber(longArray, viewElement);
            Console.Clear();
            switch (menuNumber)
            {
                case 1:
                    {
                        miniViewElement.PrintCourseSearchingOfMajor();
                        nextIndex = CheckNumber(longArray, viewElement);
                        courseVO.Major = major[nextIndex - 1];
                        break;
                    }
                case 2:
                    {
                        miniViewElement.PrintCourseSearchingOfNumber();
                        CheckClassNumber(viewElement);
                        break;
                    }
                case 3:
                    {
                        miniViewElement.PrintCourseSearchingOfName();
                        courseVO.NameOfCourse = CheckName(74, 20, viewElement);
                        break;
                    }
                case 4:
                    {
                        miniViewElement.PrintCourseSearchingOfProfessor();
                        courseVO.NameOfProfessor = CheckName(72, 20, viewElement);
                        break;
                    }
            }

        }

        protected void SearchUserCourse(ViewElement viewElement) // 검색 기반 
        {
            Console.Clear();
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var path = Path.Combine(outPutDirectory, "Folder\\2022년도 1학기 강의시간표.xlsx");

            workbook = application.Workbooks.Open(path);
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
            for (int i = 2; i < 186; i++)
            {
                if (sheetNumber == data1.GetValue(i, 1).ToString())
                { // 관심과목 담기 성공
                    AddUserCourseOfInterest(i, data1, data2, data3);
                    AddToTimeTable(i, data1, data2);
                    miniViewElement.PrintSuccessMessage(3, 6);
                    break;
                }
                if (i == 185)
                {
                    miniViewElement.PrintEmptyMessage(3, 6);
                }
            }

            application.Workbooks.Close();
            application.Quit();
        }

        protected void PrintDataMajorOrCourse(int dataNumber, Array data1, Array data2, Array data3)
        {
            for (int i = 2; i < 186; i++)
            {
                if (data1.GetValue(i, dataNumber).Equals(memberData))
                {
                    PrintData(i, data1, data2, data3);
                }
            }
        }

        protected void PrintDataNumber(int dataNumber, Array data1, Array data2, Array data3)
        {
            for (int i = 2; i < 186; i++)
            {
                if (data1.GetValue(i, dataNumber).Equals(memberData) && data1.GetValue(i, dataNumber).Equals(courseVO.NumberClass))
                {
                    PrintData(i, data1, data2, data3);
                }
            }
        }

        protected void PrintDataDivisionOrName(int dataNumber, Array data1, Array data2, Array data3)
        {
            for (int i = 2; i < 186; i++)
            {
                if (data2.GetValue(i, dataNumber).Equals(memberData) || data3.GetValue(i, dataNumber).Equals(memberData))
                {
                    PrintData(i, data1, data2, data3);
                }
            }
        }

        protected void PrintData(int i, Array data1, Array data2, Array data3)
        {
            Console.Write(" " + data1.GetValue(i, 1) + "  "); // NO
            Console.Write(" " + data1.GetValue(i, 2) + "  "); // 전공 <
            Console.Write(" " + data1.GetValue(i, 3) + "  "); // 학수번호 <
            Console.Write(" " + data1.GetValue(i, 4) + "  "); // 분반 <<
            Console.Write(" " + data1.GetValue(i, 5) + "  "); // 과목명 <

            Console.Write(" " + data2.GetValue(i, 1) + "  "); // 이수구분 <
            Console.Write(" " + data2.GetValue(i, 2) + "  "); // 학년
            Console.Write(" " + data2.GetValue(i, 3) + "  "); // 학점
            Console.Write(" " + data2.GetValue(i, 4) + "  "); // 시간
            Console.Write(" " + data2.GetValue(i, 5) + "  "); // 장소

            Console.Write(" " + data3.GetValue(i, 1) + "  "); // 교수명  <
            Console.Write(" " + data3.GetValue(i, 2) + "  "); // 언어

            Console.WriteLine();
        }

        protected void AddUserCourseOfInterest(int i, Array data1, Array data2, Array data3) // 관심과목 추가
        {
            try {
                var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var path = Path.Combine(outPutDirectory, "Folder\\관심과목목록.xlsx");

                courseWorkbook = courseOfInterestApplication.Workbooks.Open(path);
                courseSheets = courseWorkbook.Sheets;
                courseWorksheet = courseSheets["Sheet1"] as Excel.Worksheet;

                Excel.Range cellRange1 = courseWorksheet.Range["A1", "E25"];
                Excel.Range cellRange2 = courseWorksheet.Range["F1", "J25"];
                Excel.Range cellRange3 = courseWorksheet.Range["K1", "L25"];

                int row = courseWorksheet.UsedRange.Rows.Count + 1;
                cellRange1[row, 1].Value = data1.GetValue(i, 1).ToString();
                cellRange1[row, 2].Value = data1.GetValue(i, 2).ToString();
                cellRange1[row, 3].Value = data1.GetValue(i, 3).ToString();
                cellRange1[row, 4].Value = data1.GetValue(i, 4).ToString();
                cellRange1[row, 5].Value = data1.GetValue(i, 5).ToString();

                cellRange2[row, 1].Value = data2.GetValue(i, 1).ToString();
                cellRange2[row, 2].Value = data2.GetValue(i, 2).ToString();
                cellRange2[row, 3].Value = data2.GetValue(i, 3).ToString();
                cellRange2[row, 4].Value = data2.GetValue(i, 4).ToString();
                cellRange2[row, 5].Value = data2.GetValue(i, 5).ToString();

                cellRange3[row, 1].Value = data3.GetValue(i, 1).ToString();
                cellRange3[row, 2].Value = data3.GetValue(i, 2).ToString();
                

                courseWorkbook.Save();
                courseOfInterestApplication.Workbooks.Close();
                courseOfInterestApplication.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        private void DeleteUserCourseOfInterest() // 관심과목 삭제
        {
            try
            {
                var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var path = Path.Combine(outPutDirectory, "Folder\\관심과목목록.xlsx");

                courseWorkbook = courseOfInterestApplication.Workbooks.Open(path);
                courseSheets = courseWorkbook.Sheets;
                courseWorksheet = courseSheets["Sheet1"] as Excel.Worksheet;

                Excel.Range cellRange1 = courseWorksheet.Range["A1", "E25"];
                Excel.Range cellRange2 = courseWorksheet.Range["F1", "J25"];
                Excel.Range cellRange3 = courseWorksheet.Range["K1", "L25"];

                miniViewElement.PrintInterestCourse();
                courseOfInterestList.PrintCourseOfInterestList();

                Console.SetCursorPosition(45, 4);
                string row = Console.ReadLine();

                for (int i = 2; i <= courseWorksheet.UsedRange.Rows.Count; i++)
                {
                    if (cellRange1[i, 1].Value.ToString() == row)
                    {
                        cellRange1[row, 1].Value = "";
                        cellRange1[row, 2].Value = "";
                        cellRange1[row, 3].Value = "";
                        cellRange1[row, 4].Value = "";
                        cellRange1[row, 5].Value = "";

                        cellRange2[row, 1].Value = "";
                        cellRange2[row, 2].Value = "";
                        cellRange2[row, 3].Value = "";
                        cellRange2[row, 4].Value = "";
                        cellRange2[row, 5].Value = "";

                        cellRange3[row, 1].Value = "";
                        cellRange3[row, 2].Value = "";

                        miniViewElement.PrintDeleteMessage(3, 6);
                        break;
                    }
                    if (i == courseWorksheet.UsedRange.Rows.Count)
                    {
                        miniViewElement.PrintWarningMessage(3, 6);
                    }
                }

                courseWorkbook.Save();
                courseOfInterestApplication.Workbooks.Close();
                courseOfInterestApplication.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddToTimeTable(int i, Array data1, Array data2) // 시간표에 관심과목 추가
        {
            try
            {
                var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var path = Path.Combine(outPutDirectory, "Folder\\시간표.xlsx");

                Excel.Application applicationTimeTable = new Excel.Application();
                Excel.Workbook workbookTimeTable = applicationTimeTable.Workbooks.Open(path);
                Excel.Sheets sheetsTimeTable = workbookTimeTable.Sheets;
                Excel.Worksheet worksheetTimeTable = sheetsTimeTable["Sheet1"] as Excel.Worksheet;

                Excel.Range cellRange1 = worksheetTimeTable.get_Range("A1", "E51") as Excel.Range;
                Excel.Range cellRange2 = worksheetTimeTable.get_Range("F1", "J51") as Excel.Range;
                Excel.Range cellRange3 = worksheetTimeTable.get_Range("K1", "K51") as Excel.Range;

                Array timeData1 = cellRange1.Cells.Value2;

                string course = data1.GetValue(i, 5).ToString();
                string lectureRoom = data2.GetValue(i, 5).ToString();
                string time = data2.GetValue(i, 4).ToString();
                int column, startRow, endRow;

                switch (time.Length) // 
                {
                    case 13: // 하루 수업
                        {
                            column = ConfirmDay(time[0]);
                            startRow = ConfirmTime(timeData1, time.Substring(2, 5), 0);
                            endRow = ConfirmTime(timeData1, time.Substring(8, 5), 6);
                            AddCourse(course, lectureRoom, column, startRow, endRow, cellRange1, cellRange2, cellRange3);
                            break;
                        }
                    case 15: // 주 2일 수업, 시간 같음
                        {
                            column = ConfirmDay(time[0]);
                            startRow = ConfirmTime(timeData1, time.Substring(2, 5), 0);
                            endRow = ConfirmTime(timeData1, time.Substring(8, 5), 6);
                            AddCourse(course, lectureRoom, column, startRow, endRow, cellRange1, cellRange2, cellRange3);

                            column = ConfirmDay(time[2]);
                            AddCourse(course, lectureRoom, column, startRow, endRow, cellRange1, cellRange2, cellRange3);
                            break;
                        }
                    case 28: // 주 2일 수업, 시간 다름
                        {
                            column = ConfirmDay(time[0]);
                            startRow = ConfirmTime(timeData1, time.Substring(2, 5), 0);
                            endRow = ConfirmTime(timeData1, time.Substring(8, 5), 6);
                            AddCourse(course, lectureRoom, column, startRow, endRow, cellRange1, cellRange2, cellRange3);

                            column = ConfirmDay(time[15]);
                            startRow = ConfirmTime(timeData1, time.Substring(17, 5), 0);
                            endRow = ConfirmTime(timeData1, time.Substring(23, 5), 6);
                            AddCourse(course, lectureRoom, column, startRow, endRow, cellRange1, cellRange2, cellRange3);
                            break;
                        }
                    case 0:
                        {
                            cellRange1[50, 1].Value = course;
                            break;
                        }
                }
                workbookTimeTable.Save();
                applicationTimeTable.Workbooks.Close();
                applicationTimeTable.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private int ConfirmDay(char day) // 요일 체크
        {
            switch(day)
            {
                case '월':
                    {
                        return 3;
                    }
                case '화':
                    {
                        return 5;
                    }
                case '수':
                    {
                        return 2;
                    }
                case '목':
                    {
                        return 4;
                    }
                case '금':
                    {
                        return 1;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private int ConfirmTime(Array timeData, string time, int startString)
        { // 시간 체크
            for (int i=2;i<=48;i+=2)
            {
                if (timeData.GetValue(i, 1).ToString().Substring(startString, 5) == time) 
                {
                    return i;
                }
            }

            return 0;
        }

        private void AddCourse(string course, string lectureRoom, int column, int startRow, int endRow, Excel.Range cellRange1, Excel.Range cellRange2, Excel.Range cellRange3)
        {
            if (column == 3 || column == 5) 
            {
                for (int i = startRow; i <= endRow; i += 2)
                {
                    cellRange1[i, column].Value = course; 
                }
                for (int i = startRow + 1; i <= endRow + 1; i += 2) 
                {
                    cellRange1[i, column].Value = lectureRoom;
                }
            }

            else if (column == 2 || column == 4)
            {
                for (int i = startRow; i <= endRow; i += 2)
                {
                    cellRange2[i, column].Value = course;
                }
                for (int i = startRow + 1; i <= endRow + 1; i += 2)
                {
                    cellRange2[i, column].Value = lectureRoom;
                }
            }

            else if (column == 1)
            {
                for (int i = startRow; i <= endRow; i += 2)
                {
                    cellRange3[i, column].Value = course;
                }
                for (int i = startRow + 1; i <= endRow + 1; i += 2)
                {
                    cellRange3[i, column].Value = lectureRoom;
                }
            }
        } 

        

        

        public void SelectMenu(int number, ViewElement viewElement) // 관심과목 담기 메인 메뉴
        {
            Console.Clear();
            switch (number) ///// 매직넘버 수정하기
            {
                case Constant.COURSE_TIME_INQUIRY: // 관심과목 검색 및 추가
                    {
                        SearchInterestCourse(viewElement);
                        SearchUserCourse(viewElement);
                        break;
                    }
                case Constant.COURSE_OF_INTEREST: // 관심과목 목록
                    {
                        miniViewElement.PrintInterestCourseMessage();
                        courseOfInterestList.PrintCourseOfInterestList();
                        break;
                    }
                case Constant.COURSE_REGISTRATION: // 예상시간표
                    {
                        miniViewElement.PrintInterestTimeTableMessage();
                        courseOfInterestTimeTable.PrintCourseOfInterestTimeTable();
                        break;
                    }
                case Constant.MY_COURSE: // 선택 과목 삭제
                    {
                        DeleteUserCourseOfInterest();
                        break;
                    }
            }
        }




    }
}
