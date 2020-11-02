using System;
using System.IO;

namespace _2._Line_Numbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            int count = 1;
            string path = @"D:\Programming\Softuni\Homework\C# Advance\Streams and files- lab\Resources\02. Line Numbers\Input.txt";
            using (StreamReader sr=new StreamReader(path))
            {
                using (StreamWriter sw=new StreamWriter("OutPut.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string numberedLine = $"{count}. {line}";
                        sw.WriteLine(numberedLine);
                        count++;
                    }
                }
            }
        }
    }
}
