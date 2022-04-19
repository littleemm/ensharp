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
            Console.Clear();
            viewElement.PrintLoginPage();
            while (Constant.ID_AND_PW_UNCORRECT) {

                LoginAll();

                if (id == "AD1" && password == "1234")
                {
                    administratorMode.ShowAdministratorPage();
                    break;
                }

                viewElement.ClearLine(1, 37);
                Console.SetCursorPosition(37, 16);
                viewElement.ClearLine(2, 37);
                Console.SetCursorPosition(37, 14);
                viewElement.PrintLoginWarning(2, 12);
            }
        }

        public void LoginMemberMode() // database
        {
            Console.Clear();
            bool isIdAndPassword = false;
            viewElement.PrintLoginPage();
            while (isIdAndPassword == false)
            {
                LoginAll();
                isIdAndPassword = databaseMember.SelectMember(4, id, password);
                if (isIdAndPassword == false)
                {
                    viewElement.ClearLine(1, 37);
                    Console.SetCursorPosition(37, 16);
                    viewElement.ClearLine(2, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.PrintLoginWarning(2, 12);
                }
            }
            
        }

        public void LoginAll()
        {
            Console.SetCursorPosition(37, 14);
            id = Console.ReadLine();

            Console.SetCursorPosition(37, 16);
            password = Console.ReadLine();
        }
    }
}
