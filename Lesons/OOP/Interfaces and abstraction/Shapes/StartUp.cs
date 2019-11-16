using Shapes.Shapes;
using System;

namespace Shapes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable circle = new Circle(6);
            circle.Draw();

            Console.WriteLine();

            IDrawable rectangle = new Rectangle(10,5);
            rectangle.Draw();
        }
    }
}
