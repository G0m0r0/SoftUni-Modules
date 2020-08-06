using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal Balance { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
