using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class LoginViewElement // 로그인 요소 관련 프린트
    {
        public void PrintMainPage()
        {
            Console.WriteLine();
            Console.WriteLine("  ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine();
            Console.WriteLine("                                     L O G I N                                    ");
            Console.WriteLine();
            Console.WriteLine("                           ID(8자리) : ");
            Console.WriteLine("                           PW(4자리) : ");
            Console.WriteLine();
            Console.WriteLine("  =============================================================================== ");
        }

        public void PrintSystemPage()
        {
            Console.WriteLine("  ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                              § 강좌 조회 및 수강신청 §                             ");
            Console.WriteLine();
            Console.WriteLine("                               ① 강의시간표 조회                                  ");
            Console.WriteLine("                               ② 관심과목 담기                                    ");
            Console.WriteLine("                               ③ 수강신청                                         ");
            Console.WriteLine("                               ④ 수강내역 조회                                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  =============================================================================== ");
        }

        public void PrintInterestedSubject()
        {
            Console.WriteLine("  ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                 § 관심과목 담기 §                             ");
            Console.WriteLine();
            Console.WriteLine("                               ① 관심과목 분야별 검색                                 ");
            Console.WriteLine("                               ② 관심과목 목록                                    ");
            Console.WriteLine("                               ③ 예상시간표                                         ");
            Console.WriteLine("                               ④ 관심과목 삭제                                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  =============================================================================== ");
        }
    }
}
