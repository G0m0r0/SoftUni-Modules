using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            double lenghtHall = double.Parse(Console.ReadLine());
            double widthHall = double.Parse(Console.ReadLine());
            double wardrobe = double.Parse(Console.ReadLine());
            double hall = lenghtHall * widthHall;
            double freeSpace = hall - (wardrobe * wardrobe) - (hall / 10);
            Console.WriteLine(Math.Floor((freeSpace * 10000) / (40 + 7000)));
            Console.Read();
        }
    }
}
