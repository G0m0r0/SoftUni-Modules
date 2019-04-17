using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            //even office O{floor}{apartament}
            //odd apartament A{floor}{apartament}
            //big apartaments L only L if one floor
            for (int i = 0; i < rooms; i++)
            {
                Console.Write($"L{floors}{i} ");
            }
            Console.WriteLine();
            for (int i = floors-1; i > 0; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if(i%2==0) Console.Write($"O{i}{j} ");
                    else Console.Write($"A{i}{j} ");
                }
               Console.WriteLine();
            }
        }
    }
}
