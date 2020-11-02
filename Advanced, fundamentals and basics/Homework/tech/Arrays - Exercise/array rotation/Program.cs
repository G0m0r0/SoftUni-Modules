using System;

namespace array_rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int rotation = int.Parse(Console.ReadLine());
            for (int i = 0; i < rotation; i++)
            {
                string swap = array[0];
                for (int j = 0; j < array.Length-1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length-1] = swap;
            }
            Console.WriteLine(string.Join(' ',array));
        }
    }
}
