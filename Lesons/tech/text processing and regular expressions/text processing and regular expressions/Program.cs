using System;
using System.Diagnostics;

namespace text_processing_and_regular_expressions
{
    class Program
    {

        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            string result = string.Empty;
            for (int i = 0; i < 100000; i++)
            {
                result += i;
            }
            Console.WriteLine(sw.Elapsed); //14seconds
        }
    }
}
