using System.Collections;
using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ICommando:ISpecialiasedSoldiers
    {
        public ICollection<IMission> Missions { get; }
       // public void CompleteMission();
    }
}
