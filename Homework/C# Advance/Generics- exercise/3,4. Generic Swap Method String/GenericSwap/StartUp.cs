using System;
using System.Linq;

namespace GenericSwap
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfOperations = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < numOfOperations; i++)
            {
                int element =int.Parse( Console.ReadLine());
                box.AddElement(element);  
            }
                int[] tokenIndex = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int index1 = tokenIndex[0];
                int index2 = tokenIndex[1];
                box.Swap(index1, index2);

            Console.WriteLine(box.ToString());
        }
    }
}
