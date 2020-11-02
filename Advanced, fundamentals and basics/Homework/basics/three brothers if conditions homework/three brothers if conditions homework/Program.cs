using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace three_brothers_if_conditions_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double sumTime = ((a + b + c)+ (a + b + c) * 0.15);
            Console.WriteLine("Cleaning time: {0}",Math.Round((sumTime),2));
            if (d < sumTime)
                Console.WriteLine("Yes, there is a surprise - time left -> {0} hours.",Math.Floor(sumTime-d));
            else
                Console.WriteLine("No, there isn'ct a surprise - shortage of time - {0} hours.",Math.Ceiling( d-sumTime));
        }
    }
}
