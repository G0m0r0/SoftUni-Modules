using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private Dictionary<string, IPlayer> PlayerByName;
        public PlayerRepository()
        {
            PlayerByName = new Dictionary<string, IPlayer>();
        }
        public int Count => PlayerByName.Count;

        public IReadOnlyCollection<IPlayer> Players =>
            this.PlayerByName.Values.ToList().AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (this.PlayerByName.ContainsKey(player.Username))
            {
                throw new ArgumentException(
                    $"Player {player.Username} already exists!");
            }

            PlayerByName[player.Username] = player;
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;
            if (this.PlayerByName.ContainsKey(username))
            {
                player = this.PlayerByName[username];
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

                return PlayerByName.Remove(player.Username);
        }
    }
}
