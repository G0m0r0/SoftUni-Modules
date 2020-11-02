using System;

namespace Reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = Console.ReadLine();
            string myReverseString = string.Empty;
            for (int i = myString.Length - 1; i >= 0; i--)
            {
                myReverseString += myString[i];
            }
            Console.WriteLine(myReverseString);
        }
    }
}
