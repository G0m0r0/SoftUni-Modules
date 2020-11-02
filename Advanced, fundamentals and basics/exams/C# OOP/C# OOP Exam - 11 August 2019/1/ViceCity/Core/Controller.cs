using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood gangNeighbourhood;
        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.gangNeighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (nameof(Pistol) == type)
            {
                gun = new Pistol(name);
            }
            else if (nameof(Rifle) == type)
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.guns.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count <= 0)
            {
                return "There are no guns in the queue!";
            }

            var civilPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            var gunToAdd = this.guns.FirstOrDefault(g => g.Name == name);
            string message = string.Empty;

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gunToAdd);
                this.guns.Remove(gunToAdd);

                message= $"Successfully added {gunToAdd.Name} to the Main Player: Tommy Vercetti";
            }
            else if (civilPlayer != null)
            {
                civilPlayer.GunRepository.Add(gunToAdd);
                guns.Remove(gunToAdd);

                message= $"Successfully added {gunToAdd.Name} to the Civil Player: {civilPlayer.Name}";
            }
            else
            {
                message= "Civil player with that name doesn't exists!";
            }
            return message;
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);
            int totalSumLifePoints = this.civilPlayers.Sum(p => p.LifePoints);

            const int mainPlayerInitialLifePpoints = 100;
            int totalSumLifePointsAfterFight = this.civilPlayers.Sum(p => p.LifePoints);

            int aliveCivilPlayersCount = this.civilPlayers.Count(p => p.IsAlive);

            string message = string.Empty;
            //TODO: if injured
            if(mainPlayer.LifePoints==mainPlayerInitialLifePpoints&&totalSumLifePoints==totalSumLifePointsAfterFight)
            {
                message = "Everything is okay!";
            }
            else
            {
                message = "A fight happened:"+Environment.NewLine;
                message += $"Tommy live points: {this.mainPlayer.LifePoints}!"+Environment.NewLine;
                message += $"Tommy has killed: {this.civilPlayers.Count-aliveCivilPlayersCount} players!"+Environment.NewLine;
                message += $"Left Civil Players: {aliveCivilPlayersCount}!";
            }

            return message;
        }
    }
}
