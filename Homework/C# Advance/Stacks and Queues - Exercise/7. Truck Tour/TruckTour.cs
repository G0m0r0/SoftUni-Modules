using System;
using System.Linq;

namespace EX07_Truck_Tour
{
    class CalculateCircle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] pumps = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] token = Console.ReadLine().Split().Select(int.Parse).ToArray();
                //negative-not enough/ possitive-enough fuel
                pumps[i] = token[0] - token[1];
            }

            int currentPump = 0;
            //if fuel is enough to go though every pump, first pump will stay- index 0
            int smallestIndex = 0;

            for (int i = 0; i < n; i++)
            {
                currentPump += pumps[i];

                if (currentPump < 0)
                {
                    currentPump = 0;
                    smallestIndex = i + 1;
                }
            }
            Console.WriteLine(smallestIndex);
        }
    }
}