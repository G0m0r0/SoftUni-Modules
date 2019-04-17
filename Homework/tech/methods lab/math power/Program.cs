using System;

namespace math_power
{
    class Program
    {
        static double mathPower(double num,int pow)
        {
            return Math.Pow(num, pow);
        }
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(mathPower(number, power)); 
        }
    }
}
