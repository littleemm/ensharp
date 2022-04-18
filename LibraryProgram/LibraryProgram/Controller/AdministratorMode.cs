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

        public AdministratorMode(BasicViewElement viewElement, MenuSelection menuSelection)
        {
            bookAdministration = new BookAdministration(viewElement, menuSelection);
            memberAdministration = new MemberAdministration(viewElement, menuSelection);

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
                        viewElement.PrintExit();
                        break;
                    }
            }
        }

    }
}
