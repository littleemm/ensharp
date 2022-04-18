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

        public ModeSelection(MenuSelection menuSelection, LoginSystem loginPage, BasicViewElement viewElement)
        {
            this.viewElement = viewElement;
            this.loginPage = loginPage;
            this.menuSelection = menuSelection;
        }
        
        public void SelectMode()
        {
            string menuNumber = menuSelection.CheckMenuNumber(46, 22, Constant.ARRAY_THREE);
            switch (int.Parse(menuNumber))
            {
                case 1:
                    {
                        loginPage.LoginAdministratorMode();
                        break;
                    }
                case 2:
                    {
                        viewElement.PrintMemberPage();
                        SelectMemberMode();
                        break;
                    }
                case 3:
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
                case 1: // 로그인
                    {
                        loginPage.LoginMemberMode();
                        break;
                    }
                case 2: // 회원가입
                    {

                        loginPage.LoginMemberMode();
                        break;
                    }
                case 3: // 나가기
                    {
                        Console.Clear();
                        viewElement.PrintExit();
                        break;
                    }
            }
        }
    }
}
