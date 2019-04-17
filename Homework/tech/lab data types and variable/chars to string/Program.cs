using System;

namespace chars_to_string
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            string str = a.ToString() + b.ToString() + c.ToString();
            Console.WriteLine(str);
        }
    }
}
