using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        private double length;

        public double Length
        {
            get { return length; }
            private set
            {
                if (value >= 0)
                    length = value;
                else
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    throw new Exception();
                }
            }
        }

        private double width;

        public double Width
        {
            get { return width; }
            private set
            {
                if (value >= 0)
                    width = value;
                else
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    throw new Exception();
                }

            }
        }

        private double height;

        public double Height
        {
            get { return height; }
            private set
            {
                if (value >= 0)
                    height = value;
                else
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    throw new Exception();
                }
            }
        }

        public string CalculateSurfaceArea()
        {
            double result = 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
            return $"Surface Area - {result:f2}";
        }

        public string CalculateLateralSurface()
        {
            double result = 2 * this.length * this.height + 2 * this.width * this.height;
            return $"Lateral Surface Area - {result:f2}";
        }

        public string CalculateVolume()
        {
            double result= this.length * this.height * this.width;
            return $"Volume - {result:f2}";
        }

    }
}
