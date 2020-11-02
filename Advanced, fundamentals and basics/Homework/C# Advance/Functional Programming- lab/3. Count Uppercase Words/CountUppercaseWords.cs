using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> operationUppercase = x => x[0].ToString().ToUpper() == x[0].ToString();
            var inputLine = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(operationUppercase);

            Console.WriteLine(string.Join(Environment.NewLine, inputLine));
        }
    }
}
