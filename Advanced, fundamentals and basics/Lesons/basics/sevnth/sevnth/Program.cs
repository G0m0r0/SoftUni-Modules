using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sevnth
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = 22;
            int second = 7;
            double pi = first / second;
            Console.WriteLine($"{pi:F5}"); //we have 5 numbers after the ,
            Console.WriteLine($"{pi:0.00}"); //we have 2 number after the ,
            double testNumber = 0.1;
            Console.WriteLine(Math.Ceiling(testNumber));
            Console.WriteLine(Math.Floor(testNumber));
            Console.WriteLine(Math.Round(testNumber)); //depends before or 0.5
            Console.WriteLine(Math.Max(first, second));
            Console.WriteLine(Math.Min(first, second));
            Console.Read();
        }
    }
}
