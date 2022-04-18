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
        BasicViewElement viewElement;

        public LoginSystem(BasicViewElement viewElement, MenuSelection menuSelection)
        {
            this.viewElement = viewElement;
            administratorMode = new AdministratorMode(viewElement, menuSelection);
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
            LoginAll();

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
