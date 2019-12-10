using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advance : Player,IPlayer
    {
        private const int BeginnerPlayerHealthInitialization = 250;
        public Advance(string username, ICardRepository cardRepository) 
            : base(cardRepository,username, BeginnerPlayerHealthInitialization)
        {
        }
    }
}
