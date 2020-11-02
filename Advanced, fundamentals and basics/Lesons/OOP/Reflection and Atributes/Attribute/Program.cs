using System;

namespace Attribute
{
    [Flags]
    public enum Border
    {
        Left=1,
        Right=2,
        Bottom=4,
        Top=8,
    }
    class Program
    {
        static void Main(string[] args)
        {
            Border border = Border.Left | Border.Right;
            Console.WriteLine(border);
        }
    }
}
