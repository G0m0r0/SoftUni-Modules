using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                name = value;
            }
        }

        private decimal money;

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                money = value;
            }
        }

        private List<Product> bag;
        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public void AddToBag(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.bag.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");

                this.Money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if(this.Bag.Count==0)
            {
                return $"{this.Name} - Nothing bought";
            }
            return $"{this.Name} - {string.Join(", ", this.Bag.Select(x => x.Name))}";
        }

    }
}
