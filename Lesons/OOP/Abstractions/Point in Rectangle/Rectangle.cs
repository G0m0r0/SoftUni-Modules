using System;
using System.Collections.Generic;
using System.Text;

namespace Point_in_Rectangle
{
    public class Rectangle
    {
        public Rectangle(int top,int left,int bottom, int right)
        {
            this.TopLeft = new Point(left,top);
            this.TopLeft = new Point(right,bottom);
        }
        public Rectangle(Point topleft, Point bottomRight)
        {
            this.BottomRight = bottomRight;
            this.TopLeft = topleft;
        }

        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

       
        public bool Contains(Point point)
        {
            if(point.XCoordinate>=TopLeft.XCoordinate&&
                point.XCoordinate<=BottomRight.XCoordinate&&
                point.YCoordinate<=TopLeft.YCoordinate&&
                point.YCoordinate>=BottomRight.YCoordinate)
            {
                return true;
            }
            return false;
        }

    }
}
