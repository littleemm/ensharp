using System;

namespace Library
{
    class ScanJoinElement
    {
        MemberVO memberVO;
        private SetMemberData memberData;
        private FindJoinException findException;

        private string id;
        private string password;
        private string name;
        private string birth;
        private string phoneNumber;
        private string address;
        private bool isValue;
        private ConsoleKeyInfo keyInfo;
        public ScanJoinElement()
        {
            memberVO = new MemberVO();
            memberData = new SetMemberData();
            findException = new FindJoinException();
            isValue = false;
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
        }

        private string ScanId()
        {
            while (isValue == false)
            {
                Console.Write("                  ID (8자 이내) : ");
                id = Console.ReadLine();
                isValue = findException.IsId(id);
 
            }
            isValue = false;
            return id;
        }
        private string ScanPassword()
        {
            while (isValue == false)
            {
                Console.Write("                  PW (5자 이내) : ");
                password = Console.ReadLine();
                isValue = findException.IsPassword(password);
            }
            isValue = false;
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
            while (isValue == false)
            {
                Console.Write("               BIRTH(YYYYMMDD) : ");
                birth = Console.ReadLine();
                isValue = findException.IsBirth(birth);
            }
            isValue = false;
            return birth;
        }
        private string ScanPhoneNumber()
        {
            while (isValue == false)
            {
                Console.Write("            PHONE NUMBER(ex. 01000000000) : ");
                phoneNumber = Console.ReadLine();
                isValue = findException.IsPhoneNumber(phoneNumber);
            }
            isValue = false;
            return phoneNumber;
        }

        private string ScanAddress()
        {
            while (isValue == false)
            {
                Console.Write("         ADDRESS(ex. 서울시 광진구) : ");
                address = Console.ReadLine();
                isValue = findException.IsAddress(address);
            }
            isValue = false;
            return address;
        }

        private void PrintSuccess()
        {
            Console.WriteLine("             회원 등록이 완료되었습니다!");
            keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine(" 종료합니다. . .");
            }
            else if (keyInfo.Key == ConsoleKey.F1)
            {
                
            }
        }
    }

}
