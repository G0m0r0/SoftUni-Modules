using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class Stack<T>: IEnumerable<T>
    {
        private List<T> myStack;
        public Stack()
        {
            myStack = new List<T>();
        }

        public void Push(T[] element)
        {
            foreach (var item in element)
            {
                myStack.Add(item);
            }
        }

        public void Pop()
        {
            if(!myStack.Any())
            {
                throw new Exception("No elements");
            }
            myStack.RemoveAt(myStack.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = myStack.Count - 1; i >= 0; i--)
            {
                yield return myStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
