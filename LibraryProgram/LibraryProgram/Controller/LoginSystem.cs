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

        AdministratorMode administratorMode;
        MemberMode memberMode;
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
            administratorMode = new AdministratorMode(viewElement, menuSelection, databaseMember, memberDTO, databaseBook, exception, databaseLog, logDTO);
            memberMode = new MemberMode(viewElement, menuSelection, databaseMember, databaseBook, exception, databaseLog, logDTO);
        }

        public void LoginAdministratorMode() // 관리자 로그인 모드
        {
            Console.Clear();
            bool isIdAndPassword = Constant.ID_AND_PW_UNCORRECT_NOW;
            viewElement.PrintLoginPage();
            while (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW) {
                LoginAll(); 
                isIdAndPassword = databaseMember.SelectMember(Constant.SELECT_QUERY_ADMIN, id, password);
                if (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)
                { // 아이디, 비밀번호 중 하나라도 틀리면 다시
                    viewElement.ClearLine(0, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.ClearLine(0, 37);
                    viewElement.PrintLoginWarning(2, 12);
                }
            }
            SelectManagement();
        }

        public void LoginMemberMode() // 로그인 회원모드
        {
            Console.Clear();
            bool isIdAndPassword = Constant.ID_AND_PW_UNCORRECT_NOW;
            viewElement.PrintLoginPage();
            while (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)
            {
                LoginAll();
                isIdAndPassword = databaseMember.SelectMember(Constant.SELECT_QUERY_MEMBER, id, password);
                if (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)// 아이디 비밀번호 틀렸을 경우 <- 매직넘버 처리 
                {
                    viewElement.ClearLine(0, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.ClearLine(0, 37);
                    viewElement.PrintLoginWarning(2, 12);
                }
            }

            SelectMenu(id);
            
        }

        public void LoginAll() // 공통 로그인 폼 함수
        {
            Console.SetCursorPosition(37, 14);
            id = Console.ReadLine(); // 아이디 입력

            Console.SetCursorPosition(37, 16);
            password = "";

             // 비밀번호 *처리
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
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

        private void SelectManagement() // 관리자 메뉴
        {
            Console.Clear();
            viewElement.PrintAdministratorPage();
            string number = menuSelection.CheckMenuKey(46, 23, Constant.ARRAY_FOUR);
            Console.Clear();
            if (number.Equals("\\n"))
            {
                LoginAdministratorMode();
            }
            switch (int.Parse(number))
            {
                case Constant.MEMBER_MANAGE:
                    {
                        administratorMode.SelectMemberAdministration();
                        break;
                    }
                case Constant.BOOK_MANAGE:
                    {
                        administratorMode.SelectBookAdministration();
                        break;
                    }
                case Constant.LOG_MANAGE:
                    {
                        administratorMode.SelectLogAdministration();
                        break;
                    }
                case Constant.EXIT:
                    {
                        administratorMode.AskExit();
                        break;
                    }
            }
        }

        private void SelectMenu(string id)
        {
            Console.Clear();
            viewElement.PrintMemberMode();
            string number = menuSelection.CheckMenuKey(46, 24, Constant.ARRAY_FIVE);
            Console.Clear();
            if (number.Equals("\\n"))
            {
                LoginMemberMode();
            }
            switch (int.Parse(number))
            {
                case Constant.SEARCH_BOOK:
                    {
                        memberMode.SearchBook(id);
                        break;
                    }
                case Constant.BOOKLIST:
                    {
                        memberMode.PrintList();
                        break;
                    }
                case Constant.CHECKOUT:
                    {
                        memberMode.CheckOutBook(id);
                        break;
                    }
                case Constant.RETURN:
                    {
                        memberMode.ReturnBook(id);
                        break;
                    }
                case Constant.MYPAGE:
                    {
                        memberMode.EditMyInformation(id);
                        break;
                    }
            }

            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                SelectMenu(id);
            }
        }
    }
}
