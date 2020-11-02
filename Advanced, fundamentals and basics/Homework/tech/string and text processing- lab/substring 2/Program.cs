using System;

namespace substring_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strToRemove = Console.ReadLine().ToLower();
            string str = Console.ReadLine().ToLower();

            while (str.Contains(strToRemove))
            {
                int index = str.IndexOf(strToRemove);
                str = str.Remove(index, strToRemove.Length);
            }

            Console.WriteLine(str);
        }

    }
}
