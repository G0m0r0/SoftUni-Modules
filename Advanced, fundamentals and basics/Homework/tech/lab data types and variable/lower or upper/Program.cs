using System;

namespace lower_or_upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());
           
            Console.WriteLine(char.IsLower(letter)?"lower-case":"upper-case");
        }

    }
}
