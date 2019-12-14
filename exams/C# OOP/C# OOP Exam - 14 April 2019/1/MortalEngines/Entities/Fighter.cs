using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }
        //TODO: protected set ?
        public bool AggressiveMode {get;}

        public void ToggleAggressiveMode()
        {
            if(AggressiveMode)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var onOrOff = string.Empty;
            if (AggressiveMode)
            {
                onOrOff = "ON";
            }
            else
            {
                onOrOff = "OFF";
            }

            return base.ToString() + Environment.NewLine + $" *Aggressive: {onOrOff}";
        }
    }
}
