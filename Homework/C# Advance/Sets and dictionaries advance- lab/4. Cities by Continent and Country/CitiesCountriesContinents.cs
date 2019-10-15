using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> world = new Dictionary<string, Dictionary<string, List<string>>>();

            int numberOfKVP = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfKVP; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];
                if (!world.ContainsKey(continent))
                {
                    world[continent] = new Dictionary<string, List<string>>();
                }
                if (!world[continent].ContainsKey(country))
                {
                    world[continent][country] = new List<string>();
                }

                world[continent][country].Add(city);
            }

            foreach (var continent in world)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
