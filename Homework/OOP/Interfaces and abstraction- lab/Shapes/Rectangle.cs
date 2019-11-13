using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle:IDrawable
    {
        public Rectangle(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }
        private int width;

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        private int height; 

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 1; i < this.Height-1; i++)
            {
                DrawLine(this.Width, '*', ' ');
            }
            DrawLine(this.Width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width-1; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
