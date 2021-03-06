using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class FindJoinException
    {
        private int countBirth;
        private int countNumber;

        public FindJoinException()
        {
            countBirth = 0;
            countNumber = 0;
        }

        public bool IsId(string id)
        {
            if (id.Length > 8)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   8자 이내로 다시 입력하세요!");
                Console.ResetColor();
                

                return false;
            }
            return true;
        }

        public bool IsPassword(string password)
        {
            if (password.Length > 5)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   5자 이내로 다시 입력하세요!");
                Console.ResetColor();

                return false;
            }
            return true;
        }

        public bool IsBirth(string birth)
        {
            for (int i = 0; i < birth.Length; i++)
            {
                for (char number = '0'; number <= '9'; number++)
                {
                    if (birth[i] == number)
                    {
                        countBirth++;
                        break;
                    }
                }
            }

            if (countBirth < 8)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("        숫자로 이루어진 8자리의 생년월일로 다시 입력하세요!");
                Console.ResetColor();
                return false;
            }

            if (birth.Length > 8)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   8자리의 생년월일로 다시 입력하세요!");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        public bool IsPhoneNumber(string phoneNumber)
        {
            for (int i = 0; i < phoneNumber.Length; i++) 
            {
                for (char number = '0'; number <= '9'; number++) 
                {
                    if (phoneNumber[i] == number)
                    {
                        countNumber++;
                        break;
                    }
                }
            }
            if (countNumber < 11)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("          숫자로만 이루어진 휴대폰 번호로 다시 입력하세요!");
                Console.ResetColor();
                return false;
            }

            if (phoneNumber.Length > 11)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("            11자리의 휴대폰 번호로 다시 입력하세요!");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        public bool IsAddress(string address)
        {
            for (int i = 0; i < address.Length; i++)
            {
                for (char number = 'a'; number <= 'z'; number++)
                {
                    if (address[i] == number)
                    {
                        ClearLine(2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("    한글로 이루어진 주소로 다시 입력하세요!");
                        Console.ResetColor();
                        return false;
                    }
                }

                for (char number = 'A'; number <= 'Z'; number++)
                {
                    if (address[i] == number)
                    {
                        ClearLine(2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("    한글로 이루어진 주소로 다시 입력하세요!");
                        Console.ResetColor();
                        return false;
                    }
                }
            }

            if (address.Length > 12 || address.Length < 7)
            {
                ClearLine(2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     올바른 주소로 다시 입력하세요!(ex. 세종시 조치원읍");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        private void ClearLine(int line)
        { // 라인 한줄씩 청소
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }
    }
}
