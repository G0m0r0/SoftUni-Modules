using System;
using System.Collections.Generic;
using System.Linq;

namespace smallest_three_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            List<int> arrayOfNumbers = new List<int>();

            for (int i = 0; i < countOfNumbers; i++)
            {
                arrayOfNumbers.Add(int.Parse(Console.ReadLine()));
            }

            arrayOfNumbers.Sort();

            //or var smallest3Nums = numbers.OrderBy(i => i).Take(3);
            List<int> threeSmallestNumbers = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                if(countOfNumbers==1&&i==1)
                {
                    break;
                }
                else if(countOfNumbers==2&&i==2)
                {
                    break;
                }
                threeSmallestNumbers.Add(arrayOfNumbers[i]);
            }

            Console.WriteLine(string.Join("\n", threeSmallestNumbers.OrderBy(x => x)));
        }
    }
}
