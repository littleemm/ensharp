using System;

namespace Library
{
    class ScanJoinElement
    {
        MemberVO memberVO = new MemberVO();
        SetMemberData memberData = new SetMemberData();

        private string id;
        private string password;
        private string name;
        private string birth;
        private string phoneNumber;
        private string address;

        public ScanJoinElement()
        {

        }
        public void ScanJoinInformation()
        {
            memberVO.Id = ScanId();
            memberVO.Password = ScanPassword();
            memberVO.Name = ScanName();
            memberVO.Birth = ScanBirth();
            memberVO.PhoneNumber = ScanPhoneNumber();
            memberVO.Address = ScanAddress();
            memberData.memberList.Add(new MemberVO(memberVO.Id, memberVO.Password, memberVO.Name, memberVO.Birth, memberVO.PhoneNumber, memberVO.Address));
        }
        public string ScanId()
        {
            Console.Write("                    ID : ");
            id = Console.ReadLine();
            return id;
        }
        public string ScanPassword()
        {
            Console.Write("                    PW : ");
            password = Console.ReadLine();
            return password;
        }

        public string ScanName()
        {
            Console.Write("                  NAME : ");
            name = Console.ReadLine();
            return name;
        }

        public string ScanBirth()
        {
            Console.Write("            BIRTH(YYYYMMDD) : ");
            birth = Console.ReadLine();
            return birth;
        }
        public string ScanPhoneNumber()
        {
            Console.Write("            PHONE NUMBER('-' 제외) : ");
            phoneNumber = Console.ReadLine();
            return phoneNumber;
        }

        public string ScanAddress()
        {
            Console.Write("         ADDRESS(ex. 서울시 광진구) : ");
            address = Console.ReadLine();
            return address;
        }
    }

}
