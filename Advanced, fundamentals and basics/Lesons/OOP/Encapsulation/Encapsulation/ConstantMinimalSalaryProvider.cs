using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    public class ConstantMinimalSalaryProvider : IMinimalSalaryProvider
    {
        public int GetMinimalSalary()
        {
            return 600;
        }
    }
}
