using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowAdministratorPage
    { // 관리자 로그인 성공 후 페이지 내부

        ScanBasicElement scanAdministratorElement;
        DoAdministratorMode doAdministratorMode;
        DoMemberMode doMemberMode;
        SetMemberData setMemberData;

        private int menuNumber;
        private string[] menuNumberArray;

        public ShowAdministratorPage()
        { // 생성자
            scanAdministratorElement = new ScanBasicElement();
            doAdministratorMode = new DoAdministratorMode();
            doMemberMode = new DoMemberMode();
            setMemberData = new SetMemberData();
           
            menuNumber = 0;
            menuNumberArray = new string[] { "1", "2" };


        }
        
        public void ShowAdministrator()
        {
            Console.Clear();
            PrintAdministrator();
            menuNumber = scanAdministratorElement.SelectMenu(menuNumberArray);

            switch (menuNumber)
            {
                case 1:
                    {
                        doAdministratorMode.ShowAdministratorMode();
                        break;
                    }
                case 2:
                    {
                        setMemberData.memberList.Add(new MemberVO("Administrator1", "1234", "관리자", "20000328", "알 수 없음", "01012345678", " "));
                        doMemberMode.ShowMemberMode(setMemberData.memberList.Count - 1);
                        break;
                    }
            }
        }
        
        public void PrintAdministrator()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      W E L C O M E T O                    ");
            Console.WriteLine("                      ADMINISTRATOR PAGE                   ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                    1. ADMINISTRATOR MODE                  ");
            Console.WriteLine("                       2. MEMBER MODE                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }


    }
}
