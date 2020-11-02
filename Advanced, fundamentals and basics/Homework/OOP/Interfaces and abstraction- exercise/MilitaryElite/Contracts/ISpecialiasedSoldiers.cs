using MilitaryElite.Enums;
namespace MilitaryElite.Contracts
{
    public interface ISpecialiasedSoldiers:IPrivate
    {
        public Corps Corps { get; }
    }
}
