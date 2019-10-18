using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
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
                throw new InvalidOperationException();
            }
            var topElement = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return topElement;
        }

        public Box()
        {
            list = new List<T>();
        }
    }
}
