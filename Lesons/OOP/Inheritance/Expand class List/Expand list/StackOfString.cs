using System;
using System.Collections.Generic;
using System.Text;

namespace Expand_list
{
    class StackOfString:Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                this.Push(item);
            }
        }
    }
}
