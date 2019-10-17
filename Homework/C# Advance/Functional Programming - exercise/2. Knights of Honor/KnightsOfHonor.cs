using System;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            string[] namesArray = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> printNames = names =>
              {
                  foreach (var name in names)
                  {
                      Console.WriteLine($"Sir {name}");
                  }
              };

            printNames(namesArray);
        }
    }
}
