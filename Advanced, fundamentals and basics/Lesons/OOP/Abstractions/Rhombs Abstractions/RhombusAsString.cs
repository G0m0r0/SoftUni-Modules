using System;
using System.Collections.Generic;
using System.Text;

namespace Rhombs_Abstractions
{
    public class RhombusAsString
    {
        public string Draw(int countOfStars)
        {
            StringBuilder sb = new StringBuilder();
            this.DrawTopPart(sb, countOfStars);
            this.DrawLineOfStars(sb, countOfStars);
            this.DrawBottomPart(sb, countOfStars);

            return sb.ToString();
        }

        private void DrawTopPart(StringBuilder sb, int n)
        {
            for (int i = 1; i < n; i++)
            {
                sb.Append(new string(' ', n - i));
                DrawLineOfStars(sb, i);
            }
        }
        private void DrawBottomPart(StringBuilder sb, int n)
        {
            for (int i = n - 1; i >= 1; i--)
            {
                sb.Append(new string(' ', n - i));
                DrawLineOfStars(sb, i);
            }
        }

        private void DrawLineOfStars(StringBuilder sb, int numOfStars)
        {
            for (int star = 0; star < numOfStars; star++)
            {
                sb.Append('*');
                if (star < numOfStars - 1)
                {
                    sb.Append(' ');
                }
            }
            // sb.Append(new string(' ', n - i - 1));
            sb.AppendLine();
        }
    }
}
