﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        private int radius;

        public int Radius
        {
            get { return radius; }
            private set { radius = value; }
        }


        public void Draw()
        {
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            for (double y = this.Radius; y >= -this.radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}