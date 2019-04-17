using System;

namespace infinite_recursion_full_stack
{
    class Program
    {
        private static int a = 0;
        static void CallMyself(int a)
        {
           // a++;
            CallMyself(a+1);
        }
        static void Main(string[] args)
        {
            CallMyself(1);
        }
    }
}
