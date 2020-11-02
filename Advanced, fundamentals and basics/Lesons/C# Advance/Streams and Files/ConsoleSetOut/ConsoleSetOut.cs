using System;
using System.IO;

namespace ReadOddLines
{
    class ConsoleSetOut
    {
        static void Main(string[] args)
        {
            var consoleOutPut = new StreamWriter("console-output.txt");
            Console.SetOut(consoleOutPut);
            using (var reader = new StreamReader($"TextFile3.txt"))
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
            //File.Delete("name of the file")

            consoleOutPut.Close();
            //or
            //consoleOutPut.Flush();
        }
    }
}
