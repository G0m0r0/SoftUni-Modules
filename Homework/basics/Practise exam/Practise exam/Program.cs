using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise_exam
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyFood = double.Parse(Console.ReadLine());
            double moneySouvenirs = double.Parse(Console.ReadLine());
            double moneyHotel = double.Parse(Console.ReadLine());
            //210km 
            //100km 7 litters 1.85lv per litter
            moneyFood *= 3;
            moneySouvenirs *= 3;
            moneyHotel = moneyHotel * 0.9 + moneyHotel * 0.8 + moneyHotel * 0.85;
            double totalMoney = moneyHotel + moneyFood + moneySouvenirs + (4.2 * 7) * 1.85;
            Console.WriteLine("Money needed: {0}",Math.Round((totalMoney),2));
        }
    }
}
