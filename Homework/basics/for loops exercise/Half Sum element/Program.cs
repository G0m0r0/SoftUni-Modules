using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Half_Sum_element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            int max = num;
            int sum = num;
            for(int i=1;i<n;i++)
            {
                
                num = int.Parse(Console.ReadLine());
                
                if (max < num)
                {
                    max = num;
                }
                sum += num;
            }
            if (max == sum-max) Console.WriteLine("Yes Sum = {0}",max);
            else Console.WriteLine("No Diff = {0}",Math.Abs(max-(sum-max)));
        }
    }
}
