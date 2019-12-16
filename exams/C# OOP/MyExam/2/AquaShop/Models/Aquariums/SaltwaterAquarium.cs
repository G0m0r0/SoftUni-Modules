using AquaShop.Models.Aquariums.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium,IAquarium
    {
        private const int InitialCapacity = 25;
        public SaltwaterAquarium(string name) 
            : base(name, InitialCapacity)
        {
        }
        public override string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{base.Name} (SaltwaterAquarium):");
            if (base.Fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", base.Fish)}");
            }
            sb.AppendLine($"Decorations: {base.Decorations.Count}");
            sb.AppendLine($"Comfort: {base.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
