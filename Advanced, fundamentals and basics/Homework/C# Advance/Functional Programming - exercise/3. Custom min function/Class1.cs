using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Custom_min_function
{
    public static class Class1
    {
       public static int MyMinValue(this IEnumerable<int> source)
        {
            int minValue = int.MaxValue;
            foreach (var num in source)
            {
                if (minValue > num)
                {
                    minValue = num;
                }
            }
            return minValue;
        }
    }
}
