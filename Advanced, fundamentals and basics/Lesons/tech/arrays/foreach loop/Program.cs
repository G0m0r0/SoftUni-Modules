using System;

namespace foreach_loop
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 9, -100, -10, 0 };
            foreach  (int num in array)
            {
                Console.Write(num+" ");
            }
        }
    }
}
