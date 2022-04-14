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
            Console.SetWindowSize(120, 28);
            MainLoginPage mainLoginPage = new MainLoginPage();
            mainLoginPage.ShowLoginPage();
        }
    }

    // 로그인 가능 계정
    // ID: 20010501
    // PW: 1234
}
