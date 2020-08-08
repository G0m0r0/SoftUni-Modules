using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGamesDTO
    {
        [Required]
        public string Name { get; set; }
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public string Genre { get; set; }
        public string[] Tags { get; set; }
    }
}
