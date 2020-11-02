using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            long FirstNum=long.Parse(Console.ReadLine());
            long SecondNum = long.Parse(Console.ReadLine());
            long sumOdd = 0;
            long sumEven = 0;
            long a=0, b=0, c=0, d=0, e=0, f=0;
            for (long i = FirstNum; i <= SecondNum; i++)
            {
                a = i % 10;         
                b = (i / 10) % 10;  
                c = (i / 100) % 10; 
                d = (i / 1000) % 10;
                e = (i / 10000) % 10;
                f = i / 100000;

                sumEven = a + c + e;
                sumOdd = b + d + f;
                if (sumOdd == sumEven) Console.Write(i+"");
            }

        }
    }
}
