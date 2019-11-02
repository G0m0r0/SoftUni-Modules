using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Rhombus_of_Stars
{
    public class Rhombus
    {
        public string Draw(int n)
        {
            var top = DrawTop(n);
            var bottom = DrawBottom(n);
            StringBuilder sb = new StringBuilder();

            return top.ToString() + bottom.ToString();
        }

        private StringBuilder DrawTop(int n)
        {
            StringBuilder sbtop = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                sbtop.Append(new string(' ', n - i));
                sbtop.Append(DrawLineStar(i));
            }            

            return sbtop;
        }

        private string DrawLineStar(int num)
        {
            StringBuilder sbLine = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sbLine.Append("* ");
            }
            sbLine.AppendLine();

            return sbLine.ToString();
        }

        private StringBuilder DrawBottom(int n)
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
