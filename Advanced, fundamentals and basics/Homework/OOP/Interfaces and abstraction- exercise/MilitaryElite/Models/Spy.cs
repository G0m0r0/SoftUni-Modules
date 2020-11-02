namespace MilitaryElite.Models
{
    using Contracts;
    using System;
    public class Spy:Soldier,ISpy
    {
        public Spy(string firstName,string lastName,int id,int codeNumber):base(firstName,lastName,id)
        {
            this.CodeNumber = codeNumber;
        }
        public int CodeNumber { get; set; }

        public override string ToString()
        {
            return base.ToString()+
                $"{Environment.NewLine}Code Number: { this.CodeNumber}";
        }
    }
}
