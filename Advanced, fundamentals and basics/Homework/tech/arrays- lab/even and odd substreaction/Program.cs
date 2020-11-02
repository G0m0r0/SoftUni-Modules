using System;
using System.Linq;
namespace even_and_odd_substreaction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int even = 0;
            int odd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                    even += array[i];
                else odd += array[i];         
            }
            Console.WriteLine(even-odd);
        }
    }
}
