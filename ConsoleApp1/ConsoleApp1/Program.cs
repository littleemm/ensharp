using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) 
            {
                for (int j = 1; j <= n - 1; j++) 
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= (n / 2) * i - 1; j++) 
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
