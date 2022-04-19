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
        MemberVO memberVO;

        public FormOfSignUp(BasicViewElement viewElement, MemberVO memberVO)
        {
            this.viewElement = viewElement;
            this.memberVO = memberVO;
        }

        public void ShowSignUpPage()
        {
            viewElement.PrintSignUpPage();
            Console.SetCursorPosition(41, 15);
            memberVO.Id = Console.ReadLine();

        }
    }
}
