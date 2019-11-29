using System;
using System.Collections.Generic;
using System.Text;

namespace CodingAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
