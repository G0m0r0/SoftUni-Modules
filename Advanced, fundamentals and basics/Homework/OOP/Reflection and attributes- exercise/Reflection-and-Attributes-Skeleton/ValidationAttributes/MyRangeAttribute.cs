using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
        private readonly int Min;
        private readonly int Max;
        public override bool IsValid(object obj)
        {
            if (obj is int valueAsInt)
            {
                if (valueAsInt >= Min && valueAsInt <= Max)
                {
                    return true;
                }
                return false;
            }

            throw new ArgumentException("Invalid type");

        }
    }
}
