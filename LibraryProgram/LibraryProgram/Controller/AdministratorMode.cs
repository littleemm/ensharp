﻿using System;
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

        public AdministratorMode(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberDTO memberDTO, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogDTO logDTO)
        {
            bookViewElement = new BookViewElement();
            memberViewElement = new MemberViewElement();
            logViewElement = new LogViewElement();
            bookAdministration = new BookAdministration (viewElement, bookViewElement, menuSelection, databaseBook, exception, databaseLog, logDTO);
            memberAdministration = new MemberAdministration(viewElement, memberViewElement, menuSelection, databaseMember, memberDTO, exception, databaseLog, logDTO);
            logAdministration = new LogAdministration(viewElement, logViewElement, menuSelection, databaseLog);
            
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
        }

        public void ShowAdministratorPage()
        {
            Console.Clear();
            viewElement.PrintAdministratorPage();
            SelectManagement();
        }

        private void SelectManagement()
        {
            string number = menuSelection.CheckMenuNumber(46, 23, Constant.ARRAY_FOUR);
            Console.Clear();
            switch(int.Parse(number))
            {
                case Constant.MEMBER_MANAGE:
                    {
                        SelectMemberAdministration();
                        break;
                    }
                case Constant.BOOK_MANAGE: 
                    {
                        SelectBookAdministration(); 
                        break;
                    }
                case Constant.LOG_MANAGE:
                    {
                        SelectLogAdministration();
                        break;
                    }
                case Constant.EXIT: 
                    {
                        AskExit();
                        break;
                    }
            }
        }
        public void SelectBookAdministration() // 책 관리 모드에서 메뉴 선택
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            bookViewElement.PrintManageBookMenu();
            string number = menuSelection.CheckMenuKey(46, 25, Constant.ARRAY_SEVEN);
            Console.Clear();
            switch (int.Parse(number))
            {
                case (0):
                    {
                        ShowAdministratorPage();
                        break;
                    }
                case Constant.REGISTRATION:
                    {
                        bookAdministration.RegisterBook();
                        break;
                    }
                case Constant.EDIT:
                    {
                        bookAdministration.EditBook();
                        break;
                    }
                case Constant.DELETE:
                    {
                        bookAdministration.DeleteBook();
                        break;
                    }
                case Constant.SEARCH:
                    {
                        bookAdministration.SearchBook();
                        break;
                    }
                case Constant.SEARCH_NAVER:
                    {
                        bookAdministration.SearchNaverBook();
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
            CreateKey();
        }

        public void SelectMemberAdministration() // 회원 관리모드에서 메뉴 선택
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            memberViewElement.PrintManageMemberMenu();
            string number = menuSelection.CheckMenuKey(46, 23, Constant.ARRAY_FIVE);
            Console.Clear();
            switch (int.Parse(number))
            {
                case (0):
                    {
                        ShowAdministratorPage();
                        break;
                    }
                case Constant.REGISTRATION:
                    {
                        memberAdministration.RegisterMember();
                        break;
                    }
                case Constant.EDIT:
                    {
                        memberAdministration.EditMember();
                        break;
                    }
                case Constant.DELETE:
                    {
                        memberAdministration.DeleteMember();
                        break;
                    }
                case Constant.SEARCH:
                    {
                        memberAdministration.SearchMember();
                        break;
                    }
                case Constant.MEMBER_LIST:
                    {
                        memberAdministration.PrintList();
                        break;
                    }
            }
            CreateKey();
        }

        public void SelectLogAdministration() // 로그 관리 모드에서 메뉴 선택
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            logViewElement.PrintManageLogMenu();
            string number = menuSelection.CheckMenuKey(46, 23, Constant.ARRAY_FIVE);
            Console.Clear();
            switch (int.Parse(number))
            {
                case (0):
                    {
                        ShowAdministratorPage();
                        break;
                    }
                case Constant.EDIT_LOG:
                    {
                        logAdministration.EditLog();
                        break;
                    }
                case Constant.INIT_LOG:
                    {
                        logAdministration.InitializeLog();
                        break;
                    }
                case Constant.SAVE_LOG:
                    {
                        logAdministration.SaveLogFile();
                        break;
                    }
                case Constant.DELETE_LOG:
                    {
                        logAdministration.DeleteLogFile();
                        break;
                    }
                case Constant.LOG_LIST:
                    {
                        logAdministration.PrintLogList();
                        break;
                    }
            }
            CreateKey();
        }

        private void AskExit() // 나가기 전 한 번 더 묻기
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
                        ShowAdministratorPage();
                        break;
                    }
            }
        }

        private void CreateKey()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                SelectLogAdministration();
            }
        }
    }
}
