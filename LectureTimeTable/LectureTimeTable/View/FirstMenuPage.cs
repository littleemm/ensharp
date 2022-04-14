using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class FirstMenuPage // 로그인 성공 후 메뉴 첫페이지 (visible)
    {

        private string[] numberArray;

        private MenuSelectionController menuSelectionController;

        public FirstMenuPage()
        {
            numberArray = new string[] { "1", "2", "3", "4" };
            menuSelectionController = new MenuSelectionController();
        }

        public void ShowMenuSelection() 
        {
            Console.Clear();
            menuSelectionController.CheckMenuNumber(numberArray);
        }
    }
}
