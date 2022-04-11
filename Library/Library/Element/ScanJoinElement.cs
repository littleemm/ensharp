using System;

namespace Library
{
    class ScanJoinElement
    {
        MemberVO memberVO;
        private SetMemberData memberData;

        private string id;
        private string password;
        private string name;
        private string birth;
        private string phoneNumber;
        private string address;
        private ConsoleKeyInfo keyInfo;
        public ScanJoinElement()
        {
            memberVO = new MemberVO();
            memberData = new SetMemberData();
        }
        public void ScanJoinInformation()
        {
            memberVO.Id = ScanId();
            memberVO.Password = ScanPassword();
            memberVO.Name = ScanName();
            memberVO.Birth = ScanBirth();
            memberVO.PhoneNumber = ScanPhoneNumber();
            memberVO.Address = ScanAddress();
            memberData.memberList.Add(new MemberVO(memberVO.Id, memberVO.Password, memberVO.Name, memberVO.Birth, memberVO.PhoneNumber, memberVO.Address, ""));
            PrintSuccess();
        }

        private string ScanId()
        {
            Console.Write("                    ID : ");
            id = Console.ReadLine();
            return id;
        }
        private string ScanPassword()
        {
            Console.Write("                    PW : ");
            password = Console.ReadLine();
            return password;
        }

        private string ScanName()
        {
            Console.Write("                  NAME : ");
            name = Console.ReadLine();
            return name;
        }

        private string ScanBirth()
        {
            Console.Write("            BIRTH(YYYYMMDD) : ");
            birth = Console.ReadLine();
            return birth;
        }
        private string ScanPhoneNumber()
        {
            Console.Write("            PHONE NUMBER('-' 제외) : ");
            phoneNumber = Console.ReadLine();
            return phoneNumber;
        }

        private string ScanAddress()
        {
            Console.Write("         ADDRESS(ex. 서울시 광진구) : ");
            address = Console.ReadLine();
            return address;
        }

        private void PrintSuccess()
        {
            Console.WriteLine("       가입이 완료되었습니다! 로그인 창에서 로그인해주세요 ^______^");
            keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("      료합니다. . .");
            }
            else if (keyInfo.Key == ConsoleKey.F1)
            {
                
            }
        }
    }

}
