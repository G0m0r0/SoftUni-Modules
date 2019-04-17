using System;
using System.Collections.Generic;

namespace word_synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfWords = int.Parse(Console.ReadLine());

            var synonymsDictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < numOfWords; i++)
            {
                string key = Console.ReadLine();
                string value = Console.ReadLine();
                if (!synonymsDictionary.ContainsKey(key))
                {
                    synonymsDictionary.Add(key, new List<string>());
                }
                synonymsDictionary[key].Add(value);
            }

            foreach (var item in synonymsDictionary)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ",item.Value)}");
            }
        }
    }
}
