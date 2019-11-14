using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ISoldier
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }

    }
}
