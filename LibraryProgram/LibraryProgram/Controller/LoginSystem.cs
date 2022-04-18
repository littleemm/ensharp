using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class LoginSystem
    {
        BasicViewElement viewElement;

        public LoginSystem(BasicViewElement viewElement)
        {
            this.viewElement = viewElement;
        }

        public void LoginAll()
        {
            string id;
            string password;

            Console.Clear();
            viewElement.PrintLoginPage();
            Console.SetCursorPosition(37, 14);
            id = Console.ReadLine();

            Console.SetCursorPosition(37, 16);
            password = Console.ReadLine();

            if (id == "AD1")
            {
                LoginAdministratorMode(password);
            }
            else
            {
                LoginMemberMode(id, password);
            }
        }

        public void LoginAdministratorMode(string password)
        {
            if (password == "1234")
            {

            }

            else
            {
                viewElement.PrintWarningSentence(4, 16);
            }
        }

        public void LoginMemberMode(string id, string password)
        {

        }
    }
}
