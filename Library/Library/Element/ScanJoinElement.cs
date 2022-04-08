using System;
using System.Collections.Generic;
using System.Text;

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
            ScanId();
            ScanPassword();
            ScanName();
            ScanBirth();
            ScanPhoneNumber();
            ScanAddress();
        }
        public void ScanId()
        {
            Console.Write("                    ID : ");
            memberVO.Id = Console.ReadLine();
        }
        public void ScanPassword()
        {
            Console.Write("                    PW : ");
            memberVO.Password = Console.ReadLine();
        }

        public void ScanName()
        {
            Console.Write("                  NAME : ");
            memberVO.Name = Console.ReadLine();
        }

        public void ScanBirth()
        {
            Console.Write("            BIRTH(YYYYMMDD) : ");
            memberVO.Birth = Console.ReadLine();
        }
        public void ScanPhoneNumber()
        {
            Console.Write("            PHONE NUMBER('-' 제외) : ");
            memberVO.PhoneNumber = Console.ReadLine();
        }

        public void ScanAddress()
        {
            Console.Write("         ADDRESS(ex. 서울시 광진구) : ");
            memberVO.Address = Console.ReadLine();
        }
    }

}
