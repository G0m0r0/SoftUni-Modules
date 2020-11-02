using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }

            string command = string.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                string[] token = command.Split().ToArray();
                int row =int.Parse( token[1]);
                int col =int.Parse(token[2]);
                int value =int.Parse( token[3]);

                if(ValidateCoordinates(row,col,matrix))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (token[0])
                {
                    case "Add":
                        matrix[row, col] += value;
                        break;
                    case "Subtract":
                        matrix[row, col] -= value;
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }

        private static bool ValidateCoordinates(int row, int col, int[,] matrix)
        {
            if(row>matrix.GetLength(0)-1||row<0)
            {
                return true;
            }
            if(col>matrix.GetLength(1)-1||col<0)
            {
                return true;
            }
            return false;
        }
    }
}
