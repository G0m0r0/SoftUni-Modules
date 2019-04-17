using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthSpaceship = double.Parse(Console.ReadLine());
            double lenghtSpaceship = double.Parse(Console.ReadLine());
            double heightSpaceship = double.Parse(Console.ReadLine());
            double avrHeightAstronauts = double.Parse(Console.ReadLine());
            double VspaveShip = widthSpaceship * lenghtSpaceship * heightSpaceship;
            double Vroom = (avrHeightAstronauts +0.40) * 2 * 2;
            double astronauts = Math.Floor(VspaveShip / Vroom);
            if(astronauts>=3&&astronauts<=10)
            Console.WriteLine($"The spacecraft holds {astronauts} astronauts.");
            else if (astronauts > 10) Console.WriteLine("The spacecraft is too big.");
            else Console.WriteLine("The spacecraft is too small.");
        }
    }
}
