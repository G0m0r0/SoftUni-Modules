using System;
using System.Linq;

namespace AggregateNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 10)
                .Aggregate((a, b) => a * b); //factoriel
            Console.WriteLine(string.Join(" ",numbers));

            //.Any returns true or false by some condition
            //.All same as any but for all
            //.FirstOrDefault takes first element by condition
        }
    }
}
