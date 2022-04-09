using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class MemberVO
    {
        private string id;
        private string password;
        private string name;
        private string birth;
        private string address;
        private string phoneNumber;
        private string book;

        public MemberVO()
        {

        }

        public MemberVO(string id, string password, string name, string birth, string address, string phoneNumber, string book)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.birth = birth;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.book = book;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Birth
        {
            get { return birth; }
            set { birth = value; }
        }


        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Book
        {
            get { return book; }
            set { book = value; }
        }

    }
}
