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

            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(41, 15);
                memberVO.Id = Console.ReadLine();
                isMemberValue = databaseMember.IsMemberId(memberVO.Id);

                if (isMemberValue == true)
                {
                    viewElement.PrintSameDataSentence(5, 12);
                    Console.SetCursorPosition(41, 15);
                    viewElement.ClearLine(0, 41);
                    isMemberValue = false;
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberVO.Id);
                if (isMemberValue == false)
                {
                    PrintFalse(41, 15);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(41, 17);
                memberVO.Password = Console.ReadLine();

                isMemberValue = exception.IsPassword(memberVO.Password);
                if (isMemberValue == false)
                {
                    PrintFalse(41, 17);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(41, 19);
                memberVO.Name = Console.ReadLine();

                isMemberValue = exception.IsMemberName(memberVO.Name);
                if (isMemberValue == false)
                {
                    PrintFalse(41, 19);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(41, 21);
                memberVO.Age = Console.ReadLine();

                isMemberValue = exception.IsAge(memberVO.Age);
                if (isMemberValue == false)
                {
                    PrintFalse(41, 21);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(41, 23);
                memberVO.PhoneNumber = Console.ReadLine();

                isMemberValue = exception.IsPhoneNumber(memberVO.PhoneNumber);
                if (isMemberValue == false)
                {
                    PrintFalse(41, 23);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(41, 25);
                memberVO.Address = Console.ReadLine();

                isMemberValue = exception.IsAddress(memberVO.Address);
                if (isMemberValue == false)
                {
                    PrintFalse(41, 25);
                }
            }

            databaseMember.InsertMember(memberVO);

        }

        private void PrintFalse(int x, int y)
        {
            viewElement.PrintWarningSentence(3, 12);
            Console.SetCursorPosition(x, y);
            viewElement.ClearLine(0, x);
        }
    }
}
