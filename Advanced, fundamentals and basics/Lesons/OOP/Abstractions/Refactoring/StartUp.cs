using P03_StudentSystem.IO;
using System;

namespace P03_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem =
                new StudentSystem(new ConsoleIoEngine());
            studentSystem.ParseCommands();

            Color color = Color.Yellow;
            Console.WriteLine(color);
            Console.WriteLine((int)color);
            color = Color.Yellow;
            if (color == Color.Yellow)
            {
                Console.WriteLine("Yellow!!!");
            }
        }
    }
}
