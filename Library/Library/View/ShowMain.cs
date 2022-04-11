using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowMain
    {
        ScanBasicElement scanElement;
        PrintBasicElement printElement;
        ShowLogin showLogin;
        ShowMemberPage showMemberPage;
        
        private int realMenuNumber;
        private string[] menuNumberArray;

        public ShowMain()
        {
            scanElement = new ScanBasicElement();
            printElement = new PrintBasicElement();
            showLogin = new ShowLogin();
            showMemberPage = new ShowMemberPage();

            menuNumberArray = new string[] { "1", "2", "3" };
        }
        public void ShowPage()
        {
            printElement.PrintLibraryMain();
            realMenuNumber = scanElement.SelectMenu(menuNumberArray);
            
            switch(realMenuNumber)
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
                        printElement.PrintExit();
                        break;
                    }
            }
        }
    }
}
