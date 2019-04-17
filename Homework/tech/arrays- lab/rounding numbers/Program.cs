using System;
using System.Linq;

namespace rounding_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrayOfRealNum = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < arrayOfRealNum.Length; i++)
            {
                Console.WriteLine($"{arrayOfRealNum[i]} => {Math.Round(arrayOfRealNum[i],MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
