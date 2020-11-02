using System;
using System.Collections.Generic;

namespace UniueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            HashSet<string> HashSetNames = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                HashSetNames.Add(Console.ReadLine());
            }

            // Console.WriteLine(string.Join(Environment.NewLine,HashSetNames));
            //or
            foreach (var item in HashSetNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
