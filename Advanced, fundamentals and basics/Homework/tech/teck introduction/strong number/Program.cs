using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strong_number
{
    class Program
    {
        static long recursion(long num)
        {
            if (num == 1) return 1;
            return num * recursion(num-1);
        }
        static void Main(string[] args)
        {
            string integerString = Console.ReadLine();
            long integer = long.Parse(integerString);
            long sumFactorial = 0;
           // int factorielNum = 0;
            long num = 0;
            for (int i = 0; i < integerString.Length; i++)
            {
                num = integer % 10;
                sumFactorial += recursion(num);
                integer /= 10;
            }
            if (sumFactorial == long.Parse(integerString)) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}
