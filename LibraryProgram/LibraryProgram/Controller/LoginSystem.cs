using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class LoginSystem
    {
        private string id;
        private string password;

        BasicViewElement viewElement;
        DatabaseMember databaseMember;
        KeyReader keyReader;

        public LoginSystem(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberDTO memberDTO, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            this.viewElement = viewElement;
            this.databaseMember = databaseMember;
            this.viewElement = viewElement;
            this.keyReader = keyReader;
}

        public string LoginAdministratorMode() // 관리자 모드 로그인
        {
            Console.Clear();
            bool isIdAndPassword = false;
            viewElement.PrintLoginPage();

            while (!isIdAndPassword) {
                id = keyReader.ReadKeyBasic(37, 14, id);
                if (id == "\\n") return id;
                password = keyReader.ReadKeySecret(37, 16, password);
                if (password == "\\n") return password;

                isIdAndPassword = databaseMember.SelectMember(Constant.SELECT_QUERY_ADMIN, id, password);
                if (!isIdAndPassword)
                { // 아이디, 비밀번호 중 하나라도 틀리면 다시
                    viewElement.ClearLine(0, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.ClearLine(0, 37);
                    viewElement.PrintWarningSentence(2, 12, "일치하는 회원정보가 없습니다!");
                }
            }

            return id;
        }

        public string LoginMemberMode() // 회원 모드 로그인
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            bool isIdAndPassword = false;
            viewElement.PrintLoginPage();

            while (!isIdAndPassword)
            {
                id = keyReader.ReadKeyBasic(37, 14, id);
                if (id == "\\n") return id;
                password = keyReader.ReadKeySecret(37, 16, password);
                if (password == "\\n") return password;

                isIdAndPassword = databaseMember.SelectMember(Constant.SELECT_QUERY_MEMBER, id, password);
                if (!isIdAndPassword)// 아이디 비밀번호 틀렸을 경우 <- 매직넘버 처리 
                {
                    viewElement.ClearLine(0, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.ClearLine(0, 37);
                    viewElement.PrintWarningSentence(2, 12, "일치하는 회원정보가 없습니다!");
                }
            }

            return id;
        }
    }
}
