using System;

namespace Expand_list
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomList = new RandomList();
            randomList.Add("1");
            randomList.Add("2");
            randomList.Add("3");
            randomList.Add("4");
            randomList.Add("5");
            Console.WriteLine(randomList.RemoveRandom());
            Console.WriteLine(randomList.Count);

            Console.WriteLine(randomList.GetRandomElement());


            var stack = new StackOfString();
            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new[] {"1","2","3" });
            Console.WriteLine(stack.IsEmpty());

            int a = MyStatickMethod();
        }

        public static int MyStatickMethod()
        {
            int a = 5;
            return a;
        }
    }
}
