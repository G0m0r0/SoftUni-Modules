﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Atribute
{
   // [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}