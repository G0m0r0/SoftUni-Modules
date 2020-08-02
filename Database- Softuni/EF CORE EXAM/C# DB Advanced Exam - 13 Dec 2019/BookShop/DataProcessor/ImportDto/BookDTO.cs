namespace BookShop.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    [XmlType("Book")]
    public class BookDTO
    {
        [XmlElement("Name")]
        [MinLength(3)]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [XmlElement("Genre")]
        [Range(1,3)]
        public int Genre { get; set; } //later tryparse.datetime to check if its valid
        [XmlElement("Price")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        [XmlElement("Pages")]
        [Range(50,5000)]
        public int Pages { get; set; }
        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; } //later tryparse.datetime to check if its valid
    }
}
