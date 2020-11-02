using System;
using System.Linq;
using System.Collections;

namespace magic_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int searchedNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {               
                    if ((array[i] + array[j] == searchedNum)&&(i!=j))
                    { 
                        Console.WriteLine(array[i] + " " + array[j]);                    
                    }
                }
            }
        }
    }
}
