using System;
using System.Collections.Generic;
using System.Linq;

namespace P09PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            long sum = 0;
            while (distances.Count > 0)
            {
                int indexToRemove = int.Parse(Console.ReadLine());
                int changesValue = 0;

                if (indexToRemove < 0)
                {
                    changesValue = distances[0];
                    distances[0] = distances[distances.Count - 1];
                }
                else if (indexToRemove > distances.Count - 1)
                {
                    changesValue = distances[distances.Count - 1];
                    distances[distances.Count - 1] = distances[0];
                }
                else
                {
                    changesValue = distances[indexToRemove];
                    distances.RemoveAt(indexToRemove);
                }
                for (int i = 0; i < distances.Count; i++)
                {
                    if (distances[i] <= changesValue)
                    {
                        distances[i] += changesValue;
                    }
                    else
                    {
                        distances[i] -= changesValue;
                    }
                }
                sum += changesValue;
              //  Console.WriteLine(string.Join(" ",distances));
            }
            Console.WriteLine(sum);
        }
    }
}