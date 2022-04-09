using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class CheckLoginInformation
    {
        MemberVO administratorVersion;
        SetMemberData memberData = new SetMemberData();
        ShowAdministratorPage showAdministratorPage;
        DoMemberMode doMemberMode;

        bool isAdministratorValue;
        bool isMemberValue;
        int listIndex;

        public CheckLoginInformation()
        {
            administratorVersion = new MemberVO("Administrator1", "1234", "관리자", "20000328", "알 수 없음", "01012345678", " ");
            showAdministratorPage = new ShowAdministratorPage();
            doMemberMode = new DoMemberMode();
            isMemberValue = false;
        }
        
        public bool IsLogin(string id, string password)
        {
            isAdministratorValue = IsAdministrator(id, administratorVersion.Id);
            if (isAdministratorValue == true)
            {
                isAdministratorValue = IsAdministrator(password, administratorVersion.Password);
            }

            if (isAdministratorValue == true) // 관리자 정보 확인 -> 성공 -> 넘어감
            {
                showAdministratorPage.ShowAdministrator();
                return true;
            }

            isMemberValue = IsMember(id, password); // 관리자가 아니면 회원인지 체크

            if (isMemberValue == true) // 회원 정보 확인 -> 성공 -> 넘어감
            {
                doMemberMode.ShowMemberMode();
                return true;
            }

            return false; // 일치하는 정보 없음

        }

        public bool IsAdministrator(string inputValue, string administratorValue) // 관리자인지 체크
        {
            if (administratorValue.Equals(inputValue))
            {
                return true;
            } 

            return false;
        }

        public bool IsMember(string inputId, string inputPassword) // 회원인지 체크
        {
            for (int i = 0; i < (memberData.memberList).Count; i++) 
            {
                if (inputId.Equals(memberData.memberList[i].Id))
                {
                    if (inputPassword.Equals(memberData.memberList[i].Password))
                    {
                        listIndex = i;
                        return true;
                    }
                }
            }

            return false;
        }

        public int returnList()
        {
            return listIndex;
        }
    }
}
