namespace TeisterMask.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        public DateTime? DueDate { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
