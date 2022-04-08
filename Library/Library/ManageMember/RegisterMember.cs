using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class RegisterMember
    {
        MemberVO memberVO = new MemberVO();
        SetMemberData memberData = new SetMemberData();
        
        public RegisterMember()
        {

        }

        public void RegisterNewMember()
        {
            Console.Clear();
            PrintRegisterMember();
            ScanRegisterMember();
        }

        public void PrintRegisterMember()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      REGISTER MEMBER                      ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void ScanRegisterMember()
        {
            Console.Write("                   ID : ");
            memberVO.Id = Console.ReadLine();
            Console.Write("                   PW : ");
            memberVO.Password = Console.ReadLine(); ///////// 예외처리
            Console.Write("                   NAME : ");
            memberVO.Name = Console.ReadLine(); 
            Console.Write("                   BIRTH(YYYYMMDD) : ");
            memberVO.Birth = Console.ReadLine(); ///////// 예외처리
            Console.Write("                   PHONE NUMBER('-' 제외) : ");
            memberVO.PhoneNumber = Console.ReadLine(); ///////// 예외처리
            Console.Write("                   ADDRESS(ex. 서울시 광진구) : ");
            memberVO.Address = Console.ReadLine(); ///////// 예외처리

            memberData.memberList.Add(new MemberVO(memberVO.Id, memberVO.Password, memberVO.Name, memberVO.Birth, memberVO.PhoneNumber, memberVO.Address));
        }
    }
}
