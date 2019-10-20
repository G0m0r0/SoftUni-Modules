using System;
using System.Collections.Generic;
using System.Text;

namespace template_collection
{
    public class Box<T> 
       // where T:class
        //it meand that i cannot have int,couble- all 
    {
        private List<T> list;

        public int Count => list.Count;
        public void Add(T element)
        {
            list.Add(element);
        }

        public T Remove()
        {
            if(list.Count==0)
            {
                throw new InvalidOperationException("Cannot remove from empty list");
            }
            var element = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return element;
        }

        public Box()
        {
            this.list = new List<T>();
        }
    }
}
