using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyExcursion = double.Parse(Console.ReadLine());
            double myMoney = double.Parse(Console.ReadLine());
            string operation = " ";
            double moneySpendSave = 0;
            int br = 0;
            int i = 0;
            while (moneyExcursion > moneySpendSave+myMoney)
            {
                i++;
                operation = Console.ReadLine();
                if (operation == "spend")
                {
                    br++;
                    if (br == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(i);
                        break;
                    }
                }
                else br = 0;
                if (operation == "save") moneySpendSave += double.Parse(Console.ReadLine());
                else if (operation == "spend")
                {
                    moneySpendSave -= double.Parse(Console.ReadLine());
                    if (moneySpendSave+myMoney < 0) moneySpendSave = 0;
                }
            }
            if (moneyExcursion <= moneySpendSave+myMoney)
            {
                Console.WriteLine("You saved the money for {0} days.", i);
            }
        }
    }
}

