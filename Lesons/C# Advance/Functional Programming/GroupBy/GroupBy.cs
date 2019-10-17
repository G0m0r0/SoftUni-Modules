using System;
using System.Linq;

namespace GroupBy
{
    class GroupBy
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 100)
                .GroupBy(x =>x.ToString().Length)
                .ToDictionary(g=>g.Key,g=>g.ToList());
            foreach (var kvp in numbers)
            {
                Console.WriteLine($"{kvp.Key} => {string.Join(", ",kvp.Value)}");
            }
        }
    }
}
