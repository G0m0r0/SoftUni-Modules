using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            //TODO: add when water is suitable for the fish
            //SaltwaterAquarium
           //string typeOfWater = nameof(fish).SkipLast(4).ToString();
           //string typeOfAquarium = nameof(Aquarium);


            if (this.Capacity<0)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var separeFish in this.fish)
            {
                separeFish.Eat();
            }
        }

        public abstract string GetInfo();
        //{
          //  //TODO: aquarium type "{aquariumName} ({aquariumType}):
          //  var sb = new StringBuilder();
          //  sb.AppendLine($"{this.Name} ({nameof(Aquarium)}):");
          //  if(this.fish.Count==0)
          //  {
          //      sb.AppendLine("Fish: none");
          //  }
          //  else
          //  {
          //      sb.AppendLine($"Fish: {string.Join(", ",this.fish)}");
          //  }
          //  sb.AppendLine($"Decorations: {this.decorations.Count}");
          //  sb.AppendLine($"Comfort: {this.Comfort}");

         //   return sb.ToString().TrimEnd();
       // }

        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);
    }
}
