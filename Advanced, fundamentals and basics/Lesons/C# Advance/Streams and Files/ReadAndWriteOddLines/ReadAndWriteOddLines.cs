using System;
using System.IO;

namespace ReadOddLines
{
    class ReadAndWriteOddLines
    {
        static void Main(string[] args)
        {     
            using (var reader = new StreamReader($"TextFile2.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    var counter = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (counter % 2 != 1)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
