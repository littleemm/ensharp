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

        public MainPage()
        {
            basicViewElement = new BasicViewElement();
        }

        public void ShowMainPage()
        {
            basicViewElement.PrintLibraryMain();

        }
    }
}
