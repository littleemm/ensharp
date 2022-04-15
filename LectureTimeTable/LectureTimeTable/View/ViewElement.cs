using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class ViewElement // 요소 관련 프린트
    {
        public void PrintMainPage()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine();
            Console.WriteLine("                                                | 학사정보시스템 |  LOGIN  |                                   ");
            Console.WriteLine();
            Console.WriteLine("                                               ID(8자리) : ");
            Console.WriteLine();
            Console.WriteLine("                                               PW(4자리) : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      =============================================================================== ");
        }

        public void PrintSystemPage()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                § 강좌 조회 및 수강신청 §                             ");
            Console.WriteLine();
            Console.WriteLine("                                                   ① 강의시간표 조회                                  ");
            Console.WriteLine("                                                   ② 관심과목 담기                                    ");
            Console.WriteLine("                                                   ③ 수강신청                                         ");
            Console.WriteLine("                                                   ④ 수강내역 조회                                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                       원하시는 기능의 번호를 입력하세요 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      =============================================================================== ");
        }

        public void PrintCourseOfInterest()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                     § 관심과목 담기 §                             ");
            Console.WriteLine();
            Console.WriteLine("                                                ① 관심과목 분야별 검색 및 추가                                 ");
            Console.WriteLine("                                                ② 관심과목 목록                                    ");
            Console.WriteLine("                                                ③ 예상시간표                                         ");
            Console.WriteLine("                                                ④ 관심과목 삭제                                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                       원하시는 기능의 번호를 입력하세요 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      =============================================================================== ");
        }

        public void PrintCourseRegistration()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                       § 수강 신청 §                             ");
            Console.WriteLine();
            Console.WriteLine("                                              ① 과목 분야별 검색 및 추가                                ");
            Console.WriteLine("                                              ② 신청 과목 (재)조회                                    ");
            Console.WriteLine("                                              ③ 예상시간표                                         ");
            Console.WriteLine("                                              ④ 신청 과목 삭제                                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                       원하시는 기능의 번호를 입력하세요 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      =============================================================================== ");
        }

        public void Print(string form)
        {

        }

        public void PrintWarning(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                [메뉴에 나와있는 번호만 입력 가능합니다. 다시 입력하세요.]              ");
            Console.ResetColor();
        }

        public void PrintWarningSentence(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                            [조건에 맞춰서 다시 입력해주세요.]              ");
            Console.ResetColor();
        }

        public void ClearLine(int line, int width)
        {
            Console.SetCursorPosition(width, Console.CursorTop - line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }

        public void ClearLineMore(int line, int cursor, int width)
        {
            Console.SetCursorPosition(width, cursor - line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(width + 50, cursor - line);
        }

    }
}
