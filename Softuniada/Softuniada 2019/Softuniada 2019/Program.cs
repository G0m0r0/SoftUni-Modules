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
            int[] numbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int sum = numbers.Sum();

           List<double> num = new List<double>();
            for (int i = 0; i <3 ; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        num.Add((numbers[i] * 100 + numbers[j] + 10 + numbers[k]) / sum);
                    }
                }
            }

           double v = 0;
            for (int i = 0; i < num.Count; i++)
            {
                if (double.TryParse, out v))
                {

                }
            }
        }
    }
}
