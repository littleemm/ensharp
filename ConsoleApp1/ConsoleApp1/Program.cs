using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ScanAndPrint
    {
        public void ReadAndPrint()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1: 정방향 피라미드");
            Console.WriteLine("2: 역방향 피라미드");
            Console.WriteLine("3: 피라미드 응용 : 모래시계");
            Console.WriteLine("4: 피라미드 응용 : 다이아");
            Console.WriteLine("5: 프로그램 종료");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();

            while (true)
            {
                int pyramidNumber;
                Console.Write("원하시는 메뉴의 번호를 입력하세요: ");
                String unknownNumber = Console.ReadLine();
                bool checkPyramidNumber = int.TryParse(unknownNumber, out pyramidNumber); // 정수인지 체크하고 저장시키기 위한 변수

                if (pyramidNumber == 1 || pyramidNumber == 2 || pyramidNumber == 3 || pyramidNumber == 4)
                {
                    StarPyramid starPyramid = new StarPyramid();

                    int row;

                    Console.Write("1 이상의 줄 수를 입력하세요: ");
                    String unknownRow = Console.ReadLine();
                    bool checkNumber = int.TryParse(unknownRow, out row); // 정수인지 체크하고 저장시키기 위한 변수 
                    Console.WriteLine();

                    if (checkNumber == false || row < 0)
                    {
                        Console.WriteLine("피라미드를 만들 수 없습니다! 처음으로 돌아갑니다. . .");
                        Console.WriteLine();
                        continue;
                    }
                    
                    switch (pyramidNumber)
                    {
                        case 1:
                            starPyramid.PrintPyramid1(row);
                            break;
                        case 2:
                            starPyramid.PrintPyramid2(row);
                            break;
                        case 3:
                            starPyramid.PrintPyramid3(row);
                            break;
                        case 4:
                            starPyramid.PrintPyramid4(row);
                            break;
                    }
                }
                else if (pyramidNumber == 5)
                {
                    Console.WriteLine("프로그램을 종료합니다. . .");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("1 ~ 5 사이의 수를 다시 입력해주세요!");
                }

                Console.WriteLine();
            }
        }
    }

    class StarPyramid // 피라미드 출력
    {
        public void PrintPyramid1(int row)
        {
            for (int i = 0; i < row; i++) 
            {
                for (int j = row - 1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (i + 1) * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintPyramid2(int row)
        {
            for (int i = 0; i < row; i++) 
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = (i + 1) * 2 - 2; j < row * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintPyramid3(int row)
        {
            for (int i = 0; i < row; i++) 
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = (i + 1) * 2 - 2; j < row * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < row; i++) 
            {
                for (int j = row - 1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (i + 1) * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintPyramid4(int row)
        {
            for (int i = 0; i < row; i++) 
            {
                for (int j = row - 1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (i + 1) * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 1; i < row; i++) 
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = (i + 1) * 2 - 2; j < row * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ScanAndPrint scanNumber = new ScanAndPrint();
            scanNumber.ReadAndPrint();
        }
    }
}
