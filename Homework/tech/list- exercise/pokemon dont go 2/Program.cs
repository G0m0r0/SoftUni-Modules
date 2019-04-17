using System;
using System.Collections.Generic;
using System.Linq;

namespace pokemon_dont_go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distancePokemon = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int sum = 0;
            do
            {
                int index = int.Parse(Console.ReadLine());



                Console.WriteLine(string.Join(" ", distancePokemon));
            } while (distancePokemon.Count > 0);
            Console.WriteLine(sum);
        }
    }
}
