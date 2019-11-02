using System;
using System.Linq;

namespace Point_in_Rectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] pointsTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Rectangle rectangle = InitializeRectangle(pointsTokens);

            int numOfpoints = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfpoints; i++)
            {
                pointsTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Point point = TakePoint(pointsTokens);
                if (rectangle.Contains(point))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }

        }

        private static Point TakePoint(int[] points)
        {
            int xCoordinate = points[0];
            int yCoordinate = points[1];

            Point point = new Point(xCoordinate, yCoordinate);

            return point;
        }

        private static Rectangle InitializeRectangle(int[] tokens)
        {
            int xTopLeft = tokens[0];
            int yTopLeft = tokens[1];
            int xBottomRight = tokens[2];
            int yBottomRight = tokens[3];
            Point pointTopLeft = new Point(xTopLeft, yTopLeft);
            Point pointBottomRight = new Point(xBottomRight, yBottomRight);

            Rectangle rectangle = new Rectangle(pointTopLeft, pointBottomRight);

            return rectangle;
        }
    }
}
