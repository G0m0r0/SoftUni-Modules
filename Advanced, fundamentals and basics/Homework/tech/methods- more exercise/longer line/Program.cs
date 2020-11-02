using System;

namespace longer_line
{
    class Program
    {
        static void LongerLine(double x1, double y1,
                               double x2, double y2,
                               double x3, double y3,
                               double x4, double y4)
        {
            //c1 & c2 coordinates of (x1,y1) & (x2,y2)
            double c1 = x2 - x1;
            double c2 = y2 - y1;
            //c2 & c3 coordinates of (x3,y3) & (x4,y4)
            double c3 = x4 - x3;
            double c4 = y4 - y3;

            double firstLineLenght = Math.Sqrt(c1*c1+c2*c2);
            double secondLineLenght = Math.Sqrt(c3 * c3 + c4 * c4);
            if (firstLineLenght >= secondLineLenght)
            {
                ClosestCenterPoint(x1, y1, x2, y2);
            }
            else ClosestCenterPoint(x3, y3, x4, y4);
        }
        static void ClosestCenterPoint(double x1, double y1, double x2, double y2)
        {
            double c1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double c2 = Math.Sqrt(x2 * x2 + y2 * y2);
            if (c1 <= c2)
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            else
            Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
           
            

        }
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            LongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }
    }
}
