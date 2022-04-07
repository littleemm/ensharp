using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowMain
    {
        ScanBasicElement scanElement = new ScanBasicElement();
        PrintBasicElement printElement = new PrintBasicElement();
        ShowLogin showLogin = new ShowLogin();
        ShowJoin showJoin = new ShowJoin();
        int realMenuNumber;
        public ShowMain()
        {

        }
        public void ShowPage()
        {
            printElement.PrintLibraryMain();
            realMenuNumber = scanElement.SelectMenu();
            
            switch(realMenuNumber)
            {
                case 1:
                    {
                        showLogin.ShowLoginPage();
                        break;
                    }
                case 2:
                    {
                        showJoin.ShowJoinPage();
                        break;
                    }
                case 3:
                    {
                        break;
                    }
            }
        }
    }
}
