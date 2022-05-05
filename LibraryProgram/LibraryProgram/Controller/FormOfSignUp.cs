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
        MemberDTO memberDTO;
        DatabaseMember databaseMember;
        Exception exception;
        DatabaseLog databaseLog;
        LogDTO logDTO;

        public FormOfSignUp(BasicViewElement viewElement, MemberDTO memberDTO, DatabaseMember databaseMember, Exception exception, DatabaseLog databaseLog, LogDTO logDTO)
        {
            this.viewElement = viewElement;
            this.memberDTO = memberDTO;
            this.databaseMember = databaseMember;
            this.exception = exception;
            this.databaseLog = databaseLog;
            this.logDTO = logDTO;
        }

        public void ShowSignUpPage() // 회원가입 페이지
        {
            Console.SetWindowSize(74, 33);
            viewElement.PrintSignUpPage();

            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(42, 15);
                memberDTO.Id = Console.ReadLine();
                isMemberValue = databaseMember.IsMemberId(memberDTO.Id);

                if (isMemberValue == true)
                {
                    viewElement.PrintSameDataSentence(5, 12);
                    Console.SetCursorPosition(42, 15);
                    viewElement.ClearLine(0, 42);
                    isMemberValue = false;
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberDTO.Id);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 15);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(42, 17);
                memberDTO.Password = Console.ReadLine();

                isMemberValue = exception.IsPassword(memberDTO.Password);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 17);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(42, 19);
                memberDTO.Name = Console.ReadLine();

                isMemberValue = exception.IsMemberName(memberDTO.Name);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 19);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(42, 21);
                memberDTO.Age = Console.ReadLine();

                isMemberValue = exception.IsAge(memberDTO.Age);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 21);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(42, 23);
                memberDTO.PhoneNumber = Console.ReadLine();

                isMemberValue = exception.IsPhoneNumber(memberDTO.PhoneNumber);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 23);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(42, 25);
                memberDTO.Address = Console.ReadLine();

                isMemberValue = exception.IsAddress(memberDTO.Address);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 25);
                }
            }
            viewElement.ClearLineEasy(12, 5);
            databaseMember.InsertMember(memberDTO);
            
            logDTO.User = memberDTO.Id;
            logDTO.History = "회원가입";
            databaseLog.InsertLog(logDTO);
        }

        private void PrintFalse(int x, int y)
        {
            viewElement.PrintWarningSentence(3, 12);
            Console.SetCursorPosition(x, y);
            viewElement.ClearLine(0, x);
        }
    }
}
