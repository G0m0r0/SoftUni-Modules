using System;
using System.Collections.Generic;
using System.Linq;

namespace cards_game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                if (firstPlayer[0] > secondPlayer[0])
                {
                    firstPlayer.Add(firstPlayer[0]);
                    firstPlayer.Add(secondPlayer[0]);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else if (firstPlayer[0] < secondPlayer[0])
                {
                    secondPlayer.Add(secondPlayer[0]);
                    secondPlayer.Add(firstPlayer[0]);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }

            if(firstPlayer.Count>secondPlayer.Count)
                Console.WriteLine("First player wins! Sum: {0}",firstPlayer.Sum());
            else
                Console.WriteLine("Second player wins! Sum: {0}",secondPlayer.Sum());

        }
    }
}
