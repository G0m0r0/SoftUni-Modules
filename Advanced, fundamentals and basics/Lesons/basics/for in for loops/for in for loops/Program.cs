using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_in_for_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0;  j < 9;  j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        Console.WriteLine(i+j+k);
                    }
                }
            }
        }
    }
}
