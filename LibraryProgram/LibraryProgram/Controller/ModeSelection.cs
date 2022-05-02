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

        public ModeSelection(MenuSelection menuSelection, LoginSystem loginPage, BasicViewElement viewElement, MemberVO memberVO, DatabaseMember databaseMember, Exception exception, DatabaseLog databaseLog, LogVO logVO)
        {
            this.viewElement = viewElement;
            this.loginPage = loginPage;
            this.menuSelection = menuSelection;

            formOfSignUp = new FormOfSignUp(viewElement, memberVO, databaseMember, exception, databaseLog, logVO);
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
                        SelectMemberMode();
                        break;
                    }
                case Constant.EXIT:
                    {
                        AskExit();
                        break;
                    }
            }
        }

        private void SelectMemberMode()
        {
            viewElement.PrintMemberPage();
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
                        AskExitMember();
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
                        viewElement.PrintLibraryMain();
                        SelectMode();
                        break;
                    }
            }
        }

        private void AskExitMember()
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
                        SelectMemberMode();
                        break;
                    }
            }
        }
    }
}
