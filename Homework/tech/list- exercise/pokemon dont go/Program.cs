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
            while (distancePokemon.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int value = 0;
                if(index>distancePokemon.Count-1)
                {
                    value = distancePokemon[distancePokemon.Count - 1];
                    distancePokemon.RemoveAt(distancePokemon.Count - 1);
                    distancePokemon.Insert(distancePokemon.Count, distancePokemon[0]);
                }
                else if()

                Console.WriteLine(string.Join(" ", distancePokemon));

            } 
            Console.WriteLine(sum);
        }
    }
}
