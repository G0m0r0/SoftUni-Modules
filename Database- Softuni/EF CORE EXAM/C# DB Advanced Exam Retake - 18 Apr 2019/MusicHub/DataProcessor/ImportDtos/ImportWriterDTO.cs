﻿using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportWriterDTO
    {
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+")]
        public string Pseudonym { get; set; }
    }
}
