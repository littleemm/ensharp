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
        BasicViewElement viewElement;
        MenuSelection menuSelection;

        public AdministratorMode(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberVO memberVO, DatabaseBook databaseBook, DatabaseMemberBook databaseMemberBook, Exception exception)
        {
            bookAdministration = new BookAdministration(viewElement, menuSelection, databaseBook, databaseMemberBook, exception);
            memberAdministration = new MemberAdministration(viewElement, menuSelection, databaseMember, memberVO, databaseMemberBook, exception);

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
            string number = menuSelection.CheckMenuNumber(46, 22, Constant.ARRAY_THREE);
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
                case (1):
                    {
                        viewElement.PrintExit();
                        break;
                    }
                case (2):
                    {
                        ShowAdministratorPage();
                        break;
                    }
            }
        }

    }
}
