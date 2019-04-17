using System;
using System.Text.RegularExpressions;

namespace string_and_regulax_expresions__more_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {
                string information = Console.ReadLine();
                Regex name = new Regex(@"@(?<name>[A-Za-z]*)\|");
                Regex age = new Regex(@"#(?<age>[0-9]+)\*");
                if (name.IsMatch(information) && age.IsMatch(information))
                {
                    Console.WriteLine($"{name.Match(information).Groups["name"].ToString()} is {age.Match(information).Groups["age"].ToString()} years old.");
                }
            }
        }
    }
}
