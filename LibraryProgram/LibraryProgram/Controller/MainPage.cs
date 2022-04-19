using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MainPage
    {
        BasicViewElement basicViewElement;
        ModeSelection modeSelection;
        MenuSelection menuSelection;
        LoginSystem loginSystem;
        DatabaseMember databaseMember;
        MemberVO memberVO;

        public MainPage()
        {
            memberVO = new MemberVO("", "", "", "", "", "", "", "");
            basicViewElement = new BasicViewElement();
            databaseMember = new DatabaseMember();
            menuSelection = new MenuSelection(basicViewElement);
            loginSystem = new LoginSystem(basicViewElement, menuSelection, databaseMember);
            modeSelection = new ModeSelection(menuSelection, loginSystem, basicViewElement, memberVO);
          
        }

        public void ShowMainPage()
        {
            basicViewElement.PrintLibraryMain();
            modeSelection.SelectMode();
        }
    }
}
