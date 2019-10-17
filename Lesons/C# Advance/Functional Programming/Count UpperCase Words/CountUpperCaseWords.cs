using System;
using System.Linq;

namespace Count_UpperCase_Words
{
    class CountUpperCaseWords
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var words = input.Split(new char[] { ' ', ',', '!', '?', ':' }, StringSplitOptions.RemoveEmptyEntries);
            var capitalWords = words.Where(word => char.IsUpper(word[0]));

            Console.WriteLine(string.Join(" ",capitalWords));
        }
    }
}
