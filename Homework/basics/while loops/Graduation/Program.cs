using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            double sum = 0;
            int i = 1;
            double mark = 0;
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
                    continue;
                   
                }    
            }
          Console.WriteLine($"{name} graduated. Average grade: {(sum / 12):f2}");
        }
    }
}
