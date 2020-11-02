using System;
using System.Collections.Generic;
using System.Text;

namespace EgnHelper
{
    public interface IEgnValidator
    {
        bool IsValid(string egn);
    }
}
