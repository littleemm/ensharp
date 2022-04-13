using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class MainLoginPage // 로그인 페이지 (Visible)
    {
        private LoginViewElement loginViewElement;
        private LoginAdministrationPage administrationPage;

        public MainLoginPage()
        {
            loginViewElement = new LoginViewElement();
            administrationPage = new LoginAdministrationPage();
        }

        public void ShowLoginPage()
        {
            loginViewElement.PrintMainPage();
            administrationPage.CheckPersonalInformation(40, 5, "20010501");
            administrationPage.CheckPersonalInformation(40, 6, "1234");



        }



    }
}
