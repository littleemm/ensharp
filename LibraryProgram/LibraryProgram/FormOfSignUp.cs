using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class FormOfSignUp
    {

        BasicViewElement viewElement;

        public FormOfSignUp(BasicViewElement viewElement)
        {
            this.viewElement = viewElement;
        }

        public void ShowSignUpPage()
        {
            viewElement.PrintSignUpPage();


        }
    }
}
