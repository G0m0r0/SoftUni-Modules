using System;
using System.Collections.Generic;
using System.Linq;

namespace demo_final_exam_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var wordDefinitionDictionary = new Dictionary<string, List<string>>();

            PutWordsAndDefinitionsIntoDictionary(wordDefinitionDictionary, input);

            string selectedWords = Console.ReadLine();
            PrintSelectedWords(wordDefinitionDictionary, selectedWords);

            string listOrEnd = Console.ReadLine();
            if(listOrEnd=="End")
            {
                return;
            }
            else
            {
                Console.WriteLine(string.Join(" ", wordDefinitionDictionary.Keys.OrderBy(x => x)));
            }
        }

        private static void PrintSelectedWords(Dictionary<string, List<string>> Dictionary, string words)
        {
            string[] token = words.Split(" | ");

            for (int i = 0; i < token.Length; i++)
            {
                if(Dictionary.ContainsKey(token[i]))
                {
                    Console.WriteLine(token[i]);
                    foreach (var item in Dictionary[token[i]].OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine($"-{item}");
                    }
                }
            }
        }

        private static void PutWordsAndDefinitionsIntoDictionary(Dictionary<string, List<string>> Dictionary, string input)
        {
            string[] token = input.Split(new char[] { ':', '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < token.Length; i++)
            {
                string word = token[i++].Trim();
                string definition = token[i].Trim();
                if(!Dictionary.ContainsKey(word))
                {
                    Dictionary[word] = new List<string>();
                }
                Dictionary[word].Add(definition);
            }
        }
    }
}
