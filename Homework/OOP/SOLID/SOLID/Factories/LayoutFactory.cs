using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Factories
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                case "jasonlayout":
                    return new JasonLayout();
                default:
                    throw new ArgumentException("Invalid Layout");
            }
        }
    }
}
