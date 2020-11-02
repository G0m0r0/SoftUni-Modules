using System;

namespace beer_kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte kegNumber = sbyte.Parse(Console.ReadLine());
            double volume = 0;
            double biggestKeg = 0;
            string biggestKegModel = string.Empty;
            for (int i = 0; i < kegNumber; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                volume = Math.PI * radius * radius * height;
                if (volume > biggestKeg)
                {
                    biggestKeg = volume;
                    biggestKegModel = model;
                }
            }
            Console.WriteLine(biggestKegModel);
        }
    }
}
