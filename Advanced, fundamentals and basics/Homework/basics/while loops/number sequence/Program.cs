using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string num =Console.ReadLine(); ;
            double a = 0;
            a =double.Parse(num);
            double min = a;
            double max =a;
            while (num!="END")
            {
                num = Console.ReadLine();
                if (num == "END") break;
                a = double.Parse(num);
                if (a < min) min = a;
                if (a > max) max = a;
            }
            Console.WriteLine("Max number: {0}",max);
            Console.WriteLine("Min number: {0}",min);
        }
    }
}
