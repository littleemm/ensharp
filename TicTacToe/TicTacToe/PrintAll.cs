using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class PrintAll
    {
        public void PrintMenu() // TicTacToe 메인 메뉴 출력
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                                 MENU                                 ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("    1: vs Computer : 컴퓨터와 당신이 게임을 진행합니다.");
            Console.WriteLine("    2: vs User : 당신 혼자 혹은 옆에 있는 사람과 게임을 진행합니다.     ");
            Console.WriteLine("    3: Score Board");
            Console.WriteLine("    4: 게임 종료");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintToScanAgain() // 잘못 입력했을 경우 출력되는 문구
        {
            ClearLine(3);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                          다시 입력해주세요!                           ");
            Console.WriteLine("----------------------------------------------------------------------");
        }
    
        public void ClearLine(int line)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
