using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class SpecialisedSoldier:Private
    {
        public SpecialisedSoldier(string firstName,string lastName,string id,decimal salary,string occupationTitle):base(firstName,lastName,id,salary)
        {
            this.OccupationTitle = occupationTitle;
        }
        //TODO: add corpses
        private List<Soldier> corpses; //Airforces or Marines
        public string OccupationTitle { get; set; }
    }
}
