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
        Exception exception;
        DatabaseLog databaseLog;
        LogVO logVO;

        public MainPage()
        {
            memberVO = new MemberVO("", "", "", "", "", "");
            logVO = new LogVO("", "", "", "");
            basicViewElement = new BasicViewElement();
            databaseMember = new DatabaseMember();
            databaseBook = new DatabaseBook();
            exception = new Exception();
            databaseLog = new DatabaseLog();
            menuSelection = new MenuSelection(basicViewElement);
            loginSystem = new LoginSystem(basicViewElement, menuSelection, databaseMember, memberVO, databaseBook, exception, databaseLog, logVO);
            modeSelection = new ModeSelection(menuSelection, loginSystem, basicViewElement, memberVO, databaseMember, exception, databaseLog, logVO);
        }

        public void ShowMainPage()
        {
            databaseLog.ExportLog();
            basicViewElement.PrintLibraryMain();
            modeSelection.SelectMode();
        }
    }
}
