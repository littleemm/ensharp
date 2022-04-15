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
        protected string[] major;
        private string[] longArray;
        protected bool isNumber;
        protected Regex regex;
        protected Regex regexNumber;

        protected MiniViewElement miniViewElement;

        public CourseOfInterestController(int positionX, int positionY) 
        {
            courseVO = new CourseVO("", "", "", "", "", "", "");
            regex = new Regex(@"^[0-9]{6}$");
            regexNumber = new Regex(@"^[0-9]{3}$");
            major = new string[] { "컴퓨터공학과", "소프트웨어학과", "지능기전공학부", "기계항공우주공학부" };
            longArray = new string[] { "1", "2", "3", "4" };

            this.positionX = positionX;
            this.positionY = positionY;

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

        private void SearchInterestCourse(ViewElement viewElement) 
        {
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

        private void SearchUserInterestCourse()
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
        }

        public void SelectMenu(int number, ViewElement viewElement) // 관심과목 담기 관련 메뉴 집합
        {
            Console.Clear();
            switch (number) ///// 매직넘버 수정하ㅏ기
            {
                case Constant.COURSE_TIME_INQUIRY: // 관심과목 검색 및 추가
                    {
                        SearchInterestCourse(viewElement);
                        SearchUserInterestCourse();
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
