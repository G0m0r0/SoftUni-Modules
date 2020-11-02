using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class ToppingValidator
    {
       private static Dictionary<string, double> topping;

        public static bool IsValidTopping(string type)
        {
            if(topping==null)
            {
                Intialize();
            }
            return topping.ContainsKey(type.ToLower());
        }

        private static void Intialize()
        {
            topping = new Dictionary<string, double>()
            {
                {   "meat",  1.2},
                {   "veggies" , 0.8},
                {   "cheese" , 1.1 },
                {	"sauce" , 0.9}
            };
        }

        public static double GetToppingModifier(string type) => topping[type.ToLower()];
    }
}
