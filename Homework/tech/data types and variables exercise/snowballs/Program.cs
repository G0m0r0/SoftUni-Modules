using System;
using System.Numerics;
namespace snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfSnowballs = int.Parse(Console.ReadLine());
            BigInteger bestSnowball = 0;
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            int sSnow = 0;
            int sT = 0;
            int sQ = 0;
            for (int i = 0; i < numOfSnowballs; i++)
            {
                 snowballSnow = int.Parse(Console.ReadLine());
                 snowballTime = int.Parse(Console.ReadLine());
                 snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowball = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);      
                if (snowball > bestSnowball)
                {
                    bestSnowball = snowball;
                    sSnow = snowballSnow;
                    sT = snowballTime;
                    sQ = snowballQuality;
                }
            }
            Console.WriteLine($"{sSnow} : {sT} = {bestSnowball} ({sQ})");
        }
    }
}
