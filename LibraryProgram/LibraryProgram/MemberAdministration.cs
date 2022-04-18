using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MemberAdministration
    {
        MemberViewElement memberViewElement;
        BasicViewElement viewElement;
        MenuSelection menuSelection;

        public MemberAdministration(BasicViewElement viewElement, MenuSelection menuSelection)
        {
            memberViewElement = new MemberViewElement();
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
        }

        public void SelectMemberAdministration()
        {
            memberViewElement.PrintManageMemberMenu();
            string number = menuSelection.CheckMenuNumber(46, 23, Constant.ARRAY_FIVE);
            switch (int.Parse(number))
            {
                case Constant.REGISTRATION:
                    {
                        RegisterMember();
                        break;
                    }
                case Constant.EDIT:
                    {
                        EditMember();
                        break;
                    }
                case Constant.DELETE:
                    {
                        DeleteMember();
                        break;
                    }
                case Constant.SEARCH:
                    {
                        SearchMember();
                        break;
                    }
                case Constant.LIST:
                    {
                        PrintList();
                        break;
                    }
            }
        }

        private void RegisterMember()
        {
            memberViewElement.PrintRegistration();
        }

        private void EditMember()
        {
            memberViewElement.PrintEditMember();
        }

        private void DeleteMember()
        {
            memberViewElement.PrintDeleteMember();
        }

        private void SearchMember()
        {
            memberViewElement.InformMemberList();
        }

        private void PrintList()
        {
            memberViewElement.InformMemberList();
        }
    }
}
