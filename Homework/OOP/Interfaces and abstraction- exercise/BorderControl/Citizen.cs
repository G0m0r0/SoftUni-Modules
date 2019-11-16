using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen
    {
        public Citizen()
        {
            this.Citizens = new List<ICitizen>();
        }
        private List<ICitizen> Citizens;

        public void AddCitizen(ICitizen citizen)
        {
            this.Citizens.Add(citizen);
        }

        public void PrintDetainedIds(string id)
        {
            foreach (var citizen in this.Citizens)
            {
                if(citizen.ID.EndsWith(id))
                Console.WriteLine(citizen.ID);
            }
        }
    }
}
