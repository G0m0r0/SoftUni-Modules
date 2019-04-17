using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magic_6_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int magicNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        for (int p = 0; p < 9; p++)
                        {
                            for (int m = 0; m < 9; m++)
                            {
                                for (int n = 0; n < 9; n++)
                                {
                                    if (i * j * k * p * m * n == magicNumber) Console.Write($"{i}{j}{k}{p}{m}{n} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}