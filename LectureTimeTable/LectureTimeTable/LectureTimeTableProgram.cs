using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    class LectureTimeTableProgram
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(84, 28);
            MainLoginPage mainLoginPage = new MainLoginPage();
            mainLoginPage.ShowLoginPage();
        }
    }
}
