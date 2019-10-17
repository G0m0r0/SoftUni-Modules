using System;
using System.Linq;

namespace Linq_with_parameters
{
    class LinqyWithParameters
    {
        static void Main(string[] args)
        {
            var input = new[] { 100, 101, 103,927,923 };
            //x is the values(100,101,102) i is the index(0,1,2)
            var result = input.Where((x, i) => i % 2 == 0||x%2==0);
            Console.WriteLine(string.Join(' ',result));
        }
    }
}
