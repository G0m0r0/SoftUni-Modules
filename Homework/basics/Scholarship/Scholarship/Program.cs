using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double Grades = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());
            double socialScholarship = Math.Floor( minSalary * 0.35);
            double Scholarship =Math.Floor( Grades * 25);
            if (income >= minSalary)
            {
                if (Grades >= 5.50)
                {
                    Console.WriteLine(" You get a scholarship for excellent results {0} BGN", Scholarship);

                }
                else  Console.WriteLine("You cannot get a scholarship!");
            }
             else if (income < minSalary)
                if (Grades >= 5.5)
                {
                    if (socialScholarship > Scholarship) Console.WriteLine(" You get a Social scholarship {0} BGN", socialScholarship);
                    else Console.WriteLine(" You get a scholarship for excellent results {0} BGN", Scholarship);
                }
                else if ((Grades > 4.5) && (Grades < 5.5)) Console.WriteLine(" You get a Social scholarship {0} BGN", socialScholarship);
                else Console.WriteLine("You cannot get a scholarship!");
        }
    }
}
