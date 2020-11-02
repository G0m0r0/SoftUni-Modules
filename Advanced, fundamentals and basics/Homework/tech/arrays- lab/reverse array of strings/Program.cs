using System;
using System.Linq;

namespace reverse_array_of_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArray = Console
                .ReadLine()
                .Split()
                .ToArray();
            Array.Reverse(strArray);
            Console.WriteLine(string.Join(' ',strArray));
        }
    }
}
