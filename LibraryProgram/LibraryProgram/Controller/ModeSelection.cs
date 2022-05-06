using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class ModeSelection 
    {
        BasicViewElement viewElement;
        LoginSystem loginPage;
        MenuSelection menuSelection;
        FormOfSignUp formOfSignUp;
        AdministratorMode administratorMode;
        MemberMode memberMode;

        public ModeSelection(MenuSelection menuSelection, LoginSystem loginPage, BasicViewElement viewElement, MemberDTO memberDTO, DatabaseMember databaseMember, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            this.viewElement = viewElement;
            this.loginPage = loginPage;
            this.menuSelection = menuSelection;

            formOfSignUp = new FormOfSignUp(viewElement, memberDTO, databaseMember, exception, databaseLog, logDTO, keyReader);
            administratorMode = new AdministratorMode(viewElement, menuSelection, databaseMember, memberDTO, databaseBook, exception, databaseLog, logDTO, keyReader);
            memberMode = new MemberMode(viewElement, menuSelection, databaseMember, databaseBook, exception, databaseLog, logDTO, keyReader);

        }

        public void SelectMode() // 모드 선택
        {
            Console.Clear();
            viewElement.PrintLibraryMain();
            string menuNumber = menuSelection.CheckMenuNumber(46, 22, Constant.ARRAY_THREE);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case Constant.ADMINISTRATOR_MODE:
                    {
                        if (loginPage.LoginAdministratorMode() == "\\n") SelectMode();
                        else SelectManagement();
                        break;
                    }
                case Constant.MEMBER_MODE:
                    {
                        SelectMemberMode();
                        break;
                    }
                case Constant.EXIT:
                    {
                        AskExit();
                        break;
                    }
            }
        }
        public void SelectManagement() // 관리자 모드 첫 화면
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            viewElement.PrintAdministratorPage();
            string number = menuSelection.CheckMenuKey(46, 23, Constant.ARRAY_FOUR);
            string smallNumber = "";
            Console.Clear();
            if (number.Equals("\\n"))
            {
                SelectMode();
            }
            else
            {
                switch (int.Parse(number))
                {
                    case Constant.MEMBER_MANAGE:
                        {
                            smallNumber = administratorMode.SelectMemberAdministration();
                            if (smallNumber == "\\n") SelectManagement();
                            break;
                        }
                    case Constant.BOOK_MANAGE:
                        {
                            smallNumber = administratorMode.SelectBookAdministration();
                            if (smallNumber == ("\\n")) SelectManagement();

                            break;
                        }
                    case Constant.LOG_MANAGE:
                        {
                            smallNumber = administratorMode.SelectLogAdministration();
                            if (smallNumber == "\\n") SelectManagement();
                            break;
                        }
                    case Constant.EXIT:
                        {
                            smallNumber = administratorMode.AskExit();
                            if (smallNumber == "\\n") SelectManagement();
                            break;
                        }
                }
            }
        }
        private void SelectMemberMode() // 멤버 모드 첫 화면
        {
            string id = "";
            Console.SetWindowSize(60, 28);
            viewElement.PrintMemberPage();
            string menuNumber = menuSelection.CheckMenuKey(46, 22, Constant.ARRAY_THREE);
            Console.Clear();
            if (menuNumber.Equals("\\n"))
            {
                SelectMode();
            }
            else
            {
                switch (int.Parse(menuNumber))
                {
                    case Constant.LOGIN:
                        {
                            Console.SetWindowSize(60, 28);
                            id = loginPage.LoginMemberMode();
                            if (id == "\\n") SelectMode();
                            else SelectMenu(id);
                            break;
                        }
                    case Constant.SIGN_UP:
                        {
                            formOfSignUp.ShowSignUpPage();
                            
                            id = loginPage.LoginMemberMode();
                            if (id == "\\n") SelectMode();
                            else SelectMenu(id);
                            break;
                        }
                    case Constant.EXIT:
                        {
                            AskExitMember();
                            break;
                        }
                }
            }
        }

        private void SelectMenu(string id) // 멤버 메뉴 선택
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            viewElement.PrintMemberMode();
            string number = menuSelection.CheckMenuKey(46, 24, Constant.ARRAY_FIVE);
            Console.Clear();
            if (number.Equals("\\n"))
            {
                SelectMemberMode();
            }
            else
            {
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

        private void AskExit() // 종료 전 한 번 더 묻기
        {
            viewElement.PrintExitForm();
            string menuNumber = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case Constant.EXIT_REAL:
                    {
                        viewElement.PrintExit();
                        break;
                    }
                case Constant.GOBACK:
                    {
                        viewElement.PrintLibraryMain();
                        SelectMode();
                        break;
                    }
            }
        }

        private void AskExitMember() // 멤버 모드 종료 전 한 번 더 묻기
        {
            viewElement.PrintExitForm();
            string menuNumber = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case Constant.EXIT_REAL:
                    {
                        viewElement.PrintExit();
                        break;
                    }
                case Constant.GOBACK:
                    {
                        SelectMemberMode();
                        break;
                    }
            }
        }
    }
}
