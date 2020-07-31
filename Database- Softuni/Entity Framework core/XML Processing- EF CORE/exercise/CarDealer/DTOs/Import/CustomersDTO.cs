using System;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Customer")]
    public class CustomersDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("birthdate")]
        public DateTime BirthDate { get; set; } //it can be string but we have to parse it latter in the xml
        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}

