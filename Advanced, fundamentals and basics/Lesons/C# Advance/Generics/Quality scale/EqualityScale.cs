using System;
using System.Collections.Generic;
using System.Text;

namespace Quality_scale
{
    public class EqualityScale<T>
        where T:IComparable
    {
        private T first;
        private T second;

        public T Second
        {
            get;
            //set { second = value; }
        }


        public T First
        {
            get;
           // set { first = value; }
        }


        public EqualityScale(T first,T second)
        {
            this.First = first;
            this. Second = second;
        }

        public bool AreEqual()
        {
            return this.first.Equals(this.second);
        }

        public bool IsFirstGreater()
        {
            return this.First.CompareTo(this.Second)>0;
            //compareTo returns -1,-,+1
        }
    }
}
