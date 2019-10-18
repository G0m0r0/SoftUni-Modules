using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var qualityScale = new EqualityScale<int>(3, 3);
            Console.WriteLine(qualityScale.AreEqual());
        }
    }
}
