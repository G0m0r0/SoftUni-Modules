using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageOfLily = int.Parse(Console.ReadLine());
            double PriceOfWasher = double.Parse(Console.ReadLine());
            int priceOfToy = int.Parse(Console.ReadLine());
            int sumOfSavings = 0;
            int brToys = 0;
            for (int i = 1; i <= ageOfLily; i++)
            {
                if (i % 2 != 0) brToys++;
                else
                {
                    sumOfSavings += i * 5;
                    sumOfSavings--;
                }
            }
            sumOfSavings += priceOfToy * brToys;
            if(sumOfSavings>=PriceOfWasher)Console.WriteLine("Yes! {0:f2}",sumOfSavings-PriceOfWasher);
            else Console.WriteLine("No! {0:f2}",PriceOfWasher-sumOfSavings);
        }
    }
}
