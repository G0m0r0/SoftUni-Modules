using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Engineer:SpecialisedSoldier
    {
        public Engineer(string firstName,string lastName,string id,decimal salary,string occupationTitle,params Repair[] repairs):base(firstName,lastName,id,salary,occupationTitle)
        {
            this.Repairs = repairs.ToList();
        }
        private List<Repair> Repairs;
    }
}
