using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MainPage
    {
        BasicPage basicPage;
        ModeSelection modeSelection;
        MenuSelection menuSelection;
        LoginSystem loginSystem;
        MemberDAO databaseMember;
        BookDAO databaseBook;
        MemberDTO memberDTO;
        Exception exception;
        LogDAO databaseLog;
        LogDTO logDTO;
        KeyReader keyReader;

        public MainPage()
        {
            memberDTO = new MemberDTO("", "", "", "", "", "");
            logDTO = new LogDTO("", "", "", "");
            basicPage = new BasicPage();
            databaseMember = new MemberDAO();
            databaseBook = new BookDAO();
            exception = new Exception();
            databaseLog = new LogDAO();
            keyReader = new KeyReader();
            menuSelection = new MenuSelection(basicPage);
            loginSystem = new LoginSystem(basicPage, menuSelection, databaseMember, memberDTO, databaseBook, exception, databaseLog, logDTO, keyReader);
            modeSelection = new ModeSelection(menuSelection, loginSystem, basicPage, memberDTO, databaseMember, databaseBook, exception, databaseLog, logDTO, keyReader);
        }

        public void ShowMainPage()
        {

            modeSelection.SelectMode();
        }
    }
}
