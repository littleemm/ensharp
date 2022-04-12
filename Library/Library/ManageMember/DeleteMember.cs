using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class DeleteMember
    {
        SetMemberData memberData;
        FindMemberInformation findDeleteMemberInformation;
        
        private bool isMemberId; // 일치하는 회원 id인지 판별
        private int memberListIndex; // 회원 리스트 인덱스
        private string memberId; // 회원 id

        public DeleteMember()
        {
            memberData = new SetMemberData();
            findDeleteMemberInformation = new FindMemberInformation();

            isMemberId = false;
            memberId = "";
        }
        public void DeleteLibraryMember()
        {
            Console.Clear();
            PrintDeleteMember();
            memberId = findDeleteMemberInformation.ScanFindMember(isMemberId);
            memberListIndex = findDeleteMemberInformation.FindListIndex(memberId);
            DeleteMemberInformation(memberListIndex);
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
        public void DeleteMemberInformation(int listIndex)
        {
            memberData.memberList.RemoveAt(listIndex);
            Console.WriteLine("                 성공적으로 처리되었습니다 ");
        }
    }
}
