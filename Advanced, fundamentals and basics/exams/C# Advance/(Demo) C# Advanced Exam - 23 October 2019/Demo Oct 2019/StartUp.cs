using System;
using System.Linq;

namespace Demo_Oct_2019
{
    class StartUp
    {
        static char[][] jaggedGarden;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            jaggedGarden = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                char[] vegetables = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                jaggedGarden[i] = vegetables;
            }

            string command = string.Empty;
            int harmedVegetables = 0;
            int harvestPotatoes = 0;
            int harvestCarrots = 0;
            int harvestLettuce = 0;
            while ((command = Console.ReadLine()) != "End of Harvest")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                if (tokens[0] == "Harvest")
                {
                    if (ValidCoordinats(row, col))
                        if (jaggedGarden[row][col] != ' ')
                        {
                            switch (jaggedGarden[row][col])
                            {
                                case 'L':
                                    harvestLettuce++;
                                    break;
                                case 'P':
                                    harvestPotatoes++;
                                    break;
                                case 'C':
                                    harvestCarrots++;
                                    break;
                            }
                            jaggedGarden[row][col] = ' ';
                        }
                }
                else if (tokens[0] == "Mole")
                {
                    string direction = tokens[3];

                    while (ValidCoordinats(row, col))
                    {
                        if (jaggedGarden[row][col] != ' ')
                        {
                            jaggedGarden[row][col] = ' '; 
                            harmedVegetables++;
                        }
                        switch (direction)
                        {
                            case "up":
                                row -= 2;
                                break;
                            case "down":
                                row += 2;
                                break;
                            case "right":
                                col += 2;
                                break;
                            case "left":
                                col -= 2;
                                break;
                        }
                    }
                }
            }
            PrintGarden();
            Console.WriteLine($"Carrots: {harvestCarrots}");
            Console.WriteLine($"Potatoes: {harvestPotatoes}");
            Console.WriteLine($"Lettuce: {harvestLettuce}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }

        private static void PrintGarden()
        {
            for (int i = 0; i < jaggedGarden.Length; i++)
            {
                Console.WriteLine(string.Join(" ",jaggedGarden[i]));
            }
        }

        private static bool ValidCoordinats(int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }
            if (jaggedGarden.Length - 1 < row)
            {
                return false;
            }
            if (jaggedGarden[row].Length - 1 < col)
            {
                return false;
            }
            return true;
        }
    }
}
