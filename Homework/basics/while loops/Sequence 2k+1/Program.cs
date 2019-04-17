using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 1;
            Console.WriteLine(sum);
            while (sum < n)
            {
                if (sum * 2 + 1 <= n)
                    sum = (sum * 2) + 1;
                else break;

                Console.WriteLine(sum);
            } 

        }
    }
}
