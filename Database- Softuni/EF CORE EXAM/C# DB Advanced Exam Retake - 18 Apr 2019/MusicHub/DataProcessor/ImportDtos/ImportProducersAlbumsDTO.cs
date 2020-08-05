using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducersAlbumsDTO
    {
        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+")]
        public string Pseudonym { get; set; }
        [RegularExpression(@"\+359\s(\d{3})\s(\d{3})\s(\d{3})")]
        public string PhoneNumber { get; set; }
        public ImportProducersAlbumsInnerDTO[] Albums { get; set; }
    }
    public class ImportProducersAlbumsInnerDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
    }
}
