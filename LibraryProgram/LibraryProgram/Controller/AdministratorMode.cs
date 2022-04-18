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
        ModeSelection modeSelection;

        public AdministratorMode(BasicViewElement viewElement, ModeSelection modeSelection)
        {
            bookAdministration = new BookAdministration();
            memberAdministration = new MemberAdministration();

            this.viewElement = viewElement;
            this.modeSelection = modeSelection;
        }

        public void ShowAdministratorPage()
        {
            Console.Clear();
            viewElement.PrintAdministratorPage();
            SelectManagement();
        }

        private void SelectManagement()
        {
            string number = modeSelection.CheckMenuNumber(Constant.ARRAY_THREE);
            
            switch(int.Parse(number))
            {
                case Constant.MEMBER_MANAGE:
                    { 
                        
                        break;
                    }
                case Constant.BOOK_MANAGE: 
                    {

                        break;
                    }
                case Constant.EXIT: 
                    {
                        break;
                    }
            }
        }

    }
}
