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
                        showLogin.showLoginPage();
                        break;
                    }
                case 2:
                    {
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
