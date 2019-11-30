using MyTestingframework.Executor;
using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Executor ex = new Executor();
            ex.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
