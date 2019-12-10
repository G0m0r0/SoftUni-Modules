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

        public IReadOnlyCollection<IPlayer> Players { get; }

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            foreach (var person in this.Players)
            {
                if (person.Username == player.Username)
                {
                    throw new ArgumentException($"Player {player.Username} already exists!");
                }
            }

            if (!PlayerByName.ContainsKey(player.Username))
            {
                PlayerByName[player.Username] = player;
            }
        }

        public IPlayer Find(string username)
        {
            foreach (var person in this.Players)
            {
                if (person.Username == username)
                {
                    return person;
                }
            }

            return null;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if(PlayerByName.ContainsKey(player.Username))
            {
                PlayerByName.Remove(player.Username);
                return true;
            }
            return false;
        }
    }
}
