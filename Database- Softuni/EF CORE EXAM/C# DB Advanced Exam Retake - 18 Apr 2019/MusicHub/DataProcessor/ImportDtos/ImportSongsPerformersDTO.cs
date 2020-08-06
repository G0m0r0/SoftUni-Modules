using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportSongsPerformersDTO
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [XmlElement("Age")]
        [Required]
        [Range(18,70)]
        public int Age { get; set; }
        [XmlElement("NetWorth")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [Required]
        public decimal NetWorth { get; set; }
        [XmlArray("PerformersSongs")]
        public ImportSongsPerformersSongsDTO[] Songs { get; set; }
    }

    [XmlType("Song")]
    public class ImportSongsPerformersSongsDTO
    {
        [XmlAttribute("id")]
        [Required]
        public int Id { get; set; }
    }
}
