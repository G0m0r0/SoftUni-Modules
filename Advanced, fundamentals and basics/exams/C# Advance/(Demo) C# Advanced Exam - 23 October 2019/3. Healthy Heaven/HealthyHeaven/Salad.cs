using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad 
    {
        public string Name { get; set; }
        public List<Vegetable> products { get; set; }

        public Salad(string name)
        {
            this.Name = name;
            products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            int calories = 0;
            foreach (var salad in products)
            {
                calories += salad.Calories;
            }
            return calories;
        }
        public int GetProductCount()
        {
            return products.Count();            
        }

        public override string ToString()
        {
            return $"Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:{Environment.NewLine}{string.Join(Environment.NewLine, products)}";
        }
        // public IEnumerator<Vegetable> GetEnumerator()
        // {
        //     foreach (var element in this.products)
        //     {
        //         yield return element;
        //     }
        // }
        //
        // IEnumerator IEnumerable.GetEnumerator()
        // {
        //     return this.GetEnumerator();
        // }
    }
}
