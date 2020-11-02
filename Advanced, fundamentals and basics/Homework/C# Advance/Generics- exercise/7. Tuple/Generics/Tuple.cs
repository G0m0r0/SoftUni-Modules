using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Tuple<T,TT>
    {
        private T item1;
        private TT item2;

        public TT Item2
        {
            get { return item2; }
            set { item2 = value; }
        }

        public T Item1
        {
            get { return item1; }
            set { item1 = value; }
        }

        public Tuple(T item1,TT item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
