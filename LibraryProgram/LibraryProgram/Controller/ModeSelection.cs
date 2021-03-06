using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class ModeSelection 
    {
        BasicPage basicPage;
        LoginSystem loginPage;
        MenuSelection menuSelection;
        FormOfSignUp formOfSignUp;
        AdministratorMode administratorMode;
        MemberMode memberMode;

        public ModeSelection(MenuSelection menuSelection, LoginSystem loginPage, BasicPage basicPage, MemberDTO memberDTO, MemberDAO databaseMember, BookDAO databaseBook, Exception exception, LogDAO databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            this.basicPage = basicPage;
            this.loginPage = loginPage;
            this.menuSelection = menuSelection;

            formOfSignUp = new FormOfSignUp(basicPage, memberDTO, databaseMember, exception, databaseLog, logDTO, keyReader);
            administratorMode = new AdministratorMode(basicPage, menuSelection, databaseMember, memberDTO, databaseBook, exception, databaseLog, logDTO, keyReader);
            memberMode = new MemberMode(basicPage, menuSelection, databaseMember, databaseBook, exception, databaseLog, logDTO, keyReader);

        }

        public void SelectMode() // 모드 선택
        {
            Console.Clear();
            basicPage.PrintLibraryMain();
            string menuNumber = menuSelection.CheckMenuNumber(46, 22, Constant.ARRAY_THREE);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case Constant.ADMINISTRATOR_MODE:
                    {
                        SetDirectionToFirstOr(loginPage.LoginAdministratorMode());
                        break;
                    }
                case Constant.MEMBER_MODE:
                    {
                        SelectMemberMode();
                        break;
                    }
                case Constant.EXIT:
                    {
                        AskExitEnd();
                        break;
                    }
            }
        }
        private void SelectManagement() // 관리자 모드 첫 화면
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            basicPage.PrintAdministratorPage();
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
                            SetDirectionToManagement(smallNumber);
                            break;
                        }
                    case Constant.BOOK_MANAGE:
                        {
                            smallNumber = administratorMode.SelectBookAdministration();
                            SetDirectionToManagement(smallNumber);

                            break;
                        }
                    case Constant.LOG_MANAGE:
                        {
                            smallNumber = administratorMode.SelectLogAdministration();
                            SetDirectionToManagement(smallNumber);
                            break;
                        }
                    case Constant.EXIT:
                        {
                            smallNumber = administratorMode.AskExit();
                            SetDirectionToManagement(smallNumber);
                            break;
                        }
                }
            }
        }
        private void SelectMemberMode() // 멤버 모드 첫 화면
        {
            string id = "";
            Console.SetWindowSize(60, 28);
            basicPage.PrintMemberPage();
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
                            id = loginPage.LoginMemberMode();
                            SetDirectionMemberLogin(id);
                            break;
                        }
                    case Constant.SIGN_UP:
                        {
                            SetDirectionToFirst(formOfSignUp.ShowSignUpPage());
                            SelectMode();
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
            while (Constant.LOOP_UNTIL_F1_KEY_PRESSED)
            {
                Console.Clear();
                Console.SetWindowSize(60, 28);
                basicPage.PrintMemberMode();
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
                    if (consoleKey.Key == ConsoleKey.F1)
                    {
                        break;
                    }

                    Console.Clear();
                }
            }
        }

        private void AskExitEnd() // 종료 전 한 번 더 묻기
        {
            Console.Clear();
            basicPage.PrintExitForm();
            string menuNumber = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case Constant.EXIT_REAL:
                    {
                        basicPage.PrintExit();
                        break;
                    }
                case Constant.GOBACK:
                    {
                        basicPage.PrintLibraryMain();
                        SelectMode();
                        break;
                    }
            }
        }

        private void AskExitMember() // 멤버 모드 종료 전 한 번 더 묻기
        {
            Console.Clear();
            basicPage.PrintExitForm();
            string menuNumber = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case Constant.EXIT_REAL:
                    {
                        basicPage.PrintExit();
                        break;
                    }
                case Constant.GOBACK:
                    {
                        SelectMemberMode();
                        break;
                    }
            }
        }

        private void SetDirectionMemberLogin(string id)
        {
            if (id == "\\n")
            {
                SelectMode();
            }
            else SelectMenu(id);
        }

        private void SetDirectionToFirstOr(string input)
        {
            if (input == "\\n")
            {
                SelectMode();
            }
            else SelectManagement();
        }

        private void SetDirectionToManagement(string input)
        {
            if (input == "\\n") SelectManagement();
        }

        private void SetDirectionToFirst(string input)
        {
            if (input == "\\n")
            {
                SelectMode();
            }
        }
    }
}
