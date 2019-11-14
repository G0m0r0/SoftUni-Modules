using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Repair
    {
        public Repair(string partName,int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }
        public string PartName { get; set; }
        public int HoursWorked { get; set; }
    }
}
