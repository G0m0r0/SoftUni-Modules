﻿namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Medicament
    {
        public Medicament()
        {
            Prescriptions = new HashSet<PatientMedicament>();
        }
        [Key]
        public int MedicamentId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
