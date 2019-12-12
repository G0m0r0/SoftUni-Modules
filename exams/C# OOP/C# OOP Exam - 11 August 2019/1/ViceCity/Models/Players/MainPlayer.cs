using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player, IPlayer
    {
        private const int initialStartingPoints = 100;
        private const string nameHero= "Tommy Vercetti";
        public MainPlayer() 
            : base(nameHero, initialStartingPoints)
        {
        }
    }
}
