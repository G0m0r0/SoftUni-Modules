using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorationRepository = new DecorationRepository();
        }
        private IRepository<IDecoration> decorationRepository;
        private List<IAquarium> aquariums;
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            this.aquariums.Add(aquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            this.decorationRepository.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            string aquariumType = string.Empty;
            // if(fishType== "FreshwaterFish")
            //  {
            //      aquariumType = "FreshwaterAquarium";
            //  }
            // else if(fishType== "SaltwaterFish")
            //  {
            //      aquariumType = "SaltwaterAquarium";
            //  }
            foreach (var aquarium in this.aquariums)
            {
                if (aquarium.Name == aquariumName)
                {
                    aquariumType = aquarium.GetType().Name;
                }
            }
            var aquariumTypeFish = string.Empty;
            if(aquariumType== "FreshwaterAquarium")
            {
                aquariumTypeFish = "FreshwaterFish";
            }
            else if(aquariumType== "SaltwaterAquarium")
            {
                aquariumTypeFish = "SaltwaterFish";
            }

            if (aquariumTypeFish != fishType)
            {
                return "Water not suitable.";
            }

            foreach (var aqurium in this.aquariums)
            {
                if (aqurium.Name == aquariumName)
                {
                    aqurium.AddFish(fish);
                }
            }


            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            decimal calculatedPrice = 0;
            foreach (var aquarium in this.aquariums)
            {
                if (aquarium.Name == aquariumName)
                {
                    calculatedPrice += aquarium.Fish.Sum(x => x.Price);
                    calculatedPrice += aquarium.Decorations.Sum(x => x.Price);
                }
            }

            return $"The value of Aquarium {aquariumName} is {calculatedPrice:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            //TODO: improvements
            int fishFed = 0;

            foreach (var aquarium in this.aquariums)
            {
                if (aquarium.Name == aquariumName)
                {
                    aquarium.Feed();
                    fishFed = aquarium.Fish.Count;
                }
            }

            return $"Fish fed: {fishFed}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            //var desiredAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var decoration = this.decorationRepository.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            this.decorationRepository.Remove(decoration);

            foreach (var aquarium in this.aquariums)
            {
                if (aquarium.Name == aquariumName)
                {
                    aquarium.AddDecoration(decoration);
                }
            }

            //desiredAquarium.AddDecoration(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
