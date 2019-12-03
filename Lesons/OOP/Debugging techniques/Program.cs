using System;

namespace Debugging_techniques
{
    class Program
    {
        static void Main()
        {
            ;
            int a = 10;
            int b = 30;

            int result = GetSum(a, b);

            Console.WriteLine(result);
        }

        private static int GetSum(int a, int b)
        {
            return a + b;
        }
    }
}
