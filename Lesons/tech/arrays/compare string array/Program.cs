using System;

namespace compare_string_array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "Sofia", "Plovdiv", "Burgas" };
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
