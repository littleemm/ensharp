using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class ModeSelection : MenuSelection
    {
        int positionX;
        int positionY;

        BasicViewElement viewElement;
        LoginSystem loginPage;

        public ModeSelection(int positionX, int positionY, LoginSystem loginPage, BasicViewElement viewElement) : base(positionX, positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;

            this.viewElement = viewElement;
            this.loginPage = loginPage;
        }
        
        public void SelectMode()
        {
            string menuNumber = CheckMenuNumber(Constant.ARRAY_THREE, viewElement);
            switch (int.Parse(menuNumber))
            {
                case 1:
                    {
                        loginPage.LoginAll();
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
            string menuNumber = CheckMenuNumber(Constant.ARRAY_THREE, viewElement);
            Console.Clear();
            switch (int.Parse(menuNumber))
            {
                case 1: // 로그인
                    {
                        loginPage.LoginAll();
                        break;
                    }
                case 2: // 회원가입
                    {
                        
                        
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
