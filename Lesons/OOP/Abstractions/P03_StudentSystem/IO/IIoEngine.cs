using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.IO
{
    public interface IIoEngine
    {
        string Read();
       void Write(string str);
    }
}
