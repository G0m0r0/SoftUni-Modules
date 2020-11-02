using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier,ICommando
    {
        public Commando(string firstName, string lastName, int id, decimal salary, Corps corps,ICollection<IMission> missions) : base(firstName, lastName, id, salary, corps)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }
       //public void CompleteMission()
       //{
       //    throw new NotImplementedException();
       //}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            foreach (var currentMissions in this.Missions)
            {
                sb.AppendLine("  " + currentMissions.ToString());
            }

            return sb.ToString().TrimEnd();
        }      
}
}
