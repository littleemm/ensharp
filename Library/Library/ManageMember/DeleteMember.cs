using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class DeleteMember
    {
        MemberVO memberVO = new MemberVO();
        FindMemberInformation findDeleteMemberInformation = new FindMemberInformation();
        private bool isMemberId; // 일치하는 회원 id인지 판별
        private int bookListIndex; // 회원 리스트 인덱스
        private string memberId; // 회원 id

        public DeleteMember()
        {
            isMemberId = false;
            memberId = "";
        }
        public void DeleteLibraryMember()
        {
            Console.Clear();
            PrintDeleteMember();
            memberId = findDeleteMemberInformation.ScanFindMember(isMemberId);
            bookListIndex = findDeleteMemberInformation.FindListIndex(memberId);
        }

        public void PrintDeleteMember()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                      DELETE MEMBER T_T                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }
        public void DeleteBookInformation(int listIndex)
        {
            SetMemberData.memberList[listIndex] = null;
        }
    }
}
