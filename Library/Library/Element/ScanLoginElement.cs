using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ScanLoginElement // 로그인 입력 받기
    {
        CheckLoginInformation checkLoginInformation = new CheckLoginInformation();

        string id;
        string password;
        bool isLoginSuccess;

        public ScanLoginElement()
        {
            id = "";
            password = "";
            isLoginSuccess = false;
        }
        
        public void ScanInformation() // 로그인
        {
            while (isLoginSuccess == false)
            {
                Console.Write("                    ID : ");
                id = Console.ReadLine();
                Console.Write("                    PW : ");
                password = Console.ReadLine();

                isLoginSuccess = checkLoginInformation.IsLogin(id, password);
                if (isLoginSuccess == false)
                {
                    Console.WriteLine("        일치하는 회원 정보가 없습니다. 다시 로그인하세요! ");
                }
            }
        }

        
    }
}
