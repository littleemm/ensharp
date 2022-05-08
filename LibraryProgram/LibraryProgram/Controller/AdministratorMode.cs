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
            string key = "";
            while (Constant.LOOP_UNTIL_F1_KEY_PRESSED) // 마지막에 F1 누를 때까지 반복됨
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
                                key = bookAdministration.RegisterBook();
                                GobackAdministratorBookMenu(key);
                                break;
                            }
                        case Constant.EDIT:
                            {
                                key = bookAdministration.EditBook();
                                GobackAdministratorBookMenu(key);
                                break;
                            }
                        case Constant.DELETE:
                            {
                                key = bookAdministration.DeleteBook();
                                GobackAdministratorBookMenu(key);
                                break;
                            }
                        case Constant.SEARCH:
                            {
                                key = bookAdministration.SearchBook();
                                GobackAdministratorBookMenu(key);
                                break;
                            }
                        case Constant.SEARCH_NAVER:
                            {
                                key = bookAdministration.SearchNaverBook();
                                GobackAdministratorBookMenu(key);
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
                if (key != "\\n")
                {
                    ConsoleKeyInfo consoleKey = Console.ReadKey();
                    if (consoleKey.Key == ConsoleKey.F1)
                    {
                        break;
                    }
                    Console.Clear();
                }
                
            }

            return number;
        }

        public string SelectMemberAdministration() // 회원 관리모드에서 메뉴 선택
        {
            string number = "";
            string key = "";
            while (Constant.LOOP_UNTIL_F1_KEY_PRESSED)
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
                                key = memberAdministration.RegisterMember();
                                GobackAdministratorMemberMenu(key);
                                break;
                            }
                        case Constant.EDIT:
                            {
                                key = memberAdministration.EditMember();
                                GobackAdministratorMemberMenu(key);
                                break;
                            }
                        case Constant.DELETE:
                            {
                                key = memberAdministration.DeleteMember();
                                GobackAdministratorMemberMenu(key);
                                break;
                            }
                        case Constant.SEARCH:
                            {
                                key = memberAdministration.SearchMember();
                                GobackAdministratorMemberMenu(key);
                                break;
                            }
                        case Constant.MEMBER_LIST:
                            {
                                memberAdministration.PrintList();
                                break;
                            }
                    }
                }
                if (key != "\\n")
                {
                    ConsoleKeyInfo consoleKey = Console.ReadKey();
                    if (consoleKey.Key == ConsoleKey.F1)
                    {
                        break;
                    }
                    Console.Clear();
                }

            }

            return number;
        }

        public string SelectLogAdministration() // 로그 관리 모드에서 메뉴 선택
        {
            string number = "";
            string key = "";
            while (Constant.LOOP_UNTIL_F1_KEY_PRESSED)
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
                                key = logAdministration.EditLog();
                                GobackAdministratorLogMenu(key);
                                break;
                            }
                        case Constant.INIT_LOG:
                            {
                                key = logAdministration.InitializeLog();
                                GobackAdministratorLogMenu(key);
                                break;
                            }
                        case Constant.SAVE_LOG:
                            {
                                key = logAdministration.SaveLogFile();
                                GobackAdministratorLogMenu(key);
                                break;
                            }
                        case Constant.DELETE_LOG:
                            {
                                key = logAdministration.DeleteLogFile();
                                GobackAdministratorLogMenu(key);
                                break;
                            }
                        case Constant.LOG_LIST:
                            {
                                logAdministration.PrintLogList();
                                break;
                            }
                    }
                }
                if (key != "\\n")
                {
                    ConsoleKeyInfo consoleKey = Console.ReadKey();
                    if (consoleKey.Key == ConsoleKey.F1)
                    {
                        break;
                    }
                    Console.Clear();
                }

            }

            return number;
        }

        public string AskExit() // 나가기 전 한 번 더 묻기
        {
            string menuNumber = "";
            while (Constant.LOOP_UNTIL_EXIT)
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
