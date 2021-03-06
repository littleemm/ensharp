using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MemberPage
    {
        public void PrintManageMemberMenu()
        {
            Console.WriteLine(" ESC: 뒤로가기                                             ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        MANAGE MEMBER                        ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     1. REGISTER MEMBER                    ");
            Console.WriteLine("                     2. EDIT MEMBER                        ");
            Console.WriteLine("                     3. DELETE MEMBER                      ");
            Console.WriteLine("                     4. SEARCH MEMBER                      ");
            Console.WriteLine("                     5. MEMBER LIST                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine();
            Console.WriteLine("          원하시는 기능의 번호를 입력하세요 :                  ");
            Console.WriteLine();
            Console.WriteLine("                                                           ");
        }

        public void PrintRegistration()
        {
            Console.WriteLine(" ESC: 뒤로가기                                               ");
            Console.WriteLine("                  *                 *                 *            ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("        *                  *                  *                  * ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                              REGISTER MEMBER                      ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("        *                  *                  *                  * ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                  *                 *                 *            ");
            Console.WriteLine();
            Console.WriteLine("                                                                 ");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("     ID (8자 이내, 영어·숫자 가능)     :                 ");
            Console.WriteLine();
            Console.WriteLine("  PW (5~8자, 영어·숫자·특수문자 포함) :                  ");
            Console.WriteLine();
            Console.WriteLine("            이름 (25자 이내)            :                  ");
            Console.WriteLine();
            Console.WriteLine("        나이(1~150, 숫자만 입력)        :                  ");
            Console.WriteLine();
            Console.WriteLine("            전화번호(-제외)             :                  ");
            Console.WriteLine();
            Console.WriteLine("       도로명 주소 (건물 번호까지)      :                   ");
            Console.WriteLine(" ex. 서울특별시 서초구 반포대로23길 6 ");
        }

        public void PrintRegistrationSuccessMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                 [성공적으로 등록되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintEditMember()
        {
            Console.WriteLine(" ESC: 뒤로가기                                               ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                EDIT ADDRESS / PHONE NUMBER                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void PrintEditMemberForm()
        {
            Console.WriteLine();
            Console.WriteLine("                 MEMBER ID  : ");
            Console.WriteLine();
            Console.WriteLine("                  ADDRESS   : ");
            Console.WriteLine();
            Console.WriteLine("               PHONE NUMBER : ");
            Console.WriteLine();
        }

        public void PrintEditMineForm()
        {
            Console.WriteLine();
            Console.WriteLine("                  ADDRESS   : ");
            Console.WriteLine();
            Console.WriteLine("               PHONE NUMBER :  ");
            Console.WriteLine();
        }

        public void PrintDeleteMember()
        {
            Console.WriteLine(" ESC: 뒤로가기                                               ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                     DELETE MEMBER T_T                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void PrintDeleteMemberForm()
        {
            Console.WriteLine();
            Console.WriteLine("                 MEMBER ID  : ");
            Console.WriteLine();
        }

        public void InformMemberList()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("ESC: 뒤로가기        M E M B E R L I S T                      ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine();

        }

        public void SearchMember()
        {
            Console.WriteLine();
            Console.WriteLine("        회원 ID : ");
            Console.WriteLine();
        }

        public void PrintEditSuccessMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                [성공적으로 수정되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintEditFailMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                   [수정 내용이 없습니다!]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintDeleteSuccessMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                [성공적으로 삭제되었습니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintWarningMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("           [조건에 맞춰 다시 입력하세요!]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintDeleteWarningMessage(int x, int y)
        {
            Console.WriteLine();
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        [대출중인 책이 있어 삭제가 불가합니다.]");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintSearchWarningMessage(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    [올바른 아이디로 다시 입력하세요!]");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
