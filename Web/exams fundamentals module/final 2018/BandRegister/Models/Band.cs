using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandRegister.Models
{
    public class Band
    {
        //TODO check libraries
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Members { get; set; }
        [Required]
        public double Honorarium { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
