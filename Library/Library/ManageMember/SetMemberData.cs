﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class SetMemberData
    {
        public List<MemberVO> memberList = new List<MemberVO>();
        public SetMemberData()
        {
            memberList.Add(new MemberVO("gogogo1", "password1", "고양이", "20210101", "경기도 고양시", "01011111111", "신과 함께 저승편 1"));
            memberList.Add(new MemberVO("hihihi1", "password2", "이하이", "20000101", "인천시 계양구", "01022222222", ""));
            memberList.Add(new MemberVO("20193029", "password3", "강아지", "20200101", "경기도 의왕시", "01033333333", ""));
            memberList.Add(new MemberVO("whoareyou", "password4", "일론머스크", "20220202", "서울시 서초구", "01044444444", ""));
            memberList.Add(new MemberVO("iimm", "password5", "어피치", "20000303", "경기도 성남시", "01055555555", ""));
            memberList.Add(new MemberVO("endendend", "password6", "장조림", "20220102", "서울시 종로구", "01066666666", ""));
        }
    }
}
