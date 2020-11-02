using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public int Id { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
