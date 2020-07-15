namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
    }
}
