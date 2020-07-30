using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportUserCountDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public ExportUsersWithProductsDTO[] Users { get; set; }
    }
}
