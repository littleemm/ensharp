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
        DatabaseMemberBook databaseMemberBook;
        MemberVO memberVO;
        Exception exception;

        public MainPage()
        {
            memberVO = new MemberVO("", "", "", "", "", "");
            basicViewElement = new BasicViewElement();
            databaseMember = new DatabaseMember();
            databaseBook = new DatabaseBook();
            exception = new Exception();
            menuSelection = new MenuSelection(basicViewElement);
            loginSystem = new LoginSystem(basicViewElement, menuSelection, databaseMember, memberVO, databaseBook, databaseMemberBook, exception);
            modeSelection = new ModeSelection(menuSelection, loginSystem, basicViewElement, memberVO, databaseMember, exception);
        }

        public void ShowMainPage()
        {
            basicViewElement.PrintLibraryMain();
            modeSelection.SelectMode();
        }
    }
}
