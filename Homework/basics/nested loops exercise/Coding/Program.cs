using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int n = 0;
            while(num>0)
            {
                n = num % 10;
                if(n!=0)
                    for (int i = 0; i <n; i++)
                    {
                        Console.Write($"{(char)(n+33)}");
                    }
                else Console.Write("ZERO");
                num /= 10;
                Console.WriteLine();
            }
        }
    }
}
