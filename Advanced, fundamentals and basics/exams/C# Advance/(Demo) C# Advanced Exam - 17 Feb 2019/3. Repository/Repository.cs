using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        public Dictionary<int, Person> persons;
        private int countId;

        public Repository()
        {
            persons = new Dictionary<int, Person>();
            countId = 0;
        }

        public void Add(Person person)
        {
            persons[countId] = person;
            countId++;
        }
            
        public Person Get(int id)
        {
            foreach (var kvpPerson in persons)
            {
                if(kvpPerson.Key==id)
                {
                    return kvpPerson.Value;
                }
            }
            return null;
        }
            
        public bool Update(int id,Person newPerson)
        {
            if(persons.ContainsKey(id))
            {
                persons[id] = newPerson;
                return true;
            }
            return false;
        }
            
        public bool Delete(int id)
        {
            if (persons.ContainsKey(id))
            {
                persons.Remove(id);
                return true;
            }
            return false;
        }

        public int Count => persons.Count;
    }
}
