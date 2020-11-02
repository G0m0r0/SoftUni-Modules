using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class FashionBoutuque
    {
        static void Main(string[] args)
        {
            //stack
            int[] clothesBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacityRack = int.Parse(Console.ReadLine());
            int original = capacityRack;
            int sumOfClothes = 0;
            int countRacks = 1;

            Stack<int> clothes = new Stack<int>(clothesBox);
            while (clothes.Count > 0)
            {
                int cloth = clothes.Pop();

                if (sumOfClothes + cloth < capacityRack)
                {
                    sumOfClothes += cloth;
                }
                else if (sumOfClothes + cloth == capacityRack)
                {
                    if (clothes.Count > 0)
                    {
                        countRacks++;
                        sumOfClothes = 0;
                    }
                }
                else
                {
                    countRacks++;
                    sumOfClothes = 0;
                    sumOfClothes += cloth;
                }
            }

            Console.WriteLine(countRacks);
        }
    }
}
