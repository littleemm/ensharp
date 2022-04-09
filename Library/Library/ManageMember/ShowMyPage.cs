using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ShowMyPage
    {
        MemberVO memberVO;
        SetMemberData memberData;

        public ShowMyPage()
        {
            memberVO = new MemberVO();
            memberData = new SetMemberData();
        }

        public void PrintMyPage(int listIndex)
        {
            Console.Clear();
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                           MY PAGE                         ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("=============================================================");
            Console.WriteLine("       아  이  디 : " + memberData.memberList[listIndex].Id);
            Console.WriteLine("       이      름 : " + memberData.memberList[listIndex].Name);
            Console.WriteLine("       출  생  일 : " + memberData.memberList[listIndex].Birth);
            Console.WriteLine("       주      소 : " + memberData.memberList[listIndex].Address);
            Console.WriteLine("       폰  번  호 : " + memberData.memberList[listIndex].PhoneNumber);
            Console.WriteLine("       빌  린  책 : " + memberData.memberList[listIndex].Book);
            Console.WriteLine("=============================================================");
        }
    }
}
