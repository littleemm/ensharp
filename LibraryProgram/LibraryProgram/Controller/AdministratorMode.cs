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
        MenuSelection menuSelection;

        public AdministratorMode(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberVO memberVO, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogVO logVO)
        {
            bookAdministration = new BookAdministration (viewElement, menuSelection, databaseBook, exception, databaseLog, logVO);
            memberAdministration = new MemberAdministration(viewElement, menuSelection, databaseMember, memberVO, exception, databaseLog, logVO);
            logAdministration = new LogAdministration(viewElement, menuSelection, databaseLog);
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
                        memberAdministration.SelectMemberAdministration();
                        break;
                    }
                case Constant.BOOK_MANAGE: 
                    {
                        bookAdministration.SelectBookAdministration();
                        break;
                    }
                case Constant.LOG_MANAGE:
                    {
                        logAdministration.SelectLogAdministration();
                        break;
                    }
                case Constant.EXIT: 
                    {
                        AskExit();
                        break;
                    }
            }
        }

        private void AskExit()
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

    }
}
