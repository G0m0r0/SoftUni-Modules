using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOdd = 0, sumEven = 0;
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (i % 2 == 0) sumEven += num;
                else sumOdd += num;
            }
            if (sumOdd == sumEven) Console.WriteLine("Yes sum = {0}",sumEven);
            else Console.WriteLine("No Diff = {0}",Math.Abs(sumEven-sumOdd));
        }
    }
}
