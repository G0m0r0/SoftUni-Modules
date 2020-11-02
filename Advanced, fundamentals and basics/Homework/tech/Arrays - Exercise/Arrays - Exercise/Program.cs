using System;
using System.Linq;

namespace Arrays___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfWagons = int.Parse(Console.ReadLine());
            int[] wagons = new int[numOfWagons];
            int sum = 0;
            for (int i = 0; i <wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
            }
            Console.WriteLine(string.Join(' ',wagons)+"\n {0}",sum);
        }
    }
}
