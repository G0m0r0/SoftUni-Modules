using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InteratorsAndComperators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> Listy;
        private int currentIndex;
        public ListyIterator(List<T> elements)
        {
            this.Listy = elements;
            this.currentIndex = 0;
        }
        // public void Create(List<T> elements)
        // {
        //     Listy = new List<T>(elements);
        // }

        public bool Move()
        {
            bool hasNext = this.HasNext();

            if (hasNext)
            {
                this.currentIndex++;
            }
            return hasNext;
        }

        public bool HasNext()
        {
            if (Listy.Count > currentIndex + 1)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (!this.Listy.Any())
            {
                throw new InvalidOperationException("Ivalid Operation");
            }
            Console.WriteLine(this.Listy[currentIndex]);
        }

         public IEnumerator<T> GetEnumerator()
         {
             foreach (var item in this.Listy)
             {
                 yield return item;
             }
         }
        
         IEnumerator IEnumerable.GetEnumerator()
         {
             return this.GetEnumerator();
         }
    }
}
