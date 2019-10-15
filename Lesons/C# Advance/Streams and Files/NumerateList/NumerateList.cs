using System;
using System.IO;

namespace NumerateList
{
    class NumerateList
    {
        static void Main(string[] args)
        {
            using (var reader=new StreamReader("TextFile5.txt"))
            {
                var lineNumber = 1;
                using (var writer=new StreamWriter("output2.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        writer.WriteLine($"{lineNumber}. {line}");
                        lineNumber++;
                    }
                }
            }
        }
    }
}
