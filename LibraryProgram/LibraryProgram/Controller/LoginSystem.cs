using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class LoginSystem
    {
        private string id;
        private string password;

        AdministratorMode administratorMode;
        MemberMode memberMode;
        BasicViewElement viewElement;
        DatabaseMember databaseMember;

        public LoginSystem(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember)
        {
            this.viewElement = viewElement;
            this.databaseMember = databaseMember;
            this.viewElement = viewElement;
            administratorMode = new AdministratorMode(viewElement, menuSelection);
            memberMode = new MemberMode(viewElement, menuSelection);
        }

        public void LoginAdministratorMode()
        {
            while (Constant.ID_AND_PW_UNCORRECT) {

                LoginAll();

                if (id == "AD1" && password == "1234")
                {
                    administratorMode.ShowAdministratorPage();
                    break;
                }

                viewElement.PrintWarningSentence(4, 16);
            }
        }

        public void LoginMemberMode() // database
        {
            bool isIdAndPassword = false;
            while (isIdAndPassword == false)
            {
                LoginAll();
                isIdAndPassword = databaseMember.SelectMember(1, id, password);
            }
        }

        public void LoginAll()
        {
            Console.Clear();
            viewElement.PrintLoginPage();
            Console.SetCursorPosition(37, 14);
            id = Console.ReadLine();

            Console.SetCursorPosition(37, 16);
            password = Console.ReadLine();
        }
    }
}
