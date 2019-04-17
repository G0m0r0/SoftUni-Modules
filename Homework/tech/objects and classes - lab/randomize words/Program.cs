using System;
using System.Linq;

namespace randomize_words
{
    class Program
    {
        private static object random;

        static void Main(string[] args)
        {
            string[] words=Console.ReadLine()
                .Split(" ")
                .ToArray();
            Random rnd = new Random();
            for (int i = 1; i <words.Length-1 ; i++)
            {
                int newIndex= rnd.Next(0, words.Length - 1);
                string swap = words[i];
                words[i] = words[newIndex];
                words[newIndex] = swap;
            }

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
