using System;
using System.Collections.Generic;
using System.Linq;

namespace mixed_up_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> mixedList = new List<int>();

            int rangeFist = 0;
            int rangeSecond = 0;
            int smallerListCount = 0;

            //take last two integers of the longer list
            if (firstList.Count > secondList.Count)
            {
                 rangeFist = firstList[firstList.Count - 1];
                 rangeSecond = firstList[firstList.Count - 2];
                //take size of the smaller list
                 smallerListCount = secondList.Count - 1 ;
            }
            else
            {
                rangeFist = secondList[secondList.Count- 1];
                rangeSecond = secondList[secondList.Count - 2];
                smallerListCount = firstList.Count - 1;
            }

            //mixing the two lists
            int backI = smallerListCount;
            for (int i = 0; i <= smallerListCount; i++)
            {
                if (secondList.Count < firstList.Count)
                {
                    mixedList.Add(firstList[i]);
                    mixedList.Add(secondList[backI]);
                }
                else
                {
                    mixedList.Add(firstList[i]);
                    mixedList.Add(secondList[backI-2]);
                }
                backI--;
            }
            
            //create range
            List<int> resultList = new List<int>();
            if(rangeFist>rangeSecond)
            {
                int swap = rangeFist;
                rangeFist = rangeSecond;
                rangeSecond = rangeFist;
            }

            //add numbers in the range and add them to result list
            for (int i = 0; i < mixedList.Count; i++)
            {
                if (mixedList[i] > rangeFist && mixedList[i] < rangeSecond)
                    resultList.Add(mixedList[i]);
            }

            //sort and print
            resultList.Sort();
            Console.WriteLine(string.Join(" ",resultList));

        }
    }
}
