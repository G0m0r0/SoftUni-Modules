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
                char[] spliters = { ' ', ',' };
                string[] clothes = Console.ReadLine().Split(spliters, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = clothes[0];
                for (int j = 2; j < clothes.Length; j++)
                {
                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe[color] = new Dictionary<string, int>();
                    }
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color][clothes[j]] = 0;
                    }
                    wardrobe[color][clothes[j]]++;
                }
            }

            string[] search = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string searchColor = search[0];
            string searchCloth = search[1];

            foreach (var section in wardrobe)
            {
                Console.WriteLine($"{section.Key} clothes:");
                foreach (var item in section.Value)
                {
                    if (!(searchColor == section.Key && searchCloth == item.Key))
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                }
            }
        }
    }
}
