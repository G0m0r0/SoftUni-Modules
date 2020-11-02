using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card, ICard
    {
        private const int InitializeDamagePoints = 5;
        private const int InitializeHealthPoints = 80;

        public MagicCard(string name)
            : base(name, InitializeDamagePoints, InitializeHealthPoints)
        {
        }
    }
}
