using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = 0;
            string destination = Console.ReadLine();
            double minBudget = 0;
            while (destination!="End")
            {
                double moneySum = 0;
                minBudget = double.Parse(Console.ReadLine());
                while (minBudget > moneySum)
                {
                   money = double.Parse(Console.ReadLine());
                   moneySum += money;
                }
                Console.WriteLine("Going to " + destination + "!");
                destination = Console.ReadLine();
            }
        }
    }
}
