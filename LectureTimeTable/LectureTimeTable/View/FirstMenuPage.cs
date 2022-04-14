using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class FirstMenuPage // 로그인 성공 후 메뉴 첫페이지 (visible)
    {
        private bool isMenuNumber;
        private string menuNumber;
        private string[] numberArray;

        private MenuSelectionController menuSelectionController;
        private LoginViewElement loginViewElement;

        public FirstMenuPage()
        {
            isMenuNumber = false;

            numberArray = new string[] { "1", "2", "3", "4" };
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
                isMenuNumber = menuSelectionController.IsMenuNumber(menuNumber, numberArray);

                if (isMenuNumber == false)
                {
                    loginViewElement.ClearLine(1, 55);
                    Console.SetCursorPosition(55, 16);
                    loginViewElement.PrintWarning(1, 14);
                }
            }

            menuSelectionController.SelectMenu(int.Parse(menuNumber));
        }
    }
}
