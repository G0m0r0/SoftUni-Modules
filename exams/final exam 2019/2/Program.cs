using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeDictionary = new Dictionary<string, List<string>>();

            string command = string.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                string[] token = command.Split(new string[] { "->", "," }, StringSplitOptions.RemoveEmptyEntries);
                switch (token[0])
                {
                    case "Add":
                        AddToDiary(storeDictionary,token);
                        break;
                    case "Remove":
                        RemoveFromDiary(storeDictionary, token);
                        break;
                }
            }
            Console.WriteLine("Stores list:");
            foreach (var kvp in storeDictionary.OrderByDescending(x=>x.Value.Count).ThenByDescending(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }

        }

        private static void RemoveFromDiary(Dictionary<string, List<string>> storeDictionary, string[] token)
        {
            if(storeDictionary.ContainsKey(token[1]))
            {
                storeDictionary.Remove(token[1]);
            }
        }

        private static void AddToDiary(Dictionary<string, List<string>> storeDictionary,string[] token)
        {
            if(!storeDictionary.ContainsKey(token[1]))
            {
                storeDictionary[token[1]] = new List<string>();
            }
            for (int i = 2; i < token.Length; i++)
            {
                storeDictionary[token[1]].Add(token[i]);
            }
        }
    }
}
