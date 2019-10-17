using System;

namespace Delegates
{
    static class Delegates
    {
        //delegate that return something
        public delegate int Multiplayer(int x, int y);
        //void delegate
        public delegate void PrintSomething();
        static void Main(string[] args)
        {            
            Multiplayer calc = (x, y) => x * y;
            //same as Func<int,int,int>

            PrintSomething action = () => Console.WriteLine("Hello!");
            //same as action()
            Action<string> print = message => Console.WriteLine(message); 
        }
    }
}
