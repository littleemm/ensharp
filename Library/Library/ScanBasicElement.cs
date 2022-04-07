﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class ScanBasicElement
    {
        public bool isMenuNumber;
        string menuNumber;
        string[] menuNumberArray = { "1", "2", "3" };

        public ScanBasicElement()
        {
            isMenuNumber = false; // 메뉴 번호를 제대로 입력받았는지 확인을 위한 변수
            menuNumber = ""; // 입력될 메뉴 번호 (다른 문자가 입력될 수 있어 string)
        }
        public int SelectMenu() // 메뉴 입력
        {
            while (isMenuNumber == false)
            {
                Console.Write("           원하시는 기능의 번호를 입력하세요 : ");
                menuNumber = Console.ReadLine();
                isMenuNumber = IsMenuNumber(isMenuNumber, menuNumberArray, menuNumber);
            }
            return int.Parse(menuNumber);
        }
        public bool IsMenuNumber(bool isMenuNumber, string[] menuNumberArray, string menuNumber) 
        { // 올바른 메뉴 번호인지 체크
            for (int arrayIndex = 0; arrayIndex < menuNumberArray.Length; arrayIndex++)
            {
                if (string.IsNullOrEmpty(menuNumber?.Trim())) 
                { // ctrl + z 체크
                    break;
                }

                if (menuNumber.Equals(menuNumberArray[arrayIndex]))
                { // 입력 성공
                    isMenuNumber = true;
                }
            }

            if (isMenuNumber == false)
            { // 올바르지 않은 입력
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("           1 ~ 3 사이의 정수로 다시 입력해주세요!");
                Console.ResetColor();
            }

            return isMenuNumber;
        }
        public void ClearLine(int line)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
