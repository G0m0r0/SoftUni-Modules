namespace test
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var sw = Stopwatch.StartNew();

           Task.Factory.StartNew(MyMethod);

            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            Console.WriteLine(Console.Read());

            //synchronously 21sec, task.factory 8- 9miliseconds, async await 8-9 milliseconds
        }

        private static void MyMethod()
        {
            for (int i = 0; i < 100_000; i++)
            {
                for (int j = 0; j < 100_000; j++)
                {

                }
            }
        }
    }
}
