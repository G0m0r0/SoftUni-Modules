using System;

namespace padawan_equipment
{
    class Program
    {
        static void Main()
        {
            decimal money = decimal.Parse(Console.ReadLine());
            int numStudents = int.Parse(Console.ReadLine());
            double Lightsabers = double.Parse(Console.ReadLine());
            double Robe = double.Parse(Console.ReadLine());
            double Belt = double.Parse(Console.ReadLine());

            double priceLighsabers = (Math.Ceiling(numStudents * 0.1) + numStudents) * Lightsabers;
            double priceRobe = Robe * numStudents;
            double priceBelt = (numStudents - Math.Floor((double)numStudents / 6)) * Belt;

            decimal totalPrice = (decimal)priceBelt + (decimal)priceLighsabers + (decimal)priceRobe;
            if (totalPrice <= money) Console.WriteLine($"The money is enough - it would cost {(totalPrice):F2}lv.");
            else Console.WriteLine($"Ivan Cho will need {(totalPrice-money):F2}lv more.");
        }
    }
}
