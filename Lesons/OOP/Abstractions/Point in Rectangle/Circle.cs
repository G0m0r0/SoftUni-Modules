using System;
using System.Collections.Generic;
using System.Text;

namespace Point_in_Rectangle
{
    public class Circle
    {
        public Circle(int x, int y,int radius)
        {
            this.Center = new Point(x, y);
            this.Radius = radius;
        }

        public Point Center { get; set; }
        public int Radius { get; set; }

        public bool Contains(Point point)
        {
            var distance = Math.Sqrt((point.XCoordinate - this.Center.XCoordinate) * (point.XCoordinate - this.Center.XCoordinate)
                + (point.YCoordinate - this.Center.YCoordinate) * (point.YCoordinate - this.Center.YCoordinate));

            if(distance<=this.Radius)
            {
                return true;
            }

            return false;
        }
    }
}
