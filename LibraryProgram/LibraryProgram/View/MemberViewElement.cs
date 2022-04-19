using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MemberViewElement
    {
        public void PrintManageMemberMenu()
        {
            Console.WriteLine("                                                           ");
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
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      REGISTER MEMBER                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine();
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("     ID(8자리 이내, 영어, 숫자 가능) :                 ");
            Console.WriteLine();
            Console.WriteLine("       PW(5자리 이내, 숫자만 가능)   :                  ");
            Console.WriteLine();
            Console.WriteLine("         이름(8자리 이내, 한글만)    :                  ");
            Console.WriteLine();
            Console.WriteLine("         나이(0~150, 숫자만 입력)    :                  ");
            Console.WriteLine();
            Console.WriteLine("          휴대폰 번호(-제외)         :                  ");
            Console.WriteLine();
            Console.WriteLine("         주소 (ex. 서울시 광진구)    :                   ");
        }

        public void PrintRegistrationSuccessMessage()
        {
            Console.WriteLine();
            Console.WriteLine("                  [성공적으로 등록되었습니다.]");
            Console.WriteLine();
        }

        public void PrintEditMember()
        {
            Console.WriteLine("                                                           ");
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

        public void PrintDeleteMember()
        {
            Console.WriteLine("                                                           ");
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

        public void InformMemberList()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("                     M E M B E R L I S T                      ");
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
    }
}
