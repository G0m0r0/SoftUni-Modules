using System;
using System.Collections.Generic;
using System.Text;

namespace _2._Point_in_Rectangle
{
    public class Rectangle
    {
        public Point Topleft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle(Point topleft,Point bottomRight)
        {
            this.Topleft = topleft;
            this.BottomRight = bottomRight;
        }
        public Rectangle()
        {

        }

        public bool Contains(Point point)
        {
            return point.X >= Topleft.X &&
                point.Y <= Topleft.Y &&
                point.X <= BottomRight.X &&
                point.Y >= BottomRight.Y;
        }
            
    }
}
