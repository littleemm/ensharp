using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MainPage
    {
        BasicViewElement basicViewElement;
        MenuSelection menuSelection;

        public MainPage()
        {
            basicViewElement = new BasicViewElement();
            menuSelection = new MenuSelection(46, 22);
        }

        public void ShowMainPage()
        {
            basicViewElement.PrintLibraryMain();
            menuSelection.CheckMenuNumber(Constant.arrayTwo, basicViewElement);
        }
    }
}
