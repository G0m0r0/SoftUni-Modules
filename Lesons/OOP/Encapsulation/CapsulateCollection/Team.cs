using System;
using System.Collections.Generic;
using System.Text;

namespace CapsulateCollection
{
    public class Team
    {
        private List<Person> firstSquad;

        public List<Person> reserveSquad;

        public Team(string name)
        {
            this.firstSquad = new List<Person>();
            this.reserveSquad = new List<Person>();
            this.Name = name;
        }

        public string Name { get; }


        public IReadOnlyCollection<Person> FirstSquad => this.firstSquad.AsReadOnly();
        //same
        public IReadOnlyCollection<Person> ReserevedSquad
        {
            get
            {
                return this.reserveSquad.AsReadOnly();
            }
        }

        public void AddPlayer(Person player)
        {
            if(player.Age<40)
            {
                this.firstSquad.Add(player);
            }
            else
            {
                this.reserveSquad.Add(player);
            }
        }
    }
}
