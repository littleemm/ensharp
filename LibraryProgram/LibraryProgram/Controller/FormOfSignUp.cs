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
        DatabaseMember databaseMember;
        Exception exception;

        public FormOfSignUp(BasicViewElement viewElement, MemberVO memberVO, DatabaseMember databaseMember, Exception exception)
        {
            this.viewElement = viewElement;
            this.memberVO = memberVO;
            this.databaseMember = databaseMember;
            this.exception = exception;
        }

        public void ShowSignUpPage() // 회원가입 페이지
        {
            viewElement.PrintSignUpPage();
            Console.SetCursorPosition(41, 15);
            memberVO.Id = Console.ReadLine();

            Console.SetCursorPosition(41, 17);
            memberVO.Password = Console.ReadLine();

            Console.SetCursorPosition(41, 19);
            memberVO.Name = Console.ReadLine();

            Console.SetCursorPosition(41, 21);
            memberVO.Age = Console.ReadLine();

            Console.SetCursorPosition(41, 23);
            memberVO.PhoneNumber = Console.ReadLine();

            Console.SetCursorPosition(41, 25);
            memberVO.Address = Console.ReadLine();

            databaseMember.InsertMember(memberVO);

        }
    }
}
