using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Mission
    {
        public Mission(string codeName,bool state)
        {
            this.CodeName = codeName;
            this.State = false;
        }
        public string CodeName { get; set; }
        public bool State { get; set; }
        public void CompleteMission()
        {
            this.State = true;
        }
    }
}
