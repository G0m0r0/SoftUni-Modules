using System;

namespace middle_characters
{
    class Program
    {
        static void MiddleStringElements(string str)
        {
            int halfLenght = str.Length/2;
            if (str.Length % 2 == 0)
                Console.WriteLine($"{str[halfLenght - 1]}{str[halfLenght]}");
            else Console.WriteLine(str[halfLenght]);
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            MiddleStringElements(str);
        }
    }
}
