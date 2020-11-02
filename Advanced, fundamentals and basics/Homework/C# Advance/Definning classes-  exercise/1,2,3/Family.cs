using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyList;
        public Family()
        {
            this.familyList = new List<Person>();
        }

        public List<Person> FamilyList
        {
            get { return familyList; }
            set { familyList = value; }
        }

        public void AddMember(Person member)
        {
            familyList.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = familyList.OrderByDescending(a => a.Age).FirstOrDefault();
            return oldestPerson;
        }
        //or
        //public Person GetOldestMember()=>familyList.OrderByDescending(a => a.Age).FirstOrDefault();
    }
}
