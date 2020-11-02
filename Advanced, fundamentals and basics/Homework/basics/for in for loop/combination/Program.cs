using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            int br = 0;
            for (int i = 0; i <= num; i++)
            {
                for (int j = 0; j <= num; j++)
                {
                    for (int k = 0; k <= num; k++)
                    {
                        for (int l = 0; l <= num; l++)
                        {
                            for (int m = 0; m <= num; m++)
                            {
                                if (i + j + k + l + m == num) br++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(br);
        }
    }
}
