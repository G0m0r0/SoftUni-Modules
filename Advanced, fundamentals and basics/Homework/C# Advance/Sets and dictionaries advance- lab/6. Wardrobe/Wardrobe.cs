using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfClothes = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numOfClothes; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string color = tokens[0];
                string[] clothes = tokens[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int j = 0; j < clothes.Length; j++)
                {                    
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color][clothes[j]] = 0;
                    }
                    wardrobe[color][clothes[j]]++;
                }
            }

            string[] search = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string searchColor = search[0];
            string searchCloth = search[1];

            foreach (var (color,clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (clothing, count) in clothes)
                {
                    //if (!(searchColor == section.Key && searchCloth == item.Key))
                    //{
                    //    Console.WriteLine($"* {item.Key} - {item.Value}");
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    //}
                    Console.Write($"* {clothing} - {count}");
                    if(color==searchColor&&clothing==searchCloth)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
