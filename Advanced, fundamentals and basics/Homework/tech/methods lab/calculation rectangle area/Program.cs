using System;

namespace calculation_rectangle_area
{
    class Program
    {
        static double RectangleArea(double width,double height)
        {
            return width * height;
        }
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(RectangleArea(width,height));
        }
    }
}
