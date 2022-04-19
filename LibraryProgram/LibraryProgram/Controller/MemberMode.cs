using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MemberMode
    {
        BasicViewElement viewElement;
        MenuSelection menuSelection;

        public MemberMode(BasicViewElement viewElement, MenuSelection menuSelection)
        {
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
        }

        public void ShowMemberPage()
        {
            Console.Clear();
            viewElement.PrintMemberMode();
            SelectMenu();
        }

        private void SelectMenu()
        {
            string number = menuSelection.CheckMenuNumber(46, 22, Constant.ARRAY_FIVE);
            Console.Clear();
            switch (int.Parse(number))
            {
                case Constant.SEARCH_BOOK:
                    {   
                        break;
                    }
                case Constant.BOOKLIST:
                    {
                        break;
                    }
                case Constant.CHECKOUT:
                    {
                        break;
                    }
                case Constant.RETURN:
                    {
                        break;
                    }
                case Constant.MYPAGE:
                    {
                        break;
                    }
            }
        }


    }
}
