using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equals_pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[] mass = new double[n];
            double num1 = 0, num2 = 0;
            double max = double.MinValue;
            double maxDiff = 0;
            for (int i = 0; i < n; i++)
            {
                num1 = double.Parse(Console.ReadLine());
                num2 = double.Parse(Console.ReadLine());        
                mass[i] = num1 + num2;    
        }
            int j = 0;
            while (j<n)
            {
                if (max < mass[j]-mass[j++]) max = Math.Abs(num1 - num2);
                if (mass[j] != mass[n-1])
                {
                   j++;
                    break;
                }
                j++;
            }
           
            if (j == n) Console.WriteLine("Yes, value={0}",mass[0]);
            else Console.WriteLine("No, maxdiff={0}",max);
        }
    }
}
