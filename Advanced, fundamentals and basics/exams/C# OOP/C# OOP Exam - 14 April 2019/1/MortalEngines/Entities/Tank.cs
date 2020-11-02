using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine,ITank
    {
        private const double InitialHealthPoints = 100;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        //TODO: protected set ?
        public bool DefenseMode { get; }

        public void ToggleDefenseMode()
        {
            if(DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
                    
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var onOrOff = string.Empty;
            if(DefenseMode)
            {
                onOrOff = "ON";
            }
            else
            {
                onOrOff = "OFF";
            }

            return base.ToString() + Environment.NewLine + $" *Defense: {onOrOff}";
        }
    }
}
