using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
        public Random random = new Random();

        public string Randomstring()
        {
            var index = random.Next(0, this.Count-1);
            var element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
