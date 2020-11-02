using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }
        private List<IDecoration> models;
        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        //TODO:findType
        public IDecoration FindByType(string type)
        {
           foreach (var decoration in this.models)
           {
               if(decoration.GetType().Name==type)
               {
                   return decoration;
               }
           }
           return null;                        
        }

        public bool Remove(IDecoration model) => this.models.Remove(model);
    }
}
