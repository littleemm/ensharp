using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    class CourseOfInterestList
    {
        public void PrintCourseOfInterestList()
        {
            try
            {
                var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var path = Path.Combine(outPutDirectory, "Folder\\관심과목목록.xlsx");

                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(path);

                Excel.Sheets sheets = workbook.Sheets;
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;  

                Excel.Range cellRange1 = worksheet.Range["A1", "E25"];
                Excel.Range cellRange2 = worksheet.Range["F1", "J25"];
                Excel.Range cellRange3 = worksheet.Range["K1", "L25"];

                Array data1 = cellRange1.Cells.Value2;
                Array data2 = cellRange2.Cells.Value2;
                Array data3 = cellRange3.Cells.Value2;

                for (int i = 1; i < worksheet.UsedRange.Rows.Count + 1; i++)
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


                application.Workbooks.Close();
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
