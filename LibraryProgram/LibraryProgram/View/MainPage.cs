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
        LoginSystem loginSystem;

        public MainPage()
        {
            basicViewElement = new BasicViewElement();
            loginSystem = new LoginSystem(basicViewElement);
            modeSelection = new ModeSelection(46, 22, loginSystem, basicViewElement);
        }

        public void ShowMainPage()
        {
            basicViewElement.PrintLibraryMain();
            modeSelection.SelectMode();
        }
    }
}
