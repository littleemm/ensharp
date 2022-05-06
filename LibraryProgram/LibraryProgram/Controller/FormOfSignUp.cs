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
        KeyReader keyReader;

        public FormOfSignUp(BasicViewElement viewElement, MemberDTO memberDTO, DatabaseMember databaseMember, Exception exception, DatabaseLog databaseLog, LogDTO logDTO, KeyReader keyReader)
        {
            this.viewElement = viewElement;
            this.memberDTO = memberDTO;
            this.databaseMember = databaseMember;
            this.exception = exception;
            this.databaseLog = databaseLog;
            this.logDTO = logDTO;
            this.keyReader = keyReader;
        }

        public string ShowSignUpPage() // 회원가입 페이지
        {
            Console.SetWindowSize(74, 33);
            viewElement.PrintSignUpPage();

            bool isMemberValue = false;

            while (!isMemberValue)
            {
                memberDTO.Id = keyReader.ReadKeyBasic(42, 15, memberDTO.Id);
                if (memberDTO.Id == "\\n") return "\\n";

                isMemberValue = databaseMember.IsMemberId(memberDTO.Id);

                if (isMemberValue)
                {
                    viewElement.PrintWarningSentence(8, 12, "이미 존재하는 아이디입니다.");
                    Console.SetCursorPosition(42, 15);
                    viewElement.ClearLine(0, 42);
                    isMemberValue = false;
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberDTO.Id);
                if (!isMemberValue)
                {
                    PrintFalse(42, 15);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (!isMemberValue)
            {
                memberDTO.Id = keyReader.ReadKeySecret(42, 17, memberDTO.Password);
                if (memberDTO.Password == "\\n") return "\\n";

                isMemberValue = exception.IsPassword(memberDTO.Password);
                if (!isMemberValue)
                {
                    PrintFalse(42, 17);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (!isMemberValue)
            {
                memberDTO.Name = keyReader.ReadKeyBasic(42, 19, memberDTO.Name);
                if (memberDTO.Name == "\\n") return "\\n";

                isMemberValue = exception.IsMemberName(memberDTO.Name);
                if (!isMemberValue)
                {
                    PrintFalse(42, 19);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (!isMemberValue)
            {
                memberDTO.Age = keyReader.ReadKeyBasic(42, 21, memberDTO.Age);
                if (memberDTO.Age == "\\n") return "\\n";

                isMemberValue = exception.IsAge(memberDTO.Age);
                if (!isMemberValue)
                {
                    PrintFalse(42, 21);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (!isMemberValue)
            {
                memberDTO.PhoneNumber = keyReader.ReadKeyBasic(42, 23, memberDTO.PhoneNumber);
                if (memberDTO.PhoneNumber == "\\n") return "\\n";

                isMemberValue = exception.IsPhoneNumber(memberDTO.PhoneNumber);
                if (!isMemberValue)
                {
                    PrintFalse(42, 23);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(12, 5);

            while (!isMemberValue)
            {
                memberDTO.Address = keyReader.ReadKeyBasic(42, 25, memberDTO.Address);
                if (memberDTO.Address == "\\n") return "\\n";

                isMemberValue = exception.IsAddress(memberDTO.Address);
                if (!isMemberValue)
                {
                    PrintFalse(42, 25);
                }
            }
            viewElement.ClearLineEasy(12, 5);
            databaseMember.InsertMember(memberDTO);
            
            logDTO.User = memberDTO.Id;
            logDTO.History = "회원가입";
            databaseLog.InsertLog(logDTO);

            return "";
        }

        private void PrintFalse(int x, int y)
        {
            viewElement.PrintWarningSentence(3, 12, "조건에 맞춰서 다시 입력해주세요.");
            Console.SetCursorPosition(x, y);
            viewElement.ClearLine(0, x);
        }
    }
}
