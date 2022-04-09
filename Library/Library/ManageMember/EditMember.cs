﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class EditMember
    {
        MemberVO memberVO = new MemberVO();
        SetMemberData memberData = new SetMemberData();
        FindMemberInformation findEditMemberInformation = new FindMemberInformation();

        private bool isMemberId; // 일치하는 책 제목인지 판별
        private int memberListIndex; // 책 제목에 따른 리스트 인덱스
        private string memberId; // 책 이름

        public EditMember()
        {
            isMemberId = false;
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
            Console.WriteLine("                        EDIT ADDRESS                     ");
            Console.WriteLine("                                                           ");
            Console.WriteLine(" *                  *                  *                  * ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("           *                 *                 *            ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");
        }

        public void Edit(int listIndex) // 주소 변경
        {
            Console.Write("                  주소를 입력하세요 : ");
            memberVO.Address = Console.ReadLine(); ///////// 예외처리

            memberData.memberList[listIndex].Address = memberVO.Address;
        }
    }
}
