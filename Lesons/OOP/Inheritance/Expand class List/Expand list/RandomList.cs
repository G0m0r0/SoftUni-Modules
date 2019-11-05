using System;
using System.Collections.Generic;
using System.Text;

namespace Expand_list
{
    class RandomList:List<string>
    {
        private Random random = new Random();

        public string GetRandomElement()
        {
            var elementIndex = random.Next(0,this.Count);
            return this[elementIndex];
        }
        public string RemoveRandom()
        {
            var elementIndex = random.Next(0, this.Count);
            var element = this[elementIndex];
            this.RemoveAt(elementIndex);
            return element;
        }
    }
}
