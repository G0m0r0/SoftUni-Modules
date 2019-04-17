using System;
using System.Linq;

namespace Select
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(x => double.Parse(x));
            //or var numbers = Console.ReadLine().Split().Select(double.Parse);
            //because it takes string and output double

            var numberLenght = numbers.Select(x => x.ToString().Length);
            //crete string array with the leght of elements

            foreach (var item in numberLenght)
            {
                Console.WriteLine(item);
            }
        }
    }
}
