using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class AdministratorMode
    {
        BookAdministration bookAdministration;
        MemberAdministration memberAdministration;
        LogAdministration logAdministration;
        BasicPage basicPage;
        BookPage bookViewElement;
        MemberPage memberViewElement;
        LogPage logViewElement;
        MenuSelection menuSelection;

        public AdministratorMode(BasicPage basicPage, MenuSelection menuSelection, MemberDAO databaseMember, MemberDTO memberDTO, BookDAO databaseBook, Exception exception, LogDAO databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            bookViewElement = new BookPage();
            memberViewElement = new MemberPage();
            logViewElement = new LogPage();
            bookAdministration = new BookAdministration (basicPage, bookViewElement, menuSelection, databaseBook, exception, databaseLog, logDTO, keyReader);
            memberAdministration = new MemberAdministration(basicPage, memberViewElement, menuSelection, databaseMember, memberDTO, exception, databaseLog, logDTO, keyReader);
            logAdministration = new LogAdministration(basicPage, logViewElement, menuSelection, databaseLog, keyReader);
            
            this.basicPage = basicPage;
            this.menuSelection = menuSelection;
        }

        public string SelectBookAdministration() // 책 관리 모드에서 메뉴 선택
        {
            string number = "";
            while (Constant.LOOP_FINAL_ESC_KEY_PRESSED) // 마지막에 esc 키를 누르면 반복됨
            {
                Console.Clear();
                Console.SetWindowSize(60, 28);
                bookViewElement.PrintManageBookMenu();
                number = menuSelection.CheckMenuKey(46, 25, Constant.ARRAY_SEVEN);
                Console.Clear();
                if (number.Equals("\\n"))
                {
                    return number;
                }
                else
                {
                    switch (int.Parse(number))
                    {
                        case Constant.REGISTRATION:
                            {
                                GobackAdministratorBookMenu(bookAdministration.RegisterBook());
                                break;
                            }
                        case Constant.EDIT:
                            {
                                GobackAdministratorBookMenu(bookAdministration.EditBook());
                                break;
                            }
                        case Constant.DELETE:
                            {
                                GobackAdministratorBookMenu(bookAdministration.DeleteBook());
                                break;
                            }
                        case Constant.SEARCH:
                            {
                                GobackAdministratorBookMenu(bookAdministration.SearchBook());
                                break;
                            }
                        case Constant.SEARCH_NAVER:
                            {
                                GobackAdministratorBookMenu(bookAdministration.SearchNaverBook());
                                break;
                            }
                        case Constant.LIST:
                            {
                                bookAdministration.PrintList();
                                break;
                            }
                        case Constant.LIST_OF_CHECKOUT:
                            {
                                bookAdministration.PrintCheckOutList();
                                break;
                            }
                    }
                }

                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.F1)
                {
                    break;
                }
                Console.Clear();
                
            }

            return number;
        }

        public string SelectMemberAdministration() // 회원 관리모드에서 메뉴 선택
        {
            string number = "";
            while (Constant.LOOP_FINAL_ESC_KEY_PRESSED)
            {
                Console.Clear();
                Console.SetWindowSize(60, 28);
                memberViewElement.PrintManageMemberMenu();
                number = menuSelection.CheckMenuKey(46, 23, Constant.ARRAY_FIVE);
                Console.Clear();
                if (number.Equals("\\n"))
                {
                    return number;
                }
                else
                {
                    switch (int.Parse(number))
                    {
                        case Constant.REGISTRATION:
                            {
                                GobackAdministratorMemberMenu(memberAdministration.RegisterMember());
                                break;
                            }
                        case Constant.EDIT:
                            {
                                GobackAdministratorMemberMenu(memberAdministration.EditMember());
                                break;
                            }
                        case Constant.DELETE:
                            {
                                GobackAdministratorMemberMenu(memberAdministration.DeleteMember());
                                break;
                            }
                        case Constant.SEARCH:
                            {
                                GobackAdministratorMemberMenu(memberAdministration.SearchMember());
                                break;
                            }
                        case Constant.MEMBER_LIST:
                            {
                                memberAdministration.PrintList();
                                break;
                            }
                    }
                }
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.F1)
                {
                    break;
                }
                Console.Clear();
            }

            return number;
        }

        public string SelectLogAdministration() // 로그 관리 모드에서 메뉴 선택
        {
            string number = "";
            while (Constant.LOOP_FINAL_ESC_KEY_PRESSED)
            {
                Console.Clear();
                Console.SetWindowSize(60, 28);
                logViewElement.PrintManageLogMenu();
                number = menuSelection.CheckMenuKey(46, 23, Constant.ARRAY_FIVE);
                Console.Clear();
                if (number.Equals("\\n"))
                {
                    return number;
                }
                else
                {
                    switch (int.Parse(number))
                    {
                        case Constant.EDIT_LOG:
                            {
                                GobackAdministratorLogMenu(logAdministration.EditLog());
                                break;
                            }
                        case Constant.INIT_LOG:
                            {
                                GobackAdministratorLogMenu(logAdministration.InitializeLog());
                                break;
                            }
                        case Constant.SAVE_LOG:
                            {
                                GobackAdministratorLogMenu(logAdministration.SaveLogFile());
                                break;
                            }
                        case Constant.DELETE_LOG:
                            {
                                GobackAdministratorLogMenu(logAdministration.DeleteLogFile());
                                break;
                            }
                        case Constant.LOG_LIST:
                            {
                                logAdministration.PrintLogList();
                                break;
                            }
                    }
                }
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.F1)
                {
                    break;
                }
                Console.Clear();

            }

            return number;
        }

        public string AskExit() // 나가기 전 한 번 더 묻기
        {
            string menuNumber = "";
            while (true)
            {
                basicPage.PrintExitForm();
                menuNumber = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
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
                            return "\\n"; // ESC키가 눌린 것 과 같은 의미
                        }
                }
            }
        }

        private void GobackAdministratorBookMenu(string key) // ESC 키가 눌렸으면 다시 관리 메인 메뉴로
        { // book
            if (key == "\\n")
            {
                SelectBookAdministration();
            }
        }

        private void GobackAdministratorMemberMenu(string key) // ESC 키가 눌렸으면 다시 관리 메인 메뉴로
        { // member
            if (key == "\\n")
            {
                SelectMemberAdministration();
            }
        }

        private void GobackAdministratorLogMenu(string key) // ESC 키가 눌렸으면 다시 관리 메인 메뉴로
        { // log
            if (key == "\\n")
            {
                SelectLogAdministration();
            }
        }

    }
}
