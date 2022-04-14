using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class FirstMenuPage // 로그인 성공 후 메뉴 첫페이지 (visible)
    {
        private string number;
        private string[] numberArray;

        private NumberCheckingController menuNumberCheckingController;
        private SelectionController selectionController;
        private ViewElement viewElement;

        public FirstMenuPage()
        {
            numberArray = new string[] { "1", "2", "3", "4" };
            menuNumberCheckingController = new NumberCheckingController(55, 16);
            selectionController = new SelectionController();
            viewElement = new ViewElement();
        }

        public void ShowMenuSelection() 
        {
            Console.Clear();
            viewElement.PrintSystemPage();
            number = menuNumberCheckingController.CheckMenuNumber(numberArray, viewElement);
            selectionController.SelectMenu(int.Parse(number), viewElement, menuNumberCheckingController);
        }
    }
}
