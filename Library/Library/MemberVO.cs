using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class SaveMemberVO
    {
        private string id;
        private string password;
        private string birth;
        private string address;
        private string phoneNumber;

        public SaveMemberVO()
        {

        }

        public SaveMemberVO(string id, string password, string birth, string address, string phoneNumber)
        {
            this.id = id;
            this.birth = birth;
            this.password = password;
            this.address = address;
            this.phoneNumber = phoneNumber;
        } 
    }
}
