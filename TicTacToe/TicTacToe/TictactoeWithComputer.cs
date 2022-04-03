using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TictactoeWithComputer
    {
        public void ChooseOX()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                       O 와 X 중 하나를 고르세요!                       ");
            Console.WriteLine("                      게임은 'X'가 먼저 시작합니다.                     ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                              1: X 선택                               ");
            Console.WriteLine("                              2: O 선택                               ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
        }
        public void CheckUserNumber()
        {
            char[] sequenceNumbers = { '1', '2' }; // 메뉴 번호를 배열에 저장 후 CheckNumber 함수에서 번호 확인할 때 사용
            bool isSequenceNumber = false; // 메뉴 번호를 제대로 입력받았는지 확인을 위한 변수
            string unknownSequenceNumber = "";
            int checkedSequenceNumber;
            ScanAndPrintBasic scanAndPrint = new ScanAndPrintBasic();

            while (isSequenceNumber == true)
            {
                Console.Write("원하시는 순서의 번호를 입력하세요 : ");
                unknownSequenceNumber = Console.ReadLine();
                
                scanAndPrint.CheckMenuNumber(isSequenceNumber, sequenceNumbers, unknownSequenceNumber);
            }

            checkedSequenceNumber = int.Parse(unknownSequenceNumber);

        }
    }
}
