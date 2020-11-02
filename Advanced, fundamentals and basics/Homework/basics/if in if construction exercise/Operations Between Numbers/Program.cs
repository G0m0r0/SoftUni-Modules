using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            string evenOrOdd = " ";
            double n1 = int.Parse(Console.ReadLine());
            double n2 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            if(operation=="+")
            {
                a = n1 + n2;
                if (a % 2 == 0) evenOrOdd = "even";
                else evenOrOdd = "odd";
                Console.WriteLine($"{n1} + {n2} = {a} - {evenOrOdd}");
            }
            else if (operation == "-")
            {
                a = n1 - n2;
                if (a % 2 == 0) evenOrOdd = "even";
                else evenOrOdd = "odd";
                Console.WriteLine($"{n1} - {n2} = {a} - {evenOrOdd}");
            }
            else if (operation == "*")
            {
                a = n1 * n2;
                if (a % 2 == 0) evenOrOdd = "even";
                else evenOrOdd = "odd";
                Console.WriteLine($"{n1} * {n2} = {a} - {evenOrOdd}");
            }
            else if (operation == "/")
            {

                if (n2 == 0) Console.WriteLine("Cannot divide {0} by zero", n1);
                else
                {
                    a = n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {a:f2}");
                }
            }
            else if (operation == "%")
            {
                if (n2 == 0) Console.WriteLine("Cannot divide {0} by zero", n1);
                else
                {
                    a = n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {a}");
                }
            }
        }
    }
}
