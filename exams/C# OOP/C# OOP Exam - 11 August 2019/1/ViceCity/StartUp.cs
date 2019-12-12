using ViceCity.Core;
using ViceCity.Core.Contracts;
using System;
using ViceCity.Models.Guns;

namespace ViceCity
{
    public class StartUp
    {
        IEngine engine;
        static void Main(string[] args)
        {
            Pistol pistol = new Pistol("Name");

            int bullets = 0;
            for (int i = 0; i < 115; i++)
            {
                bullets+=pistol.Fire();
            }
            Console.WriteLine(bullets);

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
