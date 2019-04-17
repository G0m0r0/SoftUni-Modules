using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            int numberProducts = int.Parse(Console.ReadLine());
            double money = budget;
            int sumFlowers = 0;
            int sumBallons = 0;
            int sumCandles = 0;
            int sumRibbon = 0;
            while(true)
            {
                
                if (operation == "flowers") { budget -= numberProducts * 1.5; sumFlowers += numberProducts; }
                else if (operation == "balloons") { budget -= numberProducts * 0.1; sumBallons += numberProducts; }
                else if (operation == "candles") { budget -= numberProducts * 0.5; sumCandles += numberProducts; }
                else if (operation == "ribbon") { budget -= numberProducts * 2; sumRibbon += numberProducts; }
                if (budget <= 0) break;
                operation = Console.ReadLine();
                if (operation == "stop") break;
                numberProducts = int.Parse(Console.ReadLine());
            }
            if (budget > 0)
            {
                Console.WriteLine("Spend money: {0:f2}",money - budget);
                Console.WriteLine("Money left: {0:f2}",budget);
            }
            else Console.WriteLine("All money is spent!");
            Console.WriteLine($"Purchased decoration is {sumBallons} balloons, {sumRibbon} m ribbon, {sumFlowers} flowers and {sumCandles} candles.");
        }
    }
}
