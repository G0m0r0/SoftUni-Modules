using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width { get;}
        public int Height { get; }

        public void Draw()
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine(new string('*',this.Width));
            for (int i = 1; i < Height-1; i++)
            {
                Console.WriteLine($"*{new string(' ',this.Width-2)}*");
            }
            Console.WriteLine(new string('*', this.Width));

        }
    }
}
