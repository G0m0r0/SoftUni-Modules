using System;

namespace Genericsa
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfElements = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfElements; i++)
            {
                int inputLine = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(inputLine);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
