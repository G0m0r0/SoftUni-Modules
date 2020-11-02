using System;

namespace Multidimensional_arrays
{
    class EmptyArrays
    {
        static void Main(string[] args)
        {
            //string- null
            string[,] arrayNull = new string[5, 5];
            for (int i = 0; i < arrayNull.GetLength(0); i++)
            {
                for (int j = 0; j < arrayNull.GetLength(0); j++)
                {
                    Console.Write(arrayNull[i,j]+" ");
                }
                Console.WriteLine();
            }

            //zero- int
            int[,] arrayZero=new int[5, 5];
            for (int i = 0; i <arrayZero.GetLength(0); i++)
            {
                for (int j = 0; j < arrayZero.GetLength(0); j++)
                {
                    Console.Write(arrayZero[i,j]+" ");
                }
                Console.WriteLine();
            }

            //null- char
            char[,] charEmpty = new char[5, 5];
            for (int i = 0; i < charEmpty.GetLength(0); i++)
            {
                for (int j = 0; j < charEmpty.GetLength(0); j++)
                {
                    Console.Write(charEmpty[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
