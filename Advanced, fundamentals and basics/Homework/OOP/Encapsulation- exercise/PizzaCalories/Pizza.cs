using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            toppings = new List<Topping>();
        }

        private string name;
        private List<Topping> toppings;
        public Dough Dough { get; }

        public string Name
        {
            get { return name; }
            set 
            { 
                if(value.Length<1||value.Length>15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }

        public int TopingsCount => this.toppings.Count;

        public double TotalCalories => toppings.Sum(x => x.GetTotalCalories())+this.Dough.GetTotalCalories();

        public void AddTopping(Topping topping)
        {
            if(this.TopingsCount==10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
            

    }
}
