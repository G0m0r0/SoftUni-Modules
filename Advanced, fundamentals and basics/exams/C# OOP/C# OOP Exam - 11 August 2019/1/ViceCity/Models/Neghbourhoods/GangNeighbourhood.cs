using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var currentGun in mainPlayer.GunRepository.Models)
            {
                foreach (var currentCvil in civilPlayers)
                {
                    while (currentCvil.IsAlive&&currentGun.CanFire)
                    {
                        currentCvil.TakeLifePoints(currentGun.Fire());
                    }

                    if(!currentGun.CanFire)
                    {
                        break;
                    }
                }
            }

            foreach (var currentCivil in civilPlayers)
            {
                if(currentCivil.IsAlive)
                {
                    continue;
                }
                foreach (var currentGun in currentCivil.GunRepository.Models)
                {
                    while (mainPlayer.IsAlive&&currentGun.CanFire)
                    {
                        mainPlayer.TakeLifePoints(currentGun.Fire());
                    }
                   
                    if(!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}
