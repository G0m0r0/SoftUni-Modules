using System;
using System.Collections.Generic;
using System.Linq;

namespace list__more_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<char> wordsList = Console.ReadLine().ToList();

            List<string> finalList = new List<string>();
            for (int i = 0; i < numbersList.Count; i++)
            {
                int sumElement = sumOfElementDigits(numbersList[i]);

                if (sumElement > wordsList.Count)
                    sumElement %= wordsList.Count;
                finalList.Add(wordsList[sumElement].ToString());
                wordsList.RemoveAt(sumElement);
            }
            Console.WriteLine(string.Join("",finalList));
        }

        static int sumOfElementDigits(int element)
        {
            int sumElement = 0;
            while(element>0)
            {
                sumElement += element % 10;
                element /= 10;
            }
            return sumElement;
        }
    }
}
