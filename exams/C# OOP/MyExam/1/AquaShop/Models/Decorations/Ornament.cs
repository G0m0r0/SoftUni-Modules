using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration,IDecoration
    {
        private const int InitialComfort = 1;
        private const decimal InitialPrice = 5;
        public Ornament() 
            : base(InitialComfort,InitialPrice)
        {
        }
    }
}
