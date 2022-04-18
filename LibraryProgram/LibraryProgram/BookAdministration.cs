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
        BasicViewElement viewElement;
        MenuSelection menuSelection;

        public BookAdministration(BasicViewElement viewElement, MenuSelection menuSelection)
        {
            bookViewElement = new BookViewElement();
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
        }

        public void SelectBookAdministration()
        {
            string number = menuSelection.CheckMenuNumber(46, 23, Constant.ARRAY_FIVE);
            switch(int.Parse(number))
            {
                case Constant.REGISTRATION: 
                    {
                        RegisterBook();
                        break;
                    }
                case Constant.EDIT:
                    {
                        EditBook();
                        break;
                    }
                case Constant.DELETE:
                    {
                        DeleteBook();
                        break;
                    }
                case Constant.SEARCH:
                    {
                        SearchBook();
                        break;
                    }
                case Constant.LIST:
                    {
                        PrintList();
                        break;
                    }
            }

        }

        private void RegisterBook()
        {
            bookViewElement.PrintRegistration();
        }

        private void EditBook()
        {
            bookViewElement.PrintEditBook();
        }

        private void DeleteBook()
        {
            bookViewElement.PrintDeleteBook();
        }

        public void SearchBook()
        {
            bookViewElement.InformBookList();
        }

        public void PrintList()
        {
            bookViewElement.InformBookList();
        }
    }
}
