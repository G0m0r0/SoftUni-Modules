using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class LieutenantGeneral:Private
    {
        //TODO: add privates to lieutenant
        public LieutenantGeneral(string firstName,string lastName,string id,decimal salaray,params string[] idPrivates)
            :base(firstName,lastName,id,salaray)
        {
            privates = new List<Private>();
        }

        private List<Private> privates;
    }
}
