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
        ModeSelection modeSelection;
        MenuSelection menuSelection;
        LoginSystem loginSystem;

        public MainPage()
        {
            basicViewElement = new BasicViewElement();
            menuSelection = new MenuSelection(basicViewElement);
            loginSystem = new LoginSystem(basicViewElement, menuSelection);
            modeSelection = new ModeSelection(menuSelection, loginSystem, basicViewElement);
        }

        public void ShowMainPage()
        {
            basicViewElement.PrintLibraryMain();
            modeSelection.SelectMode();
        }
    }
}
