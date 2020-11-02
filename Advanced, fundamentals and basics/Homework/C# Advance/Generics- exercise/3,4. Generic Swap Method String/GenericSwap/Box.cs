using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwap
{
    public class Box<T>
    {
        public List<T> List { get; set; }

        public Box()
        {
            List = new List<T>();
        }

        public void AddElement(T element)
        {
            List.Add(element);
        }

        public void Swap(int index1,int index2)
        {
            T swapElement = List[index1];
            List[index1] = List[index2];
            List[index2] = swapElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in List)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
