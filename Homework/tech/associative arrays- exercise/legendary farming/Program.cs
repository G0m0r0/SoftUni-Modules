using System;
using System.Collections.Generic;
using System.Linq;

namespace legendary_farming
{
    class Program
    {
        static void Main(string[] args)
        {
            //wrong read on one line!!!!!!!!!!!
            string[] token = Console.ReadLine().ToLower().Split().ToArray();

            var junkDictionary = new SortedDictionary<string, int>();
            var metalDictionary = new SortedDictionary<string, int>();
            for (int i = 1; i < token.Length; i += 2)
            {
                if (token[i] == "shards" || token[i] == "fragments" || token[i] == "motes")
                {
                    if (metalDictionary.ContainsKey(token[i]))
                    {
                        metalDictionary[token[i]] += int.Parse(token[i - 1]);
                    }
                    else
                    {
                        metalDictionary.Add(token[i], int.Parse(token[i - 1]));
                    }
                }
                else
                {
                    if (junkDictionary.ContainsKey(token[i]))
                    {
                        junkDictionary[token[i]] += int.Parse(token[i - 1]);
                    }
                    else
                    {
                        junkDictionary.Add(token[i], int.Parse(token[i - 1]));
                    }
                }
                if (metalDictionary.ContainsKey("shards"))
                {
                    if (metalDictionary["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        metalDictionary["shards"] -= 250;
                        break;
                    }
                }
                if (metalDictionary.ContainsKey("fragments"))
                {
                    if (metalDictionary["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        metalDictionary["fragments"] -= 250;
                        break;
                    }
                }
                if (metalDictionary.ContainsKey("motes"))
                {
                    if (metalDictionary["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        metalDictionary["motes"] -= 250;
                        break;
                    }
                }
            }

            metalDictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            //junkDictionary.OrderBy(x => x);

            foreach (var item in metalDictionary.OrderByDescending(x=>x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            if (!metalDictionary.ContainsKey("shards"))
            {
                Console.WriteLine("shards: 0");
            }
            if (!metalDictionary.ContainsKey("fragments"))
            {
                Console.WriteLine("fragments: 0");
            }
            if (!metalDictionary.ContainsKey("motes"))
            {
                Console.WriteLine("motes: 0");
            }
            foreach (var item in junkDictionary.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            //123 silver 6 shards 8 shards 5 motes 9 fangs 75 motes 103 MOTES 8 Shards 86 Motes 7 stones 19 silver
            //3 Motes 5 stones 5 Shards 6 leathers 255 fragments 7 Shards
        }
    }
}
