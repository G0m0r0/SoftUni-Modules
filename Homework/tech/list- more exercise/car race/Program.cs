using System;
using System.Collections.Generic;
using System.Linq;

namespace car_race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double sumLeft = 0;
            for (int i = 0; i < (numberList.Count-1)/2; i++)
            {
                if (numberList[i] == 0)
                    sumLeft *= 0.8;
                sumLeft += numberList[i];
            }


            double sumRight = 0;
            for (int i =numberList.Count-1; i > (numberList.Count-1)/2; i--)
            {
                if (numberList[i] == 0)
                    sumRight *= 0.8;
                sumRight += numberList[i];
            }

            if(sumRight>sumLeft)
                Console.WriteLine("The winner is left with total time: {0}",sumLeft);
            else
                Console.WriteLine("The winner is right with total time: {0}",sumRight);
        }
    }
}
