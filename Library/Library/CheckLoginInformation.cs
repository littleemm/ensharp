using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class CheckLoginInformation
    {
        MemberVO administratorVersion;
        bool isAdministratorValue;
        bool isMemberValue;
        public CheckLoginInformation()
        {
            administratorVersion = new MemberVO("Administrator1", "1234", "관리자", "20000328", "알 수 없음", "01012345678");
            //관리자 정보
            isMemberValue = false;
        }
        
        public bool IsLogin(string id, string password)
        {
            isAdministratorValue = IsAdministrator(id, administratorVersion.Id);
            if (isAdministratorValue == true)
            {
                isAdministratorValue = IsAdministrator(password, administratorVersion.Password);
            }

            if (isAdministratorValue == true)
            {

                return;
            }

            isMemberValue = IsMember(id, password);

            if (isMemberValue == true)
            {
                return true;
            }

            return false;

        }

        public bool IsAdministrator(string inputValue, string administratorValue)
        {
            if (administratorValue.Equals(inputValue))
            {
                return true;
            } 

            return false;
        }

        public bool IsMember(string inputId, string inputPassword)
        {
            for (int i = 0; i < (SetMemberData.memberList).Count; i++) 
            {
                if (inputId.Equals(SetMemberData.memberList[i].Id))
                {
                    if (inputPassword.Equals(SetMemberData.memberList[i].Password))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public 
    }
}
