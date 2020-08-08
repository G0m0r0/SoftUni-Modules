using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersDTO
    {
        //[XmlElement("FullName")]
        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+")]
        [Required]
        public string FullName { get; set; }
        //[XmlElement("Username")]
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Username { get; set; }
        //[XmlElement("Email")]
        [Required]
        [EmailAddress]
        //TODO: CHECK IF JUDGE WANT VALID
        public string Email { get; set; }
        //[XmlElement("Age")]
        [Required]
        [Range(3,103)]
        public int Age { get; set; }
        //[XmlArray("Cards")]
        public ImportCardsDTO[] Cards { get; set; }
    }

    public class ImportCardsDTO
    {
        //[XmlElement("Number")]
        [Required]
        [RegularExpression(@"(\d{4})\s(\d{4})\s(\d{4})\s(\d{4})")]
        public string Number { get; set; }
        //[XmlElement("CVC")]
        [Required]
        [RegularExpression(@"(\d{3})")]
        public string CVC { get; set; }
       // [XmlElement("Type")]
        [Required]
        public string Type { get; set; }
    }
}
