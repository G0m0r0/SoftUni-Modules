using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlType("SoldProducts")]
    public class SoldProductsDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public ProductDTO[] Products { get; set; }
    }
}
