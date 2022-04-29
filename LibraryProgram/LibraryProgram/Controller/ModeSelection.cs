using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class ModeSelection 
    {
        BasicViewElement viewElement;
        LoginSystem loginPage;
        MenuSelection menuSelection;
        FormOfSignUp formOfSignUp;

        public ModeSelection(MenuSelection menuSelection, LoginSystem loginPage, BasicViewElement viewElement, MemberVO memberVO, DatabaseMember databaseMember, Exception exception)
        {
            this.viewElement = viewElement;
            this.loginPage = loginPage;
            this.menuSelection = menuSelection;

            formOfSignUp = new FormOfSignUp(viewElement, memberVO, databaseMember, exception);
        }
        
        public void SelectMode()
        {
            string menuNumber = menuSelection.CheckMenuNumber(46, 22, Constant.ARRAY_THREE);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case Constant.ADMINISTRATOR_MODE:
                    {
                        loginPage.LoginAdministratorMode();
                        break;
                    }
                case Constant.MEMBER_MODE:
                    {
                        viewElement.PrintMemberPage();
                        SelectMemberMode();
                        break;
                    }
                case Constant.EXIT:
                    {
                        viewElement.PrintExit();
                        break;
                    }
            }
        }

        private void SelectMemberMode()
        {
            string menuNumber = menuSelection.CheckMenuNumber(46, 22, Constant.ARRAY_THREE);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case Constant.LOGIN: 
                    {
                        loginPage.LoginMemberMode();
                        break;
                    }
                case Constant.SIGN_UP: 
                    {
                        formOfSignUp.ShowSignUpPage();
                        loginPage.LoginMemberMode();
                        break;
                    }
                case Constant.EXIT:
                    {
                        Console.Clear();
                        viewElement.PrintExit();
                        break;
                    }
            }
        }
    }
}
