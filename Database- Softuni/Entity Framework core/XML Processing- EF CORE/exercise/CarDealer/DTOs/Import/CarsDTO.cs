using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class CarsDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }
        [XmlArray("parts")]
        public CarPartDTO[] Parts { get; set; }
    }
    [XmlType("partId")]
    public class CarPartDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
