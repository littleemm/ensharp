using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class MainLoginPage // 로그인 페이지 (Visible)
    {
        private ViewElement loginViewElement;
        private LoginAdministrationPage administrationPage;
        private FirstMenuPage firstMenuPage;

        private int passwordLength;

        public MainLoginPage()
        {
            loginViewElement = new ViewElement();
            administrationPage = new LoginAdministrationPage();
            firstMenuPage = new FirstMenuPage();
        }

        public void ShowLoginPage()
        {
            loginViewElement.PrintMainPage();
            administrationPage.CheckPersonalInformation(Constant.LOGIN_WIDTH, Constant.ID_POSITION, "20010501");
            passwordLength = administrationPage.CheckPassword(Constant.LOGIN_WIDTH, Constant.PASSWORD_POSITION, "1234");

            if (passwordLength == 4)
            {
                firstMenuPage.ShowMenuSelection(firstMenuPage);
            }
        }



    }
}
