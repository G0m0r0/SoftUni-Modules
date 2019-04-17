using System;
using System.Collections.Generic;
using System.Linq;

namespace take_or_skip_rope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> nonNumberList = Console.ReadLine()
                  .ToList();
            List<int> numberList = new List<int>();
            TakeDigits(nonNumberList, numberList);

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            NumListSplit(numberList, takeList, skipList);
            Console.WriteLine(string.Join(" ",takeList));
            Console.WriteLine(string.Join(" ",skipList));

            List<string> resultString = new List<string>();
            TakeSkipCountElements(nonNumberList, takeList, skipList, resultString);
           // resultString.Reverse();
            Console.WriteLine(string.Join("",resultString));
        }

        private static void TakeSkipCountElements(List<char> nonNumberList, List<int> takeList, List<int> skipList, List<string> resultString)
        {
            for (int i = 0; i < takeList.Count; i++)
            {
                for (int j = 0; j < takeList[i]; j++)
                {
                    resultString.Add(nonNumberList[j].ToString());
                }
                for (int j = 0; j < skipList[i]; j++)
                {
                        nonNumberList.RemoveAt(0);
                }                               
            }
        }

        private static void NumListSplit(List<int> numberList, List<int> takeList, List<int> skipList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                    takeList.Add(numberList[i]);
                else
                    skipList.Add(numberList[i]);
            }
        }

        private static void TakeDigits(List<char> text, List<int> diggit)
        {
            for (int i = 0; i < text.Count; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    diggit.Add(int.Parse(text[i].ToString()));
                    text.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
