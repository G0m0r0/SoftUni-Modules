using System;

namespace Sum_of_odd_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int i = 1;
            int sum = 0;
            while(counter<n)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    counter++;
                    sum += i;
                }
                i++;
            }
            Console.WriteLine("Sum: {0}",sum);
        }
    }
}
