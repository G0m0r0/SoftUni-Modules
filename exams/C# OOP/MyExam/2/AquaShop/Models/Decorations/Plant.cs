using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration,IDecoration
    {
        private const int InitialComfort = 5;
        private const decimal InitialPrice = 10;
        public Plant() 
            : base(InitialComfort,InitialPrice)
        {
        }
    }
}
