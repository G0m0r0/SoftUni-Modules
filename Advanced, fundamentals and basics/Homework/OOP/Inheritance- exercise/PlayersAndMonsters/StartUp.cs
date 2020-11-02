using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Pesho",11);
            Console.WriteLine(wizard);
        }
    }
}