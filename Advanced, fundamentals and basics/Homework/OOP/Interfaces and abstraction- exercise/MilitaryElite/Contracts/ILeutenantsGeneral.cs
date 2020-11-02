using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ILeutenantsGeneral
    {
        public Dictionary<int,IPrivate> Privates { get; }
    }
}
