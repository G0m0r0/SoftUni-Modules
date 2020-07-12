namespace P03_SalesDatabase.IOManager
{
    using P03_SalesDatabase.IOManager.contracts;
    using System;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
