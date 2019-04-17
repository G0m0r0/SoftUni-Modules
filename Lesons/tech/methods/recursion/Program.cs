using System;

namespace recursion
{
    class Program
    {
        static void CallMyself(int n)
        {
            if (n == 0)
                return;
            CallMyself(n-1);
        }
        static void Main(string[] args)
        {
            CallMyself(100);
        }
    }
}
