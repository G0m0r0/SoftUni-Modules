using System;
using System.Linq;

namespace Count_UpperCase_words_2
{
    class CountUpperCaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];
            var words = Console.ReadLine().Split(new char[] { ' ', '!', ':', '?', '-', ':' }, StringSplitOptions.RemoveEmptyEntries).Where(checker);

            Console.WriteLine(string.Join(' ',words));
        }
    }
}
