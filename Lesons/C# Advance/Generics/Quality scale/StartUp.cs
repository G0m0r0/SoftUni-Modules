using System;

namespace Quality_scale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var qualityScale = new EqualityScale<int>(3, 4);
            Console.WriteLine(qualityScale.AreEqual());
            Console.WriteLine(qualityScale.IsFirstGreater());
        }
    }
}
