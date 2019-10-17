using System;
using System.Linq;

namespace EvenNumbersOrderBy
{
    class EvenNumbersOrderBy
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(", ").Select(int.Parse).Where(x=>x%2==0).OrderBy(x=>x);

            Console.WriteLine(string.Join(' ',list));
        }

    }
}
