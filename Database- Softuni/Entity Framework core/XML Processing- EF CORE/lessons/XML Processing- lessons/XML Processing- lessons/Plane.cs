using System;
using System.Xml.Serialization;

namespace XML_Processing__lessons
{
    [XmlType("plane")]
    [Serializable] //if we use binary serializor
    public class Plane
    {
        [XmlElement("YearOfManifactur")]
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [XmlIgnore]
        public string Color { get; set; }
    }
}
