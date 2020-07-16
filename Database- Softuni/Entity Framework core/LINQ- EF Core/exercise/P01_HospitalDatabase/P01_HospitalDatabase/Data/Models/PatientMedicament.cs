using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        public virtual Medicament Medicament { get; set; }
        [ForeignKey(nameof(Medicament))]
        public int MedicamentId { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
    }
}
