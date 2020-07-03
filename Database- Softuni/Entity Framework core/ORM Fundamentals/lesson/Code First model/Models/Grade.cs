using System.ComponentModel.DataAnnotations;

namespace Code_First_model.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public double Gradea { get; set; }
        [MaxLength(50)]
        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
