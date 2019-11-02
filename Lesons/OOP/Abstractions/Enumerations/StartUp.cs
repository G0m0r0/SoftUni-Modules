using System;

namespace Enumerations
{
    public enum Color
    {
        UnKnown=0,
        Red=1,
        Purple=2,
        Blue=3
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            Color color = Color.Blue;

            Console.WriteLine(color);
            Console.WriteLine((int)(color));
        }
    }
}
