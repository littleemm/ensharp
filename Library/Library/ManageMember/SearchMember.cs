using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class SearchMember
    {
        private MemberVO memberVO;
        private SetMemberData memberData;
        private FindMemberInformation findSearchMemberInformation;

        private bool isMemberId; //
        private int memberListIndex; // 
        private string memberId; // 

        public SearchMember()
        {
            memberVO = new MemberVO();
            memberData = new SetMemberData();
            findSearchMemberInformation = new FindMemberInformation();

            isMemberId = false;
            memberId = "";
        }

        public void ShowMemberSearching()
        {
            Console.Clear();
            PrintSearchBook();
            memberId = findSearchMemberInformation.ScanFindMember(isMemberId);
            memberListIndex = findSearchMemberInformation.FindListIndex(memberId);
            SearchMemberInformation(memberListIndex);
        }

        public void PrintSearchBook()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                        SEARCH MEMBER                       ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void SearchMemberInformation(int memberListIndex)
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("       아  이  디 : " + memberData.memberList[memberListIndex].Id);
            Console.WriteLine("       이      름 : " + memberData.memberList[memberListIndex].Name);
            Console.WriteLine("       출  생  일 : " + memberData.memberList[memberListIndex].Birth);
            Console.WriteLine("       주      소 : " + memberData.memberList[memberListIndex].Address);
            Console.WriteLine("       폰  번  호 : " + memberData.memberList[memberListIndex].PhoneNumber);
            Console.WriteLine("=============================================================");
        }
    }
}
