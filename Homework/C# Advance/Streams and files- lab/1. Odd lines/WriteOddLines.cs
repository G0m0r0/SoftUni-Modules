using System;
using System.IO;
using System.Text;
using System.Text.Unicode;

namespace Odd_lines
{
    class WriteOddLines
    {
        static void Main(string[] args)
        {
            int counter = 0;
            using (StreamReader sr = new StreamReader("Input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("OddLines.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (counter % 2 != 0)
                        {
                            sw.WriteLine(line);
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
