using System;
using System.Linq;

namespace Linq_methods
{
    class LinqMethods
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 100)
                .Where(x=>x%6==0)
                .OrderBy(x=>x%10)
                .Select(x=>x/6);
            Console.WriteLine(string.Join(' ',numbers)); //numbers from 1 to 15 :D
        }
    }
}
