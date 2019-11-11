using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int ConstCaloriesPerGram = 2;
        private double weight;
        private string backingTechique;
        private string flourType;

        public Dough(string flourType,string bakingTechType,double weight)
        {
            this.FlourType = flourType;
            this.BackingTechique = bakingTechType;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            set 
            { 
                if(!DoughValidator.IsValidFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value; 
            }
        }
        public string BackingTechique
        {
            get { return backingTechique; }
            set 
            { 
                if(!DoughValidator.IsValidBackingTechnique(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                backingTechique = value; 
            }
        }
        public double Weight
        {
            get { return weight; }
            set 
            {
                if(value<1||value>200)
                {
                    throw new Exception("Dough weight should be in the range[1..200].");
                }
                weight = value; 
            }
        }

        public double GetTotalCalories()
        {
            return this.Weight * 
                ConstCaloriesPerGram * 
                DoughValidator.GetBackingTechModifier(this.backingTechique) * 
                DoughValidator.GetFlourModifier(this.flourType);
        }

    }
}
