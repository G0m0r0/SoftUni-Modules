using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Threeuple<T,K,M>
    {
        public T Item1 { get; set; }
        public K Item2 { get; set; }
        public M Item3 { get; set; }

        public Threeuple(T item1,K item2, M item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
