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
        BasicViewElement viewElement;
        BookViewElement bookViewElement;
        MemberViewElement memberViewElement;
        LogViewElement logViewElement;
        MenuSelection menuSelection;

        public AdministratorMode(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberDTO memberDTO, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            bookViewElement = new BookViewElement();
            memberViewElement = new MemberViewElement();
            logViewElement = new LogViewElement();
            bookAdministration = new BookAdministration (viewElement, bookViewElement, menuSelection, databaseBook, exception, databaseLog, logDTO, keyReader);
            memberAdministration = new MemberAdministration(viewElement, memberViewElement, menuSelection, databaseMember, memberDTO, exception, databaseLog, logDTO, keyReader);
            logAdministration = new LogAdministration(viewElement, logViewElement, menuSelection, databaseLog, keyReader);
            
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
        }

        public string SelectBookAdministration() // 책 관리 모드에서 메뉴 선택
        {
            string number = "";
            while (true)
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
                                if (bookAdministration.RegisterBook() == "\\n")
                                {
                                    SelectBookAdministration();
                                }
                                break;
                            }
                        case Constant.EDIT:
                            {
                                if (bookAdministration.EditBook() == "\\n")
                                {
                                    SelectBookAdministration();
                                }
                                break;
                            }
                        case Constant.DELETE:
                            {
                                if (bookAdministration.DeleteBook() == "\\n")
                                {
                                    SelectBookAdministration();
                                }
                                break;
                            }
                        case Constant.SEARCH:
                            {
                                if (bookAdministration.SearchBook() == "\\n")
                                {
                                    SelectBookAdministration();
                                }
                                break;
                            }
                        case Constant.SEARCH_NAVER:
                            {
                                if (bookAdministration.SearchNaverBook() == "\\n")
                                {
                                    SelectBookAdministration();
                                }
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
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                }
                else break;
            }

            return number;
        }

        public string SelectMemberAdministration() // 회원 관리모드에서 메뉴 선택
        {
            string number = "";
            while (true)
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
                                if (memberAdministration.RegisterMember() == "\\n")
                                {
                                    SelectMemberAdministration();
                                }
                                break;
                            }
                        case Constant.EDIT:
                            {
                                if (memberAdministration.EditMember() == "\\n")
                                {
                                    SelectMemberAdministration();
                                }
                                break;
                            }
                        case Constant.DELETE:
                            {
                                if (memberAdministration.DeleteMember() == "\\n")
                                {
                                    SelectMemberAdministration();
                                }
                                break;
                            }
                        case Constant.SEARCH:
                            {
                                if (memberAdministration.SearchMember() == "\\n")
                                {
                                    SelectMemberAdministration();
                                }
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
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                }
                else break;
            }

            return number;
        }

        public string SelectLogAdministration() // 로그 관리 모드에서 메뉴 선택
        {
            string number = "";
            while (true)
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
                                if (logAdministration.EditLog() == "\\n")
                                {
                                    SelectLogAdministration();
                                }
                                break;
                            }
                        case Constant.INIT_LOG:
                            {
                                if (logAdministration.InitializeLog() == "\\n")
                                {
                                    SelectLogAdministration();
                                }
                                break;
                            }
                        case Constant.SAVE_LOG:
                            {
                                if (logAdministration.SaveLogFile() == "\\n")
                                {
                                    SelectLogAdministration();
                                }
                                break;
                            }
                        case Constant.DELETE_LOG:
                            {
                                if (logAdministration.DeleteLogFile() == "\\n")
                                {
                                    SelectLogAdministration();
                                }
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
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                }
                else break;

            }

            return number;
        }

        public string AskExit() // 나가기 전 한 번 더 묻기
        {
            string menuNumber = "";
            while (true)
            {
                viewElement.PrintExitForm();
                menuNumber = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
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
                            return "\\n";
                        }
                }
            }
        }


    }
}
