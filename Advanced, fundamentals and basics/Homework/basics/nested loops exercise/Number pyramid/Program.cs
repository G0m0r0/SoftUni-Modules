using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int numToPrint = 1;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <=n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (numToPrint > n) break;
                    Console.Write(numToPrint+" ");
                    numToPrint++;
                }
                Console.WriteLine();
            }
        }
    }
}
