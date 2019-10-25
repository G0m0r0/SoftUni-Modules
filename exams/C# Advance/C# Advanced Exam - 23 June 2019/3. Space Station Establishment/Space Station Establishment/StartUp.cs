using System;
using System.Linq;

namespace Space_Station_Establishment
{
    class StartUp
    {
        static char[,] galaxy;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            galaxy = new char[size, size];

            int xPosition = 0;
            int yPosition = 0;
            for (int i = 0; i <galaxy.GetLength(0) ; i++)
            {
                char[] tokens = Console.ReadLine().ToCharArray();
                    
                for (int j = 0; j < galaxy.GetLength(1); j++)
                {
                    galaxy[i, j] = tokens[j];
                    if(tokens[j]=='S')
                    {
                        xPosition = i;
                        yPosition = j;
                    }
                }
            }

            int energy = 0;
            while (true)
            {
                galaxy[xPosition, yPosition] = '-';
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        xPosition--;
                        break;
                    case "down":
                        xPosition++;
                        break;
                    case "right":
                        yPosition++;
                        break;
                    case "left":
                        yPosition--;
                        break;
                }

                if (!InsideGalaxy(xPosition, yPosition))
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    break;
                }
                else if (char.IsDigit(galaxy[xPosition, yPosition]))
                {
                    energy += int.Parse(galaxy[xPosition, yPosition].ToString());
                    galaxy[xPosition, yPosition] = '-';
                    if (energy >= 50)
                    {
                        Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                        galaxy[xPosition, yPosition] = 'S';
                        break;
                    }
                }
                else if (galaxy[xPosition, yPosition] == 'O')
                {
                    galaxy[xPosition, yPosition] = '-';
                    SearchForOtherBlackHole(ref xPosition, ref yPosition);
                    galaxy[xPosition, yPosition] = 'S';
                }
            }
            Console.WriteLine($"Star power collected: {energy}");
            PrintGalaxy();
        }

        private static void PrintGalaxy()
        {
            for (int i = 0; i < galaxy.GetLength(0); i++)
            {
                for (int j = 0; j < galaxy.GetLength(1); j++)
                {
                    Console.Write(galaxy[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void SearchForOtherBlackHole(ref int xPosition, ref int yPosition)
        {
            for (int i = 0; i < galaxy.GetLength(0); i++)
            {
                for (int j = 0; j < galaxy.GetLength(1); j++)
                {
                    if(galaxy[i,j]=='O')
                    {
                        if(i!=xPosition||yPosition!=j)
                        {
                            xPosition = i;
                            yPosition = j;
                        }
                    }
                }
            }
        }

        private static bool InsideGalaxy(int xPosition, int yPosition)
        {
            if(xPosition<0||yPosition<0)
            {
                return false;
            }
            if(xPosition>galaxy.GetLength(0)-1||yPosition>galaxy.GetLength(1)-1)
            {
                return false;
            }
            return true;
        }
    }
}
