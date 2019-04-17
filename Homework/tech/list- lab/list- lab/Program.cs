using System;
using System.Collections.Generic;
using System.Linq;

namespace list__lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToList();
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    numbers[i - 1] = numbers[i - 1] + numbers[i];
                    numbers.RemoveAt(i);
                    i = 0;
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
