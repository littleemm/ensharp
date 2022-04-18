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
    class CourseOfInterestTimeTable
    {
        public void PrintCourseOfInterestTimeTable()
        {
            try
            {
                var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var path = Path.Combine(outPutDirectory, "Folder\\시간표.xlsx");

                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(path);

                Excel.Sheets sheets = workbook.Sheets;
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;

                Excel.Range cellRange1 = worksheet.get_Range("A1", "E51") as Excel.Range;
                Excel.Range cellRange2 = worksheet.get_Range("F1", "J51") as Excel.Range;
                Excel.Range cellRange3 = worksheet.get_Range("K1", "K51") as Excel.Range;

                Array data1 = cellRange1.Cells.Value2;
                Array data2 = cellRange2.Cells.Value2;
                Array data3 = cellRange3.Cells.Value2;

                for (int i = 1; i < worksheet.UsedRange.Rows.Count; i++)
                {
                    Console.Write(" " + data1.GetValue(i, 1) + "  "); // 시간

                    Console.Write("                 "); 
                    Console.Write("       " + data1.GetValue(i, 3) + "        ");  
                    Console.Write("       " + data1.GetValue(i, 5) + "        "); 
                    Console.Write("       " + data2.GetValue(i, 2) + "        ");  
                    Console.Write("       " + data2.GetValue(i, 4) + "        "); 
                    Console.Write("       " + data3.GetValue(i, 1) + "        "); 

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
