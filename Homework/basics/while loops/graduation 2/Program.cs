using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduation_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double sum = 0;
            int i = 1;
            double mark = 0;
            int br = 0;
            while (i <= 12)
            {
                mark = double.Parse(Console.ReadLine());
                if (mark >= 4)
                {
                    sum += mark;
                    i++;
                }
                else
                {
                    if (br >= 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {i} grade");
                        break;
                    }
                    br++;
                    continue;
                   
                }
            }
            if(i>12) Console.WriteLine($"{name} graduated. Average grade: {(sum / 12):f2}");
        }
    }
}
