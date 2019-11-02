using System;
using System.Collections.Generic;
using System.Text;

namespace Point_in_Rectangle
{
    public class Point
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Point(int x, int y)
        {
            this.XCoordinate = x;
            this.YCoordinate = y;
        }
    }
}
