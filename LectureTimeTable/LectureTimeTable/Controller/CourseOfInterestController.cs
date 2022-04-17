using System;
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
            if (courseVO.Division.Length > 0)
            {
                memberData = courseVO.Division;
                return 6; // courseVO.Division;
            }
            if (courseVO.NameOfProfessor.Length > 0)
            {
                memberData = courseVO.NameOfProfessor;
                return 11; // courseVO.NameOfProfessor;
            }

            return 0;
        }

        private void SearchInterestCourse(ViewElement viewElement) // 관심과목 분류 검색
        {
            Console.Clear();
            miniViewElement.PrintInterestCourseSearching();
            menuNumber = CheckNumber(longArray, viewElement);
            Console.Clear();
            switch (menuNumber) {
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
            try
            {
                workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2022년도 1학기 강의시간표.xlsx");
                sheets = workbook.Sheets;
                worksheet = sheets["Sheet1"] as Excel.Worksheet;

                Excel.Range cellRange = worksheet.get_Range("A1", "L185");

                object[,] courseData = (object[,])cellRange.get_Value();


                miniViewElement.PrintSelectedCourseOfInterest();

                if (CheckFirstData(courseVO) > 0)
                {
                    dataNumber = CheckFirstData(courseVO);
                }

                if (dataNumber == 3)
                {
                    dataClassNumber = courseVO.NumberClass;
                }

                for (int j = 1; j < 12; j++)
                {
                    Console.Write(" " + courseData[1, j] + " ");
                }

                Console.WriteLine(); // 시트 맨위 출력

                // 경우에 따라 데이터 출력 
                switch (dataNumber)
                {
                    case 3:
                        {
                            PrintDataNumber(dataNumber, courseData);
                            break;
                        }
                    default:
                        {
                            PrintDataCourse(dataNumber, courseData);
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
                    if (sheetNumber.Equals(courseData[1, i]))
                    {
                        AddUserCourseOfInterest(sheetNumber, i, courseData);
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
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void PrintDataCourse(int dataNumber, object[,] courseData)
        { 
            for (int i = 2; i < 186; i++)
            {
                if (courseData[i, dataNumber].Equals(memberData))
                {
                    PrintData(i, courseData);
                }
            }
        }

        protected void PrintDataNumber(int dataNumber, object[,] courseData)
        {
            for (int i = 2; i < 186; i++)
            {
                if (courseData[i, dataNumber].Equals(memberData) && courseData[i, dataNumber].Equals(courseVO.NumberClass))
                {
                    PrintData(i, courseData);
                }
            }
        }

        protected void PrintData(int i, object[,] courseData)
        {
            for (int j = 1; j <= 12; i++) 
            {
                Console.Write(" " + courseData.GetValue(i, j) + " ");
            }
            Console.WriteLine();
        }

        protected void AddUserCourseOfInterest(string courseNumber, int i, object[,] courseData) // 관심과목 추가
        {
            if (courseData[i, 1].Equals(courseNumber))
            {
                try
                {
                    courseWorkbook = courseOfInterestApplication.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\관심과목목록.xlsx");
                    courseSheets = courseWorkbook.Sheets;
                    courseWorksheet = courseSheets["Sheet1"] as Excel.Worksheet;

                    Excel.Range cellInterest = courseWorksheet.get_Range("A1", "L185");

                    for (int j = 1; j <= 12; j++)
                    {
                        cellInterest[courseWorksheet.UsedRange.Rows.Count + 1, j] = courseData[i, 1].ToString();
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
