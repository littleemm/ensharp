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
        private ConsoleKeyInfo keyInfo;

        BasicViewElement viewElement;
        DatabaseMember databaseMember;
        MenuSelection menuSelection;

        public LoginSystem(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberDTO memberDTO, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogDTO logDTO)
        {
            keyInfo = new ConsoleKeyInfo();
            this.viewElement = viewElement;
            this.databaseMember = databaseMember;
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
}

        public string LoginAdministratorMode() // 관리자 로그인 모드
        {
            Console.Clear();
            bool isIdAndPassword = Constant.ID_AND_PW_UNCORRECT_NOW;
            viewElement.PrintLoginPage();
            while (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW) {
                LoginId();
                if (id == "\\n") return id;
                LoginPassword();
                if (password == "\\n") return password;
                isIdAndPassword = databaseMember.SelectMember(Constant.SELECT_QUERY_ADMIN, id, password);
                if (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)
                { // 아이디, 비밀번호 중 하나라도 틀리면 다시
                    viewElement.ClearLine(0, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.ClearLine(0, 37);
                    viewElement.PrintLoginWarning(2, 12);
                }
            }

            return id;
        }

        public string LoginMemberMode() // 로그인 회원모드
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            bool isIdAndPassword = Constant.ID_AND_PW_UNCORRECT_NOW;
            viewElement.PrintLoginPage();
            while (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)
            {
                LoginId();
                if (id == "\\n") return id;
                LoginPassword();
                if (password == "\\n") return password;
                isIdAndPassword = databaseMember.SelectMember(Constant.SELECT_QUERY_MEMBER, id, password);
                if (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)// 아이디 비밀번호 틀렸을 경우 <- 매직넘버 처리 
                {
                    viewElement.ClearLine(0, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.ClearLine(0, 37);
                    viewElement.PrintLoginWarning(2, 12);
                }
            }

            return id;
        }

        private void LoginId()
        {
            Console.SetCursorPosition(37, 14);
            id = "";
            keyInfo = new ConsoleKeyInfo();

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    id = "\\n";
                    break;
                }
                else if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    id += keyInfo.KeyChar.ToString();
                    Console.Write(keyInfo.KeyChar.ToString());
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && id.Length > 0)
                {
                    id = id.Substring(0, (id.Length - 1));
                    Console.Write("\b \b");
                }
            }
        }

        public void LoginPassword() 
        {
            Console.SetCursorPosition(37, 16);
            password = "";
            keyInfo = new ConsoleKeyInfo();

            // 비밀번호 *처리
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    password =  "\\n";
                    break;
                }
                else if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar.ToString();
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
            }
        }
    }
}
