using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int max = number;
            for (int i = 0; i <n-1; i++)
             {    
             number = int.Parse(Console.ReadLine());
             if (number > max) max = number;
             }
             Console.WriteLine(max);
        }
    }
}
