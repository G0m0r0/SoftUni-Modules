namespace ProductShop.Dtos
{
    using ProductShop.Models;
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class UserProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }

    }
}
