using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialiasedSoldiers
    {
        public SpecialisedSoldier(string firstName, string lastName, int id, decimal salary,Corps corps) : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }
    }
}
