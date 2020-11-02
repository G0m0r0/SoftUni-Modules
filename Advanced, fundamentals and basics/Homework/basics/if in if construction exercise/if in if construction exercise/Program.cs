using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace if_in_if_construction_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            
            if (((x1 == x || x2 == x)&&y>=y1&&y<=y2) || (y1 == y || y2 == y)&&(x>=x1&&x<=x2))
                Console.WriteLine("Border");
            else Console.WriteLine("Inside / Outside");
        }
    }
}
