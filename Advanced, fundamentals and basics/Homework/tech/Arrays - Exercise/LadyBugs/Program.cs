using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] field = new int[sizeOfField];

            int[] indexOfLadyBug = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < indexOfLadyBug.Length; j++)
                {
                    if (indexOfLadyBug[j] == i) field[i] = 1;
                }
            }


            while (true)
            {
                string choice = Console.ReadLine();
                if (choice == "end") break;
                string[] movementsArray = choice.Split().ToArray();

                int indexStart = int.Parse(movementsArray[0]);
                string moveLR = movementsArray[1];
                int lenghtMovement = int.Parse(movementsArray[2]);

                if (indexStart > field.Length) continue;
                else if (field[indexStart] == 0) continue;
                field[indexStart] = 0;

                if (lenghtMovement < 0 && moveLR == "left")
                {
                    moveLR = "right";
                    lenghtMovement = Math.Abs(lenghtMovement);
                }
                else if (lenghtMovement < 0 && moveLR == "right")
                {
                    moveLR = "left";
                    lenghtMovement = Math.Abs(lenghtMovement);
                }


                if (moveLR == "right" && indexStart + lenghtMovement < field.Length)
                {
                    while (field[(indexStart + lenghtMovement)-1] == 1)
                    {
                        indexStart++;
                        if (indexStart + lenghtMovement > field.Length)
                            break;
                    }
                    if(indexStart + lenghtMovement < field.Length)
                    field[indexStart + lenghtMovement] = 1;
                }
                else if (moveLR == "left" && indexStart - lenghtMovement >= 0)
                {
                    while (field[(indexStart - lenghtMovement)-1] == 1)
                    {
                        indexStart--;
                        if (indexStart - lenghtMovement < 0)
                            break;
                    }
                    if(indexStart - lenghtMovement > 0)
                    field[indexStart - lenghtMovement] = 1;
                }
            }
            Console.WriteLine(string.Join(' ', field));
        }
    }
}
