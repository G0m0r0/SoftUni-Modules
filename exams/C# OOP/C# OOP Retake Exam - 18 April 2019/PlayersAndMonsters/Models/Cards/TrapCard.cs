using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card, ICard
    {
        private const int InitializeDamagePoints = 120;
        private const int InitializeHealthPoints = 5;

        public TrapCard(string name)
            : base(name, InitializeDamagePoints, InitializeHealthPoints)
        {
        }
    }
}
