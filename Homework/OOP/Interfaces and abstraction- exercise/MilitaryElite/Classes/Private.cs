using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Private:Soldier
    {
        public Private(string firstName,string lastName,string id,decimal salary):base(firstName,lastName,id)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }
    }
}
