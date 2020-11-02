using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passangers = int.Parse(Console.ReadLine());
            int stops = int.Parse(Console.ReadLine());
            int getoutPassangers = 0;
            int getinPassangers = 0;
            for (int i = 1; i <= stops; i++)
            {
                getoutPassangers = int.Parse(Console.ReadLine());
                getinPassangers = int.Parse(Console.ReadLine());
                passangers += getinPassangers;
                passangers -= getoutPassangers;
                if (i % 2 == 0) passangers -= 2;
                else passangers += 2;
            }
            
            Console.WriteLine("The final number of passengers is : {0}",passangers);
        }
    }
}
