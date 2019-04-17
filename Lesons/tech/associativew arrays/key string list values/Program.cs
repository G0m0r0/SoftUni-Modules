using System;
using System.Collections.Generic;

namespace key_string_list_values
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPairs = int.Parse(Console.ReadLine());
            var synonyms = new Dictionary<string, List<string>>();
            for (int i = 1; i <= numOfPairs; i++)
            {
                string key = Console.ReadLine();
                string value = Console.ReadLine();
                // if (!synonyms.ContainsKey(key))
                // {
                //     synonyms.Add(key, new List<string>());
                //     //or synonyms[key]=new List<string>();
                //     synonyms[key].Add(value);
                // }
                // else
                //     synonyms[key].Add(value);
                if (!synonyms.ContainsKey(key))
                {
                    synonyms[key] = new List<string>();
                }
                synonyms[key].Add(value);
            }
            foreach (var item in synonyms)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
