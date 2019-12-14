using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        //check loggic
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            //while (planet.Items.Count > 0)
            //{
            //    foreach (var astronaut in astronauts)
            //    {
            //        if (!astronaut.CanBreath)
            //        {
            //            continue;
            //        }
            //        while (astronaut.CanBreath)
            //        {
            //            var item = planet.Items.FirstOrDefault();
            //            if (item == null)
            //            {
            //                break;
            //            }
            //            astronaut.Bag.Items.Add(item);
            //            planet.Items.Remove(item);
            //            astronaut.Breath();
            //        }
            //        if (planet.Items.Count == 0)
            //        {
            //            break;
            //        }
            //    }
            //}
            while (true)
            {
                var currentAstronaut = astronauts.FirstOrDefault(x => x.CanBreath);

                if (currentAstronaut is null)
                {
                    break;
                }

                var currentItem = planet.Items.FirstOrDefault();

                if (currentItem is null)
                {
                    break;
                }

                currentAstronaut.Breath();

                currentAstronaut.Bag.Items.Add(currentItem);
                planet.Items.Remove(currentItem);
            }
        }
    }
}
