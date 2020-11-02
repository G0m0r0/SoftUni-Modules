using System;
using System.Text;

namespace _1._Rhombus_of_Stars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numOfStars = int.Parse(Console.ReadLine());

            Console.WriteLine(Draw(numOfStars));
        }
        public static string Draw(int n)
        {
            var top = DrawTop(n);
            var bottom = DrawBottom(n);
            StringBuilder sb = new StringBuilder();

            return top.ToString() + bottom.ToString();
        }

        private static StringBuilder DrawTop(int n)
        {
            StringBuilder sbtop = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                sbtop.Append(new string(' ', n - i));
                sbtop.Append(DrawLineStar(i));
            }

            return sbtop;
        }

        private static string DrawLineStar(int num)
        {
            StringBuilder sbLine = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sbLine.Append("* ");
            }
            sbLine.AppendLine();

            return sbLine.ToString();
        }

        private static StringBuilder DrawBottom(int n)
        {
            StringBuilder sbBottom = new StringBuilder();
            for (int i = n - 1; i >= 1; i--)
            {
                // if (i != n)
                sbBottom.Append(new string(' ', n - i));
                sbBottom.Append(DrawLineStar(i));
            }

            return sbBottom;
        }
    }
}
