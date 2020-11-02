using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class DoughValidator
    {
        private static Dictionary<string, double> flourType;
        private static Dictionary<string, double> bakingTechniques;

        public static bool IsValidFlourType(string type)
        {
            if (flourType == null || bakingTechniques == null)
            {
                Initialize();
            }
            return flourType.ContainsKey(type.ToLower());
        }

        public static bool IsValidBackingTechnique(string type)
        {
            if (flourType == null || bakingTechniques == null)
            {
                Initialize();
            }
            return bakingTechniques.ContainsKey(type.ToLower());
        }

        private static void Initialize()
        {
            flourType = new Dictionary<string, double>()
                {
                   {   "white" , 1.5},
                   {   "wholegrain" , 1.0},
                };

            bakingTechniques = new Dictionary<string, double>()
                {
                    {   "crispy",  0.9},
                    {   "chewy" , 1.1 },
                    {   "homemade" , 1.0}
                };
        }

        public static double GetFlourModifier(string type) => flourType[type.ToLower()];


        public static double GetBackingTechModifier(string type) => bakingTechniques[type.ToLower()];
    }
}
