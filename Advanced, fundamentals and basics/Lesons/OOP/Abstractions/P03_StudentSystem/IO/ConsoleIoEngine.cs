using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.IO
{
    public class ConsoleIoEngine : IIoEngine
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
