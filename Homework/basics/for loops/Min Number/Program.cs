using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            int min = num;
            for (int i = 0; i < n-1; i++)
            {
                num =int.Parse( Console.ReadLine());
                if (min > num) min = num;
            }
            Console.WriteLine(min);
        }
    }
}
