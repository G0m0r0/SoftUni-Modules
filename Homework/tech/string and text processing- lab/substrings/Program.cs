using System;

namespace substrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string strToRemove = Console.ReadLine().ToLower();
            string str = Console.ReadLine().ToLower();

            while (str.Contains(strToRemove))
            {
               str= str.Replace(strToRemove, "");
            }

            Console.WriteLine(str);
        }
    }
}
