﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class FindMemberInformation
    {
        MemberVO memberVO = new MemberVO();
        SetMemberData memberData = new SetMemberData();
        private int memberListIndex;

        public FindMemberInformation()
        {

        }
        public string ScanFindMember(bool isMemberId)
        {
            while (isMemberId == false)
            {
                Console.Write("                 회원 ID를 입력하세요 : ");
                memberVO.Id = Console.ReadLine();
                isMemberId = IsMemberId(isMemberId, memberVO.Id);
            }

            return memberVO.Id;
        }
        public bool IsMemberId(bool isMemberId, string id)
        {
            for (int listIndex = 0; listIndex < memberData.memberList.Count; listIndex++)
            {
                if (id.Equals(memberData.memberList[listIndex].Id))
                {
                    isMemberId = true;
                }
            }

            if (isMemberId == false)
            {
                Console.WriteLine("            일치하는 회원 정보가 없습니다! 다시 입력하세요.         ");
            }

            return isMemberId;
        }

        public int FindListIndex(string id)
        {
            for (int listIndex = 0; listIndex < memberData.memberList.Count; listIndex++)
            {
                if (id.Equals(memberData.memberList[listIndex].Id))
                {
                    memberListIndex = listIndex;
                    Console.WriteLine(listIndex);
                    break;
                }
            }

            return memberListIndex;
        }
    }
}
