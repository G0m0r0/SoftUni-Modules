using GenericSwap;
using System;

namespace Generics
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countOfElements = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < countOfElements; i++)
            {
                double inputLine = double.Parse(Console.ReadLine());

                box.List.Add(inputLine);
            }

            double targetItem =double.Parse( Console.ReadLine());
            int result= box.ComparisonByValue(targetItem);
            Console.WriteLine(result);
        }
    }
}
