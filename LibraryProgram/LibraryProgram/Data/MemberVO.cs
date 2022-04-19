using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
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
        private string day;

        public MemberVO(string id, string password, string name, string birth, string phoneNumber, string address, string book, string day)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.birth = birth;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.book = book;
            this.day = day;
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

        public string Day
        {
            get { return day; }
            set { day = value; }
        }
    }
}
