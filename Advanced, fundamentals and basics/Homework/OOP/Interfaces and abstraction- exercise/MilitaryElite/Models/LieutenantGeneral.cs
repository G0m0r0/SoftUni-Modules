using MilitaryElite.Contracts;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILeutenantsGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary,Dictionary<int,IPrivate> privates) : base(firstName, lastName, id, salary)
        {
            this.Privates = privates;
        }

        public Dictionary<int, IPrivate> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
       
            foreach (var currentPrivate in this.Privates)
            {
                sb.AppendLine("  "+currentPrivate.Value.ToString());
            }
       
       
            return sb.ToString().TrimEnd();
        }
    }
}
