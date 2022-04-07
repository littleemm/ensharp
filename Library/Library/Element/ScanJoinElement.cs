using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ScanJoinElement
    {
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
            id = Console.ReadLine();
        }
        public void ScanPassword()
        {
            Console.Write("                    PW : ");
            password = Console.ReadLine();
        }

        public void ScanName()
        {
            Console.Write("                  NAME : ");
            name = Console.ReadLine();
        }

        public void ScanBirth()
        {
            Console.Write("            BIRTH(YYYYMMDD) : ");
            birth = Console.ReadLine();
        }
        public void ScanPhoneNumber()
        {
            Console.Write("            PHONE NUMBER('-' 제외) : ");
            phoneNumber = Console.ReadLine();
        }

        public void ScanAddress()
        {
            Console.Write("         ADDRESS(ex. 서울시 광진구) : ");
            address = Console.ReadLine();
        }
    }

}
