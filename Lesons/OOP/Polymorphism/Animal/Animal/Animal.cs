using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphisam_2.Animal
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public string FavouriteFood { get; set; }
        public virtual string ExplainSelf()
        {
            return "Animal";
        }
    }
}
