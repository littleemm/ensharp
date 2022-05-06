﻿using System;
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
        DatabaseMember databaseMember;
        DatabaseBook databaseBook;
        MemberDTO memberDTO;
        Exception exception;
        DatabaseLog databaseLog;
        LogDTO logDTO;
        KeyReader keyReader;

        public MainPage()
        {
            memberDTO = new MemberDTO("", "", "", "", "", "");
            logDTO = new LogDTO("", "", "", "");
            basicPage = new BasicPage();
            databaseMember = new DatabaseMember();
            databaseBook = new DatabaseBook();
            exception = new Exception();
            databaseLog = new DatabaseLog();
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
