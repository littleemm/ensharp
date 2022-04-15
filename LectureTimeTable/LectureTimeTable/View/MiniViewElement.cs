using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class MiniViewElement
    {
        public void PrintCourseSearching()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                      § 강의시간표 검색  §                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                             ● 개설학과     ①컴퓨터공학과 ②소프트웨어학과 ③지능기전공학부                 ");
            Console.WriteLine("                             ● 이수 구분    ①교양필수 ②전공필수 ③전공선택                                ");
            Console.WriteLine("                             ● 학년 선택    ①1학년 ②2학년 ③3학년 ④4학년                           ");
            Console.WriteLine("                             ● 교과목명                                          ");
            Console.WriteLine("                             ● 교수명                                    ");
            Console.WriteLine("                             ● 조회                                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                              번호나 이름을 입력하세요(ENTER만 누르면 전체 선택) : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
        }

        public void PrintNumberSentence()
        {
            Console.WriteLine("                                       학수 번호(ENTER 누르면 전체 선택) :         ");
            Console.WriteLine("                                       분     반                        :");
        }

        public void PrintInterestCourseSearching()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                       § 검색 구분  §                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                     ① 개설학과 검색                            ");
            Console.WriteLine("                                                     ② 학수번호 검색                            ");
            Console.WriteLine("                                                     ③ 교과목명 검색                            ");
            Console.WriteLine("                                                     ④ 강의교수 검색                            ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  번호를 입력하세요 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
        }

        public void PrintCourseRegistrationSearching()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                       § 검색 구분  §                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                     ① 관심과목 검색                            ");
            Console.WriteLine("                                                     ② 개설학과 검색                            ");
            Console.WriteLine("                                                     ③ 학수번호 검색                            ");
            Console.WriteLine("                                                     ④ 교과목명 검색                            ");
            Console.WriteLine("                                                     ⑤ 강의교수 검색                            ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  번호를 입력하세요 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
        }

        public void PrintCourseSearchingOfMajor()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                     § 개설학과 검색  §                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                     ① 컴퓨터공학과                            ");
            Console.WriteLine("                                                     ② 소프트웨어학과                            ");
            Console.WriteLine("                                                     ③ 지능기전공학부                            ");
            Console.WriteLine("                                                     ④ 기계항공우주공학부                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  번호를 입력하세요 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
        }

        public void PrintCourseSearchingOfNumber()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                     § 학수번호 검색  §                               ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                         학수번호는 6자리 정수로 입력하십시오. (ex.662982)              ");
            Console.WriteLine("                                         분반은 3자리 정수로 입력하십시오.  (ex.3분반 -> 003)         ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                        ※ 분반을 입력하지 않으면 검색할 수 없습니다. ※");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                   학수번호 : ");
            Console.WriteLine();
            Console.WriteLine("                                                   분    반 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
        }

        public void PrintCourseSearchingOfName()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                       § 교과목명 검색  §                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                    2글자 이상 입력하세요.                           ");
            Console.WriteLine("                                   (ex. 고급C프로그래밍 -> 고급 (O), 신입생세미나 -> 신 (X))            ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  교과목명을 입력하세요 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
        }

        public void PrintCourseSearchingOfProfessor()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                                                       § 강의교수 검색  §                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                      3글자 이상 입력하세요.                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  교수명을 입력하세요 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                       =============================================================================== ");
        }

        public void PrintCourseOfSearching()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 뒤로가기                                                      ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                    ============================== 2022년 1학기 강의 목록 ============================== ");
            Console.WriteLine();
        }
        public void PrintListSign()
        {
            Console.WriteLine();
            Console.WriteLine("                    ============================== 2022년 1학기 강의 목록 ============================== ");
            Console.WriteLine();
        }

        public void PrintSelectedCourseOfInterest()
        {
            Console.WriteLine();
            Console.WriteLine("                      ============================== SEJONG UNIVERSITY ============================== ");
            Console.WriteLine("                       F1: 관심과목 메인                                                 ESC: 로그아웃");
            Console.WriteLine();
            Console.WriteLine("                        강의 번호(NO) 입력 : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                    ============================== 2022년 1학기 강의 목록 ============================== ");
            Console.WriteLine();
        }

        public void PrintSuccessMessage(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                  [관심과목으로 등록되었습니다!] ");
            Console.ResetColor();
        }

        public void PrintEmptyMessage(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                   [일치하는 과목이 없습니다!] ");
            Console.ResetColor();
        }

        public void PrintFailMessage(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                 [동일 과목은 등록할 수 없습니다!] ");
            Console.ResetColor();
        }

        public void PrintWarning(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                [강의 번호를 정확하게 입력해주세요!] ");
            Console.ResetColor();
        }

        public void PrintDeleteMessage(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                  [관심과목에서 삭제되었습니다!] ");
            Console.ResetColor();
        }
    }
}
