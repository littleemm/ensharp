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
        MemberDTO memberDTO;
        Exception exception;
        DatabaseLog databaseLog;
        LogDTO logDTO;

        public MainPage()
        {
            memberDTO = new MemberDTO("", "", "", "", "", "");
            logDTO = new LogDTO("", "", "", "");
            basicViewElement = new BasicViewElement();
            databaseMember = new DatabaseMember();
            databaseBook = new DatabaseBook();
            exception = new Exception();
            databaseLog = new DatabaseLog();
            menuSelection = new MenuSelection(basicViewElement);
            loginSystem = new LoginSystem(basicViewElement, menuSelection, databaseMember, memberDTO, databaseBook, exception, databaseLog, logDTO);
            modeSelection = new ModeSelection(menuSelection, loginSystem, basicViewElement, memberDTO, databaseMember, databaseBook, exception, databaseLog, logDTO);
        }

        public void ShowMainPage()
        {

            modeSelection.SelectMode();
        }
    }
}
