using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class FirstMenuPage
    {
        private bool isMenuNumber;
        private string menuNumber;

        private MenuSelectionController menuSelectionController;
        private LoginViewElement loginViewElement;

        public FirstMenuPage()
        {
            isMenuNumber = false;
            menuSelectionController = new MenuSelectionController();
            loginViewElement = new LoginViewElement();
        }

        public void ShowMenuSelection()
        {
            Console.Clear();
            loginViewElement.PrintSystemPage();

            while (isMenuNumber == false)
            {
                menuNumber = menuSelectionController.ScanMenuNumber(55, 16);
                isMenuNumber = menuSelectionController.IsMenuNumber(menuNumber);

                if (isMenuNumber == false)
                {
                    loginViewElement.PrintWarning(40, 7);
                }
            }

            menuSelectionController.SelectMenu(int.Parse(menuNumber));
        }
    }
}
