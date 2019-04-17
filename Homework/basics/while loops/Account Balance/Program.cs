using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            string operation=" ";
            int numDeposit = int.Parse(Console.ReadLine());
            int i = 1;
            while(i<=numDeposit)
            {
                operation = Console.ReadLine();
                if (double.Parse(operation) < 0) { Console.WriteLine("Invalid operation!"); break; }
               // if (operation == "Invalid operation!") { Console.WriteLine("Invalid operation!"); break; }
                Console.WriteLine("Increase: {0:f2}",double.Parse(operation));
                sum +=double.Parse(operation);
                i++;
            }
            Console.WriteLine("Total: {0:f2}",sum);
        }
    }
}
