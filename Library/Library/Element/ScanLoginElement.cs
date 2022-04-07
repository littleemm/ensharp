using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ScanLoginElement // 로그인 입력 받기
    {
        string id;
        string password;

        public ScanLoginElement()
        {
            id = "";
            password = "";
        }
        
        public void ScanInformation() // 로그인
        {
            Console.Write("                    ID : ");
            id = Console.ReadLine();
            Console.Write("                    PW : ");
            password = Console.ReadLine();
        }
    }
}
