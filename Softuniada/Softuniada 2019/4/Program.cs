using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Softuniada_2019
{
    class Program
    {
        static void Main()
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            string[,,] ThreeDMatrix = new string[sizeMatrix, sizeMatrix, sizeMatrix];
            //initialize
            for (int i = 0; i < sizeMatrix; i++)
            {
                string[] token = Console.ReadLine().Split(" | ");
                for (int j = 0; j < token.Length; j++)
                {
                    string[] elements = token[j].Split().ToArray();
                    for (int k = 0; k < elements.Length; k++)
                    {
                        ThreeDMatrix[i, j, k] = elements[k];
                    }
                }
            }
            //coordinates and harvest
            string command = string.Empty;
            while ((command=Console.ReadLine())!= "Melolemonmelon")
            {
                string[] tokens = command.Split();
                int layer = int.Parse(tokens[0]);
                int row = int.Parse(tokens[1]);
                int coloumn = int.Parse(tokens[2]);

                ThreeDMatrix[layer, row, coloumn] = "0";
                //morph
                for (int i = 0; i < sizeMatrix; i++)
                {
                    for (int j = 0; j < sizeMatrix; j++)
                    {
                        for (int k = 0; k < sizeMatrix; k++)
                        {
                            if (j==row&&k==coloumn)
                                continue;
                            if(i==layer&&row+1==j&&coloumn==k)
                            {
                                continue;
                            }
                            if(i==layer&&row-1==j&&coloumn==k)
                            {
                                continue;
                            }
                            if(i==layer&&row==j&&coloumn==k+1)
                            {
                                continue;
                            }
                            if(i==layer&&row==j&&coloumn==k-1)
                            {
                                continue;
                            }
                            //Watermelon (W) -> Earthmelon (E) -> Firemelon (F) -> Airmelon (A) -> Watermelon (W)
                            if(ThreeDMatrix[i,j,k]=="W")
                            {
                                ThreeDMatrix[i, j, k] = "E";
                            }
                            else if(ThreeDMatrix[i,j,k]=="E")
                            {
                                ThreeDMatrix[i, j, k] = "F";
                            }
                            else if(ThreeDMatrix[i,j,k]=="F")
                            {
                                ThreeDMatrix[i, j, k] = "A";
                            }
                            else if(ThreeDMatrix[i,j,k]=="A")
                            {
                                ThreeDMatrix[i, j, k] = "W";
                            }
                        }
                    }
                }
            }
            Print3DMatrix(ThreeDMatrix, sizeMatrix);
        }

        private static void Print3DMatrix(string[,,] threeDMatrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        Console.Write(threeDMatrix[i, j, k] + " ");
                    }
                    if (!(j == size - 1))
                    Console.Write("| ");
                }
                Console.WriteLine();
            }
        }
    }
}
