using System;
using System.Linq;


namespace equals_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool flag = true;
            int index = 0;
            int sum = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] == secondArray[i])
                    sum += firstArray[i];
                else
                {
                    index = i;
                    flag = false;
                    break;
                }
            }
            if (flag) Console.WriteLine($"Arrays are identical. Sum: {sum}");
            else Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
        }
    }
}
