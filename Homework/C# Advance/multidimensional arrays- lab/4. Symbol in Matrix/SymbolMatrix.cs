using System;

namespace _4._Symbol_in_Matrix
{
    class SymbolMatrix
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrixChar = new char[size, size];

            for (int i = 0; i < matrixChar.GetLength(0); i++)
            {
                char[] rowInputChar = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrixChar.GetLength(1); j++)
                {
                    matrixChar[i, j] = rowInputChar[j];
                }
            }

            char elementToSerach =char.Parse( Console.ReadLine());

            for (int i = 0; i < matrixChar.GetLength(0); i++)
            {
                for (int j = 0; j < matrixChar.GetLength(1); j++)
                {
                    if(elementToSerach==matrixChar[i,j])
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{elementToSerach} does not occur in the matrix");
        }
    }
}
