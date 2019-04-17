using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_sums_left_right_position
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNum = long.Parse(Console.ReadLine());
            long secondNum = long.Parse(Console.ReadLine());
            long a = 0, b = 0;
            for (long i = firstNum; i <= secondNum; i++)
            {
                a = (i % 10) + ((i / 10) % 10);
                b = ((i / 1000) % 10) + (i / 10000);
                if (a == b)
                {
                    Console.Write(i+" ");
                }
                else 
                {
                    if (a < b)
                    {
                        a += (i / 100) % 10;
                        if (a == b) Console.Write(i+" ");
                    }
                    else
                    {
                        b += (i / 100) % 10;
                        if (a == b) Console.Write(i+" ");
                    }
                }
            }
        }
    }
}
    

