using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exellent_grade
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int result = a + b + c;
            if ((result > 59) && (result % 60 < 10)) Console.WriteLine($"{result / 60}:0{result % 60}");
            //else Console.WriteLine($"{result / 60}:{result % 60}");
            if ((result > 59) && (result % 60 >= 10)) Console.WriteLine($"{result / 60}:{result % 60}");
            if (result < 10) Console.Write($"0:0{result % 60}");
            if ((result > 10) && (result < 60)) Console.WriteLine($"0:{result % 60}");
            
            Console.ReadLine();





        }
    }
}
