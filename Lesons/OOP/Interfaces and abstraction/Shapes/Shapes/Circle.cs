using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius { get; }
        public void Draw()
        {
            var r = this.Radius;
            for (int row = 0; row <= this.Radius * 2; row++)
            {
                for (int col = 0; col <= this.Radius * 2; col++)
                {
                    var distance =Math.Ceiling(Math.Sqrt((row - r) * (row - r)
                        + (col - r) * (col - r)));
                    if (distance==r)
                        Console.Write('*');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
