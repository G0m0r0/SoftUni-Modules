using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int sweeters = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            double moneyCakes = cakes * 45;
            double moneyWaffles = waffles * 5.80;
            double moneyPancakes = pancakes * 3.20;
            double Money = (moneyCakes + moneyPancakes + moneyWaffles)*sweeters;
            double allMoney = Money * days;
            //Console.WriteLine(Math.Round(allMoney-(allMoney/8)),2);
            Console.WriteLine($"{(allMoney - allMoney / 8):F2}");
            Console.Read();

        }

    }
}
