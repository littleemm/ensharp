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
        DatabaseBook databaseBook;
        MemberVO memberVO;

        public MainPage()
        {
            memberVO = new MemberVO("", "", "", "", "", "");
            basicViewElement = new BasicViewElement();
            databaseMember = new DatabaseMember();
            databaseBook = new DatabaseBook();
            menuSelection = new MenuSelection(basicViewElement);
            loginSystem = new LoginSystem(basicViewElement, menuSelection, databaseMember, memberVO, databaseBook);
            modeSelection = new ModeSelection(menuSelection, loginSystem, basicViewElement, memberVO, databaseMember);
          
        }

        public void ShowMainPage()
        {
            basicViewElement.PrintLibraryMain();
            modeSelection.SelectMode();
        }
    }
}
