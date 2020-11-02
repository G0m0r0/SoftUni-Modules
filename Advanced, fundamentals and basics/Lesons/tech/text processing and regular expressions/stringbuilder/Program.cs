using System;
using System.Diagnostics;
using System.Text;

namespace stringbuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i <100000 ; i++)
            {
                result.Append(i);
            }
            Console.WriteLine(sw.Elapsed); //0.4 seconds
        }
    }
}
