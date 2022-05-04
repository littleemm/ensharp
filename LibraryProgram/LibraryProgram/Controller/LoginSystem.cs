﻿using System;
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
        private ConsoleKeyInfo keyInfo;

        AdministratorMode administratorMode;
        MemberMode memberMode;
        BasicViewElement viewElement;
        DatabaseMember databaseMember;

        public LoginSystem(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberDTO memberDTO, DatabaseBook databaseBook, Exception exception, DatabaseLog databaseLog, LogDTO logDTO)
        {
            keyInfo = new ConsoleKeyInfo();
            this.viewElement = viewElement;
            this.databaseMember = databaseMember;
            this.viewElement = viewElement;
            administratorMode = new AdministratorMode(viewElement, menuSelection, databaseMember, memberDTO, databaseBook, exception, databaseLog, logDTO);
            memberMode = new MemberMode(viewElement, menuSelection, databaseMember, databaseBook, exception, databaseLog, logDTO);
        }

        public void LoginAdministratorMode() // 관리자 로그인 모드
        {
            Console.Clear();
            bool isIdAndPassword = Constant.ID_AND_PW_UNCORRECT_NOW;
            viewElement.PrintLoginPage();
            while (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW) {
                LoginAll(); 
                isIdAndPassword = databaseMember.SelectMember(Constant.SELECT_QUERY_ADMIN, id, password);
                if (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)
                { // 아이디, 비밀번호 중 하나라도 틀리면 다시
                    viewElement.ClearLine(0, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.ClearLine(0, 37);
                    viewElement.PrintLoginWarning(2, 12);
                }
            }
            administratorMode.ShowAdministratorPage();
        }

        public void LoginMemberMode() // 로그인 회원모드
        {
            Console.Clear();
            bool isIdAndPassword = Constant.ID_AND_PW_UNCORRECT_NOW;
            viewElement.PrintLoginPage();
            while (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)
            {
                LoginAll();
                isIdAndPassword = databaseMember.SelectMember(Constant.SELECT_QUERY_MEMBER, id, password);
                if (isIdAndPassword == Constant.ID_AND_PW_UNCORRECT_NOW)// 아이디 비밀번호 틀렸을 경우 <- 매직넘버 처리 
                {
                    viewElement.ClearLine(0, 37);
                    Console.SetCursorPosition(37, 14);
                    viewElement.ClearLine(0, 37);
                    viewElement.PrintLoginWarning(2, 12);
                }
            }

            memberMode.ShowMemberPage(id);
            
        }

        public void LoginAll() // 공통 로그인 폼 함수
        {
            Console.SetCursorPosition(37, 14);
            id = Console.ReadLine(); // 아이디 입력

            Console.SetCursorPosition(37, 16);
            password = "";

             // 비밀번호 *처리
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar.ToString();
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
            }
        }
    }
}
