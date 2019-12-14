using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }
        private string name;
        private IPilot pilot;
        private List<string> targets;

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if(value==null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        //TODO: check if negative
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if(target==null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= this.AttackPoints - target.DefensePoints;
            
            if(target.HealthPoints<0)
            {
                target.HealthPoints = 0;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {nameof(BaseMachine)}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");
            if(targets.Count>0)
            {
                sb.AppendLine(string.Join(",", targets));
            }
            else
            {
                sb.AppendLine("None");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
