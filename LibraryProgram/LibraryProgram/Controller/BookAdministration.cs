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
        BookVO bookVO;

        public BookAdministration(BasicViewElement viewElement, MenuSelection menuSelection)
        {
            bookViewElement = new BookViewElement();
            bookVO = new BookVO("", "", "", "", "", "");
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
        }

        public void SelectBookAdministration()
        {
            Console.Clear();
            bookViewElement.PrintManageBookMenu();
            string number = menuSelection.CheckMenuNumber(46, 23, Constant.ARRAY_FIVE);
            Console.Clear();
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
            Console.SetCursorPosition(31, 13);
            bookVO.Id = Console.ReadLine();

            Console.SetCursorPosition(31, 15);
            bookVO.Name = Console.ReadLine();

            Console.SetCursorPosition(31, 17);
            bookVO.Author = Console.ReadLine();

            Console.SetCursorPosition(31, 19);
            bookVO.Publisher = Console.ReadLine();

            Console.SetCursorPosition(31, 21);
            bookVO.Price = Console.ReadLine();

            Console.SetCursorPosition(31, 23);
            bookVO.Quantity = Console.ReadLine();

            bookViewElement.PrintRegistrationSuccessMessage();
        }

        private void EditBook()
        {
            bookViewElement.PrintEditBook();
        }

        private void DeleteBook()
        {
            bookViewElement.PrintDeleteBook();
        }

        private void SearchBook()
        {
            bookViewElement.InformBookList();
        }

        private void PrintList()
        {
            bookViewElement.InformBookList();
        }
    }
}
