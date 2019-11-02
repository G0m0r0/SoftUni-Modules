using System;
using System.Collections.Generic;

namespace polymorphism
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var figures = new List<IPointContaintable>();
            figures.Add(new Rectangle(3, 1, 1, 3));
            figures.Add(new Circle(0, 0, 2));

            foreach (var figure in figures)
            {
                Console.WriteLine(figure.Contains(new Point(0, 0)));
                Console.WriteLine(figure.Contains(new Point(0, 2)));
                Console.WriteLine(figure.Contains(new Point(2, 0)));
                Console.WriteLine(figure.Contains(new Point(3, 0)));
                Console.WriteLine();
            }

         // IPointContaintable rectangle = new Rectangle(3, 1, 1, 3);
         // Console.WriteLine(rectangle.Contains(new Point(-1, -2)));
         //
         // rectangle = new Circle(0, 0, 2);

        }
    }
}
