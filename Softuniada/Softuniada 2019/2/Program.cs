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
            int number = int.Parse(Console.ReadLine());

            int width = number * 5;
            int height = number * 4 + 2;

            char[,] array = new char[width,height];
            int firstLines = number / 2;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if(j<number&&firstLines>i)
                    {
                        array[i, j] = ' ';
                        continue;
                    }
                    else if(width-number<j&&firstLines>i)
                    {
                        array[i, j] = ' ';
                        continue;
                    }
                   array[i, j] = '#';
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(array[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
