using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }
        private string name;
        private readonly List<IMachine> machines;

        public IReadOnlyCollection<IMachine> Machines => this.machines.AsReadOnly();
        public string Name
        {
            get => this.name;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if(machine==null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name}-{this.machines.Count} machines");
            foreach (var machine in this.machines)
            {
                sb.AppendLine(machine.ToString());
            }
            //TODO: what about specific last line

            return sb.ToString().TrimEnd();
        }
    }
}
