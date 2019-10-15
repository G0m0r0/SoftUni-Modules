using System;
using System.IO;

namespace ReadOddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader($"TextFile1.txt"))
            {
                var counter = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (counter % 2 != 1)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                }
            }
        }
    }
}
