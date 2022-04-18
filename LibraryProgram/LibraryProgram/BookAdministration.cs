using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class BookAdministration
    {
        BookViewElement bookViewElement;

        public BookAdministration()
        {
            bookViewElement = new BookViewElement();
        }

        public void RegisterBook()
        {
            bookViewElement.PrintRegistration();

        }

        public void EditBook()
        {

        }

        public void SearchBook()
        {

        }

        public void PrintList()
        {

        }
    }
}
