using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class WordCount
    {
        static void Main(string[] args)
        {
            string path = @"D:\Programming\Softuni\Homework\C# Advance\Streams and files- lab\Resources\03. Word Count\words.txt";
            Dictionary<string, int> dictionaryCountWords = new Dictionary<string, int>();
            using (StreamReader reader=new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string[] word = reader.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (!dictionaryCountWords.ContainsKey(word[i].ToLower()))
                        {
                            dictionaryCountWords[word[i]] = 0;
                        }
                    }
                }
            }
           path = @"D:\Programming\Softuni\Homework\C# Advance\Streams and files- lab\Resources\03. Word Count\text.txt";
            using (StreamReader reader=new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    char[] ch = { '?', '.', '-', '!', ',', ' ' };
                    string[] words = reader.ReadLine().ToLower().Split(ch, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    for (int i = 0; i < words.Length; i++)
                    {
                        if(dictionaryCountWords.ContainsKey(words[i]))
                        {
                            dictionaryCountWords[words[i]]++;
                        }
                    }
                }
            }
            using (StreamWriter writer=new StreamWriter("OutPut.txt"))
            {
                foreach (var kvp in dictionaryCountWords.OrderByDescending(x=>x.Value))
                {
                    string newLine = $"{kvp.Key} - {kvp.Value}";
                    Console.WriteLine(newLine);
                    writer.WriteLine(newLine);
                }
            }
        }
    }
}
