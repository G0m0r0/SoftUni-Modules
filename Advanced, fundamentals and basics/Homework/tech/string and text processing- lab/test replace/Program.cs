using System;

namespace test_replace
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string wordToReplace = Console.ReadLine();

            text = text.Replace(wordToReplace, "***");

            Console.WriteLine(text);
        }
    }
}
