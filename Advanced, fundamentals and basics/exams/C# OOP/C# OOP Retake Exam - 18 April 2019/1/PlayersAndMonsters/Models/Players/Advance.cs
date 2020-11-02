using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advance : Player,IPlayer
    {
        private const int AdvancedPlayerInitialHealth = 250;
        public Advance(ICardRepository cardRepository,string username) 
            : base(cardRepository,username, AdvancedPlayerInitialHealth)
        {
        }
    }
}
