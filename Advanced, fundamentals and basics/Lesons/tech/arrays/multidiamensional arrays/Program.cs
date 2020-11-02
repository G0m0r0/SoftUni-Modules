using System;

namespace multidiamensional_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array =
            {
                { 1, 2 },
                { 3, 4 },
                { -100,200}
            };
            foreach(int num in array)
            {
                Console.WriteLine(num);
            }
        }
    }
}
