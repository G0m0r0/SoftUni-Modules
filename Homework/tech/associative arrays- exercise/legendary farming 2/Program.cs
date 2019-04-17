using System;
using System.Collections.Generic;
using System.Linq;

namespace legendary_farming_2
{
    class Program
    {

        static void Main(string[] args)
        {
            var LegendaryItems = new Dictionary<string, int>();
            LegendaryItems["fragments"] = 0;
            LegendaryItems["motes"] = 0;
            LegendaryItems["shards"] = 0;
            var JunkItems = new Dictionary<string, int>();

            while (LegendaryItems.All(x => x.Value < 250))
            {
                string[] token = Console.ReadLine().ToLower().Split().ToArray();
                for (int i = 1; i < token.Length; i += 2)
                {
                    if (token[i] == "fragments" || token[i] == "motes" || token[i] == "shards")
                    {
                        LegendaryItems[token[i]] += int.Parse(token[i - 1]);
                    }
                    else
                    {
                        if (!JunkItems.ContainsKey(token[i]))
                            JunkItems[token[i]] = int.Parse(token[i-1]);
                        else
                            JunkItems[token[i]] += int.Parse(token[i - 1]);
                    }
                    if (LegendaryItems.Any(x => x.Value >= 250))
                        break;
                }
                if (LegendaryItems.Any(x => x.Value >= 250))
                {
                    if (LegendaryItems["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        LegendaryItems["shards"] -= 250;
                        break;
                    }
                    else if (LegendaryItems["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        LegendaryItems["fragments"] -= 250;
                        break;
                    }
                    else if (LegendaryItems["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        LegendaryItems["motes"] -= 250;
                        break;
                    }
                }
            }
            foreach (var item in LegendaryItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in JunkItems.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
