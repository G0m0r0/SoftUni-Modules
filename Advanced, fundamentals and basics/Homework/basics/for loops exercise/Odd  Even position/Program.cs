using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd__Even_position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double minOdd = 0, maxOdd = 0,minEven=0,maxEven=0;
            double oddSum = 0, evenSum = 0;
            bool flag = true;
            for (int i = 1; i <= n; i++)
            {
               
                double num = double.Parse(Console.ReadLine());
                if (i == 1)
                {
                    minOdd = num;
                    maxOdd = num;
                    flag = false;
                }
                if (i == 2)
                {
                    minEven = num;
                    maxEven = num;
                    flag = false;
                }
                if (i%2!=0)
                {                
                    oddSum += num;
                    if (num > maxOdd) maxOdd = num;
                    if (num < minOdd) minOdd = num;
                }
                if(i%2==0)
                {
                    evenSum += num;
                    if (num >= maxEven) maxEven = num;
                    if (num <= minEven) minEven = num;
                   
                }
            }
            Console.WriteLine($"OddSum={oddSum},");
           if(flag==false) Console.WriteLine($"OddMin={minOdd},");
           else Console.WriteLine("OddMin=No");
           if (flag == false) Console.WriteLine($"OddMax={maxOdd},");
           else Console.WriteLine("OddMax=No");
           Console.WriteLine($"EvenSum={evenSum},");
           if (flag == false) Console.WriteLine($"EvenMin={minEven},");
           else Console.WriteLine("EvenMin=No");
           if (flag == false) Console.WriteLine($"EvenMax={maxEven}");
           else Console.WriteLine("EvenMax=No");
        }
    }
}
