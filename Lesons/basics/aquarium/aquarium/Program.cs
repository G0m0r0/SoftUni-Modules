using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Height of the aquarium= ");
            int h=int.Parse(Console.ReadLine());
            Console.Write("Width of the aquarium");
            int w = int.Parse(Console.ReadLine());
            Console.Write("Lenght of the aquarium");
            int l = int.Parse(Console.ReadLine());
            Console.Write("occupide percents");
            double p = double.Parse(Console.ReadLine());
            double V = w * h * l;
            V *= 0.001;
            double remaind=(V * p)/100;
            V -= remaind;
            Console.WriteLine($"You can fill the aquarium with {V:F3} liters");
            Console.Read();
        }
    }
}
