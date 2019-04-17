using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string leapOrNot = Console.ReadLine();
            double p = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            
            double games = (48 - h) * 0.75 + h + p * 2 / 3;
            if (leapOrNot == "leap")
            {
                games += (games*0.15);
                Console.WriteLine(Math.Floor(games));
            }
            else Console.WriteLine(Math.Floor(games));
        }
    }
}
