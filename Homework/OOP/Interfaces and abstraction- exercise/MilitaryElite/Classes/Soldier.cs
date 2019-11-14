using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public string FirstName {get; set ; }
        public string LastName { get ; set ; }
        public string Id { get; set; }
    }
}
