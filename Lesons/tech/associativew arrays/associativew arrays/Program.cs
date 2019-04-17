using System;
using System.Collections.Generic;

namespace associativew_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //similar to dictionaries
            List<KeyValue<string, int>> list = new List<KeyValue<string,int>>();
            //ctrl+. var and easier declaration
            list.Add(new KeyValue<string, int>("niki", 2));
            list.Add(new KeyValue<string, int>("pesho", 3));
            list.Add(new KeyValue<string, int>("ivo", 8));
            list.Add(new KeyValue<string, int>("gosho", 9));


            //gosho ?
            //search for gosho but its slow!
            //liner number of operations
            foreach (var item in list)
            {
                if(item.Index=="gosho")
                {
                    Console.WriteLine("Found gosho:"+item.Value);
                }
            }
        }

    }
    class KeyValue<Tkey, Tvalue>
    {
        public KeyValue(Tkey index,Tvalue value)
        {
            Index = index;
            Value = value;
        }
        public Tkey Index { get; set; }
        public Tvalue Value { set; get; }
    }
}
