using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) 
            : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }
        private const double CakeGrams = 250d;
        private const double CakeCalories= 1000d;
        private const decimal CakePrice = 5m;
    }
}
