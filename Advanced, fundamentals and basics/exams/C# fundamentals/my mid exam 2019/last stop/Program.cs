using System;
using System.Collections.Generic;
using System.Linq;

namespace last_stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintings = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split(" ").ToArray();
            while (command[0]!="END")
            {
                switch (command[0])
                {
                    case "Change":
                        ChangeNumber(paintings, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Hide":
                        HideNumber(paintings, int.Parse(command[1]));
                        break;
                    case "Switch":
                        SwitchNumber(paintings, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Insert":
                        InsertNumber(paintings, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Reverse":
                        paintings.Reverse();
                        break;
                    default:
                      
                        break;
                }
                command = Console.ReadLine().Split(" ").ToArray();
            }
            Console.WriteLine(string.Join(" ", paintings));

        }

        private static void InsertNumber(List<int> paintings, int index, int paintNumber)
        {
            if (index > paintings.Count - 1 || index < 0)
                return;
            paintings.Insert(++index, paintNumber);
        }

        private static void SwitchNumber(List<int> paintings, int paintOne, int paintTwo)
        {
            if(paintings.Contains(paintOne)&&paintings.Contains(paintTwo))
            {
                int indexOne = paintings.IndexOf(paintOne);
                int indexTwo = paintings.IndexOf(paintTwo);
                int swap = paintOne;
                paintings[indexOne] = paintings[indexTwo];
                paintings[indexTwo] = swap;
            }
        }

        private static void HideNumber(List<int> paintings, int painting)
        {
            if (paintings.Contains(painting))
                paintings.Remove(painting);
        }

        private static void ChangeNumber(List<int> paintings, int paintingNumber, int changedNumber)
        {
            if (paintings.Contains(paintingNumber))
            {
                int index=paintings.IndexOf(paintingNumber);
                paintings[index] = changedNumber;
            }
        }
    }
}
