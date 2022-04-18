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

        public ModeSelection(int positionX, int positionY, AdministratorMode admistratorMode, MemberMode memberMode, BasicViewElement viewElement) : base(positionX, positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;

            this.viewElement = viewElement;
        }
        
        public void SelectMode()
        {
            string menuNumber = CheckMenuNumber(Constant.ARRAY_THREE, viewElement);
            switch (int.Parse(menuNumber))
            {
                case 1:
                    {
                        showLogin.ShowLoginPage();
                        break;
                    }
                case 2:
                    {
                        showMemberPage.ShowMemberMain();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        viewElement.PrintExit();
                        break;
                    }
            }
        }
    }
}
