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
        LoginSystem loginPage;

        public MainPage()
        {
            basicViewElement = new BasicViewElement();
            modeSelection = new ModeSelection(46, 22, loginPage, basicViewElement);
        }

        public void ShowMainPage()
        {
            basicViewElement.PrintLibraryMain();
            modeSelection.SelectMode();
        }
    }
}
