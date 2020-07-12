namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml;

    public class Patient
    {
        public Patient()
        {
            Prescriptions = new HashSet<PatientMedicament>();
            Diagnoses = new HashSet<Diagnose>();
            Visitations = new HashSet<Visitation>();
        }
        [Key]
        public int PatientId { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(250)]
        [Required]
        public string Address { get; set; }
        [MaxLength(80)]
        [Required]
        public string Email { get; set; }
        public bool HasInsurance { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }

    }
}
