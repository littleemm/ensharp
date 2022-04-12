using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class EditMember
    {
        MemberVO memberVO;
        SetMemberData memberData;
        FindMemberInformation findEditMemberInformation;
        FindJoinException findException;

        private bool isMemberId; // 일치하는 책 제목인지 판별
        private bool isValue; // 입력이 맞는지 판별
        private int memberListIndex; // 책 제목에 따른 리스트 인덱스
        private string memberId; // 책 이름

        public EditMember()
        {
            memberVO = new MemberVO();
            memberData = new SetMemberData();
            findEditMemberInformation = new FindMemberInformation();
            findException = new FindJoinException();
            isMemberId = false;
            isValue = false;
            memberId = "";
        }

        public void EditLibraryMember() // 정보 수정
        {
            Console.Clear();
            PrintEditMember();
            memberId = findEditMemberInformation.ScanFindMember(isMemberId);
            memberListIndex = findEditMemberInformation.FindListIndex(memberId);
            Edit(memberListIndex);
        }
        public void PrintEditMember()
        {
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                EDIT ADDRESS / PHONE NUMBER                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        private void Edit(int listIndex) // 주소 변경
        {
            while (isValue == false)
            {
                Console.Write("                  주소를 입력하세요 : ");
                memberVO.Address = Console.ReadLine(); ///////// 예외처리
                isValue = findException.IsAddress(memberVO.Address);
            }
            isValue = false;

            while (isValue == false)
            {
                Console.Write("                  번호를 입력하세요 : ");
                memberVO.PhoneNumber = Console.ReadLine(); ///////// 예외처리
                isValue = findException.IsPhoneNumber(memberVO.PhoneNumber);
            }

            memberData.memberList[listIndex].Address = memberVO.Address;
            memberData.memberList[listIndex].PhoneNumber = memberVO.PhoneNumber;
        }
    }
}
